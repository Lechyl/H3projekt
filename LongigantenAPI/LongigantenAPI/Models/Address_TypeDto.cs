using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class Address_TypeDto
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        public string Type { get; set; }
        public Address_TypeDto(string type)
        {
            Type = type;
        }
        public Address_TypeDto(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
