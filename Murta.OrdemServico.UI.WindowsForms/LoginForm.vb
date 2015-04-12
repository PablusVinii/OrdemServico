Public Class LoginForm
    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim mainform As New MainForm
        mainform.Show()
        Hide()
    End Sub
End Class