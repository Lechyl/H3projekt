﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Lager_Status
    {

        public int Id { get; set; }
        public string Status { get; set; }


        public Lager_Status( string status)
        {
            Status = status;
        }
        public Lager_Status(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
