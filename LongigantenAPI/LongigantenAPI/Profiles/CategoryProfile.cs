using AutoMapper;
using LongigantenAPI.Models;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ForMember(d => d.Parent_CategoryID, o => o.MapFrom(s => s.Parent_Category.Id))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}
