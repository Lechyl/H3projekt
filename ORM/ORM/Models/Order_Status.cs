using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Order_Status
    {
        public int  Id { get; set; }
        public string Status { get; set; }


        public Order_Status( string status)
        {
            Status = status;
        }
        public Order_Status(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
