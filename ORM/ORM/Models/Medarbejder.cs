using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Medarbejder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string KontoNr { get; set; }
        public string Reg { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Adresser Adresse { get; set; }
        public Afdelinger Afdeling { get; set; }
        public Butikker Butik { get; set; }


        public Medarbejder(string fornavn, string efternavn, string kontoNr, string reg, string telefon, Adresser adresse, Afdelinger afdeling, Butikker butik, string email = "ingen")
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            KontoNr = kontoNr;
            Reg = reg;
            Email = email;
            Telefon = telefon;
            Adresse = adresse;
            Afdeling = afdeling;
            Butik = butik;
        }

        public Medarbejder(int id, string fornavn, string efternavn, string kontoNr, string reg, string telefon, Adresser adresse, Afdelinger afdeling, Butikker butik, string email = "ingen")
        {
            Id = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            KontoNr = kontoNr;
            Reg = reg;
            Email = email;
            Telefon = telefon;
            Adresse = adresse;
            Afdeling = afdeling;
            Butik = butik;
        }

    }
}
