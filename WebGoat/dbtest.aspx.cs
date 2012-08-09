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
            if(!Page.IsPostBack && du != null && du.DbConfigFile != null)
            {
                dropDownDataProvider.Text = du.DbConfigFile.Get(DbConstants.KEY_DB_TYPE);
                txtClientExecutable.Text = du.DbConfigFile.Get(DbConstants.KEY_CLIENT_EXEC);
                txtFilePath.Text = du.DbConfigFile.Get(DbConstants.KEY_FILE_NAME);
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
            if (du == null || du.DbConfigFile == null)
            {
                labelError.Text = "Error testing database. Config not set.";
                PanelError.Visible = true;
                Session["DBConfigured"] = null;

                return;
            }

            //TODO: Need to provide interface for saving multiple configs need VS for it.
            if (string.IsNullOrEmpty(txtServer.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_HOST);
            else
                du.DbConfigFile.Set(DbConstants.KEY_HOST, txtServer.Text);

            if (string.IsNullOrEmpty(txtFilePath.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_FILE_NAME);
            else
                du.DbConfigFile.Set(DbConstants.KEY_FILE_NAME, txtFilePath.Text);

            if (string.IsNullOrEmpty(dropDownDataProvider.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_DB_TYPE);
            else
                du.DbConfigFile.Set(DbConstants.KEY_DB_TYPE, dropDownDataProvider.Text);

            if (string.IsNullOrEmpty(txtPort.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_PORT);
            else
                du.DbConfigFile.Set(DbConstants.KEY_PORT, txtPort.Text);

            if (string.IsNullOrEmpty(txtDatabase.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_DATABASE);
            else
                du.DbConfigFile.Set(DbConstants.KEY_DATABASE, txtDatabase.Text);
            
            if (string.IsNullOrEmpty(txtUserName.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_UID);
            else
                du.DbConfigFile.Set(DbConstants.KEY_UID, txtUserName.Text);

            if (string.IsNullOrEmpty(txtPassword.Text))
                du.DbConfigFile.Remove(DbConstants.KEY_PWD);
            else
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