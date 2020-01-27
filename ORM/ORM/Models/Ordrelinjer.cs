using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Ordrelinjer
    {
        private int _antal;
        private decimal _pris;
        public Produkter Produkt { get; set; }
        public Ordre Ordre { get; set; }

        public int Antal
        {
            get { return _antal; }
            set
            {
                if(value > 0)
                {
                    _antal = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public decimal Pris
        {
            get { return _pris; }
            set
            {
                if (value <= 99999999 && value >= 0)
                {
                    _pris = Math.Round(value, 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public Ordrelinjer(Produkter produkt, Ordre ordre, int antal,  decimal pris)
        {
            Produkt = produkt;
            Ordre = ordre;
            Antal = antal;
            Pris = pris;
        }
    }
}
