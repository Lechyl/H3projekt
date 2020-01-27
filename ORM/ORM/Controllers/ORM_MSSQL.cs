using ORM.Interface;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM
{
    public class ORM_MSSQL : IORM
    {
        private readonly SqlConnection dbConn;
        
        public ORM_MSSQL(string host, string user, string password, string database)
        {
            
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

        public void CreateAdresse(Adresser adresse)
        {
            try
            {
                string query = "insert into Adresser(postnrID,adresse,etage) values (@postnrId,@adresse@,etage)";

                SqlCommand cmd = new SqlCommand(query, dbConn);

                OpenConn();
                cmd.Parameters.AddWithValue("@postnrId", adresse.PostNr.Id);
                cmd.Parameters.AddWithValue("@adresse", adresse.Adresse);
                cmd.Parameters.AddWithValue("@etage", adresse.Etage);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateAdresseType(Adresse_Type adresse_Type)
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

        public void CreateAfdelinger(Afdelinger afdeling)
        {
            try
            {

                string query = "insert into Afdelinger(afdeling,parent_Afdeling) values (@afdeling,@parent_Afdeling)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn(); 
                cmd.Parameters.AddWithValue("@afdeling", afdeling.Afdeling);
                cmd.Parameters.AddWithValue("@parent_Afdeling", (object)afdeling.Parent_Afdeling.Id ?? DBNull.Value);
                cmd.ExecuteNonQuery();
                CloseConn();





            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateButikker(Butikker butikker)
        {
            try
            {
                string query = "insert into Butikker(adresseID) values (@adresseID)";

                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@adresseID", butikker.Adresse.Id);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateButikkerharVare(Butikker_har_Vare butikker_har_Vare)
        {
            try
            {
                string query = "insert into Butikker_har_Vare(produktID,butikID,statusID,antal) values (@produktID,@butikID,@statusID,@antal)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@produktID",butikker_har_Vare.Produkt.Id);
                cmd.ExecuteNonQuery();

                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }        
        }

        public void CreateKategorier(Kategorier kategorier)
        {
            try
            {
                string query = "insert into Kategorier(navn, parent_KategoriID) values (@navn, @parent_KategoriID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@navn", kategorier.Navn);
                cmd.Parameters.AddWithValue("@parent_KategoriID", (object)kategorier.Parent_Kategori.Id ?? DBNull.Value);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateKunder(Kunder kunder)
        {

            try
            {
                string query = "insert into Kunder(fornavn,efternavn,email,telefon) values(@fornavn,@efternavn,@email,@telefon)";

                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@fornavn", kunder.Fornavn);
                cmd.Parameters.AddWithValue("@efternavn", kunder.Efternavn);
                cmd.Parameters.AddWithValue("@email", kunder.Email);
                cmd.Parameters.AddWithValue("@telefon", kunder.Telefon);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateKunderharAdresser(Kunder_har_Adresser kunder_har_Adresser)
        {
            try
            {
                string query = "insert into Kunder_har_Adresser(adresseID,kundeID,adresseType) values (@adresseID,@kundeID,@adresseType)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@adresseID", kunder_har_Adresser.Adresse.Id);
                cmd.Parameters.AddWithValue("@kundeID",kunder_har_Adresser.Kunde.Id);
                cmd.Parameters.AddWithValue("@adresseType",kunder_har_Adresser.AdresseType.Id);

                cmd.ExecuteNonQuery();
                CloseConn();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateLagerStatus(Lager_Status lager_Status)
        {
            try
            {
                string query = "insert into Lager_Status(status) values (@status)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@status",lager_Status.Status);
                cmd.ExecuteNonQuery();
                CloseConn();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateLeverandor(Leverandor leverandor)
        {
            try
            {
                string query = "insert into Leverandor(leverandorNavn,kontaktPerson,email,telefon) values (@leverandorNavn,@kontaktPerson,@email,@telefon)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@leverandorNavn",leverandor.LeverandorNavn);
                cmd.Parameters.AddWithValue("@kontaktPerson", leverandor.KontaktPerson);
                cmd.Parameters.AddWithValue("@email", leverandor.Email);
                cmd.Parameters.AddWithValue("@telefon", leverandor.Telefon);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateMedarbejder(Medarbejder medarbejder)
        {
            try
            {
                string query = "insert into Medarbejder(fornavn,efternavn,email,telefon,kontonr,reg,adresseID,afdelingID,butikID) values (@fornavn,@efternavn,@email,@telefon,@kontonr,@reg,@adresseID,@afdelingID,@butikID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@fornavn", medarbejder.Fornavn);
                cmd.Parameters.AddWithValue("@efternavn", medarbejder.Efternavn);
                cmd.Parameters.AddWithValue("@email", medarbejder.Email);
                cmd.Parameters.AddWithValue("@telefon", medarbejder.Telefon);
                cmd.Parameters.AddWithValue("@kontonr", medarbejder.KontoNr);
                cmd.Parameters.AddWithValue("@reg", medarbejder.Reg);
                cmd.Parameters.AddWithValue("@adresseID", medarbejder.Adresse.Id);
                cmd.Parameters.AddWithValue("@afdelingID", medarbejder.Afdeling.Id);
                cmd.Parameters.AddWithValue("@butikID", medarbejder.Butik.Id);

                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateOrdre(Ordre ordre)
        {
            try
            {
                string query = "insert into Ordre(kundeID,leveringsMetodeID,leveringsAdresseID,statusID) values (@kundeID,@leveringsMetodeID,@leveringsAdresseID,@statusID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@kundeID", ordre.Kunde.Id);
                cmd.Parameters.AddWithValue("@leveringsMetodeID",ordre.LeveringsMetode.Id);
                cmd.Parameters.AddWithValue("@leveringsAdresseID",ordre.LeveringsAdresse.Id);
                cmd.Parameters.AddWithValue("@statusID",ordre.Status.Id);
                cmd.ExecuteNonQuery();
                CloseConn();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }        
        }

        public void CreateOrdreLeveringsMetode(Ordre_Leverings_Metode ordre_Leverings_Metode)
        {
            try
            {
                string query = "insert into Ordre_Leverings_Metode(metodeNavn,pris) values (@metodeNavn,@pris)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@metodeNavn",ordre_Leverings_Metode.MetodeNavn);
                cmd.Parameters.AddWithValue("@pris",ordre_Leverings_Metode.Pris);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateOrdrelinjer(Ordrelinjer ordrelinjer)
        {
            try
            {
                string query = "insert into Ordrelinjer(ordreID,produktID,antal,pris) values (@ordreID,@produktID,@antal,@pris)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@ordreID",ordrelinjer.Ordre.Id);
                cmd.Parameters.AddWithValue("@produktID",ordrelinjer.Produkt.Id);
                cmd.Parameters.AddWithValue("@antal",ordrelinjer.Antal);
                cmd.Parameters.AddWithValue("@pris",ordrelinjer.Pris);
                cmd.ExecuteNonQuery();
                CloseConn();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateOrdre_Status(Ordre_Status ordre_Status)
        {
            try
            {
                string query = "insert into Ordre_Status(status) values (@status)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@status", ordre_Status.Status);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreatePostNr(PostNr postNr)
        {
            try
            {
                string query = "insert into PostNr(byNavn) values (@byNavn)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@byNavn", postNr.ByNavn);
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
                cmd.Parameters.AddWithValue("@producentNavn", producent.ProducentNavn);
                cmd.ExecuteNonQuery();
                CloseConn();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void CreateProdukter(Produkter produkter)
        {
            try
            {
                string query = "insert into Produkter(produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID) values (@produktNavn,@beskrivelse,@pris,@kategoriID,@producentID,@leverandorID)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@produktNavn",produkter.ProduktNavn);
                cmd.Parameters.AddWithValue("@beskrivelse",produkter.Beskrivelse);
                cmd.Parameters.AddWithValue("@pris",produkter.Pris);
                cmd.Parameters.AddWithValue("@kategoriID",produkter.Kategori.Id);
                cmd.Parameters.AddWithValue("@producentID",produkter.Producent.Id);
                cmd.Parameters.AddWithValue("@leverandorID",produkter.Leverandor.Id);
                cmd.ExecuteNonQuery();
                CloseConn();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void DeleteAdresse(Adresser adresse)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteAdresseType(Adresse_Type adresse_Type)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteAfdelinger(Afdelinger afdeling)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteButikker(Butikker butikker)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteButikkerharVare(Butikker_har_Vare butikker_Har_Vare)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteKategorier(Kategorier kategorier)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteKunder(Kunder kunder)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteKunderharAdresser(Kunder_har_Adresser kunder_Har_Adresser)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteLagerStatus(Lager_Status lager_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteLeverandor(Leverandor leverandor)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteMedarbejder(Medarbejder medarbejder)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteOrdre(Ordre ordre)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteOrdreLeveringsMetode(Ordre_Leverings_Metode ordre_Leverings_Metode)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteOrdrelinjer(Ordrelinjer ordrelinjer)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteOrdre_Status(Ordre_Status ordre_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeletePostNr(PostNr postNr)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteProducent(Producent producent)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void DeleteProdukter(Produkter produkter)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        
        public Adresser GetAdresseById(int id)
        {
            try
            {
                Adresser adresse = null;
                string query = "select Adresser.id,adresse,etage,pn.id,pn.byNavn from Adresser inner join PostNr as pn on pn.id = postnrID where Adresser.id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;

                    while (reader.Read())
                    {
                        PostNr postNr = new PostNr((int)reader[3], (string)reader[4]);



                        adresse = new Adresser((int)reader[0], postNr,(string)reader[2], (string)reader[3]);
                    count++;

                        
                    }
                
                //  CloseConn();
                if (count != 1) { throw new IndexOutOfRangeException("Address unspecified error"); }

                reader.Close();
                return adresse;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Adresse_Type GetAdresseTypeById(int id)
        {
            try
            {
                Adresse_Type adresse_Type = null;
                string query = "select id,type from Adresse_Type where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id",id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;

                    while (reader.Read())
                    {
                        adresse_Type = new Adresse_Type((int)reader[0],(string)reader[1]);
                    count++;
                    }
                
                //CloseConn();
                if (count != 1) { throw new IndexOutOfRangeException("Address Type unspecified error"); }

                reader.Close();
                return adresse_Type;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public Afdelinger GetAfdelingerById(int id)
        {
            try
            {
                Afdelinger afdelinger = null;
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
                            afdelinger = new Afdelinger((int)reader[0], (string)reader[1]);
                        }
                        else
                        {
                            Afdelinger parent_Afdeling = new Afdelinger((int)reader[2], (string)reader[3]);

                            afdelinger = new Afdelinger((int)reader[0], (string)reader[1],parent_Afdeling);
                        }
                    count++;
                        
                    }
                if (count != 1) { throw new IndexOutOfRangeException("Department unspecified error"); }

                reader.Close();
                return afdelinger;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }


        public Butikker GetButikkerById(int id)
        {
             
            try
            {
                Butikker butik = null;
                string query = "select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID where b.id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int count = 0;
                while (reader.Read())
                {
                    PostNr postNr = new PostNr((int)reader[4], (string)reader[5]);
                    Adresser adresser = new Adresser((int)reader[1], postNr, (string)reader[2], (string)reader[3]);
                    butik = new Butikker((int)reader[0], adresser);
                    count++;
                }
                if(count != 1) { throw new IndexOutOfRangeException("Shop unspecified error"); }
                //CloseConn();
                reader.Close();
                return butik;
            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public List<Butikker_har_Vare> GetButikkerharVareByButik(Butikker butik)
        {
            try{
                List<Butikker_har_Vare> butikker_Har_Vares = new List<Butikker_har_Vare>();




            }
            catch (Exception e){throw new Exception(e.Message);}
        }

        public Kategorier GetKategorierById(int id)
        {

            try{
                Kategorier kategorier = null;
                string query = "select k1.id,k1.navn,k2.id,k2.navn from Kategorier as k1 left join Kategorier k2 on k1.parent_KategoriID = k2.id where k1.id = @id;
                SqlCommand cmd = new SqlCommand(query, dbConn);
                OpenConn();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                int count = 0;
                while (reader.Read())
                {
                    if(reader[2] == null)
                    {
                        kategorier = new Kategorier(reader.GetInt32(0), reader.GetString(1));
                    }
                    else
                    {
                        Kategorier parent_Kategori = new Kategorier(reader.GetInt32(2), reader.GetString(3));
                        kategorier = new Kategorier((int)reader[0],(string)reader[1],parent_Kategori);
                    }
                   
                    count++;
                }
                if (count != 1) { throw new IndexOutOfRangeException("Category unspecified error"); }
                //CloseConn();
                reader.Close();
                return kategorier;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Kunder GetKunderById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Kunder_har_Adresser GetKunderharAdresserByKunde(Kunder kunde)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Lager_Status GetLagerStatusById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Leverandor GetLeverandorById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Medarbejder GetMedarbejderById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Ordre GetOrdreById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Ordre_Leverings_Metode GetOrdreLeveringsMetodeById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Ordrelinjer GetOrdrelinjerByOrdre(Ordre ordre)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Ordre_Status GetOrdre_StatusById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public PostNr GetPostNrById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public Producent GetProducentById(int id)
        {
            try{
                Producent producent = null;
                string query = "select id,producentNavn from Producent where id = @id";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                cmd.Parameters.AddWithValue("@id", id);
                return producent;
            }catch (Exception e){throw new Exception(e.Message);}
        }

        public Produkter GetProdukterById(int id)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }
        public List<Adresser> GetAllAdresse()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Adresse_Type> GetAllAdresseType()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Afdelinger> GetAllAfdelinger()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Butikker> GetAllButikker()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Butikker_har_Vare> GetAllButikker_har_Vare()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Kategorier> GetAllKategorier()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Kunder> GetAllKunder()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Kunder_har_Adresser> GetAllKunderharAdresser()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Lager_Status> GetAllLagerStatus()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Leverandor> GetAllLeverandor()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Medarbejder> GetAllMedarbejder()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Ordre> GetAllOrdre()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Ordre_Leverings_Metode> GetAllOrdreLeveringsMetode()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Ordrelinjer> GetAllOrdrelinjer()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Ordre_Status> GetAllOrdre_Status()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<PostNr> GetAllPostNr()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Producent> GetAllProducent()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public List<Produkter> GetAllProdukter()
        {
            try { } catch (Exception e) { throw new Exception(e.Message); }
        }

        public void UpdateAdresse(Adresser adresse)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateAdresseType(Adresse_Type adresse_Type)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateAfdelinger(Afdelinger afdeling)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateButikker(Butikker butikker)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateButikkerharVare(Butikker_har_Vare butikker_har_Vare)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateKategorier(Kategorier kategorier)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateKunder(Kunder kunder)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateKunderharAdresser(Kunder_har_Adresser kunder_har_Adresser)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateLagerStatus(Lager_Status lager_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateLeverandor(Leverandor leverandor)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateMedarbejder(Medarbejder medarbejder)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrdre(Ordre ordre)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrdreLeveringsMetode(Ordre_Leverings_Metode ordre_Leverings_Metode)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrdrelinjer(Ordrelinjer ordrelinjer)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateOrdre_Status(Ordre_Status ordre_Status)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdatePostNr(PostNr postNr)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateProducent(Producent producent)
        {
            try{}catch (Exception e){throw new Exception(e.Message);}
        }

        public void UpdateProdukter(Produkter produkter)
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

   
    }
}
