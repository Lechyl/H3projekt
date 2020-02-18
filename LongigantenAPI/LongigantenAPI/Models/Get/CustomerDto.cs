using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class CustomerDto
    {

        [DataMember(Name = "CustID")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
        [DataMember(Name = "Phone")]
        public string Phone { get; set; }
        public int Age { get; set; }

        public string Password { get; set; }
        public string Token { get; set; }
        public List<Customer_AddressesDto> Addresses { get; set; }

        /*
        public CustomerDto()
        {

        }
        public CustomerDto(string name, string email, List<Customer_AddressesDto> addresses, string phone = "ingen")
        {
            Name = name;
            Email = email;
            Phone = phone;
            Addresses = addresses;
        }
        public CustomerDto(int id, string name, string email, List<Customer_AddressesDto> addresses, string phone = "ingen")
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Addresses = addresses;

        }*/
    }
}
