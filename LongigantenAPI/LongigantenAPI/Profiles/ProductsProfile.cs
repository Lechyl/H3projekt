using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class ProductsProfile : Profile
    {

        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.CategoryID, o => o.MapFrom(s => s.Category.Id))
                .ForMember(d => d.ProducentID, o => o.MapFrom(s => s.Producent.Id))
                .ForMember(d => d.SupplierID, o => o.MapFrom(s => s.Supplier.Id));
        }
    }
}
