using System;
using OWASP.WebGoat.NET.App_Code.DB;
using System.IO;
using System.Web;
using log4net;
using System.Reflection;
using System.Diagnostics;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;

namespace OWASP.WebGoat.NET.App_Code
{
    public class Settings
    {
        public static readonly string DefaultConfigName = string.Format("Default.{0}", DbConstants.CONFIG_EXT);
        private const string PARENT_CONFIG_PATH = "Configuration";
        private const string DATA_FOLDER = "App_Data";
        private const string DEFAULT_SQLITE_NAME = "webgoat_coins.sqlite";

        private static object _lock = new object();
        private static bool _inited = false;

        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
  
        public static void Init(HttpServerUtility server)
        {
            lock (_lock)
            {
                if (Debugger.IsAttached)
                    BasicConfigurator.Configure();
                else
                    XmlConfigurator.Configure();

                string configPath = Path.Combine(PARENT_CONFIG_PATH, DefaultConfigName);
                DefaultConfigPath = server.MapPath(configPath);

                RootDir = server.MapPath(".");

                log.Debug("DYLD_FALLBACK_LIBRARY_PATH: " + Environment.GetEnvironmentVariable("DYLD_FALLBACK_LIBRARY_PATH"));
                log.Debug("PWD: " + Environment.CurrentDirectory);

                //By default if there's no config let's create a sqlite db.
                string defaultConfigPath = DefaultConfigPath;

                string sqlitePath = Path.Combine(DATA_FOLDER, DEFAULT_SQLITE_NAME);
                sqlitePath = server.MapPath(sqlitePath);

                if (!File.Exists(defaultConfigPath))
                {
                    ConfigFile file = new ConfigFile(defaultConfigPath);

                    file.Set(DbConstants.KEY_DB_TYPE, DbConstants.DB_TYPE_SQLITE);
                    file.Set(DbConstants.KEY_FILE_NAME, sqlitePath);
                    file.Save();

                    CurrentConfigFile = file;
                }
                else
                {
                    CurrentConfigFile = new ConfigFile(defaultConfigPath);
                    CurrentConfigFile.Load();
                }

                CurrentDbProvider = DbProviderFactory.Create(CurrentConfigFile);
                _inited = true;
            }

        }

        public static string RootDir { get; private set; }

        public static IDbProvider CurrentDbProvider { get; set; }

        public static string DefaultConfigPath { get; private set; }

        public static ConfigFile CurrentConfigFile { get; set; }

        public static bool Inited { get { lock (_lock) { return _inited; } } }
    }
}