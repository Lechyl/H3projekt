using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]   
    public class CategoryDto
    {

        public int Id { get; }
        public string Name { get; set; }
        public CategoryDto Parent_Category { get; set; }


        public CategoryDto(string name, CategoryDto parentCategory = null)
        {
            Name = name;
            Parent_Category = parentCategory;
        }

        public CategoryDto(int id , string name, CategoryDto parentCategory = null)
        {
            Id = id;
            Name = name;
            Parent_Category = parentCategory;
        }


    }
}
