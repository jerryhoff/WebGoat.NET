using System;
using System.Web;
using System.Web.UI;

namespace OWASP.WebGoat.NET.Content
{
    public partial class MessageDigest : System.Web.UI.Page
    {
        
        public void Page_Load(object sender, EventArgs args)
        {
            lblTest.Text = "Whoa this works!";
        }

    }    
}

