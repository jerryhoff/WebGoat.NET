using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OWASP.WebGoat.NET
{
	public partial class SQLInjection : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{

		}

		protected void btnFind_Click (object sender, EventArgs e)
		{
            DatabaseUtilities du = new DatabaseUtilities(Server);
            string name = txtName.Text;
            DataSet ds = du.GetEmailByName(name);

            grdEmail.DataSource = ds.Tables[0];
            grdEmail.DataBind();

		}
	}
}