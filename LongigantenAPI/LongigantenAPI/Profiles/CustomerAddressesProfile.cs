using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class CustomerAddressesProfile : Profile
    {
        public CustomerAddressesProfile()
        {
            //Create mapping between ORM models and API models with Automapper

            // 2 nested From AddressesDto and Address_TypeDto
            CreateMap<Customer_Addresses, Customer_AddressesDto>()
                .ForMember(d => d.AddressID, o => o.MapFrom(s => s.Address.Id)).ForMember(d => d.AdresseTypeID, o => o.MapFrom(s => s.AdresseType.Id));
        }
    }
}
