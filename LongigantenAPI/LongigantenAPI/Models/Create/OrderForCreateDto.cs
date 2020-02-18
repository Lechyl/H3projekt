
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public class OrderForCreateDto : OrdersForManipulationDto
    {
       
        [Required]
        public List<OrderLineForCreateDto> OrderList {get; set;}
    }
}
