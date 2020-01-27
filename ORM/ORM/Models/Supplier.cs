using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Supplier
    {

        public int Id { get;}
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public  string Phone { get; set; }

        public Supplier(string supplierName, string phone, string contactPerson = "ingen", string email = "ingen")
        {

            SupplierName = supplierName;
            Phone = phone;
            ContactPerson = contactPerson;
            Email = email;
        }
        public Supplier(int id, string supplierName, string phone, string contactPerson = "ingen", string email = "ingen")
        {
           
            Id = id;
            SupplierName = supplierName;
            Phone = phone;
            ContactPerson = contactPerson;
            Email = email;
        }

    }
}
