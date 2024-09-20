
using System.Data.Odbc;
//  Vis Stud puts usings here.
namespace OdbcStuffConsole
{
    internal class Program
    {
        static void Main ( string [] args )
        {
            const string connectionString = "Driver={Microsoft Access Driver (*.mdb)};...";

            //  Same as OleDb
            //  Provide the query string with a param placeholder.
            const string queryString =
                "SELECT ProductID, UnitPrice, ProductName from products"
                + "WHERE UnitPrice > ? "
                + "ORDER BY UnitPrice DESC;";

            //  Always 5 for this lab.
            const int paramValue = 5;


            //  Install local version, SqlConnection Package 4.8
            //  Add using System.Data.OleDb
            using (OdbcConnection connection =
                new ( connectionString ))
            {
                OdbcCommand command = new ( queryString, connection );
                command.Parameters.AddWithValue ( "@pricePoint", paramValue );

                try
                {
                    connection.Open ();
                    OdbcDataReader reader = command.ExecuteReader ();
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
            Console.WriteLine ( "Odbc!" );
            Console.ReadLine ();
            //  End of Main
        }
    }
}
