Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        Dim ordemServicoNode As New TreeNode
        ordemServicoNode.Name = "os"
        ordemServicoNode.Text = "Ordem de Serviços"

        Dim agendamentoNode As New TreeNode
        agendamentoNode.Name = "agendamentos"
        agendamentoNode.Text = "Agendamentos"

        Dim configuracoesNode As New TreeNode
        configuracoesNode.Name = "configuracoes"
        configuracoesNode.Text = "Configurações"

        menuTree.Nodes.Add(ordemServicoNode)
        menuTree.Nodes.Add(agendamentoNode)
        menuTree.Nodes.Add(configuracoesNode)
    End Sub

    Private Sub menuTree_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles menuTree.NodeMouseClick
        Dim nomeModulo = e.Node.Name
        CarregarModulo(nomeModulo)
    End Sub

    Private Sub CarregarModulo(nomeModulo As String)
        Select Case nomeModulo
            Case "os"
                Dim osUserControl As New OrdemServicoUserControl
                pnlModulo.Controls.Add(osUserControl)
            Case "agendamentos"

            Case "configuracoes"

        End Select

    End Sub
End Class