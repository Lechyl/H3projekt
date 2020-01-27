using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Produkter
    {
        private decimal _pris;
        public int Id { get; }
        public string ProduktNavn { get; set; }
        public string Beskrivelse { get; set; }
        public decimal Pris { 
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
        public Kategorier Kategori { get; set; }
        public Producent Producent { get; set; }
        public Leverandor Leverandor { get; set; }


        //Constructor overload Create Product
        public Produkter(string produktNavn, string beskrivelse, decimal pris, Kategorier kategori, Producent producent, Leverandor leverandor)
        {
            ProduktNavn = produktNavn;
            Beskrivelse = beskrivelse;
            Pris = pris;
            Kategori = kategori;
            Producent = producent;
            Leverandor = leverandor;
        }

        //Constructor overload store Product
        public Produkter(int id, string produktNavn, string beskrivelse, decimal pris, Kategorier kategori, Producent producent,Leverandor leverandor)
        {
            Id = id;
            ProduktNavn = produktNavn;
            Beskrivelse = beskrivelse;
            Pris = pris;
            Kategori = kategori;
            Producent = producent;
            Leverandor = leverandor;
        }

    }
}
