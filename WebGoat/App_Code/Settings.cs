using System;
using OWASP.WebGoat.NET.App_Code.DB;

namespace OWASP.WebGoat.NET.App_Code
{
    public class Settings
    {
       
        public static void Init()
        {
            CurrentDbProvider = DbProviderFactory.CreateDummyDbProvider();
        }
        
        public static IDbProvider CurrentDbProvider { get; set; }

    }
}