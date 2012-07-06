using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PanelForgotPasswordStep2.Visible = false;
                PanelForgotPasswordStep3.Visible = false;
            }
        }

        protected void ButtonCheckEmail_Click(object sender, EventArgs e)
        {
            DatabaseUtilities du = new DatabaseUtilities(Server);
            string result = du.GetSecurityQuestion(Response, txtEmail.Text);
            if (result == null)
            {
                labelQuestion.Text = "That email address was not found in our database!";
                PanelForgotPasswordStep2.Visible = false;
                PanelForgotPasswordStep3.Visible = false;
            }
            else
            {
                labelQuestion.Text = "Here is the question we have on file for you: <strong>" + result + "</strong>";
                PanelForgotPasswordStep2.Visible = true;
                PanelForgotPasswordStep3.Visible = false;
            }
        }

        protected void ButtonRecoverPassword_Click(object sender, EventArgs e)
        {
            try
            {
                //get the security question answer from the cookie
                string encrypted_password = Request.Cookies["encr_sec_qu_ans"].Value.ToString();
                
                //decode it (twice for extra security!)
                string security_answer = UtilitiesHelper.Decode(UtilitiesHelper.Decode(encrypted_password));
                
                if (security_answer.Trim().ToLower().Equals(txtAnswer.Text.Trim().ToLower()))
                {
                    PanelForgotPasswordStep1.Visible = false;
                    PanelForgotPasswordStep2.Visible = false;
                    PanelForgotPasswordStep3.Visible = true;
                    labelPassword.Text = "Security Question Challenge Successfully Completed! <br/>Your password is: " + getPassword(txtEmail.Text);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "An unknown error occurred - Do you have cookies turned on? Further Details: " + ex.Message;
            }
        }

        protected void ButtonGoToCustomerLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerLogin.aspx");
        }

        string getPassword(string email)
        {
            DatabaseUtilities du = new DatabaseUtilities(Server);
            string password = du.GetPasswordByEmail(email);
            return password;
        }

    }
}