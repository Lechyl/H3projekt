using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Producent
    {
        public int Id { get; }
        public string ProducentNavn { get; set; }


        public Producent(string producentNavn)
        {
           
            ProducentNavn = producentNavn;
        }
        public Producent(int id, string producentNavn)
        {
            Id = id;
            ProducentNavn = producentNavn;
        }

    }
}
