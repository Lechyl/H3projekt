using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Afdelinger
    {
        public int Id { get; set; }
        public string Afdeling { get; set; }
        public Afdelinger Parent_Afdeling { get; set; }


        public Afdelinger(string afdeling, Afdelinger parent_Afdeling = null)
        {
            Afdeling = afdeling;
            Parent_Afdeling = parent_Afdeling;
        }
        public Afdelinger(int id,string afdeling, Afdelinger parent_Afdeling = null)
        {
            Id = id;
            Afdeling = afdeling;
            Parent_Afdeling = parent_Afdeling;
        }
    }
}
