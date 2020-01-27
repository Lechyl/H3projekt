using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Customers
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customers(string firstName, string lastName, string email, string phone = "ingen")
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
        }
        public Customers(int id, string firstName, string lastName, string email, string phone = "ingen")
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
        }
    }
}
