using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ORM.ResourceParameters;
using ORM.Models;


namespace ORM.Services
{
    public interface IORM
    {
         List<Exception> ExceptionLogging { get; set; }


        Task<Customer> Authenticate(string email, string password);
         void OpenConn();
        Task CloseConn();
        //-----------------------------------------Adresse_Type-----------------------------------------//
        //Get requests
         Task<List<Address_Type>> GetAllAdresseTypes();
         Task<Address_Type> GetAdresseTypeById(int id);
        //Delete requests
         Task<int> DeleteAdresseType(int id);
        //Create requests
         Task<Address_Type> CreateAdresseType(Address_Type adresse_Type);
        //Update requests
         Task<int> UpdateAdresseType(Address_Type adresse_Type);

        //-----------------------------------------Adresse-----------------------------------------//
         Task<List<Addresses>> GetAllAdresses();
         Task<Addresses> GetAddressById(int id);
         Task<int> DeleteAddress(int id);
         Task<Addresses> CreateAddress(Addresses address);
         Task<int> UpdateAddress(Addresses address);


        //-----------------------------------------Department-----------------------------------------//
        //Get requests
         Task<List<Department>> GetAllDepartments();
         Task<Department> GetDepartmentById(int id);
        //Delete requests
         Task<int> DeleteDepartment(int id);
        //Create requests
         Task<Department> CreateDepartment(Department department);
        //Update requests
         Task<int> UpdateDepartment(Department department);


        //-----------------------------------------Shop-----------------------------------------//
        //Get requests
         Task<List<Shop>> GetAllShops();
         Task<Shop> GetShopById(int id);
        //Delete requests
         Task<int> DeleteShop(int id);
        //Create requests
         Task<Shop> CreateShop(Shop shop);
        //Update requests
         Task<int> UpdateShop(Shop shop);


        //-----------------------------------------ShopWarehouse-----------------------------------------//
        //Get requests
         Task<List<Shop_Item>> GetAllShopWarehouses();
         Task<List<Shop_Item>> GetShopWarehouseByShopID(int id);
        //Delete requests
         Task<int> DeleteShopWarehouse(Shop_Item shopWarehouse);
        //Create requests
         Task CreateShopWarehouse(Shop_Item shopWarehouse);
        //Update requests
         Task<int> UpdateShopWarehouse(Shop_Item shopWarehouse);

        //-----------------------------------------Category-----------------------------------------//
        //Get requests
         Task<List<Category>> GetAllCategories();
         Task<Category> GetCategoryById(int id);
        //Delete requests
         Task<int> DeleteCategory(int id);
        //Create requests
         Task<Category> CreateCategory(Category category);
        //Update requests
         Task<int> UpdateCategory(Category category);

        //-----------------------------------------Customer-----------------------------------------//
        //Get requests
        Task<bool> CustomerExist(int id);
         Task<List<Customer>> GetAllCustomers();

        Task<List<Customer>> GetAllCustomers(CustomerParameters customParameters);

         Task<Customer> GetCustomerById(int id);
        //Delete requests
         Task<int> DeleteCustomer(int id);
        Task<int> DeleteCustomerData(int id);
        //Create requests
        
         Task<Customer> CreateCustomer(Customer customer);
        //Update requests
         Task<int> UpdateCustomer(Customer customer);


        //-----------------------------------------Customer_Addresses-----------------------------------------//
        //Get requests
         Task<List<Customer_Addresses>> GetAllCustomerAddresses();
         Task<List<Customer_Addresses>> GetCustomerAddressesByCustomerID(int id);
        //Delete requests
         Task<int> DeleteCustomerAddresses(Customer_Addresses customer_Addresses);
        //Create requests
         Task CreateCustomerAddresses(Customer_Addresses customer_Addresses);
        //Update requests
         Task<int> UpdateCustomerAddresses(Customer_Addresses customer_Addresses);


        //-----------------------------------------Lager_Status-----------------------------------------//
        //Get requests
         Task<List<Warehouse_Status>> GetAllWarehouseStatus();
         Task<Warehouse_Status> GetWarehouseStatusById(int id);
        //Delete requests
         Task<int> DeleteWarehouseStatus(int id);
        //Create requests
         Task<Warehouse_Status> CreateWarehouseStatus(Warehouse_Status warehouse_Status);
        //Update requests
         Task<int> UpdateWarehouseStatus(Warehouse_Status warehouse_Status);

