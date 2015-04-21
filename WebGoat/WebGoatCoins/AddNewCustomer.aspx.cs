using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code;
using OWASP.WebGoat.NET.App_Code.DB;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class AddNewCustomer : System.Web.UI.Page
    {
        protected IDbProvider du = Settings.CurrentDbProvider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateCustomer(object sender, EventArgs e)
        {
            var success = du.CreateCustomer(
                Username.Text, Email.Text, Password.Text, IsAdmin.Checked, 1, "blue");
            if (success)
            {
                InvalidUserNameOrPasswordMessage.Visible = false;
            }
            else
            {
                InvalidUserNameOrPasswordMessage.Text = "Error user creating.";
                InvalidUserNameOrPasswordMessage.Visible = true;
            }

            var s = Page.User.Identity.Name;
        }
    }
}