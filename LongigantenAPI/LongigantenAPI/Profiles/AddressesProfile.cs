using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class AddressesProfile : Profile
    {
        public AddressesProfile()
        {
            //Create mapping between ORM models and API models with Automapper
            //1 nested from ZipCodeDto
            CreateMap<Addresses, AddressesDto>()
               .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => $"{src.ZipCode.Id}, {src.ZipCode.CityName}"));

        }
    }
}
