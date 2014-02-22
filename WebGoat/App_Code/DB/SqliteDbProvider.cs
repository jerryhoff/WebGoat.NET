using System;
using System.Data;
using Mono.Data.Sqlite;
using log4net;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class SqliteDbProvider : IDbProvider
    {
        private string _connectionString = string.Empty;
        private string _clientExec;
        private string _dbFileName;

        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Name { get { return DbConstants.DB_TYPE_SQLITE; } }

        public SqliteDbProvider(ConfigFile configFile)
        {
            _connectionString = string.Format("Data Source={0};Version=3", configFile.Get(DbConstants.KEY_FILE_NAME));

            _clientExec = configFile.Get(DbConstants.KEY_CLIENT_EXEC);
            _dbFileName = configFile.Get(DbConstants.KEY_FILE_NAME);

            if (!File.Exists(_dbFileName))
                SqliteConnection.CreateFile(_dbFileName);
        }

        public bool TestConnection()
        {   
            try
            {
                using (SqliteConnection conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();
                    
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                    
                        cmd.CommandText = "SELECT date('now')";
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteReader();
                    }
                }
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
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter("select * from Products", connection);
                DataSet ds = new DataSet();
            
                da.Fill(ds);
            
                return ds;
            }
        }

        public bool IsValidCustomerLogin(string email, string password)
        {
            //encode password
            string encoded_password = Encoder.Encode(password);
            
            //check email/password
            string sql = "select * from CustomerLogin where email = '" + email + "' and password = '" + 
                         encoded_password + "';";
                        
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
            
                //TODO: User reader instead (for all calls)
                DataSet ds = new DataSet();
            
                da.Fill(ds);
                
                try
                {
                    return ds.Tables[0].Rows.Count == 0;
                }
                catch (Exception ex)
                {
                    //Log this and pass the ball along.
                    log.Error("Error checking login", ex);
                    
                    throw new Exception("Error checking login", ex);
                }
            }
        }

        public bool RecreateGoatDb()
        {
            try
            {
                log.Info("Running recreate");
                string args = string.Format("\"{0}\"", _dbFileName);
                string script = Path.Combine(Settings.RootDir, DbConstants.DB_CREATE_SQLITE_SCRIPT);
                int retVal1 = Math.Abs(Util.RunProcessWithInput(_clientExec, args, script));

                script = Path.Combine(Settings.RootDir, DbConstants.DB_LOAD_SQLITE_SCRIPT);
                int retVal2 = Math.Abs(Util.RunProcessWithInput(_clientExec, args, script));

                return Math.Abs(retVal1) + Math.Abs(retVal2) == 0;
            }
            catch (Exception ex)
            {
                log.Error("Error rebulding DB", ex);
                return false;
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
                
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
            catch (SqliteException ex)
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
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "select email from CustomerLogin where customerNumber = " + customerNumber;
                    SqliteCommand command = new SqliteCommand(sql, connection);
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
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
        
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Offices where city = @city";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                da.SelectCommand.Parameters.AddWithValue("@city", city);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetComments(string productCode)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Comments where productCode = @productCode";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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

                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sql, connection);
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
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand(sql, connection);
                
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
            
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                
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
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    //get data
                    string sql = "select * from CustomerLogin where email = '" + email + "';";
                    SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from CustomerLogin;";
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
       
        public DataSet GetOrders(int customerID)
        {
        
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Orders where customerNumber = " + customerID;
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
            SqliteDataAdapter da;
            DataSet ds = new DataSet();


            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                sql = "select * from Products where productCode = '" + productCode + "'";
                da = new SqliteDataAdapter(sql, connection);
                da.Fill(ds, "products");

                sql = "select * from Comments where productCode = '" + productCode + "'";
                da = new SqliteDataAdapter(sql, connection);
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
            
            
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string sql = "select * from Payments where customerNumber = " + customerNumber;
                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
            SqliteDataAdapter da;
            DataSet ds = new DataSet();

            //catNumber is optional.  If it is greater than 0, add the clause to both statements.
            string catClause = string.Empty;
            if (catNumber >= 1)
                catClause += " where catNumber = " + catNumber; 


            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                sql = "select * from Categories" + catClause;
                da = new SqliteDataAdapter(sql, connection);
                da.Fill(ds, "categories");

                sql = "select * from Products" + catClause;
                da = new SqliteDataAdapter(sql, connection);
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
            
            
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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
            
                using (SqliteConnection connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "select email from CustomerLogin where customerNumber = " + num;
                    SqliteCommand cmd = new SqliteCommand(sql, connection);
                    output = (string)cmd.ExecuteScalar();
                }
                
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
            
            
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteDataAdapter da = new SqliteDataAdapter(sql, connection);
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