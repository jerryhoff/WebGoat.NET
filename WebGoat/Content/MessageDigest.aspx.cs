using System;
using System.Web;
using System.Web.UI;
using OWASP.WebGoat.NET.App_Code;
using log4net;
using System.Reflection;

namespace OWASP.WebGoat.NET.Content
{
    public partial class MessageDigest : System.Web.UI.Page
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private const string MSG = "Well done! You can now consider yourself an expert hacker! Well almost. Surely this is an easy digest to break!";

        public void Page_Load(object sender, EventArgs args)
        {
            lblDigest.Text = WeakMessageDigest.GenerateWeakDigest(MSG);
        }

        public void btnDigest_Click(object sender, EventArgs args)
        {
            string result = WeakMessageDigest.GenerateWeakDigest(txtBoxMsg.Text);

            log.Info(string.Format("Result for {0} is: {1}", txtBoxMsg.Text, result));
            lblResultDigest.Text = result;
        }
    }    
}

