using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class AddressesDto
    {
        public int Id { get; set; }
        public ZipCodeDto ZipCode { get; set; }
        public string Address { get; set; }
        public string Floor { get; set; }

        public AddressesDto(ZipCodeDto zipCode, string address, string floor = "ingen")
        {

            ZipCode = zipCode;
            Address = address;
            Floor = floor;
        }
        public AddressesDto(int id, ZipCodeDto zipCode,string address, string floor = "ingen")
        {
            Id = id;
            ZipCode = zipCode;
            Address = address;
            Floor = floor;
        }

    }
}
