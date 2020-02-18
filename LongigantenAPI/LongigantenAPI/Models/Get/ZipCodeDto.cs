using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]

    public class ZipCodeDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        
        //Constructor
        public ZipCodeDto(int id, string cityName)
        {
            Id = id;
            CityName = cityName;
        }
    }
}
