using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ORM.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int? Parent_CategoryID { get; set; }


        public Category Parent_Category { get; set; }

        public Category()
        {

        }
        public Category(string name, Category parentCategory = null)
        {
            Name = name;
            Parent_Category = parentCategory;
        }

        public Category(int id , string name, Category parentCategory = null)
        {
            Id = id;
            Name = name;
            Parent_Category = parentCategory;
        }


    }
}
