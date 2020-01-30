using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LongigantenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Services;

namespace LongigantenAPI.Controllers
{
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

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomersByID(int id)
        {
            try
            {
                _orm.OpenConn();
                var customerDB = _orm.GetCustomerById(id);
                var customer = _mapper.Map<CustomerDto>(customerDB);
                if (customerDB == null)
                {
                    return NotFound();
                }

                var addressListDB = _orm.GetCustomerAddressesByCustomerID(id);
                var addressList =  _mapper.Map<List<Customer_AddressesDto>>(addressListDB);

               
                customer.Addresses = addressList;

                _orm.CloseConn();

                return Ok(customer);
            }
            catch (Exception e)
            {
                
                return StatusCode(500,e.GetType().Name +", "+e.Message);
            }
        }

        public ActionResult<List<CustomerDto>> GetCustomers()
        {
            var customersDB = _orm.GetAllCustomers();
            
            if (customersDB == null)
            {
                return NotFound();
            }



            return Ok(_mapper.Map<List<CustomerDto>>(customersDB));
        }
    }
}