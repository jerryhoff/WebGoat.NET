using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET
{
	public partial class ProxySetup : System.Web.UI.Page
	{
		protected void btnReverse_Click(object sender, EventArgs e)
        {
        
            var name = txtName.Text;
            txtName.Text = "";
            lblOutput.Text = "Thank you for using WebGoat.NET " + reverse(name);
        
        }
        
        private string reverse(string s)
        {
            //char[] charArray = s.ToCharArray();
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }
	
	}
}
