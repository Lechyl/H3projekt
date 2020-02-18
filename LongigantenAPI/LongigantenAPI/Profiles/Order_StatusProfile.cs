using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class Order_StatusProfile : Profile
    {

        public Order_StatusProfile()
        {
            CreateMap<Order_Status, Order_StatusDto>();
        }
    }
}