        //-----------------------------------------Supplier-----------------------------------------//
        //Get requests
         Task<List<Supplier>> GetAllSuppliers();
         Task<Supplier> GetSupplierById(int id);
        //Delete requests
         Task<int> DeleteSupplier(int id);
        //Create requests
         Task<Supplier> CreateSupplier(Supplier supplier);
        //Update requests
         Task<int> UpdateSupplier(Supplier supplier);


        //-----------------------------------------Employee-----------------------------------------//
        //Get requests
         Task<List<Employee>> GetAllEmployees();
         Task<Employee> GetEmployeeById(int id);
        //Delete requests
         Task<int> DeleteEmployee(int id);
        //Create requests
         Task<Employee> CreateEmployee(Employee employee);
        //Update requests
         Task<int> UpdateEmployee(Employee employee);

        //-----------------------------------------Order-----------------------------------------//
        //Get requests
         Task<List<Order>> GetAllOrders();
         Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrdersByCustomerId(int customerID);
        Task<Order> CreateOrderAndOrderLines(Order order);
        //Delete requests
        Task<int> DeleteOrder(int id);
        //Create requests
         Task<Order> CreateOrder(Order order);
        //Update requests
         Task<int> UpdateOrder(Order order);

        //-----------------------------------------Order_Leverings_Metode-----------------------------------------//
        //Get requests
         Task<List<Order_Delivery_Method>> GetAllOrderDeliveryMethod();
         Task<Order_Delivery_Method> GetOrderDeliveryMethodById(int id);
        //Delete requests
         Task<int> DeleteOrderDeliveryMethod(int id);
        //Create requests
         Task<Order_Delivery_Method> CreateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);
        //Update requests
         Task<int> UpdateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);


        //-----------------------------------------Order_Status-----------------------------------------//
        //Get requests
         Task<List<Order_Status>> GetAllOrder_Status();
         Task<Order_Status> GetOrder_StatusById(int id);
        //Delete requests
         Task<int> DeleteOrder_Status(int id);
        //Create requests
         Task<Order_Status> CreateOrder_Status(Order_Status Order_Status);
        //Update requests
         Task<int> UpdateOrder_Status(Order_Status Order_Status);

        //-----------------------------------------OrderLines-----------------------------------------//
        //Get requests
         Task<List<OrderLine>> GetAllOrderLines();
         Task<List<OrderLine>> GetOrderLinesByOrderID(int id);
        //Delete requests
         Task<int> DeleteOrderLines(OrderLine orderLines);
        //Create requests
        //Task CreateOrderLines(OrderLine orderLines);
        Task<List<OrderLine>> CreateOrderLines(List<OrderLine> orderLines, int orderID);


        //Update requests
         Task<int> UpdateOrderLines(OrderLine orderLines);

        //-----------------------------------------ZipCode-----------------------------------------//
        //Get requests
         Task<List<ZipCode>> GetAllZipCode();
         Task<ZipCode> GetZipCodeById(int id);
        //Delete requests
         Task<int> DeleteZipCode(int id);
        //Create requests
         Task<ZipCode> CreateZipCode(ZipCode zipCode);
        //Update requests
         Task<int> UpdateZipCode(ZipCode zipCode);

        //-----------------------------------------Producent-----------------------------------------//
        //Get requests
         Task<List<Producent>> GetAllProducent();
         Task<Producent> GetProducentById(int id);
        //Delete requests
         Task<int> DeleteProducent(int id);
        //Create requests
         Task<Producent> CreateProducent(Producent producent);
        //Update requests
         Task<int> UpdateProducent(Producent producent);

        //-----------------------------------------Product-----------------------------------------//
        //Get requests
         Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProducts(ProductsParameter productsParameter);

         Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductsByProducentId(int id);

        //Delete requests
         Task<int> DeleteProduct(int id);
        //Create requests
         Task<Product> CreateProduct(Product product);
        //Update requests
         Task<int> UpdateProduct(Product product);
    }
}
