using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Ordre
    {
        public int Id { get; set; }
        public DateTime OpretsDato { get; set; }
        public Kunder Kunde { get; set; }
        public Ordre_Leverings_Metode LeveringsMetode { get; set; }
        public Adresser LeveringsAdresse { get; set; }
        public Ordre_Status Status { get; set; }

        public Ordre( DateTime opretsDato, Kunder kunde, Ordre_Leverings_Metode leveringsMetode, Adresser leveringsAdresse, Ordre_Status status)
        {
         
            OpretsDato = opretsDato;
            Kunde = kunde;
            LeveringsAdresse = leveringsAdresse;
            LeveringsMetode = leveringsMetode;
            Status = status;
        }
        public Ordre(int id, DateTime opretsDato, Kunder kunde, Ordre_Leverings_Metode leveringsMetode, Adresser leveringsAdresse, Ordre_Status status)
        {
            Id = id;
            OpretsDato = opretsDato;
            Kunde = kunde;
            LeveringsAdresse = leveringsAdresse;
            LeveringsMetode = leveringsMetode;
            Status = status;
        }
    }
}
