using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OWASP.WebGoat.NET.App_Code
{
    public class ConfigFile
    {
        private string _filePath;
        
        private IDictionary<string, string> _settings = new Dictionary<string, string>();
        private IDictionary<string, string> _settingComments = new Dictionary<string, string>();
               
        private UTF8Encoding _encoding = new UTF8Encoding();
            
        private const char SPLIT_CHAR = '=';
        
        public ConfigFile(string fileName)
        {
            _filePath = fileName;
        }
            
        //TODO: Obviously no checks for problems, so when you get time do it like bhudda.
        public void Load()
        {
            string comment = string.Empty;
            
            //It's all or nothing here buddy.
            foreach (string line in File.ReadAllLines(_filePath))
            {
                
                if (line.Length == 0)
                    continue;
                
                if (line[0] == '#')
                {
                    comment = line;
                    continue;
                }
                 
                string[] tokens = line.Split(SPLIT_CHAR);
                
                if (tokens.Length >=2)
                {
                    string key = tokens[0].ToLower();
                    _settings[key] = tokens[1];
                    
                    if (!string.IsNullOrEmpty(comment))
                        _settingComments[key] = comment;
                }   
            
                comment = string.Empty;        
            }
        }
            
        public void Save()
        {
            using (FileStream stream = File.Create(_filePath))
            {
                byte[] data = ToByteArray();
                
                stream.Write(data, 0, data.Length);
            }
        }
            
        private byte[] ToByteArray()
        {
            StringBuilder builder = new StringBuilder();
                
            foreach (var pair in _settings)
            {
                if (_settingComments.ContainsKey(pair.Key))
                {
                    builder.Append(_settingComments[pair.Key]);
                    builder.AppendLine();
                }
                
                builder.AppendFormat("{0}={1}", pair.Key, pair.Value);
                builder.AppendLine();
            }
                
            return _encoding.GetBytes(builder.ToString());
        }
            
        public string Get(string key)
        {
            key = key.ToLower();
            
            if (_settings.ContainsKey(key))
                return _settings[key];
                    
            return string.Empty;
        }
            
        public void Set(string key, string value)
        {
            _settings[key.ToLower()] = value;
        }

        public void Remove(string key)
        {
            _settings.Remove(key.ToLower());
        }
    }
}

