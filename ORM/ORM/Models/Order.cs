﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CustomerID { get; set; }
        public int DeliveryMethodID { get; set; }
        public int DeliveryAddressID { get; set; }
        public int StatusID { get; set; }




        public Customer Customer { get; set; }
        public Order_Delivery_Method DeliveryMethod { get; set; }
        public Addresses DeliveryAddress { get; set; }
        public Order_Status Status { get; set; }
        public List<OrderLine> OrderList { get; set; }

        public Order() { }
        public Order( DateTime created, Customer customer, Order_Delivery_Method deliveryMethod, Addresses deliveryAddress, Order_Status status)
        {
         
            Created = created;
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            DeliveryMethod = deliveryMethod;
            Status = status;
        }
        public Order(int id, DateTime created, Customer customer, Order_Delivery_Method deliveryMethod, Addresses deliveryAddress, Order_Status status)
        {
            Id = id;
            Created = created;
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            DeliveryMethod = deliveryMethod;
            Status = status;
        }
    }
}
