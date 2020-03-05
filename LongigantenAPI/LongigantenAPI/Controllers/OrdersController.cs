using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ORM.Services;
using ORM.Models;
using LongigantenAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace LongigantenAPI.Controllers
{
    [Authorize(Roles = Role.AdminOrUser)]
    [ResponseCache(NoStore = true)]

    [ApiController]
    [Route("customers/{customerID}/orders")]
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

            //Allow only admins to access other users records
            var userid = int.Parse(User.Identity.Name);

            if(userid != customerID && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }
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
            //Change status to waiting for treatment of order
            orderForCreateDto.StatusID = 1;
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


        [HttpPut("{orderID}")]
        public async Task<ActionResult> PutOrder(int customerID,int orderID, [FromBody]OrdersForUpdate order)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(customerID))
            {
                return NotFound();
            }

            var orderFromDB = await _orm.GetOrderById(orderID);
            if(orderFromDB == null)
            {
                return NotFound();
            }
            //Map from entity (Source) to nidek (Destination)
            //Apply Updated fields values to that dto
            //Map from model (Source) to entity (Destination) 
            //aka. copying values from source to destination
            _mapper.Map(order, orderFromDB);

            if(await _orm.UpdateOrder(orderFromDB) == 0)
            {
                return BadRequest();
            }

            await _orm.CloseConn();
            return NoContent();
        }



        [HttpPatch("{orderID}")]
        public async Task<ActionResult> PatchOrder(int customerID,int orderID, [FromBody] JsonPatchDocument<OrdersForUpdate> order)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(customerID))
            {
                return NotFound();
            }

            var orderFromDB = await _orm.GetOrderById(orderID);

            if(orderFromDB == null)
            {
                return NotFound();
            }

            var orderToPatch = _mapper.Map<OrdersForUpdate>(orderFromDB);

            //Apply patch operations on object
            order.ApplyTo(orderToPatch, ModelState);

            //add validation
            if (!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }
            //Map from customerFromDB (Source) to customer (Destination)
            //Apply Updated fields values to that dto
            //Map from customer (Source) to customerFromDB (Destination) 
            //aka. copying values from source to destination
            _mapper.Map(orderToPatch, orderFromDB);

            if(await _orm.UpdateOrder(orderFromDB) == 0)
            {
                return BadRequest();
            }

            await _orm.CloseConn();

            return NoContent();
        }
        [HttpDelete("{orderID}")]
        public async Task<ActionResult> DeleteOrder(int customerID, int orderID)
        {
            _orm.OpenConn();
            if (!await _orm.CustomerExist(customerID))
            {
                return NotFound();
            }

            var orderFromDB = await _orm.GetOrderById(orderID);

            if(orderFromDB == null)
            {
                return NotFound();
            }
            //Map from entity (Source) to nidek (Destination)
            //Apply Updated fields values to that dto
            //Map from model (Source) to entity (Destination) 
            //aka. copying values from source to destination
            await _orm.DeleteOrder(orderID);
            await _orm.CloseConn();

            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetOrdersOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,ATCH,DELETE,OPTIONS");
            return Ok();
        }
    }
}
