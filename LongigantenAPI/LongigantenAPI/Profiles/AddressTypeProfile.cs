using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class AddressTypeProfile : Profile
    {
        public AddressTypeProfile()
        {
            //Create mapping between ORM models and API models with Automapper

            CreateMap<Address_Type, Address_TypeDto>();

        }

    }
}
