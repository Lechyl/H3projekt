using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")] 
    public class ProducentDto
    {
        [DataMember(Name ="Id")]
        public int Id { get; }
        [DataMember(Name = "ProductName")]

        public string ProducentName { get; set; }


        public ProducentDto(string producentName)
        {

            ProducentName = producentName;
        }
        public ProducentDto(int id, string producentName)
        {
            Id = id;
            ProducentName = producentName;
        }

    }
}
