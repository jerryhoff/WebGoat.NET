using System;
using System.Data;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public interface IDbProvider
    {
        string Name { get; }

        bool TestConnection();

        DataSet GetCatalogData();

        bool IsValidCustomerLogin(string email, string password);

        bool RecreateGoatDb();

        string GetCustomerEmail(string customerNumber);

        DataSet GetCustomerDetails(string customerNumber);

        DataSet GetOffice(string city);

        DataSet GetComments(string productCode);

        string AddComment(string productCode, string email, string comment);

        string UpdateCustomerPassword(int customerNumber, string password);

        string[] GetSecurityQuestionAndAnswer(string email);

        string GetPasswordByEmail(string email);

        DataSet GetUsers();

        DataSet GetOrders(int customerID);

        DataSet GetProductDetails(string productCode);

        DataSet GetOrderDetails(int orderNumber);

        DataSet GetPayments(int customerNumber);

        DataSet GetProductsAndCategories();

        DataSet GetProductsAndCategories(int catNumber);

        DataSet GetEmailByName(string name);

        string GetEmailByCustomerNumber(string num);

        DataSet GetCustomerEmails(string email);
    }
}