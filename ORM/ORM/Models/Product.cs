using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Product
    {
        private decimal _price;
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { 
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
        public Category Category { get; set; }
        public Producent Producent { get; set; }
        public Supplier Supplier { get; set; }


        //Constructor overload Create Product
        public Product(string productName, string description, decimal price, Category category, Producent producent, Supplier supplier)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Category = category;
            Producent = producent;
            Supplier = supplier;
        }

        //Constructor overload store Product
        public Product(int id, string productName, string description, decimal price, Category category, Producent producent, Supplier supplier)
        {
            Id = id;
            ProductName = productName;
            Description = description;
            Price = price;
            Category = category;
            Producent = producent;
            Supplier = supplier;
        }

    }
}
