using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Warehouse_Status
    {

        public int Id { get; set; }
        public string Status { get; set; }


        public Warehouse_Status( string status)
        {
            Status = status;
        }
        public Warehouse_Status(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
