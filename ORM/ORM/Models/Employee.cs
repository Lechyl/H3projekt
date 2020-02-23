using System;
using System.Collections.Generic;
using System.Text;


namespace ORM.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNr { get; set; }
        public string Reg { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }

        public int AddressID { get; set; }
        public int DepartmentsID { get; set; }
        public int ShopID { get; set; }
        public Addresses Address { get; set; }
        public Department Departments { get; set; }
        public Shop Shop { get; set; }

        public Employee () { }
        public Employee(string firstName, string lastName, string accountNr, string reg, string phone, DateTime dateOfBirth ,Addresses address, Department department, Shop shop,string role, string email = "ingen")
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNr = accountNr;
            Reg = reg;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Address = address;
            Departments = department;
            Shop = shop;
            Role = role;
        }

        public Employee(int id, string firstName, string lastName, string accountNr, string reg, string phone, DateTime dateOfBirth, Addresses address, Department department, Shop shop,string role, string email = "ingen")
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AccountNr = accountNr;
            Reg = reg;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Address = address;
            Departments = department;
            Shop = shop;
            Role = role;
        }

    }
}
