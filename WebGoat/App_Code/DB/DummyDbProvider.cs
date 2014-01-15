using System;
using System.Data;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class DummyDbProvider : IDbProvider
    {
        
        public bool TestConnection()
        {
            return true;
        }

        public ConfigFile DbConfigFile
        {
            get; set;
        }
        
        public DataSet GetCatalogData()
        {
            return null;
        }

        public bool IsValidCustomerLogin(string email, string password)
        {
            return false;
        }

        public bool RecreateGoatDb()
        {
            return false;
        }

        public string GetCustomerEmail(string customerNumber)
        {
            return string.Empty;
        }

        public DataSet GetCustomerDetails(string customerNumber)
        {
            return null;
        }

        public DataSet GetOffice(string city)
        {
            return null;
        }

        public DataSet GetComments(string productCode)
        {
            return null;
        }

        public string AddComment(string productCode, string email, string comment)
        {
            return string.Empty;
        }

        public string UpdateCustomerPassword(int customerNumber, string password)
        {
            return string.Empty;
        }

        public string[] GetSecurityQuestionAndAnswer(string email)
        {
            return null;
        }

        public string GetPasswordByEmail(string email)
        {
            return string.Empty;
        }

        public DataSet GetUsers()
        {
            return null;
        }

        public DataSet GetOrders(int customerID)
        {
            return null;
        }

        public DataSet GetProductDetails(string productCode)
        {
            return null;
        }

        public DataSet GetOrderDetails(int orderNumber)
        {
            return null;
        }

        public DataSet GetPayments(int customerNumber)
        {
            return null;
        }

        public DataSet GetProductsAndCategories()
        {
            return null;
        }

        public DataSet GetProductsAndCategories(int catNumber)
        {
            return null;
        }

        public DataSet GetEmailByName(string name)
        {
            return null;
        }

        public string GetEmailByCustomerNumber(string num)
        {
            return string.Empty;
        }

        public DataSet GetCustomerEmails(string email)
        {
            return null;
        }

        public string Name
        {
            get { return "Dummy"; }
        }
    }
}

