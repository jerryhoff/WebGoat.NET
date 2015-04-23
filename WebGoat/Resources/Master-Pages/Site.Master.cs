using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code;
using OWASP.WebGoat.NET.App_Code.DB;

namespace OWASP.WebGoat.NET.resources.Master_Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected bool IsAdmin { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["showSplash"] == null)
            {
                Session["showSplash"] = false;
                Response.Redirect("~/Default.aspx");
            }

            if (Page.User.Identity.IsAuthenticated && Settings.CurrentDbProvider != null)
            {
                IsAdmin = Settings.CurrentDbProvider.IsAdminCustomerLogin(Page.User.Identity.Name);
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