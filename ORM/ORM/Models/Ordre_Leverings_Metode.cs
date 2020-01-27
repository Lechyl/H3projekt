using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Ordre_Leverings_Metode
    {
        private decimal _pris;
        public int Id { get; set; }
        public string MetodeNavn { get; set; }
        
        public decimal Pris
        {
            get { return _pris; }
            set 
            {
                if(value <= 99999999 && value >= 0)
                {
                    _pris = Math.Round(value, 2);
                }
                else
                {
                   throw new ArgumentOutOfRangeException();
                }
            }
        }
        public Ordre_Leverings_Metode( string metodeNavn, decimal pris)
        {
           
            MetodeNavn = metodeNavn;
            Pris = pris;
        }
        public Ordre_Leverings_Metode(int id, string metodeNavn, decimal pris)
        {
            Id = id;
            MetodeNavn = metodeNavn;
            Pris = pris;
        }
    }
}
