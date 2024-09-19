Imports System
Imports System.Data

Module Program
    'Private suppliersProducts As SuppliersProducts
    Private suppliersProducts As DataSet



    ''' <summary>
    ''' Random bits Visual Basic ADO.NET example
    ''' </summary>
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub


    Private Sub CreateConstraint()
        ' Declare parent column and child column variables.
        Dim parentColumn As DataColumn
        Dim childColumn As DataColumn
        Dim fkeyConstraint As ForeignKeyConstraint

        ' Set parent and child column variables.
        parentColumn = suppliersProducts.Tables("Suppliers").Columns("SupplierID")
        childColumn = suppliersProducts.Tables("Products").Columns("SupplierID")

        ' Underscore <cr> being used to break up a long line?
        ' and then _ disappeared  t( _<cr>"S..." 
        fkeyConstraint = New ForeignKeyConstraint(
            "SupplierFKConstraint", parentColumn, childColumn)

        ' Set null values when a value is deleted.
        fkeyConstraint.DeleteRule = Rule.SetNull
        fkeyConstraint.UpdateRule = Rule.Cascade
        fkeyConstraint.AcceptRejectRule = AcceptRejectRule.Cascade

        ' Add the constraint, and set EnforceConstraints to true.
        suppliersProducts.Tables("Products").Constraints.Add(fkeyConstraint)
        suppliersProducts.EnforceConstraints = True
    End Sub

    'Private Class SuppliersProducts :   DataSet

    'End Class
End Module
