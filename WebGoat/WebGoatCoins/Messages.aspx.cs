using System;
using System.Data;
using System.Web.UI;
using OWASP.WebGoat.NET.App_Code;
using OWASP.WebGoat.NET.App_Code.DB;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class Messages : Page
    {
        private IDbProvider du = Settings.CurrentDbProvider;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["messages"] as string))
            {
                DataSet ds = du.GetMessages(User.Identity.Name);
                string messages = string.Empty;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    messages += "<strong>" + Server.HtmlEncode(row["title"].ToString()) + "</strong><br/>";
                    messages += Server.HtmlEncode(row["text"].ToString()) + "<br/><hr/>";
                }

                Session["messages"] = messages;
            }

            lblMessages.Text = (string)Session["messages"];
        }
    }
}