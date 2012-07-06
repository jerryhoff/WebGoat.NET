using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public class IOHelper
    {
        private HttpServerUtility server = null;

        public IOHelper(HttpServerUtility server)
        {
            this.server = server;
        }

        private string ConfigFilePath
        {
            get
            {
                return server.MapPath("/Configuration/db-config.txt");
            }
        }

        public string ReadAllFromFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string data = sr.ReadToEnd();
            sr.Close();
            return data;
        }
        public string GetDBConfigString()
        {
            string config = ReadAllFromFile(this.ConfigFilePath);
            return config;
        }
        public string SaveDBConfigString(string server, string port, string database, string uid, string pwd)
        {
            try
            {
                //"SERVER=localhost;PORT=3306;DATABASE=webgoat_coins;UID=root;";
                string connect_string = String.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PWD={4}", server, port, database, uid, pwd);
                StreamWriter sw = new StreamWriter(this.ConfigFilePath, false);
                sw.WriteLine(connect_string);
                sw.Close();
            }
            catch (Exception ex)
            {
                //log
                return ex.Message;
            }
            return null;
        }
        public Dictionary<string, string> GetDBConfigDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string,string>();
            string conf = GetDBConfigString();
            char[] semincolon = {';'};
            string[] fields = conf.Split(semincolon);

            char[] equal_sign = {'='};
            foreach(string field in fields)
            {
                string[] name_value = field.Split(equal_sign);
                dictionary.Add(name_value[0], name_value[1]);
            }
            return dictionary;
        }

    }
}