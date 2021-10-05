using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace OWASP.WebGoat.NET
{
    public partial class XPathInjection : System.Web.UI.Page
    {
        // Make into actual lesson
        private string xml = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><sales><salesperson><name>David Palmer</name><city>Portland</city><state>or</state><ssn>123-45-6789</ssn></salesperson><salesperson><name>Jimmy Jones</name><city>San Diego</city><state>ca</state><ssn>555-45-6789</ssn></salesperson><salesperson><name>Tom Anderson</name><city>New York</city><state>ny</state><ssn>444-45-6789</ssn></salesperson><salesperson><name>Billy Moses</name><city>Houston</city><state>tx</state><ssn>333-45-6789</ssn></salesperson></sales>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["state"] != null)
            {
                FindSalesPerson(Request.QueryString["state"]);
            }
        }

        private void FindSalesPerson(string state)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XmlNodeList list = xDoc.SelectNodes("//salesperson[state='" + state + "']");
            if (list.Count > 0)
            {

            }

        }
    }
}

