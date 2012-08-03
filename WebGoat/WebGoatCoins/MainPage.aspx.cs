using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET
{
    public partial class MainPage : System.Web.UI.Page
    {
        //TODO: Add "welcome back " + name;
        //TODO: pending orders?
        //TODO: Add "WebGoat Coins Info Center"
        //TODO: Take out monthly special, add "hear what our customers are saying" - with the latest comments.  Add date field to comments??


        private IDbProvider du = Settings.CurrentDbProvider;

        protected void Page_Load(object sender, EventArgs e)
        {
            labelUpload.Visible = false;
            if (Request.Cookies["customerNumber"] != null)
            {
                string customerNumber = Request.Cookies["customerNumber"].Value;

                DataSet ds = du.GetCustomerDetails(customerNumber);
                DataRow row = ds.Tables[0].Rows[0]; //customer row

                Image1.ImageUrl = "images/logos/" + row["logoFileName"];

                foreach (DataColumn col in ds.Tables[0].Columns)
                {
                    TableRow tablerow = new TableRow();
                    tablerow.ID = col.ColumnName.ToString();

                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.Text = col.ColumnName.ToString();
                    cell2.Text = row[col].ToString();
                    
                    tablerow.Cells.Add(cell1);
                    tablerow.Cells.Add(cell2);
                    
                    CustomerTable.Rows.Add(tablerow);
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/WebGoatCoins/uploads/") + filename);
                    
                }
                catch (Exception ex)
                {
                    labelUpload.Text = "Upload Failed: " + ex.Message;
                }
                finally
                {
                    labelUpload.Visible = true;
                }
            }
        }
    }
}

