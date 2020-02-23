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
         Task DeleteAdresseType(int id);
        //Create requests
         Task<Address_Type> CreateAdresseType(Address_Type adresse_Type);
        //Update requests
         Task UpdateAdresseType(Address_Type adresse_Type);

        //-----------------------------------------Adresse-----------------------------------------//
         Task<List<Addresses>> GetAllAdresses();
         Task<Addresses> GetAddressById(int id);
         Task DeleteAddress(int id);
         Task<Addresses> CreateAddress(Addresses address);
         Task UpdateAddress(Addresses address);


        //-----------------------------------------Department-----------------------------------------//
        //Get requests
         Task<List<Department>> GetAllDepartments();
         Task<Department> GetDepartmentById(int id);
        //Delete requests
         Task DeleteDepartment(int id);
        //Create requests
         Task<Department> CreateDepartment(Department department);
        //Update requests
         Task UpdateDepartment(Department department);


        //-----------------------------------------Shop-----------------------------------------//
        //Get requests
         Task<List<Shop>> GetAllShops();
         Task<Shop> GetShopById(int id);
        //Delete requests
         Task DeleteShop(int id);
        //Create requests
         Task<Shop> CreateShop(Shop shop);
        //Update requests
         Task UpdateShop(Shop shop);


        //-----------------------------------------ShopWarehouse-----------------------------------------//
        //Get requests
         Task<List<Shop_Item>> GetAllShopWarehouses();
         Task<List<Shop_Item>> GetShopWarehouseByShopID(int id);
        //Delete requests
         Task DeleteShopWarehouse(Shop_Item shopWarehouse);
        //Create requests
         Task CreateShopWarehouse(Shop_Item shopWarehouse);
        //Update requests
         Task UpdateShopWarehouse(Shop_Item shopWarehouse);

        //-----------------------------------------Category-----------------------------------------//
        //Get requests
         Task<List<Category>> GetAllCategories();
         Task<Category> GetCategoryById(int id);
        //Delete requests
         Task DeleteCategory(int id);
        //Create requests
         Task<Category> CreateCategory(Category category);
        //Update requests
         Task UpdateCategory(Category category);

        //-----------------------------------------Customer-----------------------------------------//
        //Get requests
        Task<bool> CustomerExist(int id);
         Task<List<Customer>> GetAllCustomers();

        Task<List<Customer>> GetAllCustomers(CustomerParameters customParameters);

         Task<Customer> GetCustomerById(int id);
        //Delete requests
         Task DeleteCustomer(int id);
        Task DeleteCustomerData(int id);
        //Create requests
        
         Task<Customer> CreateCustomer(Customer customer);
        //Update requests
         Task UpdateCustomer(Customer customer);


        //-----------------------------------------Customer_Addresses-----------------------------------------//
        //Get requests
         Task<List<Customer_Addresses>> GetAllCustomerAddresses();
         Task<List<Customer_Addresses>> GetCustomerAddressesByCustomerID(int id);
        //Delete requests
         Task DeleteCustomerAddresses(Customer_Addresses customer_Addresses);
        //Create requests
         Task CreateCustomerAddresses(Customer_Addresses customer_Addresses);
        //Update requests
         Task UpdateCustomerAddresses(Customer_Addresses customer_Addresses);


        //-----------------------------------------Lager_Status-----------------------------------------//
        //Get requests
         Task<List<Warehouse_Status>> GetAllWarehouseStatus();
         Task<Warehouse_Status> GetWarehouseStatusById(int id);
        //Delete requests
         Task DeleteWarehouseStatus(int id);
        //Create requests
         Task<Warehouse_Status> CreateWarehouseStatus(Warehouse_Status warehouse_Status);
        //Update requests
         Task UpdateWarehouseStatus(Warehouse_Status warehouse_Status);

        //-----------------------------------------Supplier-----------------------------------------//
        //Get requests
         Task<List<Supplier>> GetAllSuppliers();
         Task<Supplier> GetSupplierById(int id);
        //Delete requests
         Task DeleteSupplier(int id);
        //Create requests
         Task<Supplier> CreateSupplier(Supplier supplier);
        //Update requests
         Task UpdateSupplier(Supplier supplier);


        //-----------------------------------------Employee-----------------------------------------//
        //Get requests
         Task<List<Employee>> GetAllEmployees();
         Task<Employee> GetEmployeeById(int id);
        //Delete requests
         Task DeleteEmployee(int id);
        //Create requests
         Task<Employee> CreateEmployee(Employee employee);
        //Update requests
         Task UpdateEmployee(Employee employee);

        //-----------------------------------------Order-----------------------------------------//
        //Get requests
         Task<List<Order>> GetAllOrders();
         Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrdersByCustomerId(int customerID);
        Task<Order> CreateOrderAndOrderLines(Order order);
        //Delete requests
        Task DeleteOrder(int id);
        //Create requests
         Task<Order> CreateOrder(Order order);
        //Update requests
         Task UpdateOrder(Order order);

        //-----------------------------------------Order_Leverings_Metode-----------------------------------------//
        //Get requests
         Task<List<Order_Delivery_Method>> GetAllOrderDeliveryMethod();
         Task<Order_Delivery_Method> GetOrderDeliveryMethodById(int id);
        //Delete requests
         Task DeleteOrderDeliveryMethod(int id);
        //Create requests
         Task<Order_Delivery_Method> CreateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);
        //Update requests
         Task UpdateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method);


        //-----------------------------------------Order_Status-----------------------------------------//
        //Get requests
         Task<List<Order_Status>> GetAllOrder_Status();
         Task<Order_Status> GetOrder_StatusById(int id);
        //Delete requests
         Task DeleteOrder_Status(int id);
        //Create requests
         Task<Order_Status> CreateOrder_Status(Order_Status Order_Status);
        //Update requests
         Task UpdateOrder_Status(Order_Status Order_Status);

        //-----------------------------------------OrderLines-----------------------------------------//
        //Get requests
         Task<List<OrderLine>> GetAllOrderLines();
         Task<List<OrderLine>> GetOrderLinesByOrderID(int id);
        //Delete requests
         Task DeleteOrderLines(OrderLine orderLines);
        //Create requests
        //Task CreateOrderLines(OrderLine orderLines);
        Task<List<OrderLine>> CreateOrderLines(List<OrderLine> orderLines, int orderID);


        //Update requests
         Task UpdateOrderLines(OrderLine orderLines);

        //-----------------------------------------ZipCode-----------------------------------------//
        //Get requests
         Task<List<ZipCode>> GetAllZipCode();
         Task<ZipCode> GetZipCodeById(int id);
        //Delete requests
         Task DeleteZipCode(int id);
        //Create requests
         Task<ZipCode> CreateZipCode(ZipCode zipCode);
        //Update requests
         Task UpdateZipCode(ZipCode zipCode);

        //-----------------------------------------Producent-----------------------------------------//
        //Get requests
         Task<List<Producent>> GetAllProducent();
         Task<Producent> GetProducentById(int id);
        //Delete requests
         Task DeleteProducent(int id);
        //Create requests
         Task<Producent> CreateProducent(Producent producent);
        //Update requests
         Task UpdateProducent(Producent producent);

        //-----------------------------------------Product-----------------------------------------//
        //Get requests
         Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProducts(ProductsParameter productsParameter);

         Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductsByProducentId(int id);

        //Delete requests
         Task DeleteProduct(int id);
        //Create requests
         Task<Product> CreateProduct(Product product);
        //Update requests
         Task UpdateProduct(Product product);
    }
}
