using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OWASP.WebGoat.NET
{
	public partial class StoredXSS : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{
			if (Request ["id"] == null)
				RefreshListings ();
			else
				DisplayMessage ();
		}

		protected void btnAdd_Click (object sender, EventArgs e)
		{
			
			DatabaseUtilities du = new DatabaseUtilities ();
			du.AddNewPosting (txtTitle.Text, txtEmail.Text, txtMessage.Text);
			RefreshListings ();
			//lblOutput.Text = result;
		}

		void RefreshListings ()
		{
			DatabaseUtilities du = new DatabaseUtilities ();
			DataTable posts = du.GetAllPostings ();
			
			string output = string.Empty;
			foreach (DataRow dr in posts.Rows) {
				foreach (DataColumn col in posts.Columns) {
					output += "<b><i>" + col.ColumnName + "</i></b>: " + dr [col.ColumnName] + "<br/>";
				}
				output += "<p/>";
			}
			lblOutput.Text = output;
		}

		void DisplayMessage ()
		{
			/*
            if (Request["id"] != null)
            {
                try
                {
                    int id = int.Parse(Request["id"]);
                    DatabaseUtilities du = new DatabaseUtilities();
                    DataSet ds = du.GetPostingByID(id);
                    dtlView.DataSource = ds;
                    dtlView.DataBind();
                    RefreshListings();
                }
                catch (Exception ex)
                {
                    lblOutput.Text = "Error: " + ex.Message;
                }
            }
            */
		}
	}
}