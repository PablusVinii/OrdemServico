Public Class LoginForm

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        If (Not String.IsNullOrEmpty(txtUsername.Text) And Not String.IsNullOrEmpty(txtPassword.Text)) Then
            Dim username As String = txtUsername.Text
            Dim password As String = txtPassword.Text

            Dim mainform As New MainForm
            mainform.Show()
            Hide()
        End If
    End Sub
End Class