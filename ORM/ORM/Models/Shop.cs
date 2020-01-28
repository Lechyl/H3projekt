using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public Addresses Address { get; set; }

        //Insert Constructor
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
