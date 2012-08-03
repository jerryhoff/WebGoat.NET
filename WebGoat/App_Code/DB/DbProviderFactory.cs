using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OWASP.WebGoat.NET.App_Code.DB
{
	//NOT THREAD SAFE!
	public class DbProviderFactory
	{
		private static Dictionary<Type, IDbProvider> _providers= new Dictionary<Type, IDbProvider>();
		
		public static IDbProvider CreateMySqlDbProvider()
		{
			if (_providers.ContainsKey(typeof(MySqlDbProvider)))
			    return _providers[typeof(MySqlDbProvider)];
			    
			//TODO: Need to fill in implementation
			
			Debug.Assert(_providers.ContainsKey(typeof(MySqlDbProvider)));
			
			throw new NotImplementedException();
		}
		
		public static IDbProvider CreateSqliteProvider()
		{
			if (_providers.ContainsKey(typeof(SqliteDbProvider)))
			    return _providers[typeof(SqliteDbProvider)];
			    
			//TODO: Need to fill in implementation
			
			Debug.Assert(_providers.ContainsKey(typeof(SqliteDbProvider)));
			
			throw new NotImplementedException();
		}
        
        public static IDbProvider CreateDummyDbProvider()
        {
            if (!_providers.ContainsKey(typeof(DummyDbProvider)))
                _providers[typeof(DummyDbProvider)] = new DummyDbProvider();
                
            return _providers[typeof(DummyDbProvider)];
        }
	}
}