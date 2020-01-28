using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
