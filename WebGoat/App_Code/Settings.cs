using System;
using OWASP.WebGoat.NET.App_Code.DB;
using System.IO;
using System.Web;

namespace OWASP.WebGoat.NET.App_Code
{
    public class Settings
    {
        public static readonly string DefaultConfigName = string.Format("Default.{0}", DbConstants.CONFIG_EXT);
        
        public static void Init(HttpServerUtility server)
        {
            string configPath = Path.Combine(ParentConfigPath, DefaultConfigName);
            configPath = server.MapPath(configPath);
            
            string path = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", string.Format("{0}:/usr/local/mysql/bin", path));

            path = Environment.GetEnvironmentVariable("PATH");
            Environment.SetEnvironmentVariable("PATH", string.Format("{0}:/Applications/MAMP/Library/bin", path));

            CurrentDbProvider = DbProviderFactory.Create(configPath);
        }
        
        public static IDbProvider CurrentDbProvider { get; set; }

        public static string ParentConfigPath { get { return "Configuration"; } }

    }
}