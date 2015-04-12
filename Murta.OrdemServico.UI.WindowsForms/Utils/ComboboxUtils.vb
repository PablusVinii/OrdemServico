Public Class ComboboxUtils
    Public Shared Function CarregarCombobox(Of T)(description As String, key As String, lista As List(Of T), ByRef combobox As ComboBox, Optional ByVal defaultItem As Boolean = True) As Boolean
        Try
            Dim source As New Dictionary(Of String, String)()

            If defaultItem Then
                source.Add("", "Selecione um item")
            End If

            For Each item As T In lista
                Dim keyValue As Object = item.GetType().GetProperty(key).GetValue(item, Nothing)
                Dim descriptionValue As Object = item.GetType().GetProperty(description).GetValue(item, Nothing)
                Dim descricaoItem As String = keyValue.ToString() + " - " + descriptionValue.ToString()
                source.Add(keyValue.ToString(), descricaoItem)
            Next

            combobox.DataSource = New BindingSource(source, Nothing)
            combobox.DisplayMember = "Value"
            combobox.ValueMember = "Key"

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
