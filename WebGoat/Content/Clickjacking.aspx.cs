using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace OWASP.WebGoat.NET
{
    public partial class Clickjacking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Match match = Regex.Match(user_input, "^[\\p{L} .'-]+$", RegexOptions.IgnoreCase);
            //return match.Success;
        }
        
        protected void btnGo_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString();
            HttpCookie myCookie = new HttpCookie("ClickJackingTest");
            myCookie["LastOrder"] = time;
            myCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(myCookie);
            labelMessage.Text = "Order Placed at " + time;
        }

        protected void lnkReset_Click1(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("ClickJackingTest");
            myCookie["LastOrder"] = "Never";
            myCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(myCookie);
            labelMessage.Text = "Order History Erased";
        }

        protected void labelMessage_Load(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        protected void UpdateLabel()
        {
            if (Request.Cookies["ClickJackingTest"] != null)
            {
                string lastorder;
                if (Request.Cookies["ClickJackingTest"]["LastOrder"] != null)
                {
                    lastorder = Request.Cookies["ClickJackingTest"]["LastOrder"];
                    //labelMessage.Text = "Last Order Date on File: " + lastorder;
                }
                //else
                    //labelMessage.Text = "No Recent Orders on File";
            }

        }
    }
}