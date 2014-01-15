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
	public partial class ReflectedXSS : System.Web.UI.Page
	{
        private IDbProvider du = Settings.CurrentDbProvider;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["city"] != null)
                LoadCity(Request["city"]);
        }

		void LoadCity (String city)
		{
            DataSet ds = du.GetOffice(city);
            lblOutput.Text = "Here are the details for our " + city + " Office";
            dtlView.DataSource = ds.Tables[0];
            dtlView.DataBind();
		}

        void FixedLoadCity (String city)
        {
            DataSet ds = du.GetOffice(city);
            lblOutput.Text = "Here are the details for our " + Server.HtmlEncode(city) + " Office";
            dtlView.DataSource = ds.Tables[0];
            dtlView.DataBind();
        }
	}
}