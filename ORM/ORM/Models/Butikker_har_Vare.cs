using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Butikker_har_Vare
    {
        public Produkter Produkt { get; set; }
        public Butikker Butik { get; set; }
        public Lager_Status Status { get; set; }
        public int Antal { get; set; }

        public Butikker_har_Vare(Produkter produkt, Butikker butik, Lager_Status status, int antal = 0)
        {
            Produkt = produkt;
            Butik = butik;
            Status = status;
            Antal = antal;
        }

    }
}
