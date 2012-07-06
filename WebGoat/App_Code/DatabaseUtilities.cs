using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web.Security;
using MySql.Data.MySqlClient;

namespace OWASP.WebGoat.NET
{
    public class DatabaseUtilities
	{
        //TODO: automate the database setup
        private MySqlConnection connection = null;

        private HttpServerUtility server = null;

        public DatabaseUtilities(HttpServerUtility server)
        {
            this.server = server;
        }
        
        public DatabaseUtilities(HttpContext context)
        {
            this.server = context.Server;
        }

        private MySqlConnection GetGoatDBConnection()
        {
            if (connection == null)
            {
                //set the physical path to the SQLite database
                //var connectionstring = "SERVER=localhost;PORT=3306;DATABASE=webgoat_coins;UID=root;PWD=root";
                var iohelper = new IOHelper(server);
                string connectionstring = iohelper.GetDBConfigString();
                connection = new MySqlConnection(connectionstring);
            }
            if(connection.State == ConnectionState.Closed) connection.Open();
            return connection;
        }

        public string TestDatabaseConnection()
        {
            string message = null ;
            try
            {
                string sql = "select count('x') from CustomerLogin";
                MySqlConnection connection = GetGoatDBConnection();
                MySqlCommand command = new MySqlCommand(sql, connection);
                /* object rows = */command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }


        public DataSet GetCatalogData()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("select * from products", GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public string CustomerTicketLogin(HttpResponse response, string email, string password)
        {
            string output = null;

            //encode password
            string encoded_password = UtilitiesHelper.Encode(password);
            
            //check email/password
            string sql = "select * from CustomerLogin where email = '" + email + "' and password = '" + encoded_password + "';";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);
            try
            {

                if (ds.Tables[0].Rows.Count > 0)
                {

                    //initialize the form authentication;
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket ticket =
                        new FormsAuthenticationTicket(
                            1, //version 
                            ds.Tables[0].Rows[0]["email"].ToString(), //name 
                            DateTime.Now, //issueDate
                            DateTime.Now.AddDays(14), //expireDate 
                            true, //isPersistent
                            "customer", //userData (customer role)
                            FormsAuthentication.FormsCookiePath //cookiePath
                        );

                    string encrypted_ticket = FormsAuthentication.Encrypt(ticket); //encrypt the ticket

                    // put ticket into the cookie
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted_ticket);

                    //set expiration date
                    if (ticket.IsPersistent)
                        cookie.Expires = ticket.Expiration;
                    response.Cookies.Add(cookie);

                    //save the customerNumber as a cookie to fix the "server farm" issue we were facing
                    HttpCookie cookie_id = new HttpCookie("customerNumber", ds.Tables[0].Rows[0]["customerNumber"].ToString());
                    cookie_id.Expires = DateTime.Now.AddDays(14); //expires in 2 weeks
                    response.Cookies.Add(cookie_id);
                }
                else
                {
                    output = "No Such Username / Password";
                }
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }
        
        //Find the bugs!
        public string CustomCustomerLogin(string email, string password)
        {
            string error_message = null;
            try
            {
                //get data
                string sql = "select * from CustomerLogin where email = '" + email + "';";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
                DataSet ds = new DataSet();
                da.Fill(ds);

                //check if email address exists
                if (ds.Tables[0].Rows.Count == 0)
                {
                    error_message = "Email Address Not Found!";
                    return error_message;
                }

                string encoded_password = ds.Tables[0].Rows[0]["Password"].ToString();
                string decoded_password = UtilitiesHelper.Decode(encoded_password);

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
            catch (MySqlException ex)
            {
                error_message = ex.Message;
            }
            catch (Exception ex)
            {
                //TODO: log exception(ex);
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return error_message;    
        }



        public Boolean RecreateGoatDB() { return true; }

        public string Test()
        {

            string MyConString = "SERVER=localhost;PORT=3306;" +
                "DATABASE=webgoat_coins;" +
                "UID=root;";// +
                //"PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "select * from employees limit 5";
            connection.Open();
            Reader = command.ExecuteReader();
            
            string thisrow = " ";
             
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ",";
            }
            connection.Close();
            return thisrow;
        }

        public string GetCustomerEmail(string customerNumber)
        {
            string output = null;
            try
            {
                string sql = "select email from CustomerLogin where customerNumber = " + customerNumber;
                MySqlConnection connection = GetGoatDBConnection();
                MySqlCommand command = new MySqlCommand(sql, connection);
                output = command.ExecuteScalar().ToString();
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
                MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //log ex.message
            }
            return ds;

        }

        public DataSet GetOffice(string city)
        {
            string sql = "select * from Offices where city = @city";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            da.SelectCommand.Parameters.AddWithValue("@city", city);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



        public DataSet GetComments(string productCode)
        {
            string sql = "select * from comments where productCode = @productCode";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            da.SelectCommand.Parameters.AddWithValue("@productCode", productCode); 
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public string AddComment(string productCode, string email, string comment)
        {
            string sql = "insert into Comments(productCode, email, comment) values ('" + productCode + "','" + email +"','" + comment + "');";
            string output = null;
            try
            {
                MySqlConnection connection = GetGoatDBConnection();
                MySqlCommand command = new MySqlCommand(sql, connection);
                /*int rows_added = */command.ExecuteNonQuery();
                //log("Rows Added: " + rows_added + " to comment table");

            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }

        public string UpdateCustomerPassword(int customerNumber, string password)
        {
            string sql = "update CustomerLogin set password = '" + UtilitiesHelper.Encode(password) + "' where customerNumber = " + customerNumber;
            string output = null;
            try
            {
                MySqlConnection connection = GetGoatDBConnection();
                MySqlCommand command = new MySqlCommand(sql, connection);
                /*int rows_added = */ command.ExecuteNonQuery();
                //log("Rows Added: " + rows_added + " to comment table");
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }

        public string GetSecurityQuestion(HttpResponse response, string email)
        {
            string sql = "select SecurityQuestions.question_text, CustomerLogin.answer from CustomerLogin, SecurityQuestions where CustomerLogin.email = '" 
                + email + "' and CustomerLogin.question_id = SecurityQuestions.question_id;";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string question = row[0].ToString();
                string answer = row[1].ToString();

                //save answer as an encrypted cookie we can check later!

                HttpCookie cookie = new HttpCookie("encr_sec_qu_ans");

                //encode twice for more security!

                cookie.Value = UtilitiesHelper.Encode(UtilitiesHelper.Encode(answer));

                response.Cookies.Add(cookie);

                //return security question

                return question;
            }
            else
                return null;

        }
        public string GetPasswordByEmail(string email)
        {
            string result = string.Empty;
            try
            {
                //get data
                string sql = "select * from CustomerLogin where email = '" + email + "';";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
                DataSet ds = new DataSet();
                da.Fill(ds);

                //check if email address exists
                if (ds.Tables[0].Rows.Count == 0)
                {
                    result = "Email Address Not Found!";
                }

                string encoded_password = ds.Tables[0].Rows[0]["Password"].ToString();
                string decoded_password = UtilitiesHelper.Decode(encoded_password);
                result = decoded_password;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public DataSet GetUsers()
        {
            string sql = "select * from CustomerLogin;";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

       
        public DataSet GetOrders(int customerID)
        {
            string sql = "select * from Orders where customerNumber = " + customerID;
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds;
        }

        public DataSet GetProductDetails(string productCode)
        {
            string sql = string.Empty;
            MySqlDataAdapter da;
            DataSet ds = new DataSet();


            sql = "select * from Products where productCode = '" + productCode + "'";
            da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            da.Fill(ds, "products");

            sql = "select * from Comments where productCode = '" + productCode + "'";
            da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            da.Fill(ds, "comments");

            DataRelation dr = new DataRelation("prod_comments",
                ds.Tables["products"].Columns["productCode"], //category table
                ds.Tables["comments"].Columns["productCode"], //product table
                false);

            ds.Relations.Add(dr);
            return ds;
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
            
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds;
        }

        public DataSet GetPayments(int customerNumber)
        {
            string sql = "select * from Payments where customerNumber = " + customerNumber;
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds;
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


            sql = "select * from Categories" + catClause;
            da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            da.Fill(ds, "categories");

            sql = "select * from Products" + catClause;
            da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            da.Fill(ds, "products");


            //category / products relationship
            DataRelation dr = new DataRelation("cat_prods", 
                ds.Tables["categories"].Columns["catNumber"], //category table
                ds.Tables["products"].Columns["catNumber"], //product table
                false);

            ds.Relations.Add(dr);
            return ds;
        }

        public DataSet GetEmailByName(string name)
        {
            string sql = "select firstName, lastName, email from Employees where firstName like '" + name + "%' or lastName like '" + name + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds;
        }

        public string GetEmailByCustomerNumber(string num)
        {
            string output = "";
            try
            {
                string sql = "select email from CustomerLogin where customerNumber = " + num;
                MySqlCommand cmd = new MySqlCommand(sql, GetGoatDBConnection());
                output = (string) cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }
        public DataSet GetCustomerEmails(string email)
        {
            string sql = "select email from CustomerLogin where email like '" + email + "%'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, GetGoatDBConnection());
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ds;
        }
	}
}