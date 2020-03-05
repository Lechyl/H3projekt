using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LongigantenAPI.Helpers;
namespace LongigantenAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //Create mapping between ORM models and API models with Automapper

            //<Source, Destination>

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(d => d.Addresses, o => o.MapFrom(s => s.customer_Addresses))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.GetCurrentAge()));

            CreateMap<CustomersForUpdate, Customer>().ForMember(d => d.DateOfBirth, o => o.Ignore())
                .ForMember(d => d.Email, o => o.Ignore());
            CreateMap<Customer, CustomersForUpdate>();

            CreateMap<CustomerForCreateDto, Customer>();
        }
    }
}
