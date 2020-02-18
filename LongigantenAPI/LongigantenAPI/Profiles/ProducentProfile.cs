using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class ProducentProfile : Profile
    {
        public ProducentProfile()
        {
            CreateMap<ProducentForCreateDto, Producent>();

            CreateMap<Producent, ProducentDto>();

        }
    }
}
