using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Adresser
    {
        public int Id { get; set; }
        public PostNr PostNr { get; set; }
        public string Adresse { get; set; }
        public string Etage { get; set; }

        public Adresser(PostNr postNr, string adresse, string etage = "ingen")
        {
           
            PostNr = postNr;
            Adresse = adresse;
            Etage = etage;
        }
        public Adresser(int id, PostNr postNr,string adresse, string etage = "ingen")
        {
            Id = id;
            PostNr = postNr;
            Adresse = adresse;
            Etage = etage;
        }

    }
}
