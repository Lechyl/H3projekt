using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ORM.Services;
using ORM.Models;
using LongigantenAPI.Models;
namespace LongigantenAPI.Controllers
{
    [ApiController]
    [Route("api/customers/{customerID}/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IORM _orm;
        private readonly IMapper _mapper;

        public OrdersController(IORM orm, IMapper mapper)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{orderID}", Name = "GetOrder")]
        public async Task<ActionResult<OrderDto>> GetOrder(int customerID,int orderID)
        {
            _orm.OpenConn();
            var orderFromDB = await _orm.GetOrderById(orderID);

            if(orderFromDB == null || orderFromDB.Customer.Id != customerID)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDto>(orderFromDB);
            await _orm.CloseConn();
            return Ok(orderDto);
        }

        [HttpGet()]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersByCustomer(int customerID)
        {
            _orm.OpenConn();
            var ordersFromDB = await _orm.GetOrdersByCustomerId(customerID);

            if (ordersFromDB == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<List<OrderDto>>(ordersFromDB);
            
            await _orm.CloseConn();
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrderForCustomer(int customerID,OrderForCreateDto orderForCreateDto)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(customerID))
            {
                return NotFound();
            }
            Order orderFromDB = _mapper.Map<Order>(orderForCreateDto);
            orderFromDB.CustomerID = customerID;
            Order result = await _orm.CreateOrderAndOrderLines(orderFromDB);

            OrderDto orderDto = _mapper.Map<OrderDto>(result);
           await _orm.CloseConn();
            return CreatedAtRoute("GetOrder", new { customerID = customerID , orderID = orderDto.Ordernumber }, orderDto);
        }
        

    }
}
