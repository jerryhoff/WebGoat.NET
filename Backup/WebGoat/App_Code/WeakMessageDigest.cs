using System;
using System.Text;
using log4net;
using System.Reflection;

namespace OWASP.WebGoat.NET.App_Code
{
    public class WeakMessageDigest
    {
        private static readonly ASCIIEncoding ascii = new ASCIIEncoding();
        
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string GenerateWeakDigest(string msg)
        {
            string[] tokens = msg.Split(new[] { ' ' });

            byte[] bytes = new byte[tokens.Length];

            for(int i=0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                bytes[i] = GenByte(token);
            }

            log.Debug(string.Format("Bytes for {0}...", msg));
            log.Debug(Print(bytes));

            return ascii.GetString(bytes);
        }

        //Algo is dead simple. Just sum up the ASCII value and mod back to a printable char.
        public static byte GenByte(string word)
        {
            int val = 0;
            byte bVal;

            foreach(char c in word)
                val += (byte) c;

            //NOTE: Need to be between 32 and 126 in the ASCII table to be printable
            bVal = (byte) (val % (127 - 32 -1) + 33);

            return bVal;
        }

        private static string Print(byte[] bytes)
        {
            StringBuilder strBuild = new StringBuilder();

            foreach(byte b in bytes)
                strBuild.AppendFormat("{0},", b);

            return strBuild.ToString();
        }
    }

}
 
