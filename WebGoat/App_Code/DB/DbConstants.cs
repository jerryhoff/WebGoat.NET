using System;

namespace OWASP.WebGoat.NET.App_Code.DB
{
    public class DbConstants
    {
        //Keys
        public const string KEY_DB_TYPE = "dbtype";
        public const string KEY_HOST = "host";
        public const string KEY_PORT = "port";
        public const string KEY_FILE_NAME = "filename";
        public const string KEY_DATABASE = "database";
        public const string KEY_UID = "uid";
        public const string KEY_PWD = "pwd";
            
        //DB Types
        public const string DB_TYPE_MYSQL = "MySql";
        public const string DB_TYPE_SQLITE = "Sqlite";
        public const string CONFIG_EXT = "config";
            
    }
}
