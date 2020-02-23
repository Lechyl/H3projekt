using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Category", Namespace = "SchoolProjectAPI")]   
    public class CategoryDto
    {
        [DataMember(Name = "CatID")]
        public int Id { get; }
        [DataMember(Name = "Name")]

        public string Name { get; set; }
        [DataMember(Name = "ParentID")]

        public int Parent_CategoryID { get; set; }


       /* public CategoryDto(string name, CategoryDto parentCategory = null)
        {
            Name = name;
            Parent_Category = parentCategory;
        }

        public CategoryDto(int id , string name, CategoryDto parentCategory = null)
        {
            Id = id;
            Name = name;
            Parent_Category = parentCategory;
        }*/


    }
}
