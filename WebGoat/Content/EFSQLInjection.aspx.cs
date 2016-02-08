using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using OWASP.WebGoat.NET.Entities;

namespace OWASP.WebGoat.NET.Content
{
    public partial class EFSQLInjection : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            using (var db = new CoinsDB())
            {
                var code = txtOfficeCode.Text;
                var output = db.Database
                    .SqlQuery<string>("SELECT email FROM Employees " +
                                      "WHERE officeCode = {0}",
                                      code)
                    .ToArray();

                lblOutput.Text = output.Length == 0
                    ? "Not found email"
                    : String.Join("<br/>", output);
            }

        }
    }
}