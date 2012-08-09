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
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public static IDbProvider Create(ConfigFile configFile)
        {
            configFile.Load();

            string dbType = configFile.Get(DbConstants.KEY_DB_TYPE);

            log.Info("Creating provider for" + dbType);

            switch (dbType)
            {
                case DbConstants.DB_TYPE_MYSQL:
                    return new MySqlDbProvider(configFile);
                case DbConstants.DB_TYPE_SQLITE:
                    return new SqliteDbProvider(configFile);
                default:
                    throw new Exception(string.Format("Don't know Data Provider type {0}", dbType));
            }
        }
    }
}