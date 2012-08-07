using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET
{
	public partial class StoredXSS : System.Web.UI.Page
	{
        private IDbProvider du = Settings.CurrentDbProvider;
        
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
            DataSet ds = du.GetComments("user_cmt");
            string comments = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                comments += "<strong>Email:</strong>" + row["email"] + "<span style='font-size: x-small;color: #E47911;'> (Email Address Verified!) </span><br/>";
                comments += "<strong>Comment:</strong><br/>" + row["comment"] + "<br/><hr/>";

            }
            lblComments.Text = comments;
        }

        void FixedLoadComments()
        {
            DataSet ds = du.GetComments("user_cmt");
            string comments = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                comments += "<strong>Email:</strong>" + Server.HtmlEncode(row["email"].ToString()) + "<span style='font-size: x-small;color: #E47911;'> (Email Address Verified!) </span><br/>";
                comments += "<strong>Comment:</strong><br/>" + Server.HtmlEncode(row["comment"].ToString()) + "<br/><hr/>";

            }
            lblComments.Text = comments;
        }
	}
}