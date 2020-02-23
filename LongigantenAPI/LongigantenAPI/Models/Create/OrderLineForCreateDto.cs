using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public class OrderLineForCreateDto
    {

        [Required]
        public int ProductID { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public decimal Price { get; set; }
        

    }
}
