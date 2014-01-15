
using System;
using System.Web;
using System.Web.UI;

namespace OWASP.WebGoat.NET
{
    public partial class VerbTampering : System.Web.UI.Page
    {
        //Probably best if eventually connected to DB
        public static string tamperedMessage = "This has not been tampered with yet...";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTampered.Text = tamperedMessage;
        } 
    }
}

