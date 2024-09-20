
//  Hopefully using .NET6 Oracle and not Framework Oracle.
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace OracleClientStuffConsole
{
    /// <summary>
    /// code in this example assumes a connection to DEMO.CUSTOMER on an Oracle server. You must also add a reference to the System.Data.OracleClient.dll. The code returns the data in an OracleDataReader.
    /// </summary>
    internal class Program
    {
        static void Main ( string [] args )
        {
            const string connectionString = "Data Source=ThisOracleServer;Integrated Security=yes;";

           
            //  Provide the query string with a param placeholder.
            const string queryString =
                "SELECT CUSTOMER_ID, NAME FROM DEMO.CUSTOMER";

            //  Always 5 for this lab; BUT UNUSED HERE
            //const int paramValue = 5;


            
            using (OracleConnection connection =
                new ( connectionString ))
            {
                //  This is different than MS.
                OracleCommand command = connection.CreateCommand ();
                command.CommandText = queryString;

                try
                {
                    connection.Open ();
                    OracleDataReader reader = command.ExecuteReader ();
                    while (reader.Read ())
                    {
                        //Console.WriteLine ( "\t{0}\t{1}\t{2}",
                            //reader [0], reader [1], reader [2] );
                        Console.WriteLine ( "\t{0}\t{1}",
                            reader [0], reader [1] );
                    }
                    reader.Close ();
                }
                catch (Exception ex)
                {
                    Console.WriteLine ( ex.Message );
                }
                //  End of using
            }
            Console.WriteLine ( "Oracle!but only 2 col and no rdline?" );
            Console.ReadLine ();
            //  End of Main
        }
    }
}
