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
    //[Route("api/[controller]")]
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

        [HttpGet("api/producents/{producentID}/products")]
        public async Task<ActionResult<List<ProductDto>>> GetProductsByProducent(int producentID)
        {
            _orm.OpenConn();
            var productsFromDB = await _orm.GetProductsByProducentId(producentID);
            if (productsFromDB == null)
            {
                return NotFound();
            }
            var productsDto = _mapper.Map<List<ProductDto>>(productsFromDB);

            //_orm.CloseConn();

            return Ok(productsDto);
        }


    }
}