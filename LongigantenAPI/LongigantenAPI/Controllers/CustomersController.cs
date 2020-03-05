using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LongigantenAPI.Models;
using ORM.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Services;
using ORM.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LongigantenAPI.Controllers
{

    [Authorize(Roles = Role.AdminOrUser)]
    [Route("customers")]
    [ApiController]
    [ResponseCache(NoStore = true)]

    public class CustomersController : ControllerBase
    {
        private readonly IORM _orm;
        private readonly IMapper _mapper;

        public CustomersController(IORM orm, IMapper mapper)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{ID}", Name = "GetCustomersByID")]
        public async Task<ActionResult<CustomerDto>> GetCustomersByID(int id)
        {
            try
            {
                _orm.OpenConn();
                var customerDB = await _orm.GetCustomerById(id);
                var customer = _mapper.Map<CustomerDto>(customerDB);

                if (customerDB == null)
                {
                    return NotFound();
                }
                //Map customer addresses to customer
                var addressListDB =await _orm.GetCustomerAddressesByCustomerID(id);

                var addressList =  _mapper.Map<List<Customer_AddressesDto>>(addressListDB);

               
                customer.Addresses = addressList;

                await _orm.CloseConn();

                return Ok(customer);
            }
            catch (Exception e)
            {
                
                return StatusCode(500,e.GetType().Name +", "+e.Message);
            }
        }

        [HttpGet()]
        [HttpHead]  
        //http://localhost:5000/api/customers?email=k
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers([FromQuery]CustomerParameters customerParameters)
        {


            _orm.OpenConn();

             var customersFromDB = await _orm.GetAllCustomers(customerParameters);
            
            if (customersFromDB == null)
            {
                return NotFound();
            }
            var customersDto = _mapper.Map<List<CustomerDto>>(customersFromDB);
            await _orm.CloseConn();

            return Ok(customersDto);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody]CustomerForCreateDto customer)
        {

            _orm.OpenConn();
           var customerFromDB = _mapper.Map<Customer>(customer);

           var createdCustomer = await _orm.CreateCustomer(customerFromDB);

            var customerDto = _mapper.Map<CustomerDto>(createdCustomer);
            await _orm.CloseConn();
            return CreatedAtRoute("GetCustomersByID", new { id = customerDto.Id},customerDto);

        }
        [HttpOptions]
        public IActionResult GetCustomersOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE,OPTIONS");
            return Ok();
        }
        [ResponseCache(Duration = 604800, Location = ResponseCacheLocation.Client )]
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<CustomerDto>> Authenticate([FromBody]Authenticate authenticate)
        {
            _orm.OpenConn();
            var customerFromDB = await _orm.Authenticate(authenticate.Email, authenticate.Password);
            if(customerFromDB == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerDto>(customerFromDB);
            await _orm.CloseConn();

            return CreatedAtRoute("GetCustomersByID", new { id = customerDto.Id }, customerDto);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCustomer(int id,[FromBody]CustomersForUpdate customer)
        {
          
            _orm.OpenConn();
            if (!await _orm.CustomerExist(id))
            {
                return NotFound();
            }

            var customerFromDB = await _orm.GetCustomerById(id);
            //Map from customerFromDB (Source) to customer (Destination)
            //Apply Updated fields values to that dto
            //Map from customer (Source) to customerFromDB (Destination) 
            //aka. copying values from source to destination
            _mapper.Map(customer, customerFromDB);

            if (await _orm.UpdateCustomer(customerFromDB) == 0) {

                return BadRequest();
            }

            await _orm.CloseConn();
            return NoContent();
        }




        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchCustomer(int id, [FromBody] JsonPatchDocument<CustomersForUpdate> customer)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(id))
            {
                return NotFound();
            }

            var customerFromDB = await _orm.GetCustomerById(id);

            var customerToPatch = _mapper.Map<CustomersForUpdate>(customerFromDB);

            //Apply patch operations on object
            customer.ApplyTo(customerToPatch, ModelState);

            //add validation
            if (!TryValidateModel(customerToPatch))
            {
                return ValidationProblem(ModelState);
            }
            //Map from customerFromDB (Source) to customer (Destination)
            //Apply Updated fields values to that dto
            //Map from customer (Source) to customerFromDB (Destination) 
            //aka. copying values from source to destination
            _mapper.Map(customerToPatch, customerFromDB);

            if (await _orm.UpdateCustomer(customerFromDB) == 0)
            {
                return BadRequest();
            }

            await _orm.CloseConn();

            return NoContent();
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerByID(int id)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(id))
            {
                return NotFound();
            }
            await _orm.DeleteCustomer(id);

            await _orm.CloseConn();

            return NoContent();
        }
        [Authorize(Roles = Role.Admin)]

        [HttpDelete("{id}/alldata")]
        public async Task<IActionResult> DeleteCustomerDataByID(int id)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(id))
            {
                return NotFound();
            }
            await _orm.DeleteCustomerData(id);

            await _orm.CloseConn();

            return NoContent();
        }
        //override ValidationProblem to use my Validation error message.
        public override ActionResult ValidationProblem(
        [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}