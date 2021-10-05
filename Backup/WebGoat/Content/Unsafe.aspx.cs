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
            const string msg = "passwor";
            const int INPUT_LEN = 256;
            char[] fixedChar = new char[INPUT_LEN];

            for (int i = 0; i < fixedChar.Length; i++)
                fixedChar[i] = '\0';

            fixed (char* revLine = fixedChar)
            {
                int lineLen = txtBoxMsg.Text.Length;

                for (int i = 0; i < lineLen; i++)
                    *(revLine + i) = txtBoxMsg.Text[lineLen - i - 1];

                char* revCur = revLine;

                lblReverse.Text = string.Empty;
                while (*revCur != '\0')
                    lblReverse.Text += (char)*revCur++;
            }
        }
    }
}

