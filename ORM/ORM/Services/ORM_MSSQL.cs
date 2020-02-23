
using Microsoft.Extensions.Options;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using ORM.ResourceParameters;

namespace ORM.Services
{
    public class ORM_MSSQL : IORM, IDisposable
    {
        private readonly SqlConnection dbConn;
        public List<Exception> ExceptionLogging { get; set; }

        private readonly string _appSettings;
        public ORM_MSSQL(string host, string user, string password, string database, string Secret)
        {
            ExceptionLogging = new List<Exception>();

            _appSettings = Secret;
            //Define connection string to db
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = database,
                UserID = user,
                Password = password,
                DataSource = host,
                MultipleActiveResultSets = true,
                MaxPoolSize = 200
                

            };

            //Create connection string to database
            dbConn = new SqlConnection(conString.ToString());
        }

        public async Task<Customer> Authenticate(string email, string password)
        {
            Customer customer = null;
            string query = "select Kunder.id,fornavn,efternavn,email,telefon,dateOfBirth, password,Roller.rolle from kunder inner join Roller on Roller.id = rolleID where email = @email and password = @password and password != '[Slettet]'";
            using (SqlCommand cmd = new SqlCommand(query, dbConn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                       while(reader.Read())
                        {
                            customer = new Customer(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetDateTime(5),reader.GetString(6),reader.GetString(7),reader.GetString(4));
                        }

                        // authentication successful so generate jwt token
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(_appSettings);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, customer.Id.ToString()),
                                new Claim(ClaimTypes.Role, customer.Role)
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        customer.Token = tokenHandler.WriteToken(token);
                        customer.Password = null;
                    }


                }
            }

                return customer;
        }
        public async Task<Addresses> CreateAddress(Addresses address)
        {
            try
            {
                string query = "insert into Addressesr(postnrID,adresse,etage) output inserted.id values (@postnrId,@adresse@,etage)";
                Addresses addresses = null;
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@postnrId", address.ZipCode.Id);
                    cmd.Parameters.AddWithValue("@adresse", address.Address);
                    cmd.Parameters.AddWithValue("@etage", address.Floor);

                    //get inserted id.
                    int id = (int)await cmd.ExecuteScalarAsync();
                    address.Id = id;
                   
                }


                return addresses;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Address_Type> CreateAdresseType(Address_Type adresse_Type)
        {

            try
            {
                string query = "insert into Adresse_Type(type) output inserted.id values (@type)";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@type", adresse_Type.Type);

                    int id = (int) await cmd.ExecuteScalarAsync();
                    adresse_Type.Id = id;
                }


                return adresse_Type;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            try
            {

                string query = "insert into Afdelinger(afdeling,parent_Afdeling) output inserted.id values (@afdeling,@parent_Afdeling)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@afdeling", department.DepartmentName);
                    // if the left-hand opereator is null then use righthand operator
                    cmd.Parameters.AddWithValue("@parent_Afdeling", (object)department.Parent_Department.Id ?? DBNull.Value);
                    //get inserted id
                    int id = (int)await cmd.ExecuteScalarAsync();
                    department.Id = id;
                }
                return department;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Shop> CreateShop(Shop shop)
        {
            try
            {
                string query = "insert into Butikker(adresseID) output inserted.id values (@adresseID)";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@adresseID", shop.Address.Id);

                    //get inserted id.

                    int id =(int) await cmd.ExecuteScalarAsync();
                    shop.Id = id;
                }
                return shop;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task CreateShopWarehouse(Shop_Item shopWarehouse)
        {
            try
            {
                string query = "insert into Butikker_har_Vare(produktID,butikID,statusID,antal)  values (@produktID,@butikID,@statusID,@antal)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@produktID", shopWarehouse.Product.Id);
                    await cmd.ExecuteNonQueryAsync();
                }


                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                string query = "insert into Kategorier(navn, parent_KategoriID) output inserted.id values (@navn, @parent_KategoriID)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@navn", category.Name);
                    cmd.Parameters.AddWithValue("@parent_KategoriID", (object)category.Parent_Category.Id ?? DBNull.Value);

                    //get inserted id.
                    int id = (int)await cmd.ExecuteScalarAsync();
                    category.Id = id;
                }
                return category;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {

            try
            {
                string query = "insert into Kunder(fornavn,efternavn,email,telefon,dateOfBirth) output inserted.id values(@fornavn,@efternavn,@email,@telefon,@dateOfBirth)";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@fornavn", customer.FirstName);
                    cmd.Parameters.AddWithValue("@efternavn", customer.LastName);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@telefon", customer.Phone);
                    cmd.Parameters.AddWithValue("@dateOfBirth", customer.DateOfBirth);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    customer.Id = id;

                }
                return customer;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task CreateCustomerAddresses(Customer_Addresses customer_Addresses)
        {
            try
            {
                string query = "insert into Kunder_har_Adresser(adresseID,kundeID,adresseType) values (@adresseID,@kundeID,@adresseType)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@adresseID", customer_Addresses.Address.Id);
                    cmd.Parameters.AddWithValue("@kundeID", customer_Addresses.Customer.Id);
                    cmd.Parameters.AddWithValue("@adresseType", customer_Addresses.AdresseType.Id);

                    await cmd.ExecuteNonQueryAsync();

                }

                

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Warehouse_Status> CreateWarehouseStatus(Warehouse_Status warehouse_Status)
        {
            try
            {
                string query = "insert into Lager_Status(status) output inserted.id values (@status)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn)) 
                {

                    cmd.Parameters.AddWithValue("@status", warehouse_Status.Status);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    warehouse_Status.Id = id;
                }
                return warehouse_Status;
                

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {
            try
            {
                string query = "insert into Leverandor(leverandorNavn,kontaktPerson,email,telefon) output inserted.id values (@leverandorNavn,@kontaktPerson,@email,@telefon)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@leverandorNavn", supplier.SupplierName);
                    cmd.Parameters.AddWithValue("@kontaktPerson", supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@email", supplier.Email);
                    cmd.Parameters.AddWithValue("@telefon", supplier.Phone);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    supplier.Id = id;
                    
                }
                return supplier;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            try
            {
                string query = "insert into Medarbejder(fornavn,efternavn,email,telefon,kontonr,reg,adresseID,afdelingID,butikID,dateOfBirth) output inserted.id values (@fornavn,@efternavn,@email,@telefon,@kontonr,@reg,@adresseID,@afdelingID,@butikID,@dateOfBirth)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {


                    cmd.Parameters.AddWithValue("@fornavn", employee.FirstName);
                    cmd.Parameters.AddWithValue("@efternavn", employee.LastName);
                    cmd.Parameters.AddWithValue("@email", employee.Email);
                    cmd.Parameters.AddWithValue("@telefon", employee.Phone);
                    cmd.Parameters.AddWithValue("@kontonr", employee.AccountNr);
                    cmd.Parameters.AddWithValue("@reg", employee.Reg);
                    cmd.Parameters.AddWithValue("@adresseID", employee.Address.Id);
                    cmd.Parameters.AddWithValue("@afdelingID", employee.Departments.Id);
                    cmd.Parameters.AddWithValue("@butikID", employee.Shop.Id);
                    cmd.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);

                    //get inserted id.

                    int id = (int) await cmd.ExecuteScalarAsync();
                    employee.Id = id;
                
                }
                return employee;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                string query = "insert into Ordre(kundeID,leveringsMetodeID,leveringsAdresseID,statusID) output inserted.id values (@kundeID,@leveringsMetodeID,@leveringsAdresseID,@statusID)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@kundeID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@leveringsMetodeID", order.DeliveryMethodID);
                    cmd.Parameters.AddWithValue("@leveringsAdresseID", order.DeliveryAddressID);
                    cmd.Parameters.AddWithValue("@statusID", order.StatusID);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    order.Id = id;
                

                }
               // order =await GetOrderById(order.Id);
                return order;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async Task<Order> CreateOrderAndOrderLines(Order order)
        {
            try
            {

                Order createdOrder = await CreateOrder(order);
                
                createdOrder.OrderList = await CreateOrderLines(order.OrderList,createdOrder.Id);
                 

                
                return createdOrder;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Order_Delivery_Method> CreateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method)
        {
            try
            {
                string query = "insert into Ordre_Leverings_Metode(metodeNavn,pris) output inserted.id values (@metodeNavn,@pris)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@metodeNavn", order_Delivery_Method.MethodName);
                    cmd.Parameters.AddWithValue("@pris", order_Delivery_Method.Price);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    order_Delivery_Method.Id = id;
                }

                return order_Delivery_Method;
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderLine>> CreateOrderLines(List<OrderLine> orderLines, int orderID)
        {
            try
            {

                //create datatable and add the insert items into the datatable as this should be a matching reference to the real table in database.

                var dt = new DataTable();
                
                dt.Columns.Add(new DataColumn("produktID"));
                dt.Columns.Add(new DataColumn("ordreID"));
                dt.Columns.Add(new DataColumn("antal"));
                dt.Columns.Add(new DataColumn("pris"));
                
                //insert the insert data to datatable
                foreach(var orderline in orderLines)
                {
                   
                    dt.Rows.Add(orderline.ProductID,orderID,orderline.Quantity,orderline.Price);
                }
                // bulk insert into the database.
                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(dbConn))
                {
                    
                    sqlBulk.DestinationTableName = "Ordrelinjer";
                    await sqlBulk.WriteToServerAsync(dt);
                }

                return orderLines;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Order_Status> CreateOrder_Status(Order_Status order_Status)
        {
            try
            {
                string query = "insert into Ordre_Status(status) output inserted.id values (@status)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@status", order_Status.Status);
                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    order_Status.Id = id;
                }

                return order_Status;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ZipCode> CreateZipCode(ZipCode zipCode)
        {
            try
            {
                string query = "insert into PostNr(byNavn) output inserted.id values (@byNavn)";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@byNavn", zipCode.CityName);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    zipCode.Id = id;
                }

                return zipCode;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Producent> CreateProducent(Producent producent)
        {
            try
            {
                string query = "insert into Producent(producentNavn) output inserted.id values (@producentNavn);";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@producentNavn", producent.ProducentName);

                    //get inserted id.

                    int id =  (int)await cmd.ExecuteScalarAsync();
                    
                    producent.Id = id;
                }
                return producent;
                
            }
            catch (Exception e)
            {

                ExceptionLogging.Add(e);

                throw new Exception(e.Message);
            }
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                string query = "insert into Produkter(produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID) output inserted.id values (@produktNavn,@beskrivelse,@pris,@kategoriID,@producentID,@leverandorID)";
              
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@produktNavn", product.ProductName);
                cmd.Parameters.AddWithValue("@beskrivelse", product.Description);
                cmd.Parameters.AddWithValue("@pris", product.Price);
                cmd.Parameters.AddWithValue("@kategoriID", product.CategoryID);
                cmd.Parameters.AddWithValue("@producentID", product.ProducentID);
                cmd.Parameters.AddWithValue("@leverandorID", product.SupplierID);

                    //get inserted id.

                    int id = (int)await cmd.ExecuteScalarAsync();
                    
                    product.Id = id;
                }


                return product;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public async Task<Addresses> GetAddressById(int id)
        {
            try
            {
                Addresses adresse = null;
                string query = "select Adresser.id,adresse,etage,pn.id,pn.byNavn from Adresser inner join PostNr as pn on pn.id = postnrID where Adresser.id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;

                        while (await reader.ReadAsync())
                        {
                            ZipCode postNr = new ZipCode(reader.GetInt32(3), reader.GetString(4));



                            adresse = new Addresses(reader.GetInt32(0), postNr, reader.GetString(1), reader.GetString(2));
                            count++;


                        }

                        
                        if (count > 1) { throw new IndexOutOfRangeException("Address unspecified error"); }
                    }

                    
                }

                return adresse;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Address_Type> GetAdresseTypeById(int id)
        {
            try
            {
                Address_Type adresse_Type = null;
                string query = "select id,type from Adresse_Type where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;

                        while (await reader.ReadAsync())
                        {
                            adresse_Type = new Address_Type((int)reader[0], (string)reader[1]);
                            count++;
                        }

                        
                        if (count > 1) { throw new IndexOutOfRangeException("Address Type unspecified error"); }
                    }

                    
                }

                return adresse_Type;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            try
            {
                Department afdelinger = null;
                string query = "select a1.id,a1.afdeling,a2.id,a2.afdeling from Afdelinger as a1 left join Afdelinger a2 on a2.id = a1.parent_Afdeling where a1.id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            if (reader[2] == null)
                            {
                                afdelinger = new Department((int)reader[0], (string)reader[1]);
                            }
                            else
                            {
                                Department parent_Afdeling = new Department((int)reader[2], (string)reader[3]);

                                afdelinger = new Department((int)reader[0], (string)reader[1], parent_Afdeling);
                            }
                            count++;

                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Department unspecified error"); }
                    }

                    
                }

                return afdelinger;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        public async Task<Shop> GetShopById(int id)
        {

            try
            {
                Shop butik = null;
                string query = "select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID where b.id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            ZipCode postNr = new ZipCode((int)reader[4], (string)reader[5]);
                            Addresses adresser = new Addresses((int)reader[1], postNr, (string)reader[2], (string)reader[3]);
                            butik = new Shop((int)reader[0], adresser);
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Shop unspecified error"); }
                    }

                    
                }

                return butik;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Shop_Item>> GetShopWarehouseByShopID(int id)
        {
            try
            {
                List<Shop_Item> butikker_Har_Vare = new List<Shop_Item>();
                string query = "select produktID,statusID,antal from Butikker_har_Vare where butikID = @butikID";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@butikID", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {




                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Product produkt = await GetProductById(reader.GetInt32(0));
                                Warehouse_Status lager_Status = await GetWarehouseStatusById(reader.GetInt32(1));
                                Shop shop = await GetShopById(id);
                                butikker_Har_Vare.Add(new Shop_Item(produkt, shop, lager_Status, reader.GetInt32(2)));

                            }
                        }
                        else
                        {
                            throw new ArithmeticException("No row returned");
                        }
                    }

                    
                }


                return butikker_Har_Vare;

            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Category> GetCategoryById(int id)
        {

            try
            {
                Category kategorier = null;
                string query = "select k1.id,k1.navn,k2.id,k2.navn from Kategorier as k1 left join Kategorier k2 on k1.parent_KategoriID = k2.id where k1.id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {


                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            if (reader[2] == null)
                            {
                                kategorier = new Category(reader.GetInt32(0), reader.GetString(1));
                            }
                            else
                            {
                                Category parent_Kategori = new Category(reader.GetInt32(2), reader.GetString(3));
                                kategorier = new Category((int)reader[0], (string)reader[1], parent_Kategori);
                            }

                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Category unspecified error"); }
                    }

                    
                }

                return kategorier;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task<bool> CustomerExist(int id)
        {
            try
            {
                
                string query = "select count(id) as totalRows from kunder where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {


                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        reader.Read();

                        //Check if the total rows returned is 1 then Customer exist
                        if ((int)reader["totalRows"] == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }


                }

            }
            catch (Exception e) { throw e; }
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                Customer kunder = null;
                string query = "select Kunder.id,fornavn,efternavn,email,telefon,dateOfBirth, password,Roller.rolle from kunder inner join Roller on Roller.id = rolleID where Kunder.id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {


                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            List<Customer_Addresses> addresslist = await GetCustomerAddressesByCustomerID(reader.GetInt32(0));

                            kunder = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),reader.GetDateTime(5),reader.GetString(6),reader.GetString(7),reader.GetString(4));
                            kunder.customer_Addresses = addresslist;
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Customer unspecified error!"); }
                        
                    }

                    
                }

                return kunder;
            }
            catch (Exception e) { throw e; }

        }

        public async Task<List<Customer_Addresses>> GetCustomerAddressesByCustomerID(int id)
        {
            try
            {
                List<Customer_Addresses> kunder_Har_Adressers = new List<Customer_Addresses>();
                string query = "select adresseID,adresseType from Kunder_har_Adresser where kundeID = @kundeId";
                
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    

                    cmd.Parameters.AddWithValue("@kundeId", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {


                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Addresses adresser = await GetAddressById(reader.GetInt32(0));
                                Address_Type adresse_Type = await GetAdresseTypeById(reader.GetInt32(1));
                                //Customer customer = await GetCustomerById(reader.GetInt32(1));
                                Customer customer = new Customer();
                                kunder_Har_Adressers.Add(new Customer_Addresses(adresser, customer, adresse_Type));

                            }
                        }
                        else
                        {
                            throw new ArgumentNullException("Returned 0 Rows");
                        }


                    }
                    

                }
                
                return kunder_Har_Adressers;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Warehouse_Status> GetWarehouseStatusById(int id)
        {
            try
            {
                Warehouse_Status lager_Status = null;
                string query = "select id,status from Lager_Status where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {



                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            lager_Status = new Warehouse_Status(reader.GetInt32(0), reader.GetString(0));
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Warehouse Status unspecified error"); }
                    }

                    
                }

                return lager_Status;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            try
            {
                Supplier leverandor = null;
                string query = "select id,leverandorNavn,kontaktPerson,email,telefon from Leverandor where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {


                        int count = 0;
                        while (await reader.ReadAsync())
                        {

                            leverandor = new Supplier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Supplier unspecified error"); }

                    }
                    
                }


                return leverandor;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                Employee medarbejder = null;
                string query = "select id,fornavn,efternavn,kontonr,reg,email,telefon,adresseID,afdelingID,butikID,dateOfBirth from Medarbejder where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            Addresses adresse = await GetAddressById(reader.GetInt32(7));
                            Department afdeling = await GetDepartmentById(reader.GetInt32(8));
                            Shop butik = await GetShopById(reader.GetInt32(9));

                            medarbejder = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(6),reader.GetDateTime(10), adresse, afdeling, butik, reader.GetString(5));
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Worker unspecified error"); }
                    }

                    
                }



                return medarbejder;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }



        public async Task<Order_Status> GetOrder_StatusById(int id)
        {
            try
            {
                Order_Status ordre_Status = null;
                string query = "select id,status from Ordre_Status where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            ordre_Status = new Order_Status(reader.GetInt32(0), reader.GetString(1));
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Order Status unspecified error"); }
                    }

                    
                }

                return ordre_Status;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        public async Task<Producent> GetProducentById(int id)
        {
            try
            {
                Producent producent = null;
                string query = "select id,producentNavn from Producent where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            producent = new Producent(reader.GetInt32(0), reader.GetString(1));

                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Producent unspecified error"); }
                    }

                    
                }

                return producent;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                Product produkter = null;
                string query = "select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            Category kategori = await GetCategoryById(reader.GetInt32(4));
                            Producent producent = await GetProducentById(reader.GetInt32(5));
                            Supplier leverandor = await GetSupplierById(reader.GetInt32(6));

                            produkter = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), kategori, producent, leverandor);

                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Product unspecified error"); }
                    }

                    
                }

                return produkter;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task<Order_Delivery_Method> GetOrderDeliveryMethodById(int id)
        {
            try
            {
                Order_Delivery_Method order_Delivery_Method = null;
                string query = "select id,metodeNavn,pris from Ordre_Leverings_Metode where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            order_Delivery_Method = new Order_Delivery_Method(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Order Delivery Method unspecified error"); }
                    }

                    
                }


                return order_Delivery_Method;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                Order order = null;
                string query = "select id,opretsDato,kundeID,leveringsMetodeID,leveringsAdresseID,statusID from Ordre where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            Customer customer = await GetCustomerById(reader.GetInt32(2));
                            Order_Delivery_Method order_Delivery_Method = await GetOrderDeliveryMethodById(reader.GetInt32(3));
                            Addresses address = await GetAddressById(reader.GetInt32(4));
                            Order_Status order_Status = await GetOrder_StatusById(reader.GetInt32(5));
                            order = new Order(reader.GetInt32(0), reader.GetDateTime(1), customer, order_Delivery_Method, address, order_Status);
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("Order unspecified error"); }
                    }
                    

                }

                return order;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task<List<Order>> GetOrdersByCustomerId(int customerID)
        {
            try
            {
                List<Order> orders = new List<Order>();
                string query = "select id,opretsDato,kundeID,leveringsMetodeID,leveringsAdresseID,statusID from Ordre where kundeID = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {


                    cmd.Parameters.AddWithValue("@id", customerID);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        
                        if (reader.HasRows)
                        {

                            while ( reader.Read())
                            {
                                List<OrderLine> orderLines = await GetOrderLinesByOrderID(reader.GetInt32(0));
                                Customer customer = await GetCustomerById(reader.GetInt32(2));
                                
                                Order_Delivery_Method order_Delivery_Method = await GetOrderDeliveryMethodById(reader.GetInt32(3));
                                Addresses address = await GetAddressById(reader.GetInt32(4));
                                Order_Status order_Status = await GetOrder_StatusById(reader.GetInt32(5));
                                Order order = new Order(reader.GetInt32(0), reader.GetDateTime(1), customer, order_Delivery_Method, address, order_Status);
                                order.OrderList = orderLines;
                                orders.Add(order);
                                
                            }
                        }
                        else
                            throw new ArgumentNullException("GetOrdersByCustomerId Null rows returned");

                    }


                }

                return orders;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<ZipCode> GetZipCodeById(int id)
        {
            try
            {
                ZipCode zipCode = null;
                string query = "select id,byNavn from PostNr where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        int count = 0;
                        while (await reader.ReadAsync())
                        {
                            zipCode = new ZipCode(reader.GetInt32(0), reader.GetString(1));
                            count++;
                        }
                        if (count > 1) { throw new IndexOutOfRangeException("ZipCOde unspecified error"); }

                    }
                    

                }

                return zipCode;

            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        public async Task<List<OrderLine>> GetOrderLinesByOrderID(int id)
        {
            try
            {
                List<OrderLine> orderLines = new List<OrderLine>();

                string query = "select produktID,ordreID,antal,pris from Ordrelinjer where ordreID = @orderID";
                
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@orderID", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {

                        if (reader.HasRows)
                        {

                            while (await reader.ReadAsync())
                            {
                                Product product = await GetProductById(reader.GetInt32(0));
                                Order order = await GetOrderById(reader.GetInt32(1));
                                
                                orderLines.Add(new OrderLine(product, order, reader.GetInt32(2), reader.GetDecimal(3)));

                            }
                        }
                        else
                            throw new ArgumentNullException("GetOrderLinesByOrderID Null rows returned");

                        //
                    }

                }
                
                return orderLines;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task<List<Address_Type>> GetAllAdresseTypes()
        {
            try
            {
                List<Address_Type> address_Types = new List<Address_Type>();
                string query = "select id,type from Adresse_Type";
                using (SqlCommand cmd = new SqlCommand(query,dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                address_Types.Add(new Address_Type(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllAdresseTypes Null row returned");


                    }
                }

                return address_Types;
            }
            catch (SqlException e) { throw e; }
        }

        public async Task DeleteAdresseType(int id)
        {
            try {
                string query = "delete from Adresse_Type where id = @id";


                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@id", id);
                    await cmd.ExecuteNonQueryAsync();

                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateAdresseType(Address_Type adresse_Type)
        {
            try
            {
                string query = "update Adresse_Type set type = @type where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@type", adresse_Type.Type);

                    cmd.Parameters.AddWithValue("@id", adresse_Type.Id);


                    await cmd.ExecuteNonQueryAsync();

                }


            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Addresses>> GetAllAdresses()
        {
            try
            {
                List<Addresses> addresses = new List<Addresses>();

                string query = "select Adresser.id,adresse,etage,pn.id,pn.byNavn from Adresser inner join PostNr as pn on pn.id = postnrID";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader =await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                ZipCode zipCode = new ZipCode(reader.GetInt32(3), reader.GetString(4));
                                addresses.Add(new Addresses(reader.GetInt32(0), zipCode, reader.GetString(1), reader.GetString(2)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllAdresses Null row returned");

                    }
                }

                return addresses;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteAddress(int id)
        {
            try {
                string query = "delete from Adresser where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@id", id);


                    await cmd.ExecuteNonQueryAsync();

                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateAddress(Addresses address)
        {
            try {
                string query = "update Adresser set adresse = @address, postnrID = @postnriD, etage = @etage where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@address",address.Address);
                    cmd.Parameters.AddWithValue("@postnriD", address.ZipCodeID);
                    cmd.Parameters.AddWithValue("@etage", address.Floor);
                    cmd.Parameters.AddWithValue("@id", address.Id);


                    await cmd.ExecuteNonQueryAsync();

                }

            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            try
            {
                List<Department> departments = new List<Department>();
                string query = "select a1.id,a1.afdeling,a2.id,a2.afdeling from Afdelinger as a1 left join Afdelinger a2 on a2.id = a1.parent_Afdeling";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using(SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                Department parent_Department = reader[2] != null ? new Department(reader.GetInt32(2), reader.GetString(3)) : null;
                                departments.Add(new Department(reader.GetInt32(0), reader.GetString(1), parent_Department));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllDepartments Null row returned");

                    }
                }
                    return departments;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteDepartment(int id)
        {
            try {
                string query = "delete from Afdelinger where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    cmd.Parameters.AddWithValue("@id", id);


                    await cmd.ExecuteNonQueryAsync();

                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateDepartment(Department department)
        {
            try {
                string query = "update Afdelinger set afdeling = @afdeling, parent_Afdeling = @parentAfdeling where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
    
                    cmd.Parameters.AddWithValue("@afdeling", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@parentAfdeling",  department.Parent_DepartmentID);
                    cmd.Parameters.AddWithValue("@id", department.Id);


                    await cmd.ExecuteNonQueryAsync();

                }

            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Shop>> GetAllShops()
        {
            try
            {
                List<Shop> shops = new List<Shop>();
                string query = "select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if(reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                ZipCode zipCode = new ZipCode(reader.GetInt32(4), reader.GetString(5));
                                Addresses addresses = new Addresses(reader.GetInt32(1), zipCode, reader.GetString(2), reader.GetString(3));
                                shops.Add(new Shop(reader.GetInt32(0), addresses));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllShops Null row returned");

                    }
                }
                    return shops;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteShop(int id)
        {
            try {
                string query = "delete from Butikker  where id = @id;";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();

                }

            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateShop(Shop shop)
        {
            try {

                string query = "update Butikker set adresseID = @addressID where id = @id;";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@addressID",shop.AddressID);
                    cmd.Parameters.AddWithValue("@id",shop.Id);

                    await cmd.ExecuteNonQueryAsync();

                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Shop_Item>> GetAllShopWarehouses()
        {
            try
            {
                List<Shop_Item> shops_Warehouses = new List<Shop_Item>();
                string query = "select  p.id,p.produktNavn,p.beskrivelse,p.pris,k.id,k.navn,k2.id,k2.navn,pc.id,pc.producentNavn,lv.id,lv.leverandorNavn,lv.kontaktPerson,lv.email,lv.telefon,b.id,adr.id,psn.id,psn.byNavn,adr.adresse,adr.etage,lg.id,lg.status,bhv.antal from Butikker_har_Vare as bhv " +
                  "inner join Produkter p on p.id = bhv.produktID " +
                  "inner join Kategorier k on k.id = p.kategoriID " +
                  "left join Kategorier k2 on k2.id = k.parent_KategoriID " +
                  "inner join Producent pc on pc.id = p.producentID " +
                  "inner join Leverandor lv on lv.id = p.leverandorID " +
                  "inner join Butikker b on b.id = bhv.butikID " +
                  "inner join Adresser adr on adr.id = b.adresseID " +
                  "inner join PostNr psn on psn.id = adr.postnrID " +
                  "inner join Lager_Status lg on lg.id = bhv.statusID";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                Supplier supplier = new Supplier(reader.GetInt32(10), reader.GetString(11), reader.GetString(14), reader.GetString(12), reader.GetString(13));
                                Producent producent = new Producent(reader.GetInt32(8), reader.GetString(9));
                                Category category;
                                if (reader[6] == null)
                                {
                                    category = new Category(reader.GetInt32(4), reader.GetString(5));
                                }
                                else
                                {
                                    Category parent_cat = new Category(reader.GetInt32(6), reader.GetString(7));
                                    category = new Category(reader.GetInt32(4), reader.GetString(5), parent_cat);
                                }

                                Product product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), category, producent, supplier);
                                ZipCode zipCode = new ZipCode(reader.GetInt32(17), reader.GetString(18));
                                Addresses addresses = new Addresses(reader.GetInt32(16), zipCode, reader.GetString(19), reader.GetString(20));
                                Shop shop = new Shop(reader.GetInt32(15), addresses);
                                Warehouse_Status warehouse_Status = new Warehouse_Status(reader.GetInt32(21), reader.GetString(22));
                                shops_Warehouses.Add(new Shop_Item(product, shop, warehouse_Status, reader.GetInt32(23)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllShopWarehouses Null row returned");

                    }
                }
                    return shops_Warehouses;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteShopWarehouse(Shop_Item shop)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateShopWarehouse(Shop_Item shopWarehouse)
        {
            try {

            
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();
                string query = "select a.id,a.navn,a.parent_KategoriID,b.navn,b.parent_KategoriID from Kategorier as a left join Kategorier as b on b.id = a.parent_KategoriID";
                using (SqlCommand cmd = new SqlCommand(query,dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                if (DBNull.Value.Equals(reader[2]))
                                {
                                    categories.Add(new Category(reader.GetInt32(0), reader.GetString(1), null));

                                }
                                else
                                {
                                    Category category = new Category(reader.GetInt32(2), reader.GetString(3), null);
                                    categories.Add(new Category(reader.GetInt32(0), reader.GetString(1), category));

                                }
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllCategories Null row returned");

                    }
                }
                    return categories;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteCategory(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateCategory(Category category)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                
       
                       string query = "select Kunder.id,fornavn,efternavn,email,telefon,dateOfBirth, password,Roller.rolle from kunder inner join Roller on Roller.id = rolleID";
                using (SqlCommand cmd = new SqlCommand(query,dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                
                                List<Customer_Addresses> customer_Addresses = await GetCustomerAddressesByCustomerID(reader.GetInt32(0));
 
                                Customer customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(5),reader.GetString(6),reader.GetString(7), reader.GetString(4));
                                customer.customer_Addresses = customer_Addresses;
                                customers.Add(customer);

                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllCustomers Null row returned");


                    }
                }

                return customers;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Customer>> GetAllCustomers(CustomerParameters customerParameters)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerParameters.searchQuery))
                {
                    return await GetAllCustomers();
                }
                List<Customer> customers = new List<Customer>();
                customerParameters.searchQuery = customerParameters.searchQuery.Trim();
                string query = "select id,fornavn,efternavn,email,telefon,dateOfBirth, password from Kunder where email like @search";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@search", $"%{customerParameters.searchQuery}%@%");
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                List<Customer_Addresses> customer_Addresses1 = await GetCustomerAddressesByCustomerID(reader.GetInt32(0));

                                Customer customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(5),reader.GetString(6), reader.GetString(4));
                                customer.customer_Addresses = customer_Addresses1;
                                customers.Add(customer);

                            }
                        }

                    }
                }
                
                //customers = customers.FindAll(d => d.Email.Contains(email));
                return customers;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task DeleteCustomer(int id)
        {
            try {

                string query = "DELETE FROM Kunder WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }


            } catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task DeleteCustomerData(int id)
        {
            try
            {
                Customer customer = new Customer(id, "[Slettet]", "[Slettet]", "[Slettet]", Convert.ToDateTime("1773-01-01"), "[Slettet]", "[Slettet]");
                await UpdateCustomer(customer);

            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task UpdateCustomer(Customer customer)
        {
            try {

                string query = "Update Kunder set fornavn = @fornavn, efternavn = @efternavn, email = @email, telefon = @telefon, dateOfBirth = @dateOfBirth, password = @password where id = @id";
                using(SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@fornavn",customer.FirstName);
                    cmd.Parameters.AddWithValue("@efternavn",customer.LastName);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@telefon", customer.Phone);
                    cmd.Parameters.AddWithValue("@dateOfBirth",customer.DateOfBirth);
                    cmd.Parameters.AddWithValue("@password",customer.Password);
                    cmd.Parameters.AddWithValue("@id", customer.Id);
                    await cmd.ExecuteNonQueryAsync();
                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Customer_Addresses>> GetAllCustomerAddresses()
        {
            try
            {
                List<Customer_Addresses> customer_Addresses = new List<Customer_Addresses>();
                string query = "select adresseID,kundeID,adresseType from Kunder_har_Adresser";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {
                                Addresses addresses = await GetAddressById(reader.GetInt32(0));
                                Customer customer = await GetCustomerById(reader.GetInt32(1));
                                Address_Type address_Type = await GetAdresseTypeById(reader.GetInt32(2));

                                customer_Addresses.Add(new Customer_Addresses(addresses, customer, address_Type));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllCustomerAddresses Null rows returned");
                    }
                }
                    return customer_Addresses;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }


        public async Task DeleteCustomerAddresses(Customer_Addresses customer_Addresses)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateCustomerAddresses(Customer_Addresses customer_Addresses)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Warehouse_Status>> GetAllWarehouseStatus()
        {
            try
            {
                List<Warehouse_Status> warehouse_Statuses = new List<Warehouse_Status>();
                string query = "select id,status from Lager_Status";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                warehouse_Statuses.Add(new Warehouse_Status(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllWarehouseStatus Null row returned");

                    }
                }
                    return warehouse_Statuses;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteWarehouseStatus(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateWarehouseStatus(Warehouse_Status warehouse_Status)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                List<Supplier> suppliers = new List<Supplier>();
                string query = "select id,leverandorNavn,kontaktPerson,email,telefon from Leverandor";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {

                            while (await reader.ReadAsync())
                            {
                                suppliers.Add(new Supplier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllSuppliers Null row returned");
                    }
                }
                    return suppliers;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteSupplier(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                string query = "select id,fornavn,efternavn,kontonr,reg,email,telefon,adresseID,afdelingID,butikID,dateOfBirth from Medarbejder";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {
                                Addresses addresses = await GetAddressById(reader.GetInt32(7));
                                Department department = await GetDepartmentById(reader.GetInt32(8));
                                Shop shop = await GetShopById(reader.GetInt32(9));
                                employees.Add(new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(6),reader.GetDateTime(10),addresses,department,shop, reader.GetString(5)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllEmployees Null rows returned");
                    }
                }
                    return employees;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteEmployee(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                List<Order> orders = new List<Order>();
                string query = "select id,opretsDato,kundeID,leveringsMetodeID,leveringsAdresseID,statusID from Ordre";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {
                                Customer customer = await GetCustomerById(reader.GetInt32(2));
                                Order_Delivery_Method order_Delivery_Method = await GetOrderDeliveryMethodById(reader.GetInt32(3));
                                Addresses addresses = await GetAddressById(reader.GetInt32(4));
                                Order_Status order_Status = await GetOrder_StatusById(reader.GetInt32(4));
                                orders.Add(new Order(reader.GetInt32(0), reader.GetDateTime(1), customer, order_Delivery_Method, addresses, order_Status));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllOrders Null rows returned");
                    }
                }
                    return orders;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteOrder(int id)
        {
            try {
                

                string query = "DELETE FROM Ordre WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateOrder(Order order)
        {
            try {
                string query = "update  Ordre set leveringsAdresseID = @leveringsAdresseID, leveringsMetodeID = @leveringsMetodeID, opretsDato = @opretsDato, statusID = @statusID where id = @id";
                using (SqlCommand cmd = new SqlCommand(query,dbConn))
                {
                    cmd.Parameters.AddWithValue("@leveringsAdresseID",order.DeliveryAddressID);
                    cmd.Parameters.AddWithValue("@leveringsMetodeID",order.DeliveryMethodID);
                    cmd.Parameters.AddWithValue("@opretsDato",order.Created);
                    cmd.Parameters.AddWithValue("@statusID",order.StatusID);
                    cmd.Parameters.AddWithValue("@id", order.Id);


                    await cmd.ExecuteNonQueryAsync();

                }
            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Order_Delivery_Method>> GetAllOrderDeliveryMethod()
        {
            try
            {
                List<Order_Delivery_Method> order_Delivery_Methods = new List<Order_Delivery_Method>();
                string query = "select id,metodeNavn,pris from Ordre_Leverings_Metode";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {

                                order_Delivery_Methods.Add(new Order_Delivery_Method(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllOrderDeliveryMethod Null rows returned");
                    }
                }
                    return order_Delivery_Methods;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }



        public async Task DeleteOrderDeliveryMethod(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Order_Status>> GetAllOrder_Status()
        {
            try
            {
                List<Order_Status> order_Statuses = new List<Order_Status>();
                string query = "select id,status from Ordre_Status";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {
                                order_Statuses.Add(new Order_Status(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllOrder_Status Null rows returned");
                    }
                }
                    return order_Statuses;

            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteOrder_Status(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateOrder_Status(Order_Status order_Status)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<OrderLine>> GetAllOrderLines()
        {
            try
            {
                List<OrderLine> orderLines = new List<OrderLine>();
                string query = "select produktID,ordreID,antal,pris from Ordrelinjer";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {

                                Product product = await GetProductById(reader.GetInt32(0));
                                Order order = await GetOrderById(reader.GetInt32(1));
                                orderLines.Add(new OrderLine(product,order,reader.GetInt32(2),reader.GetDecimal(3)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllOrderLines Null rows returned");
                    }
                }
                    return orderLines;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }



        public async Task DeleteOrderLines(OrderLine orderLines)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateOrderLines(OrderLine orderLines)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<ZipCode>> GetAllZipCode()
        {
            try
            {
                List<ZipCode> zipCodes = new List<ZipCode>();
                string query = "select id,byNavn from PostNr";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {
                                zipCodes.Add(new ZipCode(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllZipCode Null rows returned");
                    }
                }
                return zipCodes;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }



        public async Task DeleteZipCode(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateZipCode(ZipCode zipCode)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }


        public async Task<List<Producent>> GetAllProducent()
        {
            try
            {
                List<Producent> producents = new List<Producent>();
                string query = "select id,producentNavn from Producent";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while(await reader.ReadAsync())
                            {
                                producents.Add(new Producent(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllProducent Null rows returned");
                    }
                }
                return producents;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task DeleteProducent(int id)
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateProducent(Producent producent)
        {
            try {  } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<List<Product>> GetAllProducts(ProductsParameter productsParameter)
        {
            if (string.IsNullOrWhiteSpace(productsParameter.Category))
            {
                return await GetAllProducts();

            }
            try
            {
                List<Product> products = new List<Product>();
                string query = "select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where kategoriID = @kategoriID";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@kategoriID", productsParameter.Category);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {

                            while (await reader.ReadAsync())
                            {
                                Category category = await GetCategoryById(reader.GetInt32(4));
                                Producent producent = await GetProducentById(reader.GetInt32(5));
                                Supplier supplier = await GetSupplierById(reader.GetInt32(6));
                                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), category, producent, supplier));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllProducts Null rows returned");

                    }
                }
                return products;
            }
            catch (Exception e) { throw new Exception(e.Message); }

        }
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = "select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter";
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {

                            while (await reader.ReadAsync())
                            {
                                Category category = await GetCategoryById(reader.GetInt32(4));
                                Producent producent = await GetProducentById(reader.GetInt32(5));
                                Supplier supplier = await GetSupplierById(reader.GetInt32(6));
                                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), category, producent, supplier));
                            }
                        }
                        else
                            throw new ArgumentNullException("GetAllProducts Null rows returned");

                    }
                }
                    return products;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        public async Task<List<Product>> GetProductsByProducentId(int id)
        {
            try { 
                string query = "select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where producentID = @producentID";
                List<Product> products = new List<Product>();
                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@producentID", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    { 
                        if (reader.HasRows)
                        {


                            while (await reader.ReadAsync())
                            {
                                Category category = await GetCategoryById(reader.GetInt32(4));
                                Producent producent = await GetProducentById(reader.GetInt32(5));
                                Supplier supplier = await GetSupplierById(reader.GetInt32(6));
                                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), category, producent, supplier));
                            }
                        }
                    }
                }
                return products;
            
            } catch (Exception e) { throw new Exception(e.Message); }


        }
        public async Task DeleteProduct(int id)
        {
            try {
                string query = "delete from Produkter where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }


            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task UpdateProduct(Product product)
        {
            try {
                string query = "update Produkter set produktNavn = @produktNavn, beskrivelse = @beskrivelse, pris = @pris, kategoriID = @kategoriID, producentID = @producentID, leverandorID = @leverandorID where id = @id";

                using (SqlCommand cmd = new SqlCommand(query, dbConn))
                {
                    cmd.Parameters.AddWithValue("@produktNavn",product.ProductName);
                    cmd.Parameters.AddWithValue("@beskrivelse",product.Description);
                    cmd.Parameters.AddWithValue("@pris",product.Price);
                    cmd.Parameters.AddWithValue("@kategoriID",product.CategoryID);
                    cmd.Parameters.AddWithValue("@producentID",product.ProducentID);
                    cmd.Parameters.AddWithValue("@leverandorID",product.SupplierID);
                    cmd.Parameters.AddWithValue("@id", product.Id);


                    await cmd.ExecuteNonQueryAsync();

                }


            } catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task CloseConn()
        {
            try
            {
                if (dbConn.State == System.Data.ConnectionState.Open)
                {
                    await dbConn.CloseAsync();
                }
            }
            catch (Exception)
            {

                throw new Exception("Couldn't close database connection");
            }

        }
        public void OpenConn()
        {
            try
            {
                if (dbConn.State == System.Data.ConnectionState.Closed)
                {
                    dbConn.Open();
                }
            }
            catch (Exception)
            {

                throw new Exception("Couldn't open database connection");
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
