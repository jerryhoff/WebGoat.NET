using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;
//using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace OWASP.WebGoat.NET
{
	public class Old_DatabaseUtilities
	{
        
        //private SqliteConnection conn = null;
        //private string GoatDBFile = HttpContext.Current.Server.MapPath ("~/App_Data/") + "goatdb.sqlite";
			
        //private SqliteConnection GetGoatDBConnection ()
        //{
        //    if (conn == null) {
        //        //set the physical path to the SQLite database
        //        string connectionstring = "Data Source=" + GoatDBFile;
				
        //        //create the connection
        //        conn = new SqliteConnection (connectionstring);
        //        conn.Open ();
        //    }
        //    return conn;
        //}


        public Boolean RecreateGoatDB() { return true; }

        public string Test()
        {

            string MyConString = "SERVER=localhost;PORT=3306;" +
                "DATABASE=webgoat_coins;" +
                "UID=root;";// +
                //"PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "select * from employees limit 5";
            connection.Open();
            Reader = command.ExecuteReader();
            
            string thisrow = " ";
             
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ",";
            }
            connection.Close();
            return thisrow;
            
			/*
            string MyConString = "SERVER=localhost;" +
                "DATABASE=employees;" +
                "UID=root;" +
                "PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "select * from employees limit 5";
            connection.Open();
            Reader = command.ExecuteReader();
            
            string thisrow = " ";
             
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ",";
            }
            connection.Close();
            return thisrow;
            */
        }

	
        //public Boolean RecreateGoatDB ()
        //{
        //    if (File.Exists (GoatDBFile)) 
        //        File.Delete (GoatDBFile);
			
        //    SqliteConnection.CreateFile (GoatDBFile);
        //    SqliteConnection cn = GetGoatDBConnection ();
        //    CreateTables (cn);
        //    AddDataToTables (cn);
        //    //create the tables
        //    cn.Close ();
        //    return true;			
        //}
		
        //public void RunSQLFromFile (SqliteConnection cn, String filename)
        //{
        //    using (FileStream fs = new FileStream(filename, FileMode.Open)) {
        //        using (StreamReader sr = new StreamReader(fs, Encoding.UTF8)) {
        //            String line = String.Empty;
        //            while ((line = sr.ReadLine ()) != null) {
        //                line = line.Trim ();
        //                if (line.StartsWith ("--"))
        //                    continue;
        //                DoNonQuery (line, cn);
        //            }
        //        }
        //    }	
        //}
		
        //public void CreateTables (SqliteConnection cn)
        //{
        //    String filename = HttpContext.Current.Server.MapPath ("~/App_Data/") + "tables.sql";
        //    RunSQLFromFile (cn, filename);
        //}
		
        //public void AddDataToTables (SqliteConnection cn)
        //{
        //    String filename = HttpContext.Current.Server.MapPath ("~/App_Data/") + "tabledata.sql";
        //    RunSQLFromFile (cn, filename);
        //}
		
        //private string DoNonQuery (String SQL, SqliteConnection conn)
        //{
        //    var cmd = new SqliteCommand (SQL, conn);
        //    var output = string.Empty;
			
        //    try {
        //        cmd.ExecuteNonQuery ();
        //        output += "<br/>SQL Executed: " + SQL;
        //    } catch (SqliteException ex) {
        //        output += "<br/>SQL Exception: " + ex.Message;
        //        output += SQL;
        //    } catch (Exception ex) {
        //        output += "<br/>Exception: " + ex.Message;
        //        output += SQL;
        //    }
        //    return output;
        //}
		
        //private string DoScalar (String SQL, SqliteConnection conn)
        //{
        //    var cmd = new SqliteCommand (SQL, conn);
        //    var output = string.Empty;
			
        //    try {
        //        output = (string)cmd.ExecuteScalar ();
        //    } catch (SqliteException ex) {
        //        output += "<br/>SQL Exception: " + ex.Message + " - ";
        //        output += SQL;
        //    } catch (Exception ex) {
        //        output += "<br/>Exception: " + ex.Message + " - ";
        //        output += SQL;
        //    }
        //    return output;
        //}
        ///*
        //private DataTable DoQuery (string SQL)
        //{			
        //    string GoatDBFile = "URI=file:" + HttpContext.Current.Server.MapPath ("~/App_Data/") + "goatdb.sqlite";
        //    var cn = new System.Data.SQLite.SQLiteConnection (GoatDBFile);
        //    cn.Open ();
			
        //    var da = new System.Data.SQLite.SQLiteDataAdapter (SQL, cn);
        //    var dt = new DataTable ();
        //    da.Fill (dt);
        //    cn.Close ();
        //    return dt;
        //}
        //*/
		
		
        ////this SQLite provider does not support datatables, so dumping query contents into a string
        ////TODO change this so there is no formatting
        ////TODO send back as an array or a dictionary or something
        ////TODO Do formatting in the page itself
        ///*
        //private string DoQuery (string SQL, SqliteConnection conn)
        //{
        //    string result = string.Empty;
        //    var cmd = new SqliteCommand (SQL, conn);
        //    using (var reader = cmd.ExecuteReader ()) {
        //        while (reader.Read ()) {
        //            for (int i = 0; i < reader.FieldCount; ++i) {
        //                result += "<b>" + reader.GetName (i) + "</b>: " + reader [i] + "<br/>";
        //            }
        //            result += "<p/>";
        //        }
        //    }
			
        //    return result;
        //}
        //*/
        //private DataTable DoQuery (string SQL, SqliteConnection conn)
        //{
        //    var cmd = new SqliteCommand (SQL, conn);
        //    DataTable dt = new DataTable ();
        //    using (var reader = cmd.ExecuteReader ()) {
				
        //        // Add all the columns.
        //        for (int i = 0; i < reader.FieldCount; i++) {
        //            DataColumn col = new DataColumn ();
        //            col.DataType = reader.GetFieldType (i);
        //            col.ColumnName = reader.GetName (i);
        //            dt.Columns.Add (col);
        //        }
				
				
        //        while (reader.Read()) {
        //            DataRow row = dt.NewRow ();
        //            for (int i = 0; i < reader.FieldCount; i++) {
        //                // Ignore Null fields.
        //                if (reader.IsDBNull (i))
        //                    continue;

        //                if (reader.GetFieldType (i) == typeof(String)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetString (i);
        //                } else if (reader.GetFieldType (i) == typeof(Int16)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetInt16 (i);
        //                } else if (reader.GetFieldType (i) == typeof(Int32)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetInt32 (i);
        //                } else if (reader.GetFieldType (i) == typeof(Int64)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetInt64 (i);
        //                } else if (reader.GetFieldType (i) == typeof(Boolean)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetBoolean (i);
        //                } else if (reader.GetFieldType (i) == typeof(Byte)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetByte (i);
        //                } else if (reader.GetFieldType (i) == typeof(Char)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetChar (i);
        //                } else if (reader.GetFieldType (i) == typeof(DateTime)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetDateTime (i);
        //                } else if (reader.GetFieldType (i) == typeof(Decimal)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetDecimal (i);
        //                } else if (reader.GetFieldType (i) == typeof(Double)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetDouble (i);
        //                } else if (reader.GetFieldType (i) == typeof(float)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetFloat (i);
        //                } else if (reader.GetFieldType (i) == typeof(Guid)) {
        //                    row [dt.Columns [i].ColumnName] = reader.GetGuid (i);
        //                }
        //            }

        //            dt.Rows.Add (row);
        //        }
        //    }
			
        //    return dt;
        //}
        public string GetEmailByUserID(string userid) { return null; }
        //public string GetEmailByUserID (string userid)
        //{
        //    if (userid.Length > 4)
        //        userid = userid.Substring (0, 4);
        //    String output = (String)DoScalar ("SELECT Email FROM UserList WHERE UserID = '" + userid + "'", GetGoatDBConnection ());
        //    if (output != null)
        //        return output;
        //    else 
        //        return "Email for userid: " + userid + " not found<p/>";
        //}
        public DataTable GetMailingListInfoByEmailAddress(string email) { return null; }
        //public DataTable GetMailingListInfoByEmailAddress (string email)
        //{
        //    string sql = "SELECT FirstName, LastName, Email FROM MailingList where Email = '" + email + "'";
        //    DataTable result = DoQuery (sql, GetGoatDBConnection ());
        //    return result;
        //}
        public string AddToMailingList(string first, string last, string email) { return null; }
        //public string AddToMailingList (string first, string last, string email)
        //{
        //    string sql = "insert into mailinglist (firstname, lastname, email) values ('" + first + "', '" + last + "', '" + email + "')";
        //    string result = DoNonQuery (sql, GetGoatDBConnection ());
        //    return result;
        //}
        public DataTable GetAllPostings() { return null; }
        //public DataTable GetAllPostings ()
        //{
        //    string sql = "SELECT Title, Email, Message FROM Postings";
        //    DataTable result = DoQuery (sql, GetGoatDBConnection ());
        //    return result;
        //}
        public string AddNewPosting(String title, String email, String message) { return null; }
        //public string AddNewPosting (String title, String email, String message)
        //{
        //    string sql = "insert into Postings(title, email, message) values ('" + title + "','" + email + "','" + message + "')";
        //    string result = DoNonQuery (sql, GetGoatDBConnection ());
        //    return result;
        //}
        public DataTable GetPostingLinks() { return null; }
        //public DataTable GetPostingLinks ()
        //{
        //    string sql = "SELECT PostingID, Title FROM Postings";
        //    DataTable result = DoQuery (sql, GetGoatDBConnection ());
        //    return result;
        //}

        public DataTable GetPostingByID(int id) { return null; }

        //public DataTable GetPostingByID(int id)
        //{
        //    string sql = "SELECT Title, Email, Message FROM Postings where PostingID=" + id;
        //    DataTable result = DoQuery (sql, GetGoatDBConnection ());
        //    return result;
        //}
		
	}
}