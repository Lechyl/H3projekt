using ORM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace ORM.Services
{
    public class ORM_MSSQL : IORM, IDisposable
    {
        private readonly SqlConnection dbConn;
        public List<Exception> ExceptionLogging { get; set; }
        public ORM_MSSQL(string host, string user, string password, string database)
        {
            ExceptionLogging = new List<Exception>();
            //Define connection string to db
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = database,
                UserID = user,
                Password = password,
                DataSource = host
            };

            //Create connection string to database
            dbConn = new SqlConnection(conString.ToString());
        }

        public void CreateAddress(Addresses address)
        {
            try
            {
                string query = "insert into Addressesr(postnrID,adresse,etage) values (@postnrId,@adresse@,etage)";

                SqlCommand cmd = new SqlCommand(query, dbConn);

                OpenConn();
                cmd.Parameters.AddWithValue("@postnrId", address.ZipCode.Id);
                cmd.Parameters.AddWithValue("@adresse", address.Address);
                cmd.Parameters.AddWithValue("@etage", address.Floor);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateAdresseType(Address_Type adresse_Type)
        {

            try
            {
                string query = "insert into Adresse_Type(type) values (@type)";

                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();

                cmd.Parameters.AddWithValue("@type", adresse_Type.Type);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateDepartment(Department department)
        {
            try
            {

                string query = "insert into Afdelinger(afdeling,parent_Afdeling) values (@afdeling,@parent_Afdeling)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn(); 
                cmd.Parameters.AddWithValue("@afdeling", department.DepartmentName);
                cmd.Parameters.AddWithValue("@parent_Afdeling", (object)department.Parent_Department.Id ?? DBNull.Value);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateShop(Shop shop)
        {
            try
            {
                string query = "insert into Butikker(adresseID) values (@adresseID)";

                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@adresseID", shop.Address.Id);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateShopWarehouse(Shops_Warehouse shopWarehouse)
        {
            try
            {
                string query = "insert into Butikker_har_Vare(produktID,butikID,statusID,antal) values (@produktID,@butikID,@statusID,@antal)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@produktID", shopWarehouse.Product.Id);
                cmd.ExecuteNonQuery();

                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }        
        }

        public void CreateCategory(Category category)
        {
            try
            {
                string query = "insert into Kategorier(navn, parent_KategoriID) values (@navn, @parent_KategoriID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@navn", category.Name);
                cmd.Parameters.AddWithValue("@parent_KategoriID", (object)category.Parent_Category.Id ?? DBNull.Value);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateCustomer(Customer customer)
        {

            try
            {
                string query = "insert into Kunder(fornavn,efternavn,email,telefon) values(@fornavn,@efternavn,@email,@telefon)";

                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@fornavn", customer.FirstName);
                cmd.Parameters.AddWithValue("@efternavn", customer.LastName);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@telefon", customer.Phone);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateCustomerAddresses(Customer_Addresses customer_Addresses)
        {
            try
            {
                string query = "insert into Kunder_har_Adresser(adresseID,kundeID,adresseType) values (@adresseID,@kundeID,@adresseType)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@adresseID", customer_Addresses.Address.Id);
                cmd.Parameters.AddWithValue("@kundeID", customer_Addresses.Customer.Id);
                cmd.Parameters.AddWithValue("@adresseType", customer_Addresses.AdresseType.Id);

                cmd.ExecuteNonQuery();
                CloseConn();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateWarehouseStatus(Warehouse_Status warehouse_Status)
        {
            try
            {
                string query = "insert into Lager_Status(status) values (@status)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@status", warehouse_Status.Status);
                cmd.ExecuteNonQuery();
                CloseConn();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateSupplier(Supplier supplier)
        {
            try
            {
                string query = "insert into Leverandor(leverandorNavn,kontaktPerson,email,telefon) values (@leverandorNavn,@kontaktPerson,@email,@telefon)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@leverandorNavn", supplier.SupplierName);
                cmd.Parameters.AddWithValue("@kontaktPerson", supplier.ContactPerson);
                cmd.Parameters.AddWithValue("@email", supplier.Email);
                cmd.Parameters.AddWithValue("@telefon", supplier.Phone);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateEmployee(Employee employee)
        {
            try
            {
                string query = "insert into Medarbejder(fornavn,efternavn,email,telefon,kontonr,reg,adresseID,afdelingID,butikID) values (@fornavn,@efternavn,@email,@telefon,@kontonr,@reg,@adresseID,@afdelingID,@butikID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@fornavn", employee.FirstName);
                cmd.Parameters.AddWithValue("@efternavn", employee.LastName);
                cmd.Parameters.AddWithValue("@email", employee.Email);
                cmd.Parameters.AddWithValue("@telefon", employee.Phone);
                cmd.Parameters.AddWithValue("@kontonr", employee.AccountNr);
                cmd.Parameters.AddWithValue("@reg", employee.Reg);
                cmd.Parameters.AddWithValue("@adresseID", employee.Address.Id);
                cmd.Parameters.AddWithValue("@afdelingID", employee.Departments.Id);
                cmd.Parameters.AddWithValue("@butikID", employee.Shop.Id);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateOrder(Order order)
        {
            try
            {
                string query = "insert into Ordre(kundeID,leveringsMetodeID,leveringsAdresseID,statusID) values (@kundeID,@leveringsMetodeID,@leveringsAdresseID,@statusID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@kundeID", order.Customer.Id);
                cmd.Parameters.AddWithValue("@leveringsMetodeID", order.DeliveryMethod.Id);
                cmd.Parameters.AddWithValue("@leveringsAdresseID", order.DeliveryAddress.Id);
                cmd.Parameters.AddWithValue("@statusID", order.Status.Id);
                cmd.ExecuteNonQuery();
                CloseConn();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }        
        }

        public void CreateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method)
        {
            try
            {
                string query = "insert into Ordre_Leverings_Metode(metodeNavn,pris) values (@metodeNavn,@pris)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@metodeNavn", order_Delivery_Method.MethodName);
                cmd.Parameters.AddWithValue("@pris", order_Delivery_Method.Price);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateOrderLines(OrderLine orderLines)
        {
            try
            {
                string query = "insert into Ordrelinjer(ordreID,produktID,antal,pris) values (@ordreID,@produktID,@antal,@pris)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@ordreID", orderLines.Order.Id);
                cmd.Parameters.AddWithValue("@produktID", orderLines.Product.Id);
                cmd.Parameters.AddWithValue("@antal", orderLines.Quantity);
                cmd.Parameters.AddWithValue("@pris", orderLines.Price);
                cmd.ExecuteNonQuery();
                CloseConn();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateOrder_Status(Order_Status Order_Status)
        {
            try
            {
                string query = "insert into Ordre_Status(status) values (@status)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@status", Order_Status.Status);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateZipCode(ZipCode zipCode)
        {
            try
            {
                string query = "insert into PostNr(byNavn) values (@byNavn)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@byNavn", zipCode.CityName);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateProducent(Producent producent)
        {
            try
            {
                string query = "insert into Producent(producentNavn) values (@producentNavn)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@producentNavn", producent.ProducentName);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {
                
                ExceptionLogging.Add(e);

                //throw new Exception(e.Message);
            }
        }

        public void CreateProduct(Product product)
        {
            try
            {
                string query = "insert into Produkter(produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID) values (@produktNavn,@beskrivelse,@pris,@kategoriID,@producentID,@leverandorID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@produktNavn", product.ProductName);
                cmd.Parameters.AddWithValue("@beskrivelse", product.Description);
                cmd.Parameters.AddWithValue("@pris", product.Price);
                cmd.Parameters.AddWithValue("@kategoriID", product.Category.Id);
                cmd.Parameters.AddWithValue("@producentID", product.Producent.Id);
                cmd.Parameters.AddWithValue("@leverandorID", product.Supplier.Id);
                cmd.ExecuteNonQuery();
                CloseConn();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public Addresses GetAddressById(int id)
        {
            try
            {
                Addresses adresse = null;
                string query = "select Adresser.id,adresse,etage,pn.id,pn.byNavn from Adresser inner join PostNr as pn on pn.id = postnrID where Adresser.id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;

                    while (reader.Read())
                    {
                        ZipCode postNr = new ZipCode((int)reader[3], (string)reader[4]);



                        adresse = new Addresses((int)reader[0], postNr,(string)reader[2], (string)reader[3]);
                    count++;

                        
                    }
                
                //  CloseConn();
                if (count != 1) { throw new IndexOutOfRangeException("Address unspecified error"); }

                reader.Close();
                return adresse;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Address_Type GetAdresseTypeById(int id)
        {
            try
            {
                Address_Type adresse_Type = null;
                string query = "select id,type from Adresse_Type where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id",id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;

                    while (reader.Read())
                    {
                        adresse_Type = new Address_Type((int)reader[0],(string)reader[1]);
                    count++;
                    }
                
                //CloseConn();
                if (count != 1) { throw new IndexOutOfRangeException("Address Type unspecified error"); }

                reader.Close();
                return adresse_Type;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public Department GetDepartmentById(int id)
        {
            try
            {
                Department afdelinger = null;
                string query = "select a1.id,a1.afdeling,a2.id,a2.afdeling from Afdelinger as a1 left join Afdelinger a2 on a2.id = a1.parent_Afdeling where a1.id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                    while (reader.Read())
                    {
                        if(reader[2] == null)
                        {
                            afdelinger = new Department((int)reader[0], (string)reader[1]);
                        }
                        else
                        {
                            Department parent_Afdeling = new Department((int)reader[2], (string)reader[3]);

                            afdelinger = new Department((int)reader[0], (string)reader[1],parent_Afdeling);
                        }
                    count++;
                        
                    }
                if (count != 1) { throw new IndexOutOfRangeException("Department unspecified error"); }

                reader.Close();
                return afdelinger;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }


        public Shop GetShopById(int id)
        {
             
            try
            {
                Shop butik = null;
                string query = "select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID where b.id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    ZipCode postNr = new ZipCode((int)reader[4], (string)reader[5]);
                    Addresses adresser = new Addresses((int)reader[1], postNr, (string)reader[2], (string)reader[3]);
                    butik = new Shop((int)reader[0], adresser);
                    count++;
                }
                if(count != 1) { throw new IndexOutOfRangeException("Shop unspecified error"); }
                //CloseConn();
                reader.Close();
                return butik;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Shops_Warehouse> GetShopWarehouseByShop(Shop shop)
        {
            try{
                List<Shops_Warehouse> butikker_Har_Vare = new List<Shops_Warehouse>();
                string query = "select produktID,statusID,antal from Butikker_har_Vare where butikID = @butikID";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@butikID", shop.Id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                
                if (reader.HasRows) { 
                    while (reader.Read())
                    {
                        Product produkt = GetProductById(reader.GetInt32(0));
                        Warehouse_Status lager_Status = GetWarehouseStatusById(reader.GetInt32(1));

                        butikker_Har_Vare.Add(new Shops_Warehouse(produkt, shop, lager_Status, reader.GetInt32(2)));
                        
                    }
                }
                else
                {
                    throw new ArithmeticException("No row returned");
                }
                //CloseConn();
                reader.Close();

                return butikker_Har_Vare;

            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public Category GetCategoryById(int id)
        {

            try{
                Category kategorier = null;
                string query = "select k1.id,k1.navn,k2.id,k2.navn from Kategorier as k1 left join Kategorier k2 on k1.parent_KategoriID = k2.id where k1.id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                int count = 0;
                while (reader.Read())
                {
                    if(reader[2] == null)
                    {
                        kategorier = new Category(reader.GetInt32(0), reader.GetString(1));
                    }
                    else
                    {
                        Category parent_Kategori = new Category(reader.GetInt32(2), reader.GetString(3));
                        kategorier = new Category((int)reader[0],(string)reader[1],parent_Kategori);
                    }
                   
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Category unspecified error"); }
                //CloseConn();
                reader.Close();
                return kategorier;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Customer GetCustomerById(int id)
        {
           // try{
                Customer kunder = null;
                string query = "select id,fornavn,efternavn,email,telefon from kunder where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                int count = 0;
                while (reader.Read())
                {
                    kunder = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Customer unspecified error!"); }
                //CloseConn();
                reader.Close();
                return kunder;
           // }catch (Exception){ throw; }

        }

        public List<Customer_Addresses> GetCustomerAddressesByCustomer(Customer customer)
        {
            try{
                List<Customer_Addresses> kunder_Har_Adressers = new List<Customer_Addresses>();
                string query = "select adresseID,kundeID,adresseType from Kunder_har_Adresser where kundeID = @kundeId";

                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@kundeId", customer.Id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.HasRows)
                { 
                    while (reader.Read())
                    {
                        Addresses adresser = GetAddressById(reader.GetInt32(0));
                        Address_Type adresse_Type = GetAdresseTypeById(reader.GetInt32(2));

                        kunder_Har_Adressers.Add(new Customer_Addresses(adresser, customer, adresse_Type));
                    
                    }
                }
                else
                {
                    throw new ArgumentNullException("Returned 0 Rows");
                }
                //CloseConn();
                reader.Close();
                return kunder_Har_Adressers;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Warehouse_Status GetWarehouseStatusById(int id)
        {
            try{
                Warehouse_Status lager_Status = null;
                string query = "select id,status from Lager_Status where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                int count = 0;
                while (reader.Read())
                {
                    lager_Status = new Warehouse_Status(reader.GetInt32(0), reader.GetString(0));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Warehouse Status unspecified error"); }
                //CloseConn();
                reader.Close();
                return lager_Status;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Supplier GetSupplierById(int id)
        {
            try{
                Supplier leverandor = null;
                string query = "select id,leverandorNavn,kontaktPerson,email,telefon from Leverandor where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                int count = 0;
                while (reader.Read())
                {

                    leverandor = new Supplier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Supplier unspecified error"); }
                //CloseConn();
                reader.Close();

                return leverandor;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Employee GetEmployeeById(int id)
        {
            try{
                Employee medarbejder = null;
                string query = "select id,fornavn,efternavn,kontonr,reg,email,telefon,adresseID,afdelingID,butikID from Medarbejder where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    Addresses adresse = GetAddressById(reader.GetInt32(7));
                    Department afdeling = GetDepartmentById(reader.GetInt32(8));
                    Shop butik = GetShopById(reader.GetInt32(9));

                    medarbejder = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(6), adresse, afdeling, butik, reader.GetString(5));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Worker unspecified error"); }
                //CloseConn();
                reader.Close();


                return medarbejder;
            }catch (Exception e){throw new Exception(e.Message);}
        }



        public Order_Status GetOrder_StatusById(int id)
        {
            try{
                Order_Status ordre_Status = null;
                string query = "select id,status from Ordre_Status where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    ordre_Status = new Order_Status(reader.GetInt32(0), reader.GetString(1));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Order Status unspecified error"); }
                //CloseConn();
                reader.Close();
                return ordre_Status;
            }catch (Exception e){throw new Exception(e.Message);}
        }


        public Producent GetProducentById(int id)
        {
            try{
                Producent producent = null;
                string query = "select id,producentNavn from Producent where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    producent = new Producent(reader.GetInt32(0), reader.GetString(1));

                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Producent unspecified error"); }
                //CloseConn();
                reader.Close();
                return producent;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Product GetProductById(int id)
        {
            try{
                Product produkter = null;
                string query = "select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    Category kategori = GetCategoryById(reader.GetInt32(4));
                    Producent producent = GetProducentById(reader.GetInt32(5));
                    Supplier leverandor = GetSupplierById(reader.GetInt32(6));

                    produkter = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), kategori, producent, leverandor);

                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Product unspecified error"); }
                //CloseConn();
                reader.Close();
                return produkter;
            }catch (Exception e){throw new Exception(e.Message);}
        }
        public Order_Delivery_Method GetOrderDeliveryMethodById(int id)
        {
            try{
                Order_Delivery_Method order_Delivery_Method = null;
                string query = "select id,metodeNavn,pris from Ordre_Leverings_Metode where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    order_Delivery_Method = new Order_Delivery_Method(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Order Delivery Method unspecified error"); }
                //CloseConn();
                reader.Close();

                return order_Delivery_Method;
            }catch (Exception e){throw new Exception(e.Message);}
            
        }
        public Order GetOrderById(int id)
        {
            try{
                Order order = null;
                string query = "select id,opretsDato,kundeID,leveringsMetodeID,leveringsAdresseID,statusID from Ordre where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    Customer customer = GetCustomerById(reader.GetInt32(2));
                    Order_Delivery_Method order_Delivery_Method = GetOrderDeliveryMethodById(reader.GetInt32(3));
                    Addresses address = GetAddressById(reader.GetInt32(4));
                    Order_Status order_Status = GetOrder_StatusById(reader.GetInt32(5));
                    order = new Order(reader.GetInt32(0), reader.GetDateTime(1),customer,order_Delivery_Method,address,order_Status);
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Order unspecified error"); }
                //CloseConn();
                reader.Close();
                return order;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }


        public ZipCode GetZipCodeById(int id)
        {
            try{
                ZipCode zipCode = null;
                string query = "select id,byNavn from PostNr where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    zipCode = new ZipCode(reader.GetInt32(0), reader.GetString(1));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("ZipCOde unspecified error"); }
                //CloseConn();
                reader.Close();
                return zipCode;

            }
            catch (Exception e){throw new Exception(e.Message);}
        }


        public List<OrderLine> GetOrderLinesByOrder(Order order)
        {
            try{
                List<OrderLine> orderLines = new List<OrderLine>();

                string query = "select produktID,ordreID,antal,pris from Ordrelinjer where ordreID = @orderID";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@orderID", order.Id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    Product product = GetProductById(reader.GetInt32(0));
                    orderLines.Add(new OrderLine(product,order,reader.GetInt32(2),reader.GetDecimal(3)));
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Order Lines unspecified error"); }
                //CloseConn();
                reader.Close();

                return orderLines;
            }catch (Exception e){throw new Exception(e.Message);}
        }
        public List<Address_Type> GetAllAdresseTypes()
        {
            try{
                List<Address_Type> address_Types = new List<Address_Type>();

                return address_Types;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteAdresseType(Address_Type adresse_Type)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateAdresseType(Address_Type adresse_Type)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Addresses> GetAllAdresses()
        {
            try{
                List<Addresses> addresses = new List<Addresses>();

                return addresses;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteAddress(Addresses address)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateAddress(Addresses address)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Department> GetAllDepartments()
        {
            try{
                List<Department> departments = new List<Department>();

                return departments;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteDepartment(Department department)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateDepartment(Department department)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Shop> GetAllShops()
        {
            try{
                List<Shop> shops = new List<Shop>();

                return shops;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteShop(Shop shop)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateShop(Shop shop)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Shops_Warehouse> GetAllShopWarehouses()
        {
            try
            {
                List<Shops_Warehouse> shops_Warehouses = new List<Shops_Warehouse>();

                return shops_Warehouses;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteShopWarehouse(Shops_Warehouse shopWarehouse)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateShopWarehouse(Shops_Warehouse shopWarehouse)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Category> GetAllCategories()
        {
            try{
                List<Category> categories = new List<Category>();

                return categories;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteCategory(Category category)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateCategory(Category category)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Customer> GetAllCustomers()
        {
            try{
                List<Customer> customers = new List<Customer>();

                return customers;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteCustomer(Customer customer)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateCustomer(Customer customer)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Customer_Addresses> GetAllCustomerAddresses()
        {
            try{
                List<Customer_Addresses> customer_Addresses = new List<Customer_Addresses>();
                return customer_Addresses;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }


        public void DeleteCustomerAddresses(Customer_Addresses customer_Addresses)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateCustomerAddresses(Customer_Addresses customer_Addresses)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Warehouse_Status> GetAllWarehouseStatus()
        {
            try{
                List<Warehouse_Status> warehouse_Statuses = new List<Warehouse_Status>();

                return warehouse_Statuses;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteWarehouseStatus(Warehouse_Status warehouse_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateWarehouseStatus(Warehouse_Status warehouse_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Supplier> GetAllSuppliers()
        {
            try{
                List<Supplier> suppliers = new List<Supplier>();

                return suppliers;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteSupplier(Supplier supplier)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateSupplier(Supplier supplier)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Employee> GetAllEmployees()
        {
            try{
                List<Employee> employees = new List<Employee>();

                return employees;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteEmployee(Employee employee)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateEmployee(Employee employee)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Order> GetAllOrders()
        {
            try{
                List<Order> orders = new List<Order>();

                return orders;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteOrder(Order order)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrder(Order order)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Order_Delivery_Method> GetAllOrderDeliveryMethod()
        {
            try{
                List<Order_Delivery_Method> order_Delivery_Methods = new List<Order_Delivery_Method>();

                return order_Delivery_Methods;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }



        public void DeleteOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrderDeliveryMethod(Order_Delivery_Method order_Delivery_Method)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Order_Status> GetAllOrder_Status()
        {
            try{
                List<Order_Status> order_Statuses = new List<Order_Status>();

                return order_Statuses;

            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteOrder_Status(Order_Status Order_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrder_Status(Order_Status Order_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<OrderLine> GetAllOrderLines()
        {
            try{
                List<OrderLine> orderLines = new List<OrderLine>();

                return orderLines;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }



        public void DeleteOrderLines(OrderLine orderLines)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrderLines(OrderLine orderLines)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<ZipCode> GetAllZipCode()
        {
            try{
                List<ZipCode> zipCodes = new List<ZipCode>();

                return zipCodes;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }



        public void DeleteZipCode(ZipCode zipCode)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateZipCode(ZipCode zipCode)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Producent> GetAllProducent()
        {
            try{
                List<Producent> producents = new List<Producent>();

                return producents;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteProducent(Producent producent)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateProducent(Producent producent)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Product> GetAllProducts()
        {
            try{
                List<Product> products = new List<Product>();

                return products;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteProduct(Product product)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateProduct(Product product)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        private void CloseConn()
        {
            try
            {
                if (dbConn.State == System.Data.ConnectionState.Open)
                {
                    dbConn.Close();
                }
            }
            catch (Exception)
            {

                throw new Exception("Couldn't close database connection");
            }

        }
        private void OpenConn()
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
