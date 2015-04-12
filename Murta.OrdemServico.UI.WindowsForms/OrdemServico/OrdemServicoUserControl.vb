Imports System
Imports System.Collections.Generic
Imports System.Globalization

Public Class OrdemServicoUserControl

    Dim client As New SistemaServiceReference.SistemaClient
    Dim ordensServico As New List(Of SistemaServiceReference.OS)
    Dim dicionarioOS As New Dictionary(Of Integer, SistemaServiceReference.OS)
    Dim edicao As Boolean

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.F2 Then
            btnNovo.PerformClick()
        ElseIf keyData = Keys.F3 Then
            btnPesquisar.PerformClick()
        ElseIf keyData = Keys.F4 Then
            btnRelatorioListagem.PerformClick()
        ElseIf keyData = Keys.F5 Then
            btnRelatorioHorasGastas.PerformClick()
        ElseIf keyData = Keys.F6 Then
            btnEnviar.PerformClick()
        End If
    End Function

    Private Sub PesquisarOrdensDeServico()
        Dim id As Integer = 0

        If Integer.TryParse(txtNumeroOS.Text, id) Then
            Dim ordemServico As SistemaServiceReference.OS = Me.client.ConsultarOrdemServico(id)
            Me.ordensServico.Add(ordemServico)
        Else
            Dim currentDateFormat As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat

            Dim dataDe As DateTime = Nothing
            Dim dataAte As DateTime = Nothing
            Dim idFuncionario As Integer = 0
            Dim idCliente As Integer = 0

            If Not String.IsNullOrEmpty(dtpDe.Text) Then
                dataDe = Convert.ToDateTime(dtpDe.Text, currentDateFormat)
            End If

            If Not String.IsNullOrEmpty(dtpAte.Text) Then
                dataAte = Convert.ToDateTime(dtpAte.Text, currentDateFormat)
            End If

            If Not String.IsNullOrEmpty(cboFuncionario.SelectedValue) Then
                idFuncionario = Convert.ToInt32(cboFuncionario.SelectedValue)
            End If

            If Not String.IsNullOrEmpty(cboCliente.SelectedValue) Then
                idCliente = Convert.ToInt32(cboCliente.SelectedValue)
            End If

            If dataDe <> Nothing And dataAte <> Nothing And idFuncionario <> 0 And idCliente <> 0 Then
                Me.ordensServico = Me.client.ListarPorRangedeDataeFuncionarioeClienteOrdemServico(dataDe, dataAte,
                                                                                      New SistemaServiceReference.Cliente With {.Codigo = idCliente},
                                                                                      New SistemaServiceReference.Funcionario With {.Codigo = idFuncionario}).ToList()

            ElseIf dataDe = Nothing And dataAte = Nothing And idFuncionario = 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarOrdemServico().ToList()

            ElseIf dataDe <> Nothing And dataAte <> Nothing And idFuncionario <> 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorRangedeDataeFuncionarioOrdemServico(dataDe, dataAte,
                                                                                          New SistemaServiceReference.Funcionario With {.Codigo = idFuncionario}).ToList()

            ElseIf dataDe <> Nothing And dataAte <> Nothing And idCliente <> 0 And idFuncionario = 0 Then
                Me.ordensServico = Me.client.ListarPorRangedeDataeClienteOrdemServico(dataDe, dataAte,
                                                                                      New SistemaServiceReference.Cliente With {.Codigo = idCliente}).ToList()

            ElseIf dataDe <> Nothing And dataAte <> Nothing And idFuncionario = 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorRangeDataOrdemServico(dataDe, dataAte).ToList()

            ElseIf dataDe <> Nothing And dataAte = Nothing And idFuncionario <> 0 And idCliente <> 0 Then
                Me.ordensServico = Me.client.ListarPorDataeFuncionarioeClienteOrdemServico(dataDe,
                                                                                           New SistemaServiceReference.Funcionario With {.Codigo = idFuncionario},
                                                                                           New SistemaServiceReference.Cliente With {.Codigo = idCliente}).ToList()

            ElseIf dataDe <> Nothing And dataAte = Nothing And idFuncionario = 0 And idCliente <> 0 Then
                Me.ordensServico = Me.client.ListarPorDataeClienteOrdemServico(dataDe,
                                                                               New SistemaServiceReference.Cliente With {.Codigo = idCliente},
                                                                               SistemaServiceReference.TipoData.DataDe).ToList()

            ElseIf dataDe = Nothing And dataAte <> Nothing And idFuncionario = 0 And idCliente <> 0 Then
                Me.ordensServico = Me.client.ListarPorDataeClienteOrdemServico(dataAte,
                                                                               New SistemaServiceReference.Cliente With {.Codigo = idCliente},
                                                                               SistemaServiceReference.TipoData.DataAte).ToList()

            ElseIf dataDe <> Nothing And dataAte = Nothing And idFuncionario <> 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorDataeFuncionarioOrdemServico(dataDe,
                                                                                   New SistemaServiceReference.Funcionario With {.Codigo = idFuncionario},
                                                                                   SistemaServiceReference.TipoData.DataDe).ToList()

            ElseIf dataDe = Nothing And dataAte <> Nothing And idFuncionario <> 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorDataeFuncionarioOrdemServico(dataAte,
                                                                                   New SistemaServiceReference.Funcionario With {.Codigo = idFuncionario},
                                                                                   SistemaServiceReference.TipoData.DataAte).ToList()

            ElseIf dataDe = Nothing And dataAte = Nothing And idFuncionario <> 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorFuncionarioOrdemServico(New SistemaServiceReference.Funcionario With {.Codigo = idFuncionario}).ToList()

            ElseIf dataDe = Nothing And dataAte = Nothing And idFuncionario = 0 And idCliente <> 0 Then
                Me.ordensServico = Me.client.ListarPorClienteOrdemServico(New SistemaServiceReference.Cliente With {.Codigo = idCliente}).ToList()

            ElseIf dataDe <> Nothing And dataAte = Nothing And idFuncionario = 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorDataOrdemServico(dataDe, SistemaServiceReference.TipoData.DataDe).ToList()

            ElseIf dataDe = Nothing And dataAte <> Nothing And idFuncionario = 0 And idCliente = 0 Then
                Me.ordensServico = Me.client.ListarPorDataOrdemServico(dataAte, SistemaServiceReference.TipoData.DataAte).ToList()

            End If

        End If
    End Sub

    Private Sub OrdemServicoUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.grdOrdemServico.AutoGenerateColumns = False

        Dim funcionarios As List(Of SistemaServiceReference.Funcionario) = Me.client.ListarFuncionarios().ToList()
        Dim clientes As List(Of SistemaServiceReference.Cliente) = Me.client.ListarClientes().ToList()
        Dim projetos As List(Of SistemaServiceReference.Projeto) = Me.client.ListarProjetos().ToList()
        Dim tiposhora As List(Of SistemaServiceReference.TipoHora) = Me.client.ListarTiposHora().ToList()
        Dim situacoes As List(Of SistemaServiceReference.Status) = Me.client.ListarStatus().ToList()

        ComboboxUtils.CarregarCombobox("Nome", "Codigo", funcionarios, cboFuncionario)
        ComboboxUtils.CarregarCombobox("Nome", "Codigo", clientes, cboCliente)
        ComboboxUtils.CarregarCombobox("Nome", "Codigo", clientes, cboClienteDetalhamento)
        ComboboxUtils.CarregarCombobox("Descricao", "Codigo", projetos, cboProjeto)
        ComboboxUtils.CarregarCombobox("Descricao", "Codigo", tiposhora, cboTipoHora)
        ComboboxUtils.CarregarCombobox("Descricao", "Codigo", situacoes, cboSituacao)
    End Sub

    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        Me.PesquisarOrdensDeServico()
        If Me.ordensServico.Count > 0 Then
            Me.dicionarioOS = Me.ordensServico.ToDictionary(Function(x) x.Codigo, Function(x) x)
            grdOrdemServico.DataSource = Me.ordensServico
            txtTotalLinhas.Text = Me.ordensServico.Count
        Else
            grdOrdemServico.DataSource = Nothing
            txtTotalLinhas.Text = 0
            MessageBox.Show("A pesquisa não retornou resultados")
        End If
    End Sub

    Private Sub grdOrdemServico_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles grdOrdemServico.CellFormatting
        If Me.dicionarioOS.Count > 0 Then
            Dim codigo As Integer = Convert.ToInt32(grdOrdemServico.Rows(e.RowIndex).Cells(0).Value.ToString())
            Dim os As SistemaServiceReference.OS = Me.dicionarioOS(codigo)
            grdOrdemServico.Rows(e.RowIndex).Cells(1).Value = Me.ordensServico(e.RowIndex).Cliente.Nome
            grdOrdemServico.Rows(e.RowIndex).Cells(2).Value = Me.ordensServico(e.RowIndex).Funcionario.Nome
            grdOrdemServico.Rows(e.RowIndex).Cells(7).Value = Me.ordensServico(e.RowIndex).Status.Descricao
        End If
    End Sub

    Private Function ValidarFormulario() As Integer
        Dim numeroErros As Integer = 0

        For Each control As Control In tabDetalhamento.Controls
            Dim validador As New Validador

            If TypeOf control Is GroupBox Then

                Dim group As GroupBox = control

                For Each sonControl As Control In group.Controls

                    If TypeOf sonControl Is ComboBox Then
                        Dim combobox As ComboBox = sonControl
                        If Not validador.ValidarPreenchimento(epPreencimentoCampo, combobox) Then
                            numeroErros = numeroErros + 1
                        End If
                    End If

                    If TypeOf sonControl Is MaskedTextBox Then
                        Dim maskedInput As MaskedTextBox = sonControl
                        If Not validador.ValidarPreenchimento(epPreencimentoCampo, maskedInput) Then
                            numeroErros = numeroErros + 1
                        End If
                    End If

                    If TypeOf sonControl Is TextBox Then
                        Dim textBox As TextBox = sonControl
                        If Not validador.ValidarPreenchimento(epPreencimentoCampo, textBox) Then
                            numeroErros = numeroErros + 1
                        End If
                    End If
                Next
            End If
        Next

        Return numeroErros
    End Function

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If ValidarFormulario() = 0 Then
            Dim ordemServico As SistemaServiceReference.OS = Me.PegarValoresFormulario()
            If Me.edicao Then
                Me.client.EditarOrdemServico(ordemServico)
            Else
                Me.client.CadastrarOrdemServico(ordemServico)
            End If
        End If
    End Sub

    Private Sub grdOrdemServico_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdOrdemServico.CellClick
        If grdOrdemServico.CurrentRow.Selected Then
            Dim idOs As Int32 = Convert.ToInt32(grdOrdemServico.CurrentRow.Cells(0).Value.ToString())
            Me.CarregarFormularioDeOrdemDeServico(idOs)
            Me.edicao = True
        End If
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Me.LimparFormulario()
        Me.guiasTab.SelectedTab = tabDetalhamento        
        Me.edicao = False
        txtDetalhamentoNumeroOS.Text = "999999"
    End Sub

    Private Sub LimparFormulario()
        txtDetalhamentoNumeroOS.Text = String.Empty
        txtAtendimento.Text = String.Empty
        txtObservacao.Text = String.Empty
        txtInicio.Text = String.Empty
        txtFim.Text = String.Empty
        txtTraslado.Text = String.Empty
        cboClienteDetalhamento.SelectedValue = String.Empty
        cboProjeto.SelectedValue = String.Empty
        cboTipoHora.SelectedValue = String.Empty
        cboSituacao.SelectedValue = String.Empty
        dtpDataAtendimento.Text = DateTime.Now.ToString()
        chkFaturado.Checked = False
    End Sub

    Private Function PegarValoresFormulario() As SistemaServiceReference.OS
        Dim ordemServico As New SistemaServiceReference.OS
        ordemServico.Codigo = Convert.ToInt32(txtDetalhamentoNumeroOS.Text)
        ordemServico.Atividade = txtAtendimento.Text
        ordemServico.Observacao = txtObservacao.Text
        ordemServico.Inicio = txtInicio.Text
        ordemServico.Fim = txtFim.Text
        ordemServico.Traslado = txtTraslado.Text
        ordemServico.Projeto = New SistemaServiceReference.Projeto With {.Codigo = Convert.ToInt32(cboProjeto.SelectedValue)}
        ordemServico.TipoHora = New SistemaServiceReference.TipoHora With {.Codigo = Convert.ToInt32(cboTipoHora.SelectedValue)}
        ordemServico.Funcionario = New SistemaServiceReference.Funcionario With {.Codigo = Convert.ToInt32(cboFuncionario.SelectedValue)}
        ordemServico.Status = New SistemaServiceReference.Status With {.Codigo = Convert.ToInt32(cboSituacao.SelectedValue)}
        ordemServico.Data = Convert.ToDateTime(dtpDataAtendimento.Text)
        Return ordemServico
    End Function

    Private Sub CarregarFormularioDeOrdemDeServico(ByVal id As Integer)
        Dim ordemServicoSelecionada As SistemaServiceReference.OS = Me.client.ConsultarOrdemServico(id)
        cboSituacao.SelectedValue = ordemServicoSelecionada.Status.Codigo.ToString()
        cboClienteDetalhamento.SelectedValue = ordemServicoSelecionada.Cliente.Codigo.ToString()
        cboProjeto.SelectedValue = ordemServicoSelecionada.Projeto.Codigo.ToString()
        cboTipoHora.SelectedValue = ordemServicoSelecionada.TipoHora.Codigo.ToString()
        chkFaturado.Checked = Convert.ToBoolean(ordemServicoSelecionada.Faturado)
        txtDetalhamentoNumeroOS.Text = ordemServicoSelecionada.Codigo
        txtInicio.Text = ordemServicoSelecionada.Inicio
        txtFim.Text = ordemServicoSelecionada.Fim
        txtTraslado.Text = ordemServicoSelecionada.Traslado
        txtAtendimento.Text = ordemServicoSelecionada.Atividade
        txtObservacao.Text = ordemServicoSelecionada.Observacao
        dtpDataAtendimento.Text = ordemServicoSelecionada.Data.ToString()
    End Sub

End Class
