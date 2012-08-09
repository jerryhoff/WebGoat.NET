using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OWASP.WebGoat.NET
{
    public partial class ExploitDebug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void btnGo_Click(object sender, EventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            
            strBuilder.AppendFormat("Current Dir: {0}", Environment.CurrentDirectory);
            strBuilder.AppendLine();
            
            strBuilder.AppendFormat("UserName: {0}", Environment.UserName);
            strBuilder.AppendLine();
            
            strBuilder.AppendFormat("Machine Name: {0}", Environment.MachineName);
            strBuilder.AppendLine();
            
            strBuilder.AppendFormat("OS Version: {0}", Environment.OSVersion);
            strBuilder.AppendLine();
            
            throw new Exception(strBuilder.ToString());
        }
    }
}
