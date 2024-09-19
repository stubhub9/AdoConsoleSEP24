using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoConsoleSEP24
{
    internal class DataTableStuff
    {
        /*The following example creates two DataTable objects and one DataRelation object, and adds the new objects to a DataSet. The tables are then displayed in a DataGridView control.  */
        private System.Data.DataSet dataSet;

        private void MakeDataTables()
        {
            //  Run all of the functions.
            MakeParentTable();
            MakeChildTable();
            MakeDataRelation();
            BindToDataGrid();
            //  End of Examples 1 methods group



        }

        #region  Examples 1 Methods Group
        private void MakeParentTable()
        {
            //  Create a new DataTable.
            System.Data.DataTable table = new DataTable ( "ParentTable" );
            //  Declare vars fro DataColumn & Row obj
            DataColumn column;
            DataRow row;

            //  Create new DataColumn, set DataType,
            //  ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType ( "System.Int32" );
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            //  Add to DataColumnCollection.
            table.Columns.Add ( column );

            column = new DataColumn();
            column.DataType = System.Type.GetType ( "System.String" );
            column.ColumnName = "ParentItem";
            column.AutoIncrement = false;
            column.Caption = "ParentItem";
            column.ReadOnly = false;
            column.Unique = false;
            //  Add to DataColumnCollection.
            table.Columns.Add ( column );

            //  Make the ID column the primary key column.
            DataColumn [] PrimaryKeyColumns = new DataColumn [1];
            PrimaryKeyColumns [0] = table.Columns ["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            //  Instantiate the DataSet variable.
            dataSet = new DataSet ();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            //  Create three new DataRow obj; add to dT.
            for (int i = 0; i <= 2; i++)
            {
                row = table.NewRow ();
                row ["id"] = i;
                row ["ParentItem"] = "ParentItem " + i;
                table.Rows.Add (row);
            }
        }


        private void MakeChildTable()
        {
            //  Create child table.
            DataTable table = new DataTable ("childTable");
            DataColumn column;
            DataRow row;

            //  Create first column and add to the DataTable.
            column = new DataColumn ();
            column.DataType = System.Type.GetType ( "System.Int32" );
            column.ColumnName= "ChildID";
            column.AutoIncrement = true;
            column.Caption = "ID";
            column.ReadOnly = true;
            column.Unique = true;
            //  Add to DataColumnCollection.
            table.Columns.Add ( column );

            column = new DataColumn ();
            column.DataType = System.Type.GetType ( "System.String" );
            column.ColumnName = "ChildItem";
            column.AutoIncrement = false;
            column.Caption = "ChildItem";
            column.ReadOnly = false;
            column.Unique = false;
            //  Add to DataColumnCollection.
            table.Columns.Add ( column );

            column = new DataColumn ();
            column.DataType = System.Type.GetType ( "System.Int32" );
            column.ColumnName = "ParentID";
            column.AutoIncrement = false;
            column.Caption = "ParentID";
            column.ReadOnly = false;
            column.Unique = false;
            //  Add to DataColumnCollection.
            table.Columns.Add ( column );

            dataSet.Tables.Add ( table );

            //  Create three sets of 5 row, Datarow obj
            //  Add to dT.
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow ();
                row ["childID"] = i;
                row ["childItem"] = "Item " + i;
                row ["ParentID"] = 0;
                table.Rows.Add ( row );
            }
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow ();
                row ["childID"] = i + 5;
                row ["childItem"] = "Item " + i;
                row ["ParentID"] = 1;
                table.Rows.Add ( row );
            }
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow ();
                row ["childID"] = i + 10;
                row ["childItem"] = "Item " + i;
                row ["ParentID"] = 2;
                table.Rows.Add ( row );
            }
        }


        private void MakeDataRelation()
        {
            //  Datarelation requires parent & child DataColumn, and a name.
            DataColumn parentColumn = dataSet.Tables ["ParentTable"].Columns ["id"];
            DataColumn childColumn = dataSet.Tables ["ChildTable"].Columns ["ParentID"];
            DataRelation relation = new DataRelation ( "parent2Child", parentColumn, childColumn );
            dataSet.Tables ["ChildTable"].ParentRelations.Add ( relation );
        }


        private void BindToDataGrid ()
        {
            //  Have the DataGrid bind to the DataSet, 
            //  with ParentTable as the topmost table.
            /*  Don't got a DataGrid1
            DataGrid1.SetDataBinding ( dataSet, "ParentTable" );
            */
        }

        #endregion  Examples 1


        private void DataTableCreation()
        {
            DataTable workTable = new DataTable ( "Customers" );

            DataSet customers = new DataSet ();
            DataTable customersTable = customers.Tables.Add ( "CustomersTable" );
        }



    }
}
