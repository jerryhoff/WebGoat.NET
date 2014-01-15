using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public partial class UploadPathManipulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/WebGoatCoins/uploads/") + filename);
                    labelUpload.Text = "<div class='success' style='text-align:center'>The file " + FileUpload1.FileName + " has been saved in to the WebGoatCoins/uploads directory</div>";
                    
                }
                catch (Exception ex)
                {
                    labelUpload.Text = "<div class='error' style='text-align:center'>Upload Failed: " + ex.Message + "</div>";
                }
                finally
                {
                    labelUpload.Visible = true;
                }
            }
        }
    }
}