using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public int AddressID { get; set; }

        public Addresses Address { get; set; }

        //Insert Constructor

        public Shop()
        {

        }
        public Shop(Addresses address)
        {
            Address = address;
        }
        //Constructor
        public Shop(int id, Addresses address)
        {
            Id = id;
            Address = address;
        }
    }
}
