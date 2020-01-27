using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Address_Type
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Address_Type(string type)
        {
            Type = type;
        }
        public Address_Type(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
