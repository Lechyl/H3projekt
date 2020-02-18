using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNr { get; set; }
        public string Reg { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressesDto Address { get; set; }
        public DepartmentDto Departments { get; set; }
        public ShopDto Shop { get; set; }


        public EmployeeDto(string firstName, string lastName, string accountNr, string reg, string phone, AddressesDto address, DepartmentDto department, ShopDto shop, string email = "ingen")
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

        public EmployeeDto(int id, string firstName, string lastName, string accountNr, string reg, string phone, AddressesDto address, DepartmentDto department, ShopDto shop, string email = "ingen")
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
