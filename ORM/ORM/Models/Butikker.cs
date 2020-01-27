using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Butikker
    {
        public int Id { get; set; }
        public Adresser Adresse { get; set; }

        //Insert Constructor
        public Butikker(Adresser adresse)
        {
            Adresse = adresse;
        }
        //Constructor
        public Butikker(int id, Adresser adresse)
        {
            Id = id;
            Adresse = adresse;
        }
    }
}
