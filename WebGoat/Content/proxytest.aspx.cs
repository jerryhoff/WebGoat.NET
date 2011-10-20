using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET
{
    public partial class proxytest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReverse_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;

            txtName.Text = "";

            lblOutput.Text = "Thank you for submitting your character-only name " + name;
        
        }
        private string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }
    }
}