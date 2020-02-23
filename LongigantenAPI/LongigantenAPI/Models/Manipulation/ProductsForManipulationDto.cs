using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public abstract class ProductsForManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]

        [MaxLength(500)]
        public string Description { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public int CategoryID { get; set; }
        [Required]

        public int ProducentID { get; set; }
        [Required]

        public int SupplierID { get; set; }
    }
}
