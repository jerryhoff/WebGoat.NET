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
		protected void Page_Load (object sender, EventArgs e)
		{
            ConfigFile configFile = Settings.CurrentConfigFile;

            if(!Page.IsPostBack)
            {
                dropDownDataProvider.Text = configFile.Get(DbConstants.KEY_DB_TYPE);
                txtClientExecutable.Text = configFile.Get(DbConstants.KEY_CLIENT_EXEC);
                txtFilePath.Text = configFile.Get(DbConstants.KEY_FILE_NAME);
                txtServer.Text = configFile.Get(DbConstants.KEY_HOST);
                txtPort.Text = configFile.Get(DbConstants.KEY_PORT);
                txtDatabase.Text = configFile.Get(DbConstants.KEY_DATABASE);
                txtUserName.Text = configFile.Get(DbConstants.KEY_UID);
                txtPassword.Text = configFile.Get(DbConstants.KEY_PWD);
            }

            PanelSuccess.Visible = false;
            PanelError.Visible = false;
            
            PanelRebuildSuccess.Visible = false;
            PanelRebuildFailure.Visible = false;

		}

		protected void btnTest_Click (object sender, EventArgs e)
		{			
            lblOutput.Text = Settings.CurrentDbProvider.TestConnection() ? "Works!" : "Problem";
		}

        protected void btnTestConfiguration_Click(object sender, EventArgs e)
        {
            ConfigFile configFile = Settings.CurrentConfigFile;

            //TODO: Need to provide interface for saving multiple configs need VS for it.
            UpdateConfigFile(configFile);

            Settings.CurrentDbProvider = DbProviderFactory.Create(configFile);

            if (Settings.CurrentDbProvider.TestConnection())
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
            ConfigFile configFile = Settings.CurrentConfigFile;

            UpdateConfigFile(configFile);

            Settings.CurrentDbProvider = DbProviderFactory.Create(configFile);
            Settings.CurrentDbProvider.RecreateGoatDb();

            if (Settings.CurrentDbProvider.TestConnection())
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

        private void UpdateConfigFile(ConfigFile configFile)
        {
           if (string.IsNullOrEmpty(txtServer.Text))
                configFile.Remove(DbConstants.KEY_HOST);
            else
                configFile.Set(DbConstants.KEY_HOST, txtServer.Text);

            if (string.IsNullOrEmpty(txtFilePath.Text))
                configFile.Remove(DbConstants.KEY_FILE_NAME);
            else
                configFile.Set(DbConstants.KEY_FILE_NAME, txtFilePath.Text);

            if (string.IsNullOrEmpty(dropDownDataProvider.Text))
                configFile.Remove(DbConstants.KEY_DB_TYPE);
            else
                configFile.Set(DbConstants.KEY_DB_TYPE, dropDownDataProvider.Text);

            if (string.IsNullOrEmpty(txtPort.Text))
                configFile.Remove(DbConstants.KEY_PORT);
            else
                configFile.Set(DbConstants.KEY_PORT, txtPort.Text);

            if (string.IsNullOrEmpty(txtClientExecutable.Text))
                configFile.Remove(DbConstants.KEY_CLIENT_EXEC);
            else
                configFile.Set(DbConstants.KEY_CLIENT_EXEC, txtClientExecutable.Text);

            if (string.IsNullOrEmpty(txtDatabase.Text))
                configFile.Remove(DbConstants.KEY_DATABASE);
            else
                configFile.Set(DbConstants.KEY_DATABASE, txtDatabase.Text);
            
            if (string.IsNullOrEmpty(txtUserName.Text))
                configFile.Remove(DbConstants.KEY_UID);
            else
                configFile.Set(DbConstants.KEY_UID, txtUserName.Text);

            if (string.IsNullOrEmpty(txtPassword.Text))
                configFile.Remove(DbConstants.KEY_PWD);
            else
                configFile.Set(DbConstants.KEY_PWD, txtPassword.Text);
            
            configFile.Save();
        }
	}
}