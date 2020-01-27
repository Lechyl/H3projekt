using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Shops
    {
        public int Id { get; set; }
        public Addresses Address { get; set; }

        //Insert Constructor
        public Shops(Addresses address)
        {
            Address = address;
        }
        //Constructor
        public Shops(int id, Addresses address)
        {
            Id = id;
            Address = address;
        }
    }
}
