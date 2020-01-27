using System;
using System.Collections.Generic;
using System.Text;
using ORM.Models;

namespace ORM.Interface
{
    public interface IORM
    {

        //-----------------------------------------Adresse_Type-----------------------------------------//
        //Get requests
        public List<Address_Type> GetAllAdresseTypes();
        public Address_Type GetAdresseTypeById(int id);
        //Delete requests
        public void DeleteAdresseType(Address_Type adresse_Type);
        //Create requests
        public void CreateAdresseType(Address_Type adresse_Type);
        //Update requests
        public void UpdateAdresseType(Address_Type adresse_Type);

        //-----------------------------------------Adresse-----------------------------------------//
        public List<Addresses> GetAllAdresses();
        public Addresses GetAddressById(int id);
        public void DeleteAddress(Addresses address);
        public void CreateAddress(Addresses address);
        public void UpdateAddress(Addresses address);


        //-----------------------------------------Department-----------------------------------------//
        //Get requests
        public List<Departments> GetAllDepartments();
        public Departments GetDepartmentById(int id);
        //Delete requests
        public void DeleteDepartment(Departments department);
        //Create requests
        public void CreateDepartment(Departments department);
        //Update requests
        public void UpdateDepartment(Departments department);


        //-----------------------------------------Shop-----------------------------------------//
        //Get requests
        public List<Shops> GetAllShops();
        public Shops GetShopById(int id);
        //Delete requests
        public void DeleteShop(Shops shop);
        //Create requests
        public void CreateShop(Shops shop);
        //Update requests
        public void UpdateShop(Shops shop);


        //-----------------------------------------ShopWarehouse-----------------------------------------//
        //Get requests
        public List<Shops_Warehouse> GetAllShopWarehouses();
        public List<Shops_Warehouse> GetShopWarehouseByButik(Shops shop);
        //Delete requests
        public void DeleteShopWarehouse(Shops_Warehouse shopWarehouse);
        //Create requests
        public void CreateShopWarehouse(Shops_Warehouse shopWarehouse);
        //Update requests
        public void UpdateShopWarehouse(Shops_Warehouse shopWarehouse);

        //-----------------------------------------Category-----------------------------------------//
        //Get requests
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        //Delete requests
        public void DeleteCategory(Category category);
        //Create requests
        public void CreateCategory(Category category);
        //Update requests
        public void UpdateCategory(Category category);

        //-----------------------------------------Customer-----------------------------------------//
        //Get requests
        public List<Customers> GetAllCustomers();
        public Customers GetCustomerById(int id);
        //Delete requests
        public void DeleteCustomer(Customers customer);
        //Create requests
        public void CreateCustomer(Customers customer);
        //Update requests
        public void UpdateCustomer(Customers customer);


        //-----------------------------------------Customer_Addresses-----------------------------------------//
        //Get requests
        public List<Customer_Addresses> GetAllCustomerAddresses();
        public List<Customer_Addresses> GetCustomerAddressesByKunde(Customers customer);
        //Delete requests
        public void DeleteCustomerAddresses(Customer_Addresses customer_Addresses);
        //Create requests
        public void CreateCustomerAddresses(Customer_Addresses customer_Addresses);
        //Update requests
        public void UpdateCustomerAddresses(Customer_Addresses customer_Addresses);


        //-----------------------------------------Lager_Status-----------------------------------------//
        //Get requests
        public List<Warehouse_Status> GetAllWarehouseStatus();
        public Warehouse_Status GetWarehouseStatusById(int id);
        //Delete requests
        public void DeleteWarehouseStatus(Warehouse_Status warehouse_Status);
        //Create requests
        public void CreateWarehouseStatus(Warehouse_Status warehouse_Status);
        //Update requests
        public void UpdateWarehouseStatus(Warehouse_Status warehouse_Status);

        //-----------------------------------------Supplier-----------------------------------------//
        //Get requests
        public List<Supplier> GetAllSuppliers();
        public Supplier GetSupplierById(int id);
        //Delete requests
        public void DeleteSupplier(Supplier supplier);
        //Create requests
        public void CreateSupplier(Supplier supplier);
        //Update requests
        public void UpdateSupplier(Supplier supplier);


        //-----------------------------------------Employee-----------------------------------------//
        //Get requests
        public List<Employees> GetAllEmployees();
        public Employees GetEmployeeById(int id);
        //Delete requests
        public void DeleteEmployee(Employees employee);
        //Create requests
        public void CreateEmployee(Employees employee);
        //Update requests
        public void UpdateEmployee(Employees employee);

        //-----------------------------------------Order-----------------------------------------//
        //Get requests
        public List<Order> GetAllOrders();
        public Order GetOrderById(int id);
        //Delete requests
        public void DeleteOrder(Order order);
        //Create requests
        public void CreateOrder(Order order);
        //Update requests
        public void UpdateOrder(Order order);

        //-----------------------------------------Order_Leverings_Metode-----------------------------------------//
        //Get requests
        public List<Order_Delivery_Method> GetAllOrderDeliveryMethod();
        public Order_Delivery_Method GetOrderDeliveryMethodById(int id);
        //Delete requests
        public void DeleteOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);
        //Create requests
        public void CreateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);
        //Update requests
        public void UpdateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);


        //-----------------------------------------Order_Status-----------------------------------------//
        //Get requests
        public List<Order_Status> GetAllOrder_Status();
        public Order_Status GetOrder_StatusById(int id);
        //Delete requests
        public void DeleteOrder_Status(Order_Status Order_Status);
        //Create requests
        public void CreateOrder_Status(Order_Status Order_Status);
        //Update requests
        public void UpdateOrder_Status(Order_Status Order_Status);

        //-----------------------------------------OrderLines-----------------------------------------//
        //Get requests
        public List<OrderLines> GetAllOrderLines();
        public List<OrderLines> GetOrderLinesByOrder(Order Order);
        //Delete requests
        public void DeleteOrderLines(OrderLines orderLines);
        //Create requests
        public void CreateOrderLines(OrderLines orderLines);
        //Update requests
        public void UpdateOrderLines(OrderLines orderLines);

        //-----------------------------------------ZipCode-----------------------------------------//
        //Get requests
        public List<ZipCode> GetAllZipCode();
        public ZipCode GetZipCodeById(int id);
        //Delete requests
        public void DeleteZipCode(ZipCode zipCode);
        //Create requests
        public void CreateZipCode(ZipCode zipCode);
        //Update requests
        public void UpdateZipCode(ZipCode zipCode);

        //-----------------------------------------Producent-----------------------------------------//
        //Get requests
        public List<Producent> GetAllProducent();
        public Producent GetProducentById(int id);
        //Delete requests
        public void DeleteProducent(Producent producent);
        //Create requests
        public void CreateProducent(Producent producent);
        //Update requests
        public void UpdateProducent(Producent producent);

        //-----------------------------------------Product-----------------------------------------//
        //Get requests
        public List<Products> GetAllProducts();
        public Products GetProductById(int id);
        //Delete requests
        public void DeleteProduct(Products product);
        //Create requests
        public void CreateProduct(Products product);
        //Update requests
        public void UpdateProduct(Products product);
    }
}
