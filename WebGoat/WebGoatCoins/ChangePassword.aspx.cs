using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            if(txtPassword1.Text != null && txtPassword2.Text != null && txtPassword1.Text == txtPassword2.Text)
            {
                //get customer ID
                string customerNumber = "";
                if (Request.Cookies["customerNumber"] != null)
                {
                    customerNumber = Request.Cookies["customerNumber"].Value;
                }

                DatabaseUtilities du = new DatabaseUtilities(Server);
                string output = du.UpdateCustomerPassword(int.Parse(customerNumber), txtPassword1.Text);
                labelMessage.Text = output;
            }
            else
            {
                labelMessage.Text = "Passwords do not match!  Please try again!";
            }

        }
    }
}