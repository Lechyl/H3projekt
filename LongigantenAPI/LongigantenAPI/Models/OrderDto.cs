using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Customer", Namespace = "SchoolProjectAPI")]
    public class OrderDto
    {

        public int Ordernumber { get; set; }
        public DateTime OrderDate { get; set; }
        public CustomerDto Customer { get; set; }
        public Order_Delivery_MethodDto DeliveryMethod { get; set; }
        public AddressesDto DeliveryAddress { get; set; }
        public Order_StatusDto Status { get; set; }
        public List<OrderLineDto> OrderList { get; set; }
        public OrderDto(DateTime created, CustomerDto customer, Order_Delivery_MethodDto deliveryMethod, AddressesDto deliveryAddress, Order_StatusDto status, List<OrderLineDto> orderList)
        {

            OrderDate = created;
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            DeliveryMethod = deliveryMethod;
            Status = status;
            OrderList = orderList;
        }
        public OrderDto(int id, DateTime created, CustomerDto customer, Order_Delivery_MethodDto deliveryMethod, AddressesDto deliveryAddress, Order_StatusDto status, List<OrderLineDto> orderList)
        {
            Ordernumber = id;
            OrderDate = created;
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            DeliveryMethod = deliveryMethod;
            Status = status;
            OrderList = orderList;

        }
    }
}
