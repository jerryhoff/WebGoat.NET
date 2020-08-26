using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public class IOHelper
    {
        public static string ReadAllFromFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string data = sr.ReadToEnd();
            sr.Close();
            return data;
        }
    }
}