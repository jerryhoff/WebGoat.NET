using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using TechInfoSystems.Data.SQLite;
using System.Web.Security;
using System.Web.Configuration;

namespace OWASP.WebGoat.NET
{
    public partial class LoginPage : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
    	{
    	}
    
    	protected void ButtonLogOn_Click(object sender, EventArgs e)
    	{
            Response.Redirect("/WebGoatCoins/CustomerLogin.aspx");

            //if(Membership.ValidateUser(txtUserName.Value.Trim(), txtPassword.Value.Trim()))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, true);
            //}
            //else
            //{
            //    labelMessage.Text = "invalid username";
            //}
	    }
    	protected void ButtonAdminLogOn_Click(object sender, EventArgs e)
    	{
    
    	}
	}
}