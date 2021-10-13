Imports System.Data.Odbc
Public Class PRINT_TIME_TABLE_PREVIEW

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim connection As New OdbcConnection
        connection = New OdbcConnection("dsn=sms;user=root;pwd=root")

        connection.Open()
        Dim DATA_ADAPTER As New OdbcDataAdapter("select * from time_table where class = '" & Form1.TIME_TABLE_VIEWER_CLASS.Text & "' and section =  '" & Form1.TIME_TABLE_VIEWER_SECTION.Text & "'", connection)
        Dim DATA_SET As New DataSet
        DATA_ADAPTER.Fill(DATA_SET)

        Dim rpath = "C:\Users\User\Documents\Visual Studio 2008\Projects\Student Management System\PRINT_TIME_TABLE.rpt"
        Dim doc As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        doc.Load(rpath)
        doc.SetDataSource(DATA_SET.Tables(0))
        CrystalReportViewer1.ReportSource = doc
        CrystalReportViewer1.RefreshReport()


        connection.Close()
    End Sub
End Class