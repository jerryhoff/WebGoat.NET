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
            if (Session["showSplash"] == null)
            {
                Session["showSplash"] = false;
                Response.Redirect("~/Default.aspx");
            }

        }
        protected void lbtGenerateTestData_Click(object sender, EventArgs e)
        {
        	Response.Redirect("/RebuildDatabase.aspx");
        }
        public void GreyOutMenu()
        {
            foreach (RepeaterItem item in rptrMenu.Items)
            {
                //nothing
            }
        }
    }
}