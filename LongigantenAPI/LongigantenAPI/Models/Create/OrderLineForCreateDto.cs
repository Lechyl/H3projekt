using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    public class OrderLineForCreateDto
    {

        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        

    }
}
