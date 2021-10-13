Imports System.Data.Odbc
Public Class Form1

    'FORM LOAD
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            present_absent_combobox.Text = "Present"
            reload_student_id_combobox()
            studentnamefirst.Focus()
            reloadclass_()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'Student ID combobox
    Private Sub student_id_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles student_id.SelectedIndexChanged
        refresh_form()
        refreshattendance()
        refreshfeespaymenthistory()
    End Sub

    'REGISTER BUTTON
    Private Sub REGISTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_register.Click
        Try

            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection
            Dim gender As String = "NULL"

            If male.Checked Then
                gender = "MALE"
            ElseIf female.Checked Then
                gender = "FEMALE"
            End If

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("insert into student_info (namefirst, namemiddle, namelast, fathernamefirst, fathernamemiddle, fathernamelast, mothernamefirst, mothernamemiddle, mothernamelast, address, country, state, city, pin, gender, dob, studentphone, studentemail, fatherphone, fatheremail, motherphone, motheremail, class, section ) VALUES ('" & studentnamefirst.Text & "','" & studentnamemiddle.Text & "','" & studentnamelast.Text & "','" & fathernamefirst.Text & "','" & fathernamemiddle.Text & "','" & fathernamelast.Text & "','" & mothernamefirst.Text & "','" & mothernamemiddle.Text & "','" & mothernamelast.Text & "','" & address.Text & "','" & country.Text & "','" & state.Text & "','" & city.Text & "','" & pin.Text & "','" & gender.ToString & "','" & Format(dob.Value, "yyyy-MM-dd") & "','" & studentphone.Text & "','" & studentemail.Text & "','" & fatherphone.Text & "','" & fatheremail.Text & "','" & motherphone.Text & "','" & motheremail.Text & "','" & class_.Text & "','" & section_.Text & "')", connection)
            command.ExecuteNonQuery()

            connection.Close()

            MsgBox("Registered Succesfully!")

            reload_student_id_combobox()

            CLEAR_Click(sender, e)

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'UPDATE BUTTON
    Private Sub UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_update.Click
        Try

            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection

            Dim gender As String = "NULL"

            If male.Checked Then
                gender = "MALE"
            ElseIf female.Checked Then
                gender = "FEMALE"
            End If

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("update student_info set namefirst = '" & studentnamefirst.Text & "', namemiddle = '" & studentnamemiddle.Text & "', namelast = '" & studentnamelast.Text & "', fathernamefirst = '" & fathernamefirst.Text & "', fathernamemiddle = '" & fathernamemiddle.Text & "', fathernamelast = '" & fathernamelast.Text & "', mothernamefirst = '" & mothernamefirst.Text & "', mothernamemiddle = '" & mothernamemiddle.Text & "', mothernamelast = '" & mothernamelast.Text & "', address = '" & address.Text & "', country = '" & country.Text & "', state = '" & state.Text & "', city = '" & city.Text & "', pin = '" & pin.Text & "', gender = '" & gender & "', dob = '" & Format(dob.Value, "yyyy-MM-dd") & "', studentphone = '" & studentphone.Text & "', studentemail = '" & studentemail.Text & "', fatherphone = '" & fatherphone.Text & "', fatheremail = '" & fatheremail.Text & "', motherphone = '" & motherphone.Text & "', motheremail = '" & motheremail.Text & "', class = '" & class_.Text & "', section = '" & section_.Text & "'", connection)
            command.ExecuteNonQuery()

            connection.Close()

            MsgBox("Updated Succesfully!")

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'SEARCH BUTTON
    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        refresh_form()
    End Sub

    'CLEAR BUTTON
    Private Sub CLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_clear.Click
        Try
            student_id.Text = ""
            studentnamefirst.Clear()
            studentnamemiddle.Clear()
            studentnamelast.Clear()
            fathernamefirst.Clear()
            fathernamemiddle.Clear()
            fathernamelast.Clear()
            mothernamefirst.Clear()
            mothernamemiddle.Clear()
            mothernamelast.Clear()
            address.Clear()
            country.Clear()
            state.Clear()
            city.Clear()
            pin.Clear()
            male.Checked = False
            female.Checked = False
            studentphone.Clear()
            studentemail.Clear()
            fatherphone.Clear()
            fatheremail.Clear()
            motherphone.Clear()
            motheremail.Clear()
            class_.Text = ""
            section_.Text = ""
            monthlyfees.Clear()
            yearlyfee.Clear()
            subjects_viewer.DataSource = Nothing
            studentnamefirst.Focus()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'DELETE BUTTON
    Private Sub DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_delete.Click
        Try
            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("DELETE FROM STUDENT_INFO WHERE STUDENT_ID = '" & student_id.Text & "' ", connection)
            command.ExecuteNonQuery()

            connection.Close()

            MsgBox("Deleted Succesfully!")

            reload_student_id_combobox()

            CLEAR_Click(sender, e)
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'Class selection Combobox
    Private Sub class__SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles class_.SelectedIndexChanged

        Try
            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE As New DataTable
            Dim DATA_READER As OdbcDataReader

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            ADAPTER = New OdbcDataAdapter("select subjects from class where class = '" & class_.Text & "' and subjects != 'left_blank' ", connection)
            ADAPTER.Fill(DATA_TABLE)
            subjects_viewer.DataSource = DATA_TABLE


            Dim fee As Integer
            command = New OdbcCommand("SELECT fees FROM class WHERE class = '" & class_.Text & "'", connection)
            DATA_READER = command.ExecuteReader
            DATA_READER.Read()
            monthlyfees.Text = DATA_READER(0)
            fee = Convert.ToInt64(DATA_READER(0))
            yearlyfee.Text = fee * 12

            connection.Close()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'Payment Button
    Private Sub Button_Pay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pay.Click
        Try
            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("insert into fees ( student_id, month, amount) VALUES ('" & student_id.Text & "','" & fees_payment_month_select.Text & "','" & amountpaid.Text & "')", connection)
            command.ExecuteNonQuery()

            connection.Close()

            fees_payment_month_select.Text = ""

            amountpaid.Text = ""

            fees_payment_month_select.Focus()

            refreshfeespaymenthistory()


        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'Save button attendance record
    Private Sub button_save_attendance_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_save_attendance_record.Click
        Try
            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE As New DataTable

            connection = New OdbcConnection("dsn=SMS;user=root;pwd=root")
            connection.Open()

            command = New OdbcCommand("INSERT INTO ATTENDANCE (STUDENT_ID, status, DATE_) VALUES('" & student_id.Text & "','" & present_absent_combobox.Text & "','" & Format(attendance_record_date.Value, "yyyy-MM-dd") & "')", connection)
            command.ExecuteNonQuery()


            connection.Close()


        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try

        refreshattendance()

    End Sub

    'Exam Information Save Button
    Private Sub button_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_save_exam_information.Click
        Try
            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            'in case any of them are left blank, the system will enter null values so that enter the data into database doesn't throw an error
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


            Dim total As Decimal = 0
            If mark1.Text = "" Then
                mark1.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark1.Text)
            End If
            If mark2.Text = "" Then
                mark2.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark2.Text)
            End If
            If mark3.Text = "" Then
                mark3.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark3.Text)
            End If
            If mark4.Text = "" Then
                mark4.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark4.Text)
            End If
            If mark5.Text = "" Then
                mark5.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark5.Text)
            End If
            If mark6.Text = "" Then
                mark6.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark6.Text)
            End If
            If mark7.Text = "" Then
                mark7.Text = "01234567"
            Else
                total = total + Convert.ToInt64(mark7.Text)
            End If

            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject1.Text & "','" & mark1.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject2.Text & "','" & mark2.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject3.Text & "','" & mark3.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject4.Text & "','" & mark4.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject5.Text & "','" & mark5.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject6.Text & "','" & mark6.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()
            command = New OdbcCommand("insert into exam_info values ('" & student_id.Text & "','" & exam_type_selection_exam_info_input.Text & "','" & subject7.Text & "','" & mark7.Text & "', '" & total.ToString & "')", connection)
            command.ExecuteNonQuery()

            connection.Close()

            subject1.Clear()
            subject2.Clear()
            subject3.Clear()
            subject4.Clear()
            subject5.Clear()
            subject6.Clear()
            subject7.Clear()
            mark1.Clear()
            mark2.Clear()
            mark3.Clear()
            mark4.Clear()
            mark5.Clear()
            mark6.Clear()
            mark7.Clear()


            MsgBox("Exam Information Recorded Succesfully!")
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'View button exam information
    Private Sub button_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_view.Click
        Try
            Dim COMMAND As New OdbcCommand
            Dim connection As New OdbcConnection
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE = New DataTable

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            ADAPTER = New OdbcDataAdapter("SELECT student_id as 'Student ID', exam_type as 'Exam Type', subjects as 'Subjects', marks as 'Marks'  from exam_info WHERE student_id =  '" & student_id.Text & "'  and exam_type = '" & exam_type_selection_combobox.Text & "' and subjects != 'left_blank'", connection)
            ADAPTER.Fill(DATA_TABLE)
            examinfoviewgrid.DataSource = DATA_TABLE

            ADAPTER = New OdbcDataAdapter("SELECT distinct total as Total from exam_info WHERE student_id =  '" & student_id.Text & "'  and exam_type = '" & exam_type_selection_combobox.Text & "' and subjects != 'left_blank'", connection)
            ADAPTER.Fill(DATA_TABLE)
            examinfoviewgrid.DataSource = DATA_TABLE

            connection.Close()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    'fill admission tab with student data from mysql table
    Sub refresh_form()
        Try
            Dim COMMAND As New OdbcCommand
            Dim connection As New OdbcConnection
            Dim DATA_READER As OdbcDataReader
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE = New DataTable

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()
            COMMAND = New OdbcCommand("SELECT namefirst FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            studentnamefirst.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT namemiddle FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            studentnamemiddle.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT namelast FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            studentnamelast.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT fathernamefirst FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            fathernamefirst.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT fathernamemiddle FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            fathernamemiddle.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT fathernamelast FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            fathernamelast.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT mothernamefirst FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            mothernamefirst.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT mothernamemiddle FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            mothernamemiddle.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT mothernamelast FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            mothernamelast.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT address FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            address.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT country FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            country.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT state FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            state.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT city FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            city.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT pin FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            pin.Text = DATA_READER(0)

            'GENDER
            COMMAND = New OdbcCommand("SELECT gender FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            studentphone.Text = DATA_READER(0) 'USING FOR TEMP VALUE STORAGE   
            If studentphone.Text = "MALE" Then
                male.Select()
            Else
                female.Select()
            End If
            studentphone.Clear() 'TEMP VALUE CLEARED

            'DOB
            COMMAND = New OdbcCommand("SELECT dob FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            dob.Value = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT studentphone FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            studentphone.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT studentemail FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            studentemail.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT fatherphone FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            fatherphone.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT fatheremail FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            fatheremail.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT motherphone FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            motherphone.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT motheremail FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            motheremail.Text = DATA_READER(0)


            COMMAND = New OdbcCommand("SELECT section FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            section_.Text = DATA_READER(0)

            COMMAND = New OdbcCommand("SELECT class FROM student_info WHERE student_id = '" & student_id.Text & "'", connection)
            DATA_READER = COMMAND.ExecuteReader
            DATA_READER.Read()
            class_.Text = DATA_READER(0)

            ADAPTER = New OdbcDataAdapter("SELECT subjects from class where class =  '" & class_.Text & "' and subjects != 'left_blank'", connection)
            ADAPTER.Fill(DATA_TABLE)
            subjects_viewer.DataSource = DATA_TABLE

            connection.Close()

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Sub reload_student_id_combobox()
        Try
            Dim command As New OdbcCommand
            Dim connection As New OdbcConnection

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("select student_id from student_info", connection)
            Dim data_reader As OdbcDataReader = command.ExecuteReader
            student_id.Items.Clear()
            While data_reader.Read
                student_id.Items.Add(data_reader(0))
            End While

            connection.Close()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Sub refreshfeespaymenthistory()
        Try
            Dim connection As New OdbcConnection
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE As New DataTable
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=SMS;user=root;pwd=root")
            connection.Open()

            ADAPTER = New OdbcDataAdapter("select * from FEES where student_id = '" & student_id.Text & "' ", connection)
            ADAPTER.Fill(DATA_TABLE)
            view_fees_payment_history.DataSource = DATA_TABLE

            connection.Close()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try

    End Sub

    Sub refreshattendance()
        Try
            Dim connection As New OdbcConnection
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE As New DataTable

            connection = New OdbcConnection("dsn=SMS;user=root;pwd=root")
            connection.Open()

            ADAPTER = New OdbcDataAdapter("select * from attendance where student_id = '" & student_id.Text & "' ", connection)
            ADAPTER.Fill(DATA_TABLE)
            view_attendance_record.DataSource = DATA_TABLE

            connection.Close()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Sub reloadclass_()
        Dim connection As New OdbcConnection
        Dim command As New OdbcCommand

        connection = New OdbcConnection("dsn=sms;user=root;password=root")
        connection.Open()

        command = New OdbcCommand("select distinct class from class", connection)
        Dim data_reader As OdbcDataReader = command.ExecuteReader
        class_.Items.Clear()
        TIME_TABLE_VIEWER_CLASS.Items.Clear()
        TIME_TABLE_CREATION.TIME_TABLE_CREATION_CLASS.Items.Clear()
        While data_reader.Read
            class_.Items.Add(data_reader(0))
            TIME_TABLE_VIEWER_CLASS.Items.Add(data_reader(0))
            TIME_TABLE_CREATION.TIME_TABLE_CREATION_CLASS.Items.Add(data_reader(0))
        End While

        connection.Close()
    End Sub

    Private Sub BUTTON_VIEW_TIME_TABLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON_VIEW_TIME_TABLE.Click
        Try
            Dim connection As New OdbcConnection
            Dim ADAPTER As New OdbcDataAdapter
            Dim DATA_TABLE As New DataTable
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            ADAPTER = New OdbcDataAdapter("select day as Day, subject1 as '09:00 AM - 10:00 AM', subject2 AS '10:00 AM - 11:00 AM', subject3 AS '11:00 AM - 12:00 PM',lunch_break as '12:00PM - 01:00 PM', subject4 as '01:00PM - 02:00PM', subject5 as '02:00PM - 03:00PM' from time_table where class = '" & TIME_TABLE_VIEWER_CLASS.Text & "' and section = '" & TIME_TABLE_VIEWER_SECTION.Text & "'", connection)
            ADAPTER.Fill(DATA_TABLE)
            TIME_TABLE_VIEW.DataSource = DATA_TABLE

            connection.Close()
        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TIME_TABLE_CREATION.Show()
        TIME_TABLE_CREATION.TopMost = True
    End Sub

    Private Sub BUTTON_CLEAR_TIME_TABLE_VIEWER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON_CLEAR_TIME_TABLE_VIEWER.Click
        TIME_TABLE_VIEW.DataSource = Nothing
    End Sub

    Private Sub BUTTON_DELETE_TIME_TABLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON_DELETE_TIME_TABLE.Click
        Try
            Dim connection As New OdbcConnection
            Dim command As New OdbcCommand

            connection = New OdbcConnection("dsn=sms;user=root;password=root")
            connection.Open()

            command = New OdbcCommand("delete from time_table where class = '" & TIME_TABLE_VIEWER_CLASS.Text & "' and section = '" & TIME_TABLE_VIEWER_SECTION.Text & "' ", connection)
            command.ExecuteNonQuery()

            connection.Close()

            BUTTON_CLEAR_TIME_TABLE_VIEWER_Click(sender, e)

            MsgBox("Time Table Deleted!")

        Catch ex As Exception
            MsgBox(Convert.ToString(ex))
        End Try
    End Sub

    Private Sub BUTTON_EDIT_SUBJECTS_FEES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON_EDIT_SUBJECTS_FEES.Click
        CREATE_CLASS.Show()
        CREATE_CLASS.TopMost = True
    End Sub

    Private Sub Search_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        refresh_form()
    End Sub

    Private Sub button_PRINT_EXAM_INFO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_PRINT_EXAM_INFO.Click
        PRINT_EXAM_REPORT_PREVIEW.Show()
    End Sub

    Private Sub BUTTON_PRINT_TIME_TABLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTON_PRINT_TIME_TABLE.Click
        PRINT_TIME_TABLE_PREVIEW.Show()
    End Sub

    Private Sub button_PRINT_FEES_INVOICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_PRINT_FEES_INVOICE.Click
        PRINT_FEES_PREVIEW.Show()
    End Sub
End Class
