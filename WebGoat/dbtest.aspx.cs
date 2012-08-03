using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET
{
	public partial class RebuildDatabase : System.Web.UI.Page
	{	   
        private IDbProvider du = Settings.CurrentDbProvider;
        
		protected void Page_Load (object sender, EventArgs e)
		{
            if(!Page.IsPostBack)
            {
                IOHelper iohelper = new IOHelper(Server);
                var values = iohelper.GetDBConfigDictionary();
                txtServer.Text = values["SERVER"];
                txtPort.Text = values["PORT"];
                txtDatabase.Text = values["DATABASE"];
                txtUserName.Text = values["UID"];
                txtPassword.Text = values["PWD"];
            }

            PanelSuccess.Visible = false;
            PanelError.Visible = false;
            
            PanelRebuildSuccess.Visible = false;
            //PanelRebuildFailure.Visible = false;

		}

		protected void btnTest_Click (object sender, EventArgs e)
		{			
            lblOutput.Text = du.TestConnection() ? "Works!" : "Problem";
		}

        protected void btnTestConfiguration_Click(object sender, EventArgs e)
        {
            //get all the fields, save in conf file
            //use that to then connect to the database
            
            IOHelper iohelper = new IOHelper(Server);
            
            string result = iohelper.SaveDBConfigString(txtServer.Text, txtPort.Text, txtDatabase.Text, txtUserName.Text, txtPassword.Text);

            if (result != null)
                lblOutput.Text = result;
            else
            {
                if (du.TestConnection())
                {
                    labelSuccess.Text = "Connection to Database Successful!";
                    PanelSuccess.Visible = true;
                    Session["DBConfigured"] = true;
                }
                else
                {
                    labelError.Text = "Error testing database. Please see logs.";
                    PanelError.Visible = true;
                    Session["DBConfigured"] = null;
                }
            }
        }

        protected void btnRebuildDatabase_Click(object sender, EventArgs e)
        {

        }
	}
}