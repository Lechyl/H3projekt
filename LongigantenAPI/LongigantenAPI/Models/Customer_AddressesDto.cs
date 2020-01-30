using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class Customer_AddressesDto
    {
        public AddressesDto Address { get; set; }
        public Address_TypeDto AdresseType { get; set; }
        public Customer_AddressesDto(AddressesDto address, Address_TypeDto adresseType)
        {
            AdresseType = adresseType;
            Address = address;
                    
        }
    }
}
