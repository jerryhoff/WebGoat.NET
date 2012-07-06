using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OWASP.WebGoat.NET
{
	public partial class ReflectedXSS : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["city"] != null)
                LoadCity(Request["city"]);
        }

		void LoadCity (String city)
		{
            DatabaseUtilities du = new DatabaseUtilities(Server);
            DataSet ds = du.GetOffice(city);
            lblOutput.Text = "Here are the details for our " + city + " Office";
            dtlView.DataSource = ds.Tables[0];
            dtlView.DataBind();
		}
	}
}