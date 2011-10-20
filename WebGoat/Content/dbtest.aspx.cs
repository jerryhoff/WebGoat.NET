using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;

namespace OWASP.WebGoat.NET
{
	public partial class RebuildDatabase : System.Web.UI.Page
	{
		   
		protected void Page_Load (object sender, EventArgs e)
		{
                        
		}

		protected void btnTest_Click (object sender, EventArgs e)
		{			

			DatabaseUtilities du = new DatabaseUtilities ();
			if (du.RecreateGoatDB ())
				lblOutput.Text = "DB Recreated";
			
            
		}
	}
}