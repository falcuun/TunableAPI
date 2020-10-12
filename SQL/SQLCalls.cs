using MySqlConnector;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TunableInterview
{

    public class SQLCalls
    {

        

        private static Dictionary<string, string> LoadCredentials()
        {
            Dictionary<string, string> items;
            using (StreamReader r = new StreamReader("Credentials.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }

            return items;
        }

        // Defines 'server' 'userid' 'password' and 'database' name of the database we want to connect to
        private static string GetCredentials()
        {
            Dictionary<string, string> credsList = LoadCredentials();
            return string.Format("server={0};userid={1};password={2};database={3}", credsList["Server"], credsList["UserID"], credsList["Password"], credsList["DBName"]);
        }

        // Opens the connection with the MySQL Database hosted on 'server'
        // Defined with 'database' tag in the provided string 
        // Using 'Userid' username and 'password' password
        private static MySqlConnection con = new MySqlConnection(GetCredentials());

        private static MySqlCommand cmd;
        private static MySqlDataReader rdr;


        // Sets up the Non Query SQL Command (The command that doesn't expect any return) and executes it.
        // Used in POST methods
        public static void ExecuteNonQuery(string NonQueryString)
        {
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = NonQueryString;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Set up the Command text for SQL Command that will Query the Databse and return the columns.
        // Used in GET methods
        public static MySqlDataReader ExecuteQuery(string QueryString)
        {
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = QueryString;
            rdr = cmd.ExecuteReader();
            return rdr;
        }

        public static void CloseConnectionAndReader()
        {
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }
            con.Close();
        }
        
    }
}
