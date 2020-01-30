using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ORM.Services;

namespace LongigantenAPI.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly IORM _orm;
        private readonly IMapper _mapper;

        public OrdersController(IORM orm, IMapper mapper)
        {
            _orm = orm ?? throw new ArgumentNullException(nameof(orm));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
