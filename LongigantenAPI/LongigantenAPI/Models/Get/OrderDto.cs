using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LongigantenAPI.Models
{
    [DataContract(Name = "Order", Namespace = "SchoolProjectAPI")]
    public class OrderDto
    {

        [DataMember(Name = "OrderNumber")]

        public int Ordernumber { get; set; }
        [DataMember(Name = "OrderDate")]

        public string OrderDate { get; set; }
        //public CustomerDto Customer { get; set; }
        [DataMember(Name = "DeliveryMethodID")]

        public int DeliveryMethodID { get; set; }
        [DataMember(Name = "DeliveryAddressID")]

        public int DeliveryAddressID { get; set; }
        [DataMember(Name = "StatusID")]

        public int StatusID { get; set; }
        [DataMember(Name = "OrderList")]

        public List<OrderLineDto> OrderList { get; set; }
        /*public OrderDto(DateTime created, CustomerDto customer, Order_Delivery_MethodDto deliveryMethod, AddressesDto deliveryAddress, Order_StatusDto status, List<OrderLineDto> orderList)
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

        }*/
    }
}
