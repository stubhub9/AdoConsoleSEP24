using System.Data.OleDb;
using System.Runtime.Versioning;

namespace OleDbClientConsole
{
    //  API is only supported on Windows
    [SupportedOSPlatform("windows")]
    static class Program
    {
        static void Main ( string [] args )
        {
            const string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" 
                + "c:\\Data\\Northwind.mdb;...";
            
            //  Provide the query string with a param placeholder.
            const string queryString =
                "SELECT ProductID, UnitPrice, ProductName from products"
                + "WHERE UnitPrice > ? "
                + "ORDER BY UnitPrice DESC;";

            const int paramValue = 5;

            //  Install local version, SqlConnection Package 4.8
            //  Add using System.Data.OleDb
            using (OleDbConnection connection =
                new ( connectionString ))
            {
                OleDbCommand command = new ( queryString, connection );
                command.Parameters.AddWithValue ( "@pricePoint", paramValue );

                try
                {
                    connection.Open ();
                    OleDbDataReader reader = command.ExecuteReader ();
                    while (reader.Read ())
                    {
                        Console.WriteLine ( "\t{0}\t{1}\t{2}",
                            reader [0], reader [1], reader [2] );
                    }
                    reader.Close ();
                }
                catch (Exception ex)
                {
                    Console.WriteLine ( ex.Message );
                }
                //  End of using
            }
            Console.WriteLine ( "OleDb!" );
            Console.ReadLine ();
            //  End of Main
        }

    }
}
