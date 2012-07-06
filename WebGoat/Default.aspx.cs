using System;
using System.Web;
using System.Web.UI;

namespace OWASP.WebGoat.NET
{
	public partial class Default : System.Web.UI.Page
	{
        protected void ButtonProceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("RebuildDatabase.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //do a quick test.  If the database connects, inform the user the database seems to be working.
            DatabaseUtilities du = new DatabaseUtilities(Server);
            string msg = du.TestDatabaseConnection();
            if (msg == null)
            {
                lblOutput.Text = "You appear to be connected to a valid MySQL Database.  If you want to reconfigure or rebuild the database, click on the button below!";
                Session["DBConfigured"] = true;
            }
            else
            {
                lblOutput.Text = "Before proceeding, please ensure this instance of WebGoat.NET can connect to the database!";
                //PanelError.Visible = true;
            }

        }
    }
}

