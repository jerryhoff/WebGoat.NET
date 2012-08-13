using System;
using System.Text;

namespace OWASP.WebGoat.NET.Content
{
    public partial class Unsafe : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs args)
        {
        }

        public unsafe void btnReverse_Click(object sender, EventArgs args)
        {
            const string msg = "Thanks for your input!";
            const int INPUT_LEN = 256;

            char* returnMsg = stackalloc char[msg.Length  + 1];
            char* revLine = stackalloc char[INPUT_LEN];

            char* msgCur = returnMsg;

            foreach (var c in msg)
                *msgCur++ = c;

            *msgCur = '\0';

            int lineLen = txtBoxMsg.Text.Length;

            try
            {
                for (int i = 0; i < lineLen; i++)
                    *(revLine + i) = txtBoxMsg.Text[lineLen - i - 1];

                *(revLine + lineLen) = '\0';
            }
            catch (Exception)
            {
                //Ignore overflow exception
            }

            char* revCur = revLine;

            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("Result: ");

            while (*revCur != '\0')
                strBuilder.Append((char) *revCur++);

            lblReverse.Text = strBuilder.ToString();

            msgCur = returnMsg;

            strBuilder = new StringBuilder();
            
            while (*msgCur != '\0')
                strBuilder.Append((char) *msgCur++);

            lblServMsg.Text = strBuilder.ToString();
        }
    }
}

