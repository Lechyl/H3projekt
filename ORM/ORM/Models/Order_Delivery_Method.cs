using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Order_Delivery_Method
    {
        private decimal _price;
        public int Id { get; set; }
        public string MethodName { get; set; }
        
        public decimal Price
        {
            get { return _price; }
            set 
            {
                if(value <= 99999999 && value >= 0)
                {
                    _price = Math.Round(value, 2);
                }
                else
                {
                   throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Order_Delivery_Method() { }
        public Order_Delivery_Method( string methodname, decimal price)
        {
           
            MethodName = methodname;
            Price = price;
        }
        public Order_Delivery_Method(int id, string methodname, decimal price)
        {
            Id = id;
            MethodName = methodname;
            Price = price;
        }
    }
}
