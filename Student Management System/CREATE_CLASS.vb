Imports System.Data.Odbc
Public Class CREATE_CLASS

    Private Sub button_SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_SAVE.Click
        Try
            If subject1.Text = "" Then
                subject1.Text = "left_blank"
            End If
            If subject2.Text = "" Then
                subject2.Text = "left_blank"
            End If
            If subject3.Text = "" Then
                subject3.Text = "left_blank"
            End If
            If subject4.Text = "" Then
                subject4.Text = "left_blank"
            End If
            If subject5.Text = "" Then
                subject5.Text = "left_blank"
            End If
            If subject6.Text = "" Then
                subject6.Text = "left_blank"
            End If
            If subject7.Text = "" Then
                subject7.Text = "left_blank"
            End If
            If subject8.Text = "" Then
                subject8.Text = "left_blank"
            End If
            If subject9.Text = "" Then
                subject9.Text = "left_blank"
            End If
            If subject10.Text = "" Then
                subject10.Text = "left_blank"
            End If

            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject1.Text & "', '1')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject2.Text & "', '2')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject3.Text & "', '3')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject4.Text & "', '4')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject5.Text & "', '5')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject6.Text & "', '6')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject7.Text & "', '7')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject8.Text & "', '8')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject9.Text & "', '9')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into class values('" & class_.Text & "', '" & fee_amount.Text & "', '" & subject10.Text & "', '10')", connection)
            command.ExecuteNonQuery()

            class_.Text = ""
            fee_amount.Clear()
            subject1.Clear()
            subject2.Clear()
            subject3.Clear()
            subject4.Clear()
            subject5.Clear()
            subject6.Clear()
            subject7.Clear()
            subject8.Clear()
            subject9.Clear()
            subject10.Clear()
            class_.Focus()

            CREATE_CLASS_Load(sender, e)

            MsgBox("Class Created")

            Form1.reloadclass_()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Private Sub CREATE_CLASS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("select distinct class from class", connection)
            Dim data_reader As OdbcDataReader = command.ExecuteReader
            class_.Items.Clear()
            While data_reader.Read
                class_.Items.Add(data_reader(0))
            End While

            connection.Close()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Private Sub class__SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles class_.SelectedIndexChanged
        Try
            Dim COMMAND As New OdbcCommand
            Dim connection As New OdbcConnection
            Dim DATA_READER As OdbcDataReader

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 1", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject1.Text = ""
            Else
                subject1.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 2", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject2.Text = ""
            Else
                subject2.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 3", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject3.Text = ""
            Else
                subject3.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 4", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject4.Text = ""
            Else
                subject4.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 5", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject5.Text = ""
            Else
                subject5.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 6", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject6.Text = ""
            Else
                subject6.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 7", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject7.Text = ""
            Else
                subject7.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 8", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject8.Text = ""
            Else
                subject8.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 9", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject9.Text = ""
            Else
                subject9.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT subjects FROM class WHERE class = '" & class_.Text & "' and count = 10", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            If DATA_READER(0) = "left_blank" Then
                subject10.Text = ""
            Else
                subject10.Text = DATA_READER(0)
            End If

            COMMAND = New OdbcCommand("SELECT distinct fees FROM class WHERE class = '" & class_.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            fee_amount.Text = DATA_READER(0)

            connection.Close()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub
End Class