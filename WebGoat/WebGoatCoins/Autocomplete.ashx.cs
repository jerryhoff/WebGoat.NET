using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    /// <summary>
    /// Summary description for Autocomplete
    /// </summary>
    public class Autocomplete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string query = context.Request["query"];
            DatabaseUtilities du = new DatabaseUtilities(context);
            DataSet ds = du.GetCustomerEmails(query);
            string json = UtilitiesHelper.ToJSONSAutocompleteString(query, ds.Tables[0]);

            if (json != null && json.Length > 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(json);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("");
            
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}