using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET.resources.Master_Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			
        }
        protected void lbtGenerateTestData_Click(object sender, EventArgs e)
        {
        	Response.Redirect("Content/RebuildDatabase.aspx");
        }
    }
}