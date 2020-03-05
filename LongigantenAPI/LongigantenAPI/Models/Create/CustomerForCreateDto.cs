using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public class CustomerForCreateDto : CustomersForManipulationDto
    {
        [Required]
        public override int DateOfBirth { get => base.DateOfBirth; set => base.DateOfBirth = value; }

    }
}
