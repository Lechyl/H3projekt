using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public abstract class CustomersForManipulationDto
    {

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
       
        public virtual int DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
       
        public string Role { get; set; }
    }
}
