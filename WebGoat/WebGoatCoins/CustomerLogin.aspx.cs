using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelError.Visible = false;

            string returnUrl = Request.QueryString["ReturnUrl"];
            if (returnUrl != null)
            {
                PanelError.Visible = true;
            }
        }

        protected void ButtonLogOn_Click(object sender, EventArgs e)
        {
            string email = txtUserName.Text;
            string pwd = txtPassword.Text;

            //log("User attempted to log in with password " + pwd);

            DatabaseUtilities du = new DatabaseUtilities(Server);

            string error_message = du.CustomerTicketLogin(Response, email, pwd);

            if (error_message == null) //login successful!
            {
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null) 
                    returnUrl = "/WebGoatCoins/MainPage.aspx";
                Response.Redirect(returnUrl);

            }
            else
                labelMessage.Text = error_message;
            
            
            /*
            string error_message = du.CustomerLogin(uid, pwd);
            if (error_message != null)
            {
                labelMessage.Text = error_message;
            }
            else
            {
                Response.Redirect("./MainPage.aspx");
            }
            */
        }


    }
}