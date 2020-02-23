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
        [DataMember(Name = "DateOfBirth")]

 
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> customer_AddressesID { get; set; }
        public List<Customer_Addresses> customer_Addresses { get; set; }

        public List<Order> orders { get; set; }
        public Customer() { }
        public Customer(string firstName, string lastName, string email, DateTime dateOfBirth,string password,string role, string phone = "ingen")
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Password = password;
            Role = role;
           
        }
        public Customer(int id, string firstName, string lastName, string email, DateTime dateOfBirth , string password,string role, string phone = "ingen")
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Password = password;
            Role = role;
        }
    }
}
