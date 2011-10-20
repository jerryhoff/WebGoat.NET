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
			try {
				DatabaseUtilities du = new DatabaseUtilities ();
				DataTable dt = du.GetMailingListInfoByEmailAddress (txtEmail.Text);
				string output = string.Empty;
				if (dt.Rows.Count > 0) {
					lblOutput.Text += "You are already on the list!<p/>";
					foreach (DataRow row in dt.Rows) {
						foreach (DataColumn col in dt.Columns) {
							output += "<b><i>" + col.ColumnName + "</i></b>: " + row [col.ColumnName] + "<br/>";
						}
						output += "<p/>";
					}
					lblOutput.Text += output;
				} else {
					string result = du.AddToMailingList (txtFirst.Text, txtLast.Text, txtEmail.Text);
					lblOutput.Text = result;
				}
			} catch (Exception ex) {
				lblOutput.Text = ex.Message;
			}
				
			/*else {
                
				bool result = du.AddToMailingList (txtFirst.Text, txtLast.Text, txtEmail.Text);
				if (result == true)
					lblOutput.Text = "You have been added!";
				else
					lblOutput.Text = "Oops, an error occurred - you were NOT added to our mailing list.  Please try again";
			}*/
            
		}
	}
}