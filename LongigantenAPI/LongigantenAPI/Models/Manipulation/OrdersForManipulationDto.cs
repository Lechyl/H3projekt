using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public abstract class OrdersForManipulationDto
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int DeliveryMethodID { get; set; }
        [Required]
        public int DeliveryAddressID { get; set; }
        
        public int StatusID { get; set; }
    }
}
