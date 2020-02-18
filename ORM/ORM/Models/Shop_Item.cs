using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Shop_Item
    {
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


    }
}
