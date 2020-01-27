using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Ordre_Status
    {
        public int  Id { get; set; }
        public string Status { get; set; }


        public Ordre_Status( string status)
        {
            Status = status;
        }
        public Ordre_Status(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
