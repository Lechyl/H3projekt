using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class OrderProfile : Profile
    {

        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(d => d.Ordernumber, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.OrderDate, o => o.MapFrom(s => s.Created.ToString("yyyy-MM-dd")))
                .ForMember(d => d.DeliveryAddressID, o => o.MapFrom(s => s.DeliveryAddress == null ? s.DeliveryAddressID : s.DeliveryAddress.Id))
                .ForMember(d => d.DeliveryMethodID, o => o.MapFrom(s =>  s.DeliveryMethod == null ? s.DeliveryMethodID : s.DeliveryMethod.Id))
                .ForMember(d => d.StatusID, o => o.MapFrom(s => s.Status == null ? s.StatusID : s.Status.Id));
                

            CreateMap<OrderForCreateDto, Order>()
                .ForMember(d => d.Created, o => o.MapFrom(s => s.OrderDate))
                .ForMember(d => d.DeliveryAddressID , o => o.MapFrom(s => s.DeliveryAddressID))
                .ForMember(d => d.OrderList, o => o.MapFrom(s => s.OrderList));
        }
    }
}
