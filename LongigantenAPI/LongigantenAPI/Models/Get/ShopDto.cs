using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class ShopDto
    {
        public int Id { get; set; }
        public AddressesDto Address { get; set; }

        //Insert Constructor
        public ShopDto(AddressesDto address)
        {
            Address = address;
        }
        //Constructor
        public ShopDto(int id, AddressesDto address)
        {
            Id = id;
            Address = address;
        }
    }
}
