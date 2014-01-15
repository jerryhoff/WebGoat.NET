using System;
using System.Web;
using System.Web.UI;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public partial class ReadlineDoS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblFileContent.Text = String.Empty;
            Stream fileContents = file1.PostedFile.InputStream;
        
            using (StreamReader reader = new StreamReader(fileContents))
            {
                while (!reader.EndOfStream)
                {
                    lblFileContent.Text += reader.ReadLine() + "<br />";
                }
            }
        }
    }
}

