using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Web.Security;

namespace OWASP.WebGoat.NET.App_Code
{
    public class Encoder
    {
        //use for encryption
        //encryption methods taken from: http://stackoverflow.com/questions/202011/encrypt-decrypt-string-in-net
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");


        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// DecryptStringAES().  The sharedSecret parameters must match.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
        public static string EncryptStringAES(string plainText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// EncryptStringAES(), using an identical sharedSecret.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        /// <summary>
        /// returns an base64 encoded string
        /// </summary>
        /// <param name="s">string to encode</param>
        /// <returns></returns>
        public static string Encode(string s)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            string output = System.Convert.ToBase64String(bytes);
            return output;
        }

        /// <summary>
        /// Converts a string from Base64
        /// </summary>
        /// <param name="s">Base64 encoded string</param>
        /// <returns></returns>
        public static String Decode(string s)
        {
            byte[] bytes = System.Convert.FromBase64String(s);
            string output = System.Text.Encoding.UTF8.GetString(bytes);
            return output;
        }


        /// <summary>
        /// From http://weblogs.asp.net/navaidakhtar/archive/2008/07/08/converting-data-table-dataset-into-json-string.aspx
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>string</returns>
        public static string ToJSONString(DataTable dt)
        {
            string[] StrDc = new string[dt.Columns.Count];

            string HeadStr = string.Empty;
            for (int i = 0; i < dt.Columns.Count; i++)
            {

                StrDc[i] = dt.Columns[i].Caption;
                HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";

            }

            HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);
            StringBuilder Sb = new StringBuilder();

            Sb.Append("{\"" + dt.TableName + "\" : [");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string TempStr = HeadStr;

                Sb.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    TempStr = TempStr.Replace(dt.Columns[j] + j.ToString() + "¾", dt.Rows[i][j].ToString());

                }
                Sb.Append(TempStr + "},");

            }
            Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));

            Sb.Append("]}");
            return Sb.ToString();
        }

        public static string ToJSONSAutocompleteString(string query, DataTable dt)
        {
            char[] badvalues = { '[', ']', '{', '}'};

            foreach (char c in badvalues)
                query = query.Replace(c, '#');

            StringBuilder sb = new StringBuilder();

            sb.Append("{\nquery:'" + query + "',\n");
            sb.Append("suggestions:[");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string email = row[0].ToString();
                sb.Append("'" + email + "',");
            }
            
            sb = new StringBuilder(sb.ToString().Substring(0, sb.ToString().Length - 1));
            sb.Append("],\n");
            sb.Append("data:" + sb.ToString().Substring(sb.ToString().IndexOf('['), (sb.ToString().LastIndexOf(']') - sb.ToString().IndexOf('[')) + 1) + "\n}");

            return sb.ToString();
        }

        public string EncodeTicket(string token)
        {
            FormsAuthenticationTicket ticket =
                new FormsAuthenticationTicket(
                    1, //version 
                    token, //token 
                    DateTime.Now, //issueDate
                    DateTime.Now.AddDays(14), //expireDate 
                    true, //isPersistent
                    "customer", //userData (customer role)
                    FormsAuthentication.FormsCookiePath //cookiePath
            );

            return FormsAuthentication.Encrypt(ticket); //encrypt the ticket
        }

    }
}