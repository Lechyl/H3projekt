using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Kunder
    {

        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public Kunder(string fornavn, string efternavn, string email, string telefon = "ingen")
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Email = email;
            Telefon = telefon;
        }
        public Kunder(int id, string fornavn, string efternavn, string email, string telefon = "ingen")
        {
            Id = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Email = email;
            Telefon = telefon;
        }
    }
}
