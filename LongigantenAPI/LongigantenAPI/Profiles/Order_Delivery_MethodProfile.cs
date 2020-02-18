using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class Order_Delivery_MethodProfile : Profile
    {
        public Order_Delivery_MethodProfile()
        {
            CreateMap<Order_Delivery_Method, Order_Delivery_MethodDto>();
        }
    }
}
