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
            lblMessage.Visible = false;
            txtEmail.Enabled = true;
            if (!Page.IsPostBack)
                LoadComments();

        }

        protected void btnSave_Click(object sender, EventArgs e)
		{
            try
            {
                DatabaseUtilities du = new DatabaseUtilities(Server);
                string error_message = du.AddComment("user_cmt", txtEmail.Text, txtComment.Text);
                txtComment.Text = error_message;
                lblMessage.Visible = true;
                LoadComments();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
            }
		}

        void LoadComments()
        {
            DatabaseUtilities du = new DatabaseUtilities(Server);   
            DataSet ds = du.GetComments("user_cmt");
            //string output = string.Empty;
            string comments = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                comments += "<strong>Email:</strong>" + row["email"] + "<span style='font-size: x-small;color: #E47911;'> (Email Address Verified!) </span><br/>";
                comments += "<strong>Comment:</strong><br/>" + row["comment"] + "<br/><hr/>";

            }
            lblComments.Text = comments;
        }
	}
}