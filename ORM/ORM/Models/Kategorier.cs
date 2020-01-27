using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ORM.Models
{
    public class Kategorier
    {

        public int Id { get; }
        public string Navn { get; set; }
        public Kategorier Parent_Kategori { get; set; }


        public Kategorier(string navn, Kategorier parentKategori = null)
        {
            Navn = navn;
            Parent_Kategori = parentKategori;
        }

        public Kategorier(int id , string navn, Kategorier parentKategori = null)
        {
            Id = id;
            Navn = navn;
            Parent_Kategori = parentKategori;
        }


    }
}
