using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class Order_StatusDto
    {
        public int  Id { get; set; }
        public string Status { get; set; }


        public Order_StatusDto( string status)
        {
            Status = status;
        }
        public Order_StatusDto(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
