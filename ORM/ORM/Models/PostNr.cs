using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{

    public class PostNr
    {
        public int Id { get; set; }
        public string ByNavn { get; set; }
        
        //Constructor
        public PostNr(int id, string byNavn)
        {
            Id = id;
            ByNavn = byNavn;
        }
    }
}
