using System;
using System.Collections.Generic;
using System.Diagnostics;
using log4net;
using System.Reflection;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    //NOT THREAD SAFE!
    public class DbProviderFactory
    {
        private static DummyDbProvider _dummyProvider = new DummyDbProvider();
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public static IDbProvider Create(string filePath)
        {
            ConfigFile configFile = new ConfigFile(filePath);
            
            configFile.Load();
            
            switch (configFile.Get(DbConstants.KEY_DB_TYPE))
            {
                case DbConstants.DB_TYPE_MYSQL:
                    return CreateMySqlDbProvider(configFile);
                case DbConstants.DB_TYPE_SQLITE:
                    return CreateSqliteProvider(configFile);
                default:
                    log.Info("Empty DB Type. Returning Dummy provider");        
                    return _dummyProvider;
            }
        }
        
        private static IDbProvider CreateMySqlDbProvider(ConfigFile configFile)
        {
            log.Info("Creating MySql Provider");
                                                             
            IDbProvider provider = new MySqlDbProvider();
            provider.DbConfigFile = configFile;
            
            return provider;
        }
        
        private static IDbProvider CreateSqliteProvider(ConfigFile configFile)
        {
            log.Info("Creating Sqlite Provider");
            
            throw new NotImplementedException();
        }
    }
}