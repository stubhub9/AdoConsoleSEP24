using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoConsoleSEP24
{
    internal class AdoStuff
    {
        static void HasRows(SqlConnection connection)
        {
            #region  Using SqlConnection
            using (connection)
            {
                //  SELECT CONVERT(char(20), SERVERPROPERTY('productlevel'));  //Determine service pack
                SqlCommand command = new (
                    "SELECT CategoryID, CategoryName FROM Categories;", connection );
                connection.Open ();

                SqlDataReader reader = command.ExecuteReader();

                if ( reader.HasRows )
                {
                    while (reader.Read ())
                    {
                        Console.WriteLine ("{0}\t{1}", reader.GetInt32 (0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close ();
            }
            #endregion  Closed SqlConnection
        }

        static void RetrieveMultipleResults ( SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new (
                    "SELECT CategoryID, CategoryName FROM dbo.Categories;" +
                    "SELECT EmployeeID, LastName FROM dbo.Employees", connection );
                connection.Open ();

                SqlDataReader reader = command.ExecuteReader ();

                while (reader.HasRows)
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read ())
                    {
                        Console.WriteLine( "\t{0}\t{1}", reader.GetInt32 ( 0 ), reader.GetString ( 1 ) );
                    }
                    reader.NextResult ();

                }
            }
            
        }


    }
}
