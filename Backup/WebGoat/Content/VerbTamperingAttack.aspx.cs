
using System;
using System.Web;
using System.Web.UI;

namespace OWASP.WebGoat.NET
{
    public partial class VerbTamperingAttack : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["message"] != null)
            {
                VerbTampering.tamperedMessage = Request.QueryString["message"];
            }
        } 
    }
}

