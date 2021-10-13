Imports System.Data.Odbc
Public Class PRINT_FEES_PREVIEW

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Try
            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand
            connection = New OdbcConnection("dsn=sms;user=root;pwd=root")
            connection.Open()
            command = New OdbcCommand("SELECT fees_id FROM fees", connection)
            Dim dr As OdbcDataReader = command.ExecuteReader
            fees_id_combobox.Items.Clear()
            While dr.Read
                fees_id_combobox.Items.Add(dr(0))
            End While

            connection.Close()

            'CLEAR CRYSTAL REPORT ON FORM LOAD
            CrystalReportViewer1.ReportSource = Nothing
            CrystalReportViewer1.Refresh()
        Catch error_ As Exception
            MsgBox(Convert.ToString(error_))
        End Try
    End Sub

    Private Sub button_generate_invoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_generate_invoice.Click
        Try

            Dim connection As New OdbcConnection

            connection = New OdbcConnection("dsn=sms;user=root;pwd=root")
            connection.Open()

            Dim DATA_ADAPTER As New OdbcDataAdapter("select * from fees where fees_id ='" & fees_id_combobox.Text & "'", connection)
            Dim DATA_SET As New DataSet
            DATA_ADAPTER.Fill(DATA_SET)

            Dim rpath = "C:\Users\User\Documents\Visual Studio 2008\Projects\Student Management System\PRINT_FEES.rpt"
            Dim doc As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            doc.Load(rpath)
            doc.SetDataSource(DATA_SET.Tables(0))
            CrystalReportViewer1.ReportSource = doc
            'CrystalReportViewer1.RefreshReport()


            connection.Close()

        Catch error_ As Exception
            MsgBox(Convert.ToString(error_))
        End Try

    End Sub
End Class