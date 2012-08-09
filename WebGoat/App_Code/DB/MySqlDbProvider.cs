using System;
using System.Data;
using MySql.Data.MySqlClient;
using log4net;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class MySqlDbProvider : IDbProvider
    {
        private readonly string _connectionString;
        private readonly string _host;
        private readonly string _port;
        private readonly string _pwd;
        private readonly string _uid;
        private readonly string _database;
        private readonly string _clientExec;

        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MySqlDbProvider(ConfigFile configFile)
        {
            if (configFile == null)
                _connectionString = string.Empty;
                
            if (!string.IsNullOrEmpty(configFile.Get(DbConstants.KEY_PWD)))
            {
                _connectionString = string.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PWD={4}",
                                                  configFile.Get(DbConstants.KEY_HOST),
                                                  configFile.Get(DbConstants.KEY_PORT),
                                                  configFile.Get(DbConstants.KEY_DATABASE),
                                                  configFile.Get(DbConstants.KEY_UID),
                                                  configFile.Get(DbConstants.KEY_PWD));
            }
            else
            {
                 _connectionString = string.Format("SERVER={0};PORT={1};DATABASE={2};UID={3}",
                                                  configFile.Get(DbConstants.KEY_HOST),
                                                  configFile.Get(DbConstants.KEY_PORT),
                                                  configFile.Get(DbConstants.KEY_DATABASE),
                                                  configFile.Get(DbConstants.KEY_UID));
            }

            _uid = configFile.Get(DbConstants.KEY_UID);
            _pwd = configFile.Get(DbConstants.KEY_PWD);
            _database = configFile.Get(DbConstants.KEY_DATABASE);
            _host = configFile.Get(DbConstants.KEY_HOST);
            _clientExec = configFile.Get(DbConstants.KEY_CLIENT_EXEC);
            _port = configFile.Get(DbConstants.KEY_PORT);
        }

        public string Name { get { return DbConstants.DB_TYPE_MYSQL; } }
        

        public bool TestConnection()
        {
            try
            {
                /*using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from information_schema.TABLES", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }*/
                MySqlHelper.ExecuteNonQuery(_connectionString, "select * from information_schema.TABLES");
                
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Error testing DB", ex);
                return false;
            }
        }
                
        public DataSet GetCatalogData()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Products", connection);
                DataSet ds = new DataSet();
            
                da.Fill(ds);
            
                return ds;
            }
        }

        public bool RecreateGoatDb()
        {
            string args;
            
            if (string.IsNullOrEmpty(_pwd))
                args = string.Format("--user={0} --database={1} --host={2} --port={3} -f",
                        _uid, _database, _host, _port);
            else
                args = string.Format("--user={0} --password={1} --database={2} --host={3} --port={4} -f",
                        _uid, _pwd, _database, _host, _port);

            log.Info("Running recreate");

            int retVal1 = Math.Abs(Util.RunProcessWithInput(_clientExec, args, DbConstants.DB_CREATE_SCRIPT));
            int retVal2 = Math.Abs(Util.RunProcessWithInput(_clientExec, args, DbConstants.DB_LOAD_MYSQL_SCRIPT));
            
            return Math.Abs(retVal1) + Math.Abs(retVal2) == 0;
        }

        public bool IsValidCustomerLogin(string email, string password)
        {
            //encode password
            string encoded_password = Encoder.Encode(password);
            
            //check email/password
            string sql = "select * from CustomerLogin where email = '" + email + 
                "' and password = '" + encoded_password + "';";
                        
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            
                //TODO: User reader instead (for all calls)
                DataSet ds = new DataSet();
            
                da.Fill(ds);
                
                try
                {
                    return ds.Tables[0].Rows.Count != 0;

                }
                catch (Exception ex)
                {
                    //Log this and pass the ball along.
                    log.Error("Error checking login", ex);
                    
                    throw new Exception("Error checking login", ex);
                }
            }
        }
        
        //Find the bugs!
        public string CustomCustomerLogin(string email, string password)
        {
            string error_message = null;
            try
            {
                //get data
                string sql = "select * from CustomerLogin where email = '" + email + "';";
                
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //check if email address exists
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        error_message = "Email Address Not Found!";
                        return error_message;
                    }

                    string encoded_password = ds.Tables[0].Rows[0]["Password"].ToString();
                    string decoded_password = Encoder.Decode(encoded_password);

                    if (password.Trim().ToLower() != decoded_password.Trim().ToLower())
                    {
                        error_message = "Password Not Valid For This Email Address!";
                    }
                    else
                    {
                        //login successful
                        error_message = null;
                    }
                }
                
            }
            catch (MySqlException ex)
            {
                log.Error("Error with custom customer login", ex);
                error_message = ex.Message;
            }
            catch (Exception ex)
            {
                log.Error("Error with custom customer login", ex);
            }

            return error_message;    
        }

        public string GetCustomerEmail(string customerNumber)
        {
            string output = null;
            try
            {
            
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "select email from CustomerLogin where customerNumber = " + customerNumber;
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    output = command.ExecuteScalar().ToString();
                } 
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }

        public DataSet GetCustomerDetails(string customerNumber)
        {
            string sql = "select Customers.customerNumber, Customers.customerName, Customers.logoFileName, Customers.contactLastName, Customers.contactFirstName, " +
                "Customers.phone, Customers.addressLine1, Customers.addressLine2, Customers.city, Customers.state, Customers.postalCode, Customers.country, " +
                "Customers.salesRepEmployeeNumber, Customers.creditLimit, CustomerLogin.email, CustomerLogin.password, CustomerLogin.question_id, CustomerLogin.answer " +
                "From Customers, CustomerLogin where Customers.customerNumber = CustomerLogin.customerNumber and Customers.customerNumber = " + customerNumber;

            DataSet ds = new DataSet();
            try
            {
            
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                    da.Fill(ds);
                }

            }
            catch (Exception ex)
            {
                log.Error("Error getting customer details", ex);
                
                throw new ApplicationException("Error getting customer details", ex);
            }
            return ds;

        }

        public DataSet GetOffice(string city)
        {
        
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "select * from Offices where city = @city";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.SelectCommand.Parameters.AddWithValue("@city", city);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetComments(string productCode)
        {
        
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "select * from Comments where productCode = @productCode";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                da.SelectCommand.Parameters.AddWithValue("@productCode", productCode); 
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public string AddComment(string productCode, string email, string comment)
        {
            string sql = "insert into Comments(productCode, email, comment) values ('" + productCode + "','" + email + "','" + comment + "');";
            string output = null;
            
            try
            {

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error adding comment", ex);
                output = ex.Message;
            }
            
            return output;
        }

        public string UpdateCustomerPassword(int customerNumber, string password)
        {
            string sql = "update CustomerLogin set password = '" + Encoder.Encode(password) + "' where customerNumber = " + customerNumber;
            string output = null;
            try
            {
            
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                
                    int rows_added = command.ExecuteNonQuery();
                    
                    log.Info("Rows Added: " + rows_added + " to comment table");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error updating customer password", ex);
                output = ex.Message;
            }
            return output;
        }

        public string[] GetSecurityQuestionAndAnswer(string email)
        {
            string sql = "select SecurityQuestions.question_text, CustomerLogin.answer from CustomerLogin, " + 
                "SecurityQuestions where CustomerLogin.email = '" + email + "' and CustomerLogin.question_id = " +
                "SecurityQuestions.question_id;";
                
            string[] qAndA = new string[2];
            
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    qAndA[0] = row[0].ToString();
                    qAndA[1] = row[1].ToString();
                }
            }
            
            return qAndA;
        }

        public string GetPasswordByEmail(string email)
        {
            string result = string.Empty;
            try
            {
            
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    //get data
                    string sql = "select * from CustomerLogin where email = '" + email + "';";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //check if email address exists
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        result = "Email Address Not Found!";
                    }

                    string encoded_password = ds.Tables[0].Rows[0]["Password"].ToString();
                    string decoded_password = Encoder.Decode(encoded_password);
                    result = decoded_password;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public DataSet GetUsers()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "select * from CustomerLogin;";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
       
        public DataSet GetOrders(int customerID)
        {
        
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "select * from Orders where customerNumber = " + customerID;
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

        public DataSet GetProductDetails(string productCode)
        {
            string sql = string.Empty;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();


            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                sql = "select * from Products where productCode = '" + productCode + "'";
                da = new MySqlDataAdapter(sql, connection);
                da.Fill(ds, "products");

                sql = "select * from Comments where productCode = '" + productCode + "'";
                da = new MySqlDataAdapter(sql, connection);
                da.Fill(ds, "comments");

                DataRelation dr = new DataRelation("prod_comments",
                ds.Tables["products"].Columns["productCode"], //category table
                ds.Tables["comments"].Columns["productCode"], //product table
                false);

                ds.Relations.Add(dr);
                return ds;
            }
        }

        public DataSet GetOrderDetails(int orderNumber)
        {

            string sql = "select Customers.customerName, Orders.customerNumber, Orders.orderNumber, Products.productName, " + 
                "OrderDetails.quantityOrdered, OrderDetails.priceEach, Products.productImage " + 
                "from OrderDetails, Products, Orders, Customers where " + 
                "Customers.customerNumber = Orders.customerNumber " + 
                "and OrderDetails.productCode = Products.productCode " + 
                "and Orders.orderNumber = OrderDetails.orderNumber " + 
                "and OrderDetails.orderNumber = " + orderNumber;
            
            
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

        public DataSet GetPayments(int customerNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "select * from Payments where customerNumber = " + customerNumber;
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

        public DataSet GetProductsAndCategories()
        {
            return GetProductsAndCategories(0);
        }

        public DataSet GetProductsAndCategories(int catNumber)
        {
            //TODO: Rerun the database script.
            string sql = string.Empty;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();

            //catNumber is optional.  If it is greater than 0, add the clause to both statements.
            string catClause = string.Empty;
            if (catNumber >= 1)
                catClause += " where catNumber = " + catNumber; 


            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {

                sql = "select * from Categories" + catClause;
                da = new MySqlDataAdapter(sql, connection);
                da.Fill(ds, "categories");

                sql = "select * from Products" + catClause;
                da = new MySqlDataAdapter(sql, connection);
                da.Fill(ds, "products");


                //category / products relationship
                DataRelation dr = new DataRelation("cat_prods", 
                ds.Tables["categories"].Columns["catNumber"], //category table
                ds.Tables["products"].Columns["catNumber"], //product table
                false);

                ds.Relations.Add(dr);
                return ds;
            }
        }

        public DataSet GetEmailByName(string name)
        {
            string sql = "select firstName, lastName, email from Employees where firstName like '" + name + "%' or lastName like '" + name + "%'";
            
            
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

        public string GetEmailByCustomerNumber(string num)
        {
            string output = "";
            try
            {
            
                output = (String)MySqlHelper.ExecuteScalar(_connectionString, "select email from CustomerLogin where customerNumber = " + num);
                /*using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string sql = "select email from CustomerLogin where customerNumber = " + num;
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    output = (string)cmd.ExecuteScalar();
                }*/
                
            }
            catch (Exception ex)
            {
                log.Error("Error getting email by customer number", ex);
                output = ex.Message;
            }
            
            return output;
        }

        public DataSet GetCustomerEmails(string email)
        {
            string sql = "select email from CustomerLogin where email like '" + email + "%'";
            
            
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                else
                    return ds;
            }
        }

    }
}
