using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Producent
    {
        public int Id { get; set; }
        public string ProducentName { get; set; }

        public Producent() { }
        public Producent(string producentName)
        {

            ProducentName = producentName;
        }
        public Producent(int id, string producentName)
        {
            Id = id;
            ProducentName = producentName;
        }

    }
}
