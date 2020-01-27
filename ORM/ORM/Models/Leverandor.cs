using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Leverandor
    {

        public int Id { get;}
        public string LeverandorNavn { get; set; }
        public string KontaktPerson { get; set; }
        public string Email { get; set; }
        public  string Telefon { get; set; }

        public Leverandor(string leverandorNavn, string telefon, string kontaktPerson = "ingen", string email = "ingen")
        {

            LeverandorNavn = leverandorNavn;
            Telefon = telefon;
            KontaktPerson = kontaktPerson;
            Email = email;
        }
        public Leverandor(int id,string leverandorNavn,string telefon, string kontaktPerson = "ingen", string email = "ingen")
        {
           
            Id = id;
            LeverandorNavn = leverandorNavn;
            Telefon = telefon;
            KontaktPerson = kontaktPerson;
            Email = email;
        }

    }
}
