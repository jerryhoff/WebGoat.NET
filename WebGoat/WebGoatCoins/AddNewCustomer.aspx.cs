using System;
using System.Web.UI;
using OWASP.WebGoat.NET.App_Code;
using OWASP.WebGoat.NET.App_Code.DB;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class AddNewCustomer : Page
    {
        protected IDbProvider du = Settings.CurrentDbProvider;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateCustomer(object sender, EventArgs e)
        {
            if (!du.IsAdminCustomerLogin(User.Identity.Name))
            {
                InvalidUserNameOrPasswordMessage.Text = "ACCESS DENIED.";
                InvalidUserNameOrPasswordMessage.Visible = true;
                return;
            }

            if (String.IsNullOrEmpty(Username.Text) ||
                String.IsNullOrEmpty(Email.Text) ||
                String.IsNullOrEmpty(Password.Text))
            {
                InvalidUserNameOrPasswordMessage.Text = "Fields Username, Email, Password should be filled.";
                InvalidUserNameOrPasswordMessage.Visible = true;
                return;
            }

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