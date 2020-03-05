using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LongigantenAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ORM.Models;
using ORM.Services;
using ORM.ResourceParameters;

namespace LongigantenAPI.Controllers
{
    [ResponseCache(NoStore = true)]

    //[Route("api/[controller]")]
    [Authorize(Roles = Role.AdminOrUser)]
    //[EnableCors]
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IORM _orm;
        private readonly IMapper _mapper;

        public ProductsController(IORM orm, IMapper mapper)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [AllowAnonymous]
        [HttpGet()]
        public async Task<ActionResult<List<ProductDto>>> GetProducts([FromQuery] ProductsParameter productsParameter)
        {
            _orm.OpenConn();
            var productsFromDB = await _orm.GetAllProducts(productsParameter);
            if (productsFromDB == null)
            {
                return NotFound();
            }
            var productsDto = _mapper.Map<List<ProductDto>>(productsFromDB);

            await _orm.CloseConn();

            return Ok(productsDto);
        }
        [AllowAnonymous]
        [HttpGet("{productID}", Name = "GetProductByID")]
        public async Task<ActionResult<ProductDto>> GetProductByID(int productID)
        {
            _orm.OpenConn();
            var productsFromDB = await _orm.GetProductById(productID);
            if (productsFromDB == null)
            {
                return NotFound();
            }
            var productsDto = _mapper.Map<ProductDto>(productsFromDB);

            await _orm.CloseConn();

            return Ok(productsDto);
        }

        [HttpPost()]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductForCreateDto product)
        {
            _orm.OpenConn();
            var productFromDB = _mapper.Map<Product>(product);
            productFromDB = await _orm.CreateProduct(productFromDB);

            var productDto = _mapper.Map<ProductDto>(productFromDB);
            await _orm.CloseConn();
            return CreatedAtRoute("GetProductByID", new { productID = productDto.Id }, productDto);

        }
        [HttpPut("{productID}")]
        public async Task<ActionResult> PutProduct(int productID, [FromBody]ProductsForUpdate product)
        {
            _orm.OpenConn();


            var productFromDB = await _orm.GetProductById(productID);
            if (productFromDB == null)
            {
                return NotFound();
            }
            //Map from entity (Source) to nidek (Destination)
            //Apply Updated fields values to that dto
            //Map from model (Source) to entity (Destination) 
            //aka. copying values from source to destination
            _mapper.Map(product, productFromDB);

            if(await _orm.UpdateProduct(productFromDB) == 0)
            {
                return BadRequest();
            }

            await _orm.CloseConn();
            return NoContent();
        }



        [HttpPatch("{productID}")]
        public async Task<ActionResult> PatchProduct(int productID, [FromBody] JsonPatchDocument<ProductsForUpdate> product)
        {
            _orm.OpenConn();

            var productFromDB = await _orm.GetProductById(productID);

            if (productFromDB == null)
            {
                return NotFound();
            }

            var productToPatch = _mapper.Map<ProductsForUpdate>(productFromDB);

            //Apply patch operations on object
            product.ApplyTo(productToPatch, ModelState);

            //add validation
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            //Map from customerFromDB (Source) to customer (Destination)
            //Apply Updated fields values to that dto
            //Map from customer (Source) to customerFromDB (Destination) 
            //aka. copying values from source to destination
            _mapper.Map(productToPatch, productFromDB);

            if(await _orm.UpdateProduct(productFromDB) == 0)
            {

            }

            await _orm.CloseConn();

            return NoContent();
        }
        [HttpDelete("{productID}")]
        public async Task<ActionResult> DeleteProduct(int productID)
        {
            _orm.OpenConn();


            var productFromDB = await _orm.GetProductById(productID);

            if (productFromDB == null)
            {
                return NotFound();
            }
            //Map from entity (Source) to nidek (Destination)
            //Apply Updated fields values to that dto
            //Map from model (Source) to entity (Destination) 
            //aka. copying values from source to destination
            await _orm.DeleteProduct(productID);
            await _orm.CloseConn();

            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetOrdersOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE,OPTIONS");
            return Ok();
        }

    }
}