﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "OrderLines", Namespace = "SchoolProjectAPI")]
    public class OrderLineDto
    {
        private int _quantity;
        private decimal _price;

        [DataMember(Name = "ProductID")]

        public int ProductID { get; set; }
        //public OrderDto Order { get; set; }
        [DataMember(Name = "Quantity")]

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
        [DataMember(Name ="Price")]

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
       /* public OrderLineDto(ProductDto product, OrderDto order, int quantity,  decimal price)
        {
            Product = product;
            Order = order;
            Quantity = quantity;
            Price = price;
        }*/
    }
}
