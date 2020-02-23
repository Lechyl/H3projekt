using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Customer_Addresses
    {
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        public int AdresseTypeID { get; set; }
        public Addresses Address { get; set; }
        public Customer Customer { get; set; }
        public Address_Type AdresseType { get; set; }

        public Customer_Addresses()
        {

        }
        public Customer_Addresses(Addresses address, Customer customer, Address_Type adresseType)
        {
            AdresseType = adresseType;
            Address = address;
            Customer = customer;
        }
    }
}
