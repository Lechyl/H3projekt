using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class SupplierDto
    {

        public int Id { get;}
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public  string Phone { get; set; }

        public SupplierDto(string supplierName, string phone, string contactPerson = "ingen", string email = "ingen")
        {

            SupplierName = supplierName;
            Phone = phone;
            ContactPerson = contactPerson;
            Email = email;
        }
        public SupplierDto(int id, string supplierName, string phone, string contactPerson = "ingen", string email = "ingen")
        {
           
            Id = id;
            SupplierName = supplierName;
            Phone = phone;
            ContactPerson = contactPerson;
            Email = email;
        }

    }
}
