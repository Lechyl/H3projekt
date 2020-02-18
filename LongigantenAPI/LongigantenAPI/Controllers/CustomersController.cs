using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LongigantenAPI.Models;
using LongigantenAPI.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Services;
using ORM.Models;

namespace LongigantenAPI.Controllers
{
    [Authorize]
    [Route("api/customers")]
    [ApiController]
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
 
            // var customersDB = _orm.GetAllCustomers();
            var customersFromDB = await _orm.GetAllCustomers(customerParameters.searchQuery);
            
            //var dd = await _orm.GetAllEmployees();//_orm.GetAllShopWarehouses();
            if (customersFromDB == null)
            {
                return NotFound();
            }
            var customersDto = _mapper.Map<List<CustomerDto>>(customersFromDB);
            await _orm.CloseConn();

            return Ok(customersDto);
        }

    /*    [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer()
        {

        }*/
        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,OPTIONS");
            return Ok();
        }
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

            await _orm.UpdateCustomer(customerFromDB);

            await _orm.CloseConn();
            return NoContent();
        }


    }
}