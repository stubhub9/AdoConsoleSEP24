using System.Data.SqlClient;

namespace MySqlClient
{
    internal class Program
    {
        static void Main ( string [] args )
        {
            const string connectionString = "Data Source=(local);Initial Catalog=Northwind;" +
                "Integrated Security=true";

            //  Provide the query string with a param placeholder.
            const string queryString =
                "SELECT ProductID, UnitPrice, ProductName from dbo.products"
                + "WHERE UnitPrice > @pricePoint "
                + "ORDER BY UnitPrice DESC;";

            const int paramValue = 5;

            //  Install local version, SqlConnection Package 4.8
            using (SqlConnection connection = 
                new (connectionString))
            {
                SqlCommand command = new (queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    connection.Open ();
                    SqlDataReader reader = command.ExecuteReader ();
                    while (reader.Read ())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader [0], reader [1], reader [2] );
                    }
                    reader.Close ();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine ();
            }






            Console.WriteLine ( "Hello, World!" );
        }
    }
}
