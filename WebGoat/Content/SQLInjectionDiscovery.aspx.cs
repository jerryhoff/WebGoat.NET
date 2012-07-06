using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OWASP.WebGoat.NET
{
	public partial class SQLInjectionDiscovery : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{

		}

		protected void btnFind_Click (object sender, EventArgs e)
		{
            try
            {
                DatabaseUtilities du = new DatabaseUtilities(Server);
                string name = txtID.Text.Substring(0, 3);
                string output = du.GetEmailByCustomerNumber(name);

                lblOutput.Text = output;
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
		}
	}
}