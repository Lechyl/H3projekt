using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public Customers Customer { get; set; }
        public Order_Delivery_Method DeliveryMethod { get; set; }
        public Addresses DeliveryAddress { get; set; }
        public Order_Status Status { get; set; }

        public Order( DateTime created, Customers customer, Order_Delivery_Method deliveryMethod, Addresses deliveryAddress, Order_Status status)
        {
         
            Created = created;
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            DeliveryMethod = deliveryMethod;
            Status = status;
        }
        public Order(int id, DateTime created, Customers customer, Order_Delivery_Method deliveryMethod, Addresses deliveryAddress, Order_Status status)
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
