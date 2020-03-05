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
    [Authorize(Roles = Role.AdminOrUser)]
    [ResponseCache(NoStore = true)]

    [Route("producent")]
    [ApiController]
    public class ProducentController : ControllerBase
    {
        private readonly IORM _orm;
        private readonly IMapper _mapper;

        public ProducentController(IORM orm, IMapper mapper)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{producentID}", Name = "GetProducent")]
        public async Task<ActionResult<ProducentDto>> GetProducentByID(int producentID)
        {
            _orm.OpenConn();
            var producent = await _orm.GetProducentById(producentID);
            if(producent == null)
            {
                return NotFound();
            }
            var producentDto = _mapper.Map<ProducentDto>(producent);
            await _orm.CloseConn();
            return Ok(producentDto);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<ProducentDto>> CreateProducent(ProducentForCreateDto producent)
        {
            _orm.OpenConn();
            var producentEntity = _mapper.Map<Producent>(producent);
            var returnedProducent = await _orm.CreateProducent(producentEntity);
            var producentDto = _mapper.Map<ProducentDto>(returnedProducent);
            
            await _orm.CloseConn();
            return CreatedAtRoute("GetProducent",new { producentID = producentDto.Id },producentDto);
        }
    }

}