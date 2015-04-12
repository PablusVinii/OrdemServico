Public Class Validador
    Public Overloads Function ValidarPreenchimento(ByVal errorProvider As ErrorProvider, ByVal maskedInput As MaskedTextBox) As Boolean
        If Not maskedInput.MaskCompleted Then
            errorProvider.SetError(maskedInput, "Este campo é obrigatório")
            Return False
        End If
        Return True
    End Function

    Public Overloads Function ValidarPreenchimento(ByVal errorProvider As ErrorProvider, ByVal combobox As ComboBox) As Boolean
        If Not combobox.SelectedValue <> Nothing Then
            errorProvider.SetError(combobox, "Este campo é obrigatório")
            Return False
        End If
        Return True
    End Function

    Public Overloads Function ValidarPreenchimento(ByVal errorProvider As ErrorProvider, ByVal textbox As TextBox) As Boolean
        If String.IsNullOrEmpty(textbox.Text) Then
            errorProvider.SetError(textbox, "Este campo é obrigatório")
            Return False
        End If
        Return True
    End Function
End Class
