Imports System.Data.Odbc
Public Class PRINT_EXAM_REPORT_PREVIEW

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Try
            Dim connection As New OdbcConnection
            connection = New OdbcConnection("dsn=sms;user=root;pwd=root")

            connection.Open()
            Dim DATA_ADAPTER As New OdbcDataAdapter("select student_id, subjects as Subjects, marks as Marks, total from exam_info where student_id = '" & Form1.student_id.Text & "' and exam_type =  '" & Form1.exam_type_selection_combobox.Text & "' and subjects != 'left_blank'", connection)
            Dim DATA_SET As New DataSet
            DATA_ADAPTER.Fill(DATA_SET)

            Dim rpath = "C:\Users\User\Documents\Visual Studio 2008\Projects\Student Management System\PRINT_EXAM_REPORT.rpt"
            Dim doc As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            doc.Load(rpath)
            doc.SetDataSource(DATA_SET.Tables(0))
            CrystalReportViewer1.ReportSource = doc
            CrystalReportViewer1.RefreshReport()


            connection.Close()
        Catch error_ As Exception
            MsgBox(Convert.ToString(error_))
        End Try
    End Sub
End Class