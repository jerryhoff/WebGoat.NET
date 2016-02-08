using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code;
using OWASP.WebGoat.NET.App_Code.DB;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class Buy : Page
    {
        private IDbProvider du = Settings.CurrentDbProvider;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["id"] == null)
                    throw new Exception("Not valid request");

                var id = Request["id"];
                double price;
                string description;
                var html = GetProductContent(id, out description, out price);
                Session["buy_product_id"] = id;
                Session["buy_product_description"] = description;
                Session["buy_product_price"] = price;
                Session["buy_product_html"] = html;
                lblOutputStep0.Text = html;
            }
            else
            {
                switch (BuyWizard.ActiveStepIndex)
                {
                    case 0:
                        break;
                    case 1:
                        Session["buy_full_name"] = tbFullName.Text;
                        Session["buy_address"] = tbAddress.Text;
                        UpdatePriceIncludeShipping();
                        break;
                    case 2:
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        protected void OnActiveStepChanged(object sender, EventArgs e)
        {
            switch (BuyWizard.ActiveStepIndex)
            {
                case 0:
                    lblOutputStep0.Text = (string)Session["buy_product_html"];
                    break;
                case 1:
                    tbFullName.Text = (string)Session["buy_full_name"];
                    tbAddress.Text = (string)Session["buy_address"];
                    ddlCountry.SelectedValue = (string)Session["buy_country"];
                    UpdatePriceIncludeShipping();
                    break;
                case 2:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        protected void OnFinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Response.Redirect("~/WebGoatCoins/Invoice.aspx");
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceIncludeShipping();
        }

        private void UpdatePriceIncludeShipping()
        {
            Session["buy_country"] = ddlCountry.SelectedValue;
            if (ddlCountry.SelectedValue == "Australia")
            {
                Session["buy_shipping_price"] = 14.0;
            }
            else
            {
                Session["buy_shipping_price"] = 10.0;
            }

            Session["buy_total_price"] = ((double)Session["buy_product_price"] + (double)Session["buy_shipping_price"]);
            lblShippingPrice.Text = " $" + Session["buy_shipping_price"];
            lblTotalPrice.Text = " $" + Session["buy_total_price"];
        }

        private string GetProductContent(string id, out string description, out double price)
        {
            price = 0.0;
            description = String.Empty;
            var output = String.Empty;
            var ds = du.GetProductDetails(id);
            foreach (DataRow prodRow in ds.Tables["products"].Rows)
            {
                output += "<div class='product2' align='center'>";
                output += "<img src='./images/products/" + prodRow["productImage"] + "'/><br/>";
                output += "<strong>" + prodRow["productName"] + "</strong><br/>";
                output += "<hr/>" + prodRow["productDescription"] + "<br/>";
                output += "<hr/><strong>Product price:</strong> $" + prodRow["buyPrice"] + "<br/>";
                output += "</div>";

                price = (double)prodRow["buyPrice"];
                description = (string)prodRow["productName"];
            }

            return output;
        }
    }
}