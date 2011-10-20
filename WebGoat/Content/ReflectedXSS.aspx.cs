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
		protected void Page_Load (object sender, EventArgs e)
		{
			if (Request ["classifiedID"] == null)
				RefreshListings ();
			else
				DisplayMessage ();
		}

		void RefreshListings ()
		{
			DatabaseUtilities du = new DatabaseUtilities ();
			DataTable dt = du.GetPostingLinks ();
			int i = 0;
			foreach (DataRow dr in dt.Rows) {
					HyperLink HL = new HyperLink();
	            	HL.ID = "HyperLink" + i++;
	            	HL.Text = dr[1].ToString();
	            	HL.NavigateUrl = Request.FilePath + "?classifiedID="+ dr[0];
	            	ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("BodyContentPlaceholder");
	            	cph.Controls.Add(HL);
	            	cph.Controls.Add(new LiteralControl("<br/>"));
			}
			
		}
		
		void DisplayMessage ()
		{
            try
            {
                int id = int.Parse(Request["classifiedID"]);
                DatabaseUtilities du = new DatabaseUtilities();
                DataTable dt = du.GetPostingByID(id);
                dtlView.DataSource = dt;
                dtlView.DataBind();
                RefreshListings();
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Record " + Request["classifiedID"] + " not found";
                Console.WriteLine(ex.Message);
            }
     
		}
	}
}