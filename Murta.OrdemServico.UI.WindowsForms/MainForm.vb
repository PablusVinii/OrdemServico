Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ordemServicoNode As New TreeNode
        ordemServicoNode.Text = "Ordem de Serviços"        

        Dim agendamentoNode As New TreeNode
        agendamentoNode.Text = "Agendamentos"

        Dim configuracoesNode As New TreeNode
        configuracoesNode.Text = "Configurações"

        menuTree.Nodes.Add(ordemServicoNode)
        menuTree.Nodes.Add(agendamentoNode)
        menuTree.Nodes.Add(configuracoesNode)
    End Sub

    Private Sub menuTree_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles menuTree.NodeMouseClick
        'Realizar aqui a abertura do formulario correspondende
    End Sub
End Class