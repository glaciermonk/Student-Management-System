Imports System.Data.Odbc
Public Class TIME_TABLE_CREATION

    Private Sub BUTTON_TIME_TABLE_SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON_TIME_TABLE_SAVE.Click
        Try
            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("insert into time_table values ('" & TIME_TABLE_CREATION_CLASS.Text & "', '" & TIME_TABLE_CREATION_SECTION.Text & "','Monday', '" & monsub1.Text & "', '" & monsub2.Text & "', '" & monsub3.Text & "','Lunch Break', '" & monsub4.Text & "', '" & monsub5.Text & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into time_table values ('" & TIME_TABLE_CREATION_CLASS.Text & "', '" & TIME_TABLE_CREATION_SECTION.Text & "','Tuesday', '" & tuesub1.Text & "', '" & tuesub2.Text & "', '" & tuesub3.Text & "','Lunch Break',  '" & tuesub4.Text & "', '" & tuesub5.Text & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into time_table values ('" & TIME_TABLE_CREATION_CLASS.Text & "', '" & TIME_TABLE_CREATION_SECTION.Text & "','Wednesday', '" & wedsub1.Text & "', '" & wedsub2.Text & "', '" & wedsub3.Text & "','Lunch Break',  '" & wedsub4.Text & "', '" & wedsub5.Text & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into time_table values ('" & TIME_TABLE_CREATION_CLASS.Text & "', '" & TIME_TABLE_CREATION_SECTION.Text & "','Thursday', '" & thursub1.Text & "', '" & thursub2.Text & "', '" & thursub3.Text & "','Lunch Break',  '" & thursub4.Text & "', '" & thursub5.Text & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into time_table values ('" & TIME_TABLE_CREATION_CLASS.Text & "', '" & TIME_TABLE_CREATION_SECTION.Text & "','Friday', '" & frisub1.Text & "', '" & frisub2.Text & "', '" & frisub3.Text & "','Lunch Break',  '" & frisub4.Text & "', '" & frisub5.Text & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into time_table values ('" & TIME_TABLE_CREATION_CLASS.Text & "', '" & TIME_TABLE_CREATION_SECTION.Text & "','Saturday', '" & satsub1.Text & "', '" & satsub2.Text & "', '" & satsub3.Text & "','Lunch Break',  '" & satsub4.Text & "', '" & satsub5.Text & "')", connection)
            command.ExecuteNonQuery()

            connection.Close()

            MsgBox("Time Table Saved Succesfully!")

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try

    End Sub

    Private Sub TIME_TABLE_CREATION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("select distinct class from class", connection)
            Dim data_reader As OdbcDataReader = command.ExecuteReader
            TIME_TABLE_CREATION_CLASS.Items.Clear()
            While data_reader.Read
                TIME_TABLE_CREATION_CLASS.Items.Add(data_reader(0))
            End While

            connection.Close()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub
End Class