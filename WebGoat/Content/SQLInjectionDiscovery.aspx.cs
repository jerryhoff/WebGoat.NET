using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET
{
	public partial class SQLInjectionDiscovery : System.Web.UI.Page
	{
    
        private IDbProvider du = Settings.CurrentDbProvider;
        
		protected void Page_Load (object sender, EventArgs e)
		{

		}

		protected void btnFind_Click (object sender, EventArgs e)
		{
            try
            {
                string name = txtID.Text.Substring(0, 3);
                string output = du.GetEmailByCustomerNumber(name);

                lblOutput.Text = String.IsNullOrEmpty(output) ? "Customer Number does not exist" : output;
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
		}
	}
}