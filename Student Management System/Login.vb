Public Class Login

    Private Sub button_Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_Login.Click
        If username.Text = "admin" And password.Text = "admin" Then
            Me.Hide()
            Form1.Show()
        Else
            MsgBox("Error: Wrong Credentials!")
            username.Clear()
            password.Clear()
            username.Focus()
        End If
    End Sub

    'form load
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        username.Focus()
    End Sub
End Class