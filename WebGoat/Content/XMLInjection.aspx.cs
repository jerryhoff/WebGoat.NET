using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using System.IO;
using System.Text;

namespace OWASP.WebGoat.NET
{
    public partial class XMLInjection : System.Web.UI.Page
    {
        List<XmlUser> users;
        protected void Page_Load(object sender, EventArgs e)
        {


            ReadXml();

            gvUsers.DataSource = users.ToArray();
           
            gvUsers.DataBind();

/*<?xml version="1.0" standalone="yes"?>
<users>
  <user>
    <name>Todd Smith</name>
    <email>todd@example.com</email>
  </user>
  <user>
    <name>Al Thompson</name>
    <email>al@example.com</email>
  </user>
</users>
*/

            //Need to add lesson!
            if (Request.QueryString["name"] != null && Request.QueryString["email"] != null)
            {
                users.Add(new XmlUser(Request.QueryString["name"], Request.QueryString["email"]));
                WriteXML();
            }
        }

        private void ReadXml()
        {
            users = new List<XmlUser>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("/App_Data/XmlInjectionUsers.xml"));
            foreach (XmlNode node in doc.ChildNodes[1].ChildNodes)
            {
                if (node.Name == "user")
                {
                    users.Add(new XmlUser(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText));
                }
            }
        }

        private void WriteXML()
        {
            string xml = "<?xml version=\"1.0\" standalone=\"yes\"?>"+ Environment.NewLine +"<users>" + Environment.NewLine;
            foreach (XmlUser user in users)
            {
                xml += "<user>" + Environment.NewLine;
                xml += "<name>" + user.Name + "</name>" + Environment.NewLine;
                xml += "<email>" + user.Email + "</email>" + Environment.NewLine;
                xml += "</user>" + Environment.NewLine;
            }
            xml += "</users>" +Environment.NewLine;

            XmlTextWriter writer = new XmlTextWriter(Server.MapPath("/App_Data/XmlInjectionUsers.xml"), Encoding.UTF8);
            writer.WriteRaw(xml);
            writer.Close();
        }
    }

    public class XmlUser
    {
        public string Name  { get; set; }
        public string Email { get; set; }

        public XmlUser(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
