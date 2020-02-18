using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class OrderLineProfile : Profile
    {
        public OrderLineProfile()
        {
            CreateMap<OrderLine, OrderLineDto>()
                .ForMember(d => d.ProductID, o => o.MapFrom(s =>  s.Product == null ? s.ProductID : s.Product.Id));
                

            CreateMap<OrderLineForCreateDto, OrderLine>()
                .ForMember(d => d.ProductID, o => o.MapFrom(s => s.ProductID));
        }
    }
}
