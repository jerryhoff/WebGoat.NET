using System;
using System.Data;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class SqliteDbProvider : IDbProvider
    {
        public string Name { get { return DbConstants.DB_TYPE_SQLITE; } }

        public bool TestConnection()
        {
            throw new System.NotImplementedException();
        }
        
        public ConfigFile DbConfigFile { get; set; }

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