using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Addresses
    {
        public int Id { get; set; }
        public int ZipCodeID { get; set; }
        public ZipCode ZipCode { get; set; }
        public string Address { get; set; }
        public string Floor { get; set; }

        public Addresses()
        {

        }
        public Addresses(ZipCode zipCode, string address, string floor = "ingen")
        {

            ZipCode = zipCode;
            Address = address;
            Floor = floor;
        }
        public Addresses(int id, ZipCode zipCode,string address, string floor = "ingen")
        {
            Id = id;
            ZipCode = zipCode;
            Address = address;
            Floor = floor;
        }

    }
}
