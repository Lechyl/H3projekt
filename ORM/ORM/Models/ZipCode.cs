using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{

    public class ZipCode
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        
        //Constructor
        public ZipCode() { }
        public ZipCode(int id, string cityName)
        {
            Id = id;
            CityName = cityName;
        }
    }
}
