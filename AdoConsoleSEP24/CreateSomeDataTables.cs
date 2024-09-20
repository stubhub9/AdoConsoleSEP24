﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoConsoleSEP24
{/// <summary>
/// Console Read and Writes need to be handled.
/// </summary>
    internal class CreateSomeDataTables
    {
        CreateSomeDataTables() 
        {
            //  Create two tables and a dataset.
            DataTable orderTable = CreateOrderTable ();
            DataTable orderDetailTable = CreateOrderDetailTable ();
            DataSet salesSet = new DataSet();
            salesSet.Tables.Add (orderTable);
            salesSet.Tables.Add (orderDetailTable);

            // Set the relations between the tables and create the related constraint.
            salesSet.Relations.Add ( "OrderOrderDetail", orderTable.Columns ["OrderId"], orderDetailTable.Columns ["OrderId"], true );

            Console.WriteLine ( "After creating the foreign key constriant, you will see the following error if inserting order detail with the wrong OrderId: " );
            try
            {
                DataRow errorRow = orderDetailTable.NewRow ();
                errorRow [0] = 1;
                errorRow [1] = "00007";
                orderDetailTable.Rows.Add ( errorRow );
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            //  Insert the rows into the table
            InsertOrders ( orderTable );
            InsertOrderDetails ( orderDetailTable );

            Console.WriteLine ( "The initial Order table." );
            ShowTable ( orderTable );

            Console.WriteLine ( "The OrderDetail table." );
            ShowTable ( orderDetailTable );


            // Use the Aggregate-Sum on the child table column to get the result.
            DataColumn colSub = new DataColumn ( "SubTotal", typeof ( Decimal ), "Sum(Child.LineTotal)" );
            orderTable.Columns.Add ( colSub );

            // Compute the tax by referencing the SubTotal expression column.
            DataColumn colTax = new DataColumn ( "Tax", typeof ( Decimal ), "SubTotal*0.1" );
            orderTable.Columns.Add ( colTax );

            // If the OrderId is 'Total', compute the due on all orders; or compute the due on this order.
            DataColumn colTotal = new DataColumn ( "TotalDue", typeof ( Decimal ), "IIF(OrderId='Total',Sum(SubTotal)+Sum(Tax),SubTotal+Tax)" );
            orderTable.Columns.Add ( colTotal );

            DataRow row = orderTable.NewRow ();
            row ["OrderId"] = "Total";
            orderTable.Rows.Add ( row );

            Console.WriteLine("The Order table with the expression columns.");
            ShowTable (orderTable );

            Console.WriteLine ("Press any key to exit....");
            Console.ReadKey ();




        }

        private static DataTable CreateOrderTable ()
        {
            DataTable orderTable = new DataTable ( "Order" );

            DataColumn colId = new DataColumn ( "OrderId", typeof ( string ) );
            orderTable.Columns.Add ( colId );


            DataColumn colDate = new DataColumn ( "OrderDate", typeof ( DateTime ) );
            orderTable.Columns.Add ( colDate );

            //  Set the OrderId column as the primary key.
            orderTable.PrimaryKey = new DataColumn [] { colId };


            return orderTable;
        }

        private static DataTable CreateOrderDetailTable ()
        {
            DataTable orderDetailTable = new DataTable ( "OrderDetail" );

            //  Define all the columns once.
            DataColumn [] cols =
            {
                new DataColumn("OrderDetailId", typeof (Int32)),
                new DataColumn("OrderId", typeof (String)),
                new DataColumn("Product", typeof (String)),
                new DataColumn("UnitPrice", typeof (Decimal)),
                new DataColumn("OrderQty", typeof (Int32)),
                new DataColumn("LineTotal", typeof (Decimal), "UnitPrice*OrderQty"),
            };

            orderDetailTable.Columns.AddRange (cols );
            orderDetailTable.PrimaryKey = new DataColumn [] { orderDetailTable.Columns ["OrderDetailId"] };
            return orderDetailTable;
        }

        private static void InsertOrders ( DataTable orderTable)
        {
            DataRow row1 = orderTable.NewRow ();
            row1 ["OrderId"] = "00001";
            row1 ["OrderDate"] = new DateTime ( 2013, 3, 1 );
            orderTable.Rows.Add ( row1 );

            DataRow row2 = orderTable.NewRow ();
            row1 ["OrderId"] = "00002";
            row1 ["OrderDate"] = new DateTime ( 2013, 3, 12 );
            orderTable.Rows.Add ( row2 );

            DataRow row3 = orderTable.NewRow ();
            row1 ["OrderId"] = "00003";
            row1 ["OrderDate"] = new DateTime ( 2013, 3, 20 );
            orderTable.Rows.Add ( row3 );
        }

        private static void InsertOrderDetails (DataTable orderDetailTable)
        {
            Object [] rows =
            {
                new Object [] { 1, "00001", "Mountain Bike", 1419.5, 36 },
                new Object [] { 2, "00001", "Road Bike", 1233.6, 16 },
                new Object [] { 3, "00001", "Touring Bike", 1653.3, 32 },
                new Object [] { 4, "00002", "Mountain Bike", 1419.5, 24 },
                new Object [] { 5, "00002", "Road Bike", 1233.6, 12 },
                new Object [] { 6, "00003", "Mountain Bike", 1419.5, 48 },
                new Object [] { 7, "00003", "Touring Bike", 1653.3, 8 },
            };

            foreach (Object [] row in rows)
            {
                orderDetailTable.Rows.Add ( row );
            }

        }

        private static void ShowTable ( DataTable table )
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0, -14}", col.ColumnName);
            }
            Console.WriteLine ();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    if (col.DataType.Equals ( typeof ( DateTime ) ))
                    {
                        Console.Write ( "{0, -14:d}", row [col] );
                    }
                    else if (col.DataType.Equals ( typeof ( Decimal ) ))
                    {
                        Console.Write ( "{0, -14:C}", row [col] );
                    }
                    else
                    {
                        Console.Write ( "{0, -14:C}", row [col] );
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }





    }
}
