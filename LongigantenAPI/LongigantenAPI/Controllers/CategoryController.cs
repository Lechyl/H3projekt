using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LongigantenAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Models;
using ORM.Services;

namespace LongigantenAPI.Controllers
{   
    [Authorize(Roles = Role.Admin)]
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {

        private readonly IORM _orm;
        private readonly IMapper _mapper;

        public CategoryController(IORM orm, IMapper mapper)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [AllowAnonymous]
        [HttpGet()]
        public async Task<ActionResult<List<CategoryDto>>> getCategories()
        {
            var categoriesFromDB = await _orm.GetAllCategories();

            if(categoriesFromDB == null)
            {
                return NotFound();
            }

            var categoriesDto = _mapper.Map<CategoryDto>(categoriesFromDB);

            return Ok(categoriesDto);
        }
    }
}