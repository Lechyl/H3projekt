using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class ProductDto
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
        public int CategoryID { get; set; }
        public int ProducentID { get; set; }
        public int SupplierID { get; set; }


     /*   //Constructor overload Create Product
        public ProductDto(string productName, string description, decimal price, CategoryDto category, ProducentDto producent, SupplierDto supplier)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Category = category;
            Producent = producent;
            Supplier = supplier;
        }

        //Constructor overload store Product
        public ProductDto(int id, string productName, string description, decimal price, CategoryDto category, ProducentDto producent, SupplierDto supplier)
        {
            Id = id;
            ProductName = productName;
            Description = description;
            Price = price;
            Category = category;
            Producent = producent;
            Supplier = supplier;
        }*/

    }
}
