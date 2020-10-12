using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using TunableInterview.SQL;

namespace TunableInterview
{


    public class Program
    {

        private static void createTables()
        {
           try
            {
                SQLCalls.ExecuteQuery(SQLQueries.Queries["createTables"]);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
        }

        private static bool doTablesExist()
        {
            MySqlDataReader rdr = SQLCalls.ExecuteQuery(SQLQueries.Queries["showTables"]);
            while (rdr.Read())
            {
                if (rdr[0].ToString() == "customers" ||
                rdr[0].ToString() == "products" ||
                rdr[0].ToString() == "orders")
                {
                    SQLCalls.CloseConnectionAndReader();
                    return true;
                }
            }
            SQLCalls.CloseConnectionAndReader();
            return false;
        }
        public static void Main(string[] args)
        {

                SQLQueries.CreateQueries();

                if (doTablesExist())
                {
                    Debug.WriteLine("Tables Already Exist");
                }
                else
                {
                    createTables();
                }
                CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
