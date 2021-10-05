using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections.Specialized;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class Orders : System.Web.UI.Page
    {
    
        private IDbProvider du = Settings.CurrentDbProvider;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            DataSet ds;
            if (Request.Cookies["customerNumber"] == null || !int.TryParse(Request.Cookies["customerNumber"].Value.ToString(), out id))
                lblOutput.Text = "Sorry, an unspecified problem regarding your Customer ID has occurred.  Are your cookies enabled?";
            else
            {
                ds = du.GetOrders(id);

                if (!Page.IsPostBack) //generate the data grid
                {
                    GridView1.DataSource = ds.Tables[0];

                    GridView1.AutoGenerateColumns = false;

                    BoundField BoundFieldOrderNumber = new BoundField();
                    BoundField BoundFieldStatus = new BoundField();
                    BoundField BoundFieldRequiredDate = new BoundField();
                    BoundField BoundFieldShippedDate = new BoundField();

                    BoundFieldOrderNumber.DataField = "orderNumber";
                    BoundFieldStatus.DataField = "status";
                    BoundFieldRequiredDate.DataField = "requiredDate";
                    BoundFieldShippedDate.DataField = "shippedDate";

                    BoundFieldOrderNumber.HeaderText = "Order Number";
                    BoundFieldStatus.HeaderText = "Status";
                    BoundFieldRequiredDate.HeaderText = "Required Date";
                    BoundFieldShippedDate.HeaderText = "Shipped Date";

                    BoundFieldRequiredDate.DataFormatString = "{0:MM/dd/yyyy}";
                    BoundFieldShippedDate.DataFormatString = "{0:MM/dd/yyyy}";

                    GridView1.Columns.Add(BoundFieldOrderNumber);
                    GridView1.Columns.Add(BoundFieldStatus);
                    GridView1.Columns.Add(BoundFieldRequiredDate);
                    GridView1.Columns.Add(BoundFieldShippedDate);

                    GridView1.DataBind();
                }
                //check if orderNumber exists
                string orderNumber = Request["orderNumber"];
                if (orderNumber != null)
                {
                    try
                    {
                        //lblOutput.Text = orderNumber;
                        DataSet dsOrderDetails = du.GetOrderDetails(int.Parse(orderNumber));
                        DetailsView1.DataSource = dsOrderDetails.Tables[0];
                        DetailsView1.DataBind();
                        //litOrderDetails.Visible = true;
                        PanelShowDetailSuccess.Visible = true;

                        //allow customer to download image of their product
                        string image = dsOrderDetails.Tables[0].Rows[0]["productImage"].ToString();
                        HyperLink1.Text = "Download Product Image";
                        HyperLink1.NavigateUrl = Request.RawUrl + "&image=images/products/" + image;
                    }
                    catch (Exception ex)
                    {
                        //litOrderDetails.Text = "Error finding order number " + orderNumber + ". Details: " + ex.Message;
                        PanelShowDetailFailure.Visible = true;
                        litErrorDetailMessage.Text = "Error finding order number " + orderNumber + ". Details: " + ex.Message;
                    }
                }

                //check if they are trying to download the image
                string target_image = Request["image"];
                if (target_image != null)
                {
                    FileInfo fi = new FileInfo(Server.MapPath(target_image));
                    lblOutput.Text = fi.FullName;

                    NameValueCollection imageExtensions = new NameValueCollection();
                    imageExtensions.Add(".jpg", "image/jpeg");
                    imageExtensions.Add(".gif", "image/gif");
                    imageExtensions.Add(".png", "image/png");

                    Response.ContentType = imageExtensions.Get(fi.Extension);
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fi.Name);
                    Response.TransmitFile(fi.FullName);
                    Response.End();
                }

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //make the first column a hyperlink
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink link = new HyperLink();
                link.Text = e.Row.Cells[0].Text;
                link.NavigateUrl = "Orders.aspx?orderNumber=" + link.Text;
                e.Row.Cells[0].Controls.Add(link);
            }

        }
    }
}