using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {

            CreateMap<ZipCode, ZipCodeDto>();

            CreateMap<Address_Type, Address_TypeDto>();

            //1 nested from ZipCodeDto
            CreateMap<Addresses, AddressesDto>()
               .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode));

            // 2 nested From AddressesDto and Address_TypeDto
            CreateMap<Customer_Addresses, Customer_AddressesDto>()
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address)).ForMember(d => d.AdresseType, o => o.MapFrom(s => s.AdresseType));

            //<Source, Destination>
            //CreateMap<Customer_AddressesDto, CustomerDto>().ForMember(d => d.Addresses, o => o.MapFrom(s => s));
            CreateMap<Customer,CustomerDto>()
                .ForMember(dest => dest.Name,opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

        }
    }
}
