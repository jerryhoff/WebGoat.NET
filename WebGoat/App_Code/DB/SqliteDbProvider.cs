using System;
using System.Data;
using System.Data.SQLite;
using log4net;
using System.Reflection;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class SqliteDbProvider : IDbProvider
    {
        private string _connectionString = string.Empty;
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Name { get { return DbConstants.DB_TYPE_SQLITE; } }

        public bool TestConnection()
        {   
            
                
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    
                    using (SQLiteCommand cmd = conn.CreateCommand())
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
        
        private static string ConfigConnection(ConfigFile configFile)
        {
            return string.Format("Data Source={0};Version=3", configFile.Get(DbConstants.KEY_FILE_NAME));
        }
        
        private ConfigFile _configFile;

        public ConfigFile DbConfigFile
        {
            get { return _configFile; } 
            set
            {
                _connectionString = ConfigConnection(value);
                _configFile = value;
            }
        }

        public DataSet GetCatalogData()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValidCustomerLogin(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool RecreateGoatDb()
        {
            throw new System.NotImplementedException();
        }

        public string GetCustomerEmail(string customerNumber)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetCustomerDetails(string customerNumber)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetOffice(string city)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetComments(string productCode)
        {
            throw new System.NotImplementedException();
        }

        public string AddComment(string productCode, string email, string comment)
        {
            throw new System.NotImplementedException();
        }

        public string UpdateCustomerPassword(int customerNumber, string password)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetSecurityQuestionAndAnswer(string email)
        {
            throw new System.NotImplementedException();
        }

        public string GetPasswordByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetOrders(int customerID)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetProductDetails(string productCode)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetOrderDetails(int orderNumber)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetPayments(int customerNumber)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetProductsAndCategories()
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetProductsAndCategories(int catNumber)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetEmailByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public string GetEmailByCustomerNumber(string num)
        {
            throw new System.NotImplementedException();
        }

        public DataSet GetCustomerEmails(string email)
        {
            throw new System.NotImplementedException();
        }

    }
}