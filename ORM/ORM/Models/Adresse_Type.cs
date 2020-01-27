using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Adresse_Type
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Adresse_Type(string type)
        {
            Type = type;
        }
        public Adresse_Type(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
