using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Customer_Addresses
    {
        public Addresses Address { get; set; }
        public Customer Customer { get; set; }
        public Address_Type AdresseType { get; set; }
        public Customer_Addresses(Addresses address, Customer customer, Address_Type adresseType)
        {
            AdresseType = adresseType;
            Address = address;
            Customer = customer;
        }
    }
}
