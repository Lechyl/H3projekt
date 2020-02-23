using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer_Address", Namespace = "SchoolProjectAPI")]
    public class Customer_AddressesDto
    {
        [DataMember(Name = "AddressID")]

        public int AddressID { get; set; }
        [DataMember(Name = "AddressTypeID")]

        public int AdresseTypeID { get; set; }
       /* public Customer_AddressesDto(AddressesDto address, Address_TypeDto adresseType)
        {
            AdresseType = adresseType;
            Address = address;
                    
        }*/
    }
}
