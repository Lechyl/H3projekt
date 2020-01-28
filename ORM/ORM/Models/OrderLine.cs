using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class OrderLine
    {
        private int _quantity;
        private decimal _price;
        public Product Product { get; set; }
        public Order Order { get; set; }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if(value > 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 99999999 && value >= 0)
                {
                    _price = Math.Round(value, 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public OrderLine(Product product, Order order, int quantity,  decimal price)
        {
            Product = product;
            Order = order;
            Quantity = quantity;
            Price = price;
        }
    }
}
