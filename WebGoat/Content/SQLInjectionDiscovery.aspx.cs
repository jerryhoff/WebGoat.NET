using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET
{
	public partial class SQLInjectionDiscovery : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{

		}

		protected void btnFind_Click (object sender, EventArgs e)
		{
			try {
				DatabaseUtilities du = new DatabaseUtilities ();
				string email = du.GetEmailByUserID (txtID.Text);
				lblOutput.Text = email;
			} catch (Exception ex) {
				lblOutput.Text = ex.Message;
			}
		}
	}
}