using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class ZipCodeProfile : Profile
    {
        public ZipCodeProfile()
        {
            //Create mapping between ORM models and API models with Automapper

            CreateMap<ZipCode, ZipCodeDto>();
        }

    }
}
