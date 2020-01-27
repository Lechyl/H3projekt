using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNr { get; set; }
        public string Reg { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Addresses Address { get; set; }
        public Departments Departments { get; set; }
        public Shops Shop { get; set; }


        public Employees(string firstName, string lastName, string accountNr, string reg, string phone, Addresses address, Departments department, Shops shop, string email = "ingen")
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNr = accountNr;
            Reg = reg;
            Email = email;
            Phone = phone;
            Address = address;
            Departments = department;
            Shop = shop;
        }

        public Employees(int id, string firstName, string lastName, string accountNr, string reg, string phone, Addresses address, Departments department, Shops shop, string email = "ingen")
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AccountNr = accountNr;
            Reg = reg;
            Email = email;
            Phone = phone;
            Address = address;
            Departments = department;
            Shop = shop;
        }

    }
}
