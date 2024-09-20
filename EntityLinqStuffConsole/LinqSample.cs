using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using NorthwindModel;
//  For more samples, if you can make this work     https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples

namespace EntityLinqStuffConsole
{
    /// <summary>
    /// I got no context, NorthwindModel what?
    /// </summary>
    internal class LinqSample
    {
        public static void ExecuteQuery ()
        {

            //using (NorthwindEntities context = new NorthwindEntities ())
            /*
            {
                try
                {
                    var query = from category in context.Categories
                                select new
                                {
                                    categoryID = category.CategoryID,
                                    categoryName = category.CategoryName,
                                };

                    foreach (var categoryInfo in query)
                    {
                        Console.WriteLine("\t{0}\t{1}", categoryInfo.categoryID, categoryInfo.categoryName);
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            */
            Console.WriteLine("EntityLinq!");
            Console.ReadLine ();
        }



    }
}
