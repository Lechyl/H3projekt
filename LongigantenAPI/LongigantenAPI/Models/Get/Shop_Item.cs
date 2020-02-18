using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Shop_Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Shop Shop { get; set; }
        public Warehouse_Status Status { get; set; }
        public int Quantity { get; set; }

        public Shop_Item(Product product, Shop shop, Warehouse_Status status, int quantity = 0)
        {
            Product = product;
            Shop = shop;
            Status = status;
            Quantity = quantity;
        }

        public Shop_Item(int id,Product product, Shop shop, Warehouse_Status status, int quantity = 0)
        {
            Id = id;
            Product = product;
            Shop = shop;
            Status = status;
            Quantity = quantity;
        }
    }
}
