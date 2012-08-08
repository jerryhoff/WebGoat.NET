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
                txtServer.Text = du.DbConfigFile.Get(DbConstants.KEY_HOST);
                txtPort.Text = du.DbConfigFile.Get(DbConstants.KEY_PORT);
                txtDatabase.Text = du.DbConfigFile.Get(DbConstants.KEY_DATABASE);
                txtUserName.Text = du.DbConfigFile.Get(DbConstants.KEY_UID);
                txtPassword.Text = du.DbConfigFile.Get(DbConstants.KEY_PWD);
            }

            PanelSuccess.Visible = false;
            PanelError.Visible = false;
            
            PanelRebuildSuccess.Visible = false;
            PanelRebuildFailure.Visible = false;

		}

		protected void btnTest_Click (object sender, EventArgs e)
		{			
            lblOutput.Text = du.TestConnection() ? "Works!" : "Problem";
		}

        protected void btnTestConfiguration_Click(object sender, EventArgs e)
        {
            //TODO: Need to provide interface for saving multiple configs need VS for it.
            du.DbConfigFile.Set(DbConstants.KEY_HOST, txtServer.Text);
            du.DbConfigFile.Set(DbConstants.KEY_PORT, txtPort.Text);
            du.DbConfigFile.Set(DbConstants.KEY_DATABASE, txtDatabase.Text);
            du.DbConfigFile.Set(DbConstants.KEY_UID, txtUserName.Text);
            du.DbConfigFile.Set(DbConstants.KEY_PWD, txtPassword.Text);
            
            du.DbConfigFile.Save();
            
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

        protected void btnRebuildDatabase_Click(object sender, EventArgs e)
        {
            if (du.RecreateGoatDb())
            {
                labelRebuildSuccess.Text = "Database Rebuild Successful!";
                PanelRebuildSuccess.Visible = true;
                Session["DBConfigured"] = true;
            }
            else
            {
                labelRebuildFailure.Text = "Error rebuilding database. Please see logs.";
                PanelRebuildFailure.Visible = true;
                Session["DBConfigured"] = null;
            }
        }
	}
}