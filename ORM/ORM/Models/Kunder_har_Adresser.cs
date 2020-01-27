using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Kunder_har_Adresser
    {
        public Adresser Adresse { get; set; }
        public Kunder Kunde { get; set; }
        public Adresse_Type AdresseType { get; set; }
        public Kunder_har_Adresser(Adresser adresse, Kunder kunde, Adresse_Type adresseType)
        {
            AdresseType = adresseType;
            Adresse = adresse;
            Kunde = kunde;
        }
    }
}
