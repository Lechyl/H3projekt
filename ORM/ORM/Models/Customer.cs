using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ORM.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class Customer
    {

        [DataMember(Name = "CustID")]
        public int Id { get; set; }
        [DataMember(Name = "FirstName")]

        public string FirstName { get; set; }
        [DataMember(Name = "LastName")]

        public string LastName { get; set; }
        [DataMember(Name = "Email")]

        public string Email { get; set; }
        [DataMember(Name = "Phone")]

        public string Phone { get; set; }

        public Customer(string firstName, string lastName, string email, string phone = "ingen")
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
        }
        public Customer(int id, string firstName, string lastName, string email, string phone = "ingen")
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
        }
    }
}
