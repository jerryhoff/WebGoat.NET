using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace OWASP.WebGoat.NET
{
    public partial class EncryptVSEncode : System.Web.UI.Page
    {
		enum WG_Hash {Sha1=1, Sha256};
		    
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGO_Click(object sender, EventArgs e)
        {
        	//url encoded
        	//base64
        	//sha1
        	//encryption with password
			
			string s = txtString.Text;
			//string p = txtPassword.Text;
			
        	Table t = new Table();
        	t.Width = new Unit("100%");
			
			t.Rows.Add(MakeRow("URL Encoded:", Server.UrlEncode(s)));
			t.Rows.Add(MakeRow("Base64 Encoded:", Base64(s)));
			t.Rows.Add(MakeRow("SHA1 Hashed:", SHA(s, WG_Hash.Sha1)));
			t.Rows.Add(MakeRow("SHA256 Hashed:", SHA(s, WG_Hash.Sha256)));
			
        
        	ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("BodyContentPlaceholder");
			cph.Controls.Add(new LiteralControl("<p/>"));
	        cph.Controls.Add(t);
	    
        
        }
        private TableRow MakeRow(string label, string val)
        {
        	TableRow row = new TableRow();
			
			TableCell t1 = new TableCell();
			t1.Text = label;
			row.Cells.Add(t1);
			
			TableCell t2 = new TableCell();
			t2.Text = val;
			row.Cells.Add(t2);
			return row;
        }
        
        private string Base64(string s)
    	{
      		byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(s);
      		return System.Convert.ToBase64String(bytes);
    	}
    	
    	private string SHA(string s, WG_Hash hash)
    	{
    		byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(s);
			byte[] result;
			HashAlgorithm sha;
			switch(hash){
				case WG_Hash.Sha1:
					sha = new SHA1Managed();
					break;
				case WG_Hash.Sha256:
					sha = new SHA256Managed();
					break;
			}
			result = sha.ComputeHash(bytes);
			return System.Convert.ToBase64String(result);
    	}
    }
}