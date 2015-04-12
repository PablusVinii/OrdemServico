<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrdemServicoUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.guiasTab = New System.Windows.Forms.TabControl()
        Me.tabConsultaOS = New System.Windows.Forms.TabPage()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnRelatorioListagem = New System.Windows.Forms.Button()
        Me.btnRelatorioHorasGastas = New System.Windows.Forms.Button()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.dtpAte = New System.Windows.Forms.DateTimePicker()
        Me.dtpDe = New System.Windows.Forms.DateTimePicker()
        Me.lblAte = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblFuncionario = New System.Windows.Forms.Label()
        Me.lblNumeroOS = New System.Windows.Forms.Label()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.cboFuncionario = New System.Windows.Forms.ComboBox()
        Me.txtNumeroOS = New System.Windows.Forms.TextBox()
        Me.grdOrdemServico = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Funcionario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Traslado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Situacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabDetalhamento = New System.Windows.Forms.TabPage()
        Me.groupAtendimento = New System.Windows.Forms.GroupBox()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.lblObservacao = New System.Windows.Forms.Label()
        Me.lblAtendimento = New System.Windows.Forms.Label()
        Me.txtAtendimento = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.groupDetalhesHoras = New System.Windows.Forms.GroupBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.dtpDataAtendimento = New System.Windows.Forms.DateTimePicker()
        Me.txtTraslado = New System.Windows.Forms.MaskedTextBox()
        Me.txtFim = New System.Windows.Forms.MaskedTextBox()
        Me.txtInicio = New System.Windows.Forms.MaskedTextBox()
        Me.lblTraslado = New System.Windows.Forms.Label()
        Me.lblFim = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.lblTipoHora = New System.Windows.Forms.Label()
        Me.cboTipoHora = New System.Windows.Forms.ComboBox()
        Me.groupGeral = New System.Windows.Forms.GroupBox()
        Me.chkFaturado = New System.Windows.Forms.CheckBox()
        Me.lblProjeto = New System.Windows.Forms.Label()
        Me.lblClienteDetalhamento = New System.Windows.Forms.Label()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.cboProjeto = New System.Windows.Forms.ComboBox()
        Me.cboClienteDetalhamento = New System.Windows.Forms.ComboBox()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.epPreencimentoCampo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblNumeroDetalhamentoOS = New System.Windows.Forms.Label()
        Me.txtDetalhamentoNumeroOS = New System.Windows.Forms.TextBox()
        Me.lblTotalLinhas = New System.Windows.Forms.Label()
        Me.txtTotalLinhas = New System.Windows.Forms.TextBox()
        Me.guiasTab.SuspendLayout()
        Me.tabConsultaOS.SuspendLayout()
        CType(Me.grdOrdemServico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDetalhamento.SuspendLayout()
        Me.groupAtendimento.SuspendLayout()
        Me.groupDetalhesHoras.SuspendLayout()
        Me.groupGeral.SuspendLayout()
        CType(Me.epPreencimentoCampo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'guiasTab
        '
        Me.guiasTab.Controls.Add(Me.tabConsultaOS)
        Me.guiasTab.Controls.Add(Me.tabDetalhamento)
        Me.guiasTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.guiasTab.Location = New System.Drawing.Point(0, 0)
        Me.guiasTab.Name = "guiasTab"
        Me.guiasTab.SelectedIndex = 0
        Me.guiasTab.Size = New System.Drawing.Size(1029, 680)
        Me.guiasTab.TabIndex = 0
        '
        'tabConsultaOS
        '
        Me.tabConsultaOS.Controls.Add(Me.txtTotalLinhas)
        Me.tabConsultaOS.Controls.Add(Me.lblTotalLinhas)
        Me.tabConsultaOS.Controls.Add(Me.btnNovo)
        Me.tabConsultaOS.Controls.Add(Me.btnRelatorioListagem)
        Me.tabConsultaOS.Controls.Add(Me.btnRelatorioHorasGastas)
        Me.tabConsultaOS.Controls.Add(Me.btnPesquisar)
        Me.tabConsultaOS.Controls.Add(Me.dtpAte)
        Me.tabConsultaOS.Controls.Add(Me.dtpDe)
        Me.tabConsultaOS.Controls.Add(Me.lblAte)
        Me.tabConsultaOS.Controls.Add(Me.lblDe)
        Me.tabConsultaOS.Controls.Add(Me.lblCliente)
        Me.tabConsultaOS.Controls.Add(Me.lblFuncionario)
        Me.tabConsultaOS.Controls.Add(Me.lblNumeroOS)
        Me.tabConsultaOS.Controls.Add(Me.cboCliente)
        Me.tabConsultaOS.Controls.Add(Me.cboFuncionario)
        Me.tabConsultaOS.Controls.Add(Me.txtNumeroOS)
        Me.tabConsultaOS.Controls.Add(Me.grdOrdemServico)
        Me.tabConsultaOS.Location = New System.Drawing.Point(4, 22)
        Me.tabConsultaOS.Name = "tabConsultaOS"
        Me.tabConsultaOS.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConsultaOS.Size = New System.Drawing.Size(1021, 654)
        Me.tabConsultaOS.TabIndex = 0
        Me.tabConsultaOS.Text = "Consulta"
        Me.tabConsultaOS.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNovo.Location = New System.Drawing.Point(710, 21)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(288, 23)
        Me.btnNovo.TabIndex = 16
        Me.btnNovo.Text = "Novo (F2)"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnRelatorioListagem
        '
        Me.btnRelatorioListagem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelatorioListagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelatorioListagem.Location = New System.Drawing.Point(710, 76)
        Me.btnRelatorioListagem.Name = "btnRelatorioListagem"
        Me.btnRelatorioListagem.Size = New System.Drawing.Size(288, 23)
        Me.btnRelatorioListagem.TabIndex = 15
        Me.btnRelatorioListagem.Text = "Relatório de Ordens de Serviço (F4)"
        Me.btnRelatorioListagem.UseVisualStyleBackColor = True
        '
        'btnRelatorioHorasGastas
        '
        Me.btnRelatorioHorasGastas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelatorioHorasGastas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelatorioHorasGastas.Location = New System.Drawing.Point(710, 105)
        Me.btnRelatorioHorasGastas.Name = "btnRelatorioHorasGastas"
        Me.btnRelatorioHorasGastas.Size = New System.Drawing.Size(288, 23)
        Me.btnRelatorioHorasGastas.TabIndex = 14
        Me.btnRelatorioHorasGastas.Text = "Relatório de Horas Gastas (F5)"
        Me.btnRelatorioHorasGastas.UseVisualStyleBackColor = True
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPesquisar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.Location = New System.Drawing.Point(710, 47)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(288, 23)
        Me.btnPesquisar.TabIndex = 13
        Me.btnPesquisar.Text = "Pesquisar (F3)"
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'dtpAte
        '
        Me.dtpAte.Location = New System.Drawing.Point(480, 24)
        Me.dtpAte.Name = "dtpAte"
        Me.dtpAte.Size = New System.Drawing.Size(165, 20)
        Me.dtpAte.TabIndex = 12
        '
        'dtpDe
        '
        Me.dtpDe.Location = New System.Drawing.Point(264, 24)
        Me.dtpDe.Name = "dtpDe"
        Me.dtpDe.Size = New System.Drawing.Size(165, 20)
        Me.dtpDe.TabIndex = 11
        '
        'lblAte
        '
        Me.lblAte.AutoSize = True
        Me.lblAte.Location = New System.Drawing.Point(435, 30)
        Me.lblAte.Name = "lblAte"
        Me.lblAte.Size = New System.Drawing.Size(26, 13)
        Me.lblAte.TabIndex = 10
        Me.lblAte.Text = "Até:"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(219, 30)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(24, 13)
        Me.lblDe.TabIndex = 9
        Me.lblDe.Text = "De:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(12, 106)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 8
        Me.lblCliente.Text = "Cliente:"
        '
        'lblFuncionario
        '
        Me.lblFuncionario.AutoSize = True
        Me.lblFuncionario.Location = New System.Drawing.Point(12, 65)
        Me.lblFuncionario.Name = "lblFuncionario"
        Me.lblFuncionario.Size = New System.Drawing.Size(62, 13)
        Me.lblFuncionario.TabIndex = 7
        Me.lblFuncionario.Text = "Funcionário"
        '
        'lblNumeroOS
        '
        Me.lblNumeroOS.AutoSize = True
        Me.lblNumeroOS.Location = New System.Drawing.Point(12, 26)
        Me.lblNumeroOS.Name = "lblNumeroOS"
        Me.lblNumeroOS.Size = New System.Drawing.Size(40, 13)
        Me.lblNumeroOS.TabIndex = 6
        Me.lblNumeroOS.Text = "Nº OS:"
        '
        'cboCliente
        '
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(88, 102)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(557, 21)
        Me.cboCliente.TabIndex = 4
        '
        'cboFuncionario
        '
        Me.cboFuncionario.FormattingEnabled = True
        Me.cboFuncionario.Location = New System.Drawing.Point(88, 61)
        Me.cboFuncionario.Name = "cboFuncionario"
        Me.cboFuncionario.Size = New System.Drawing.Size(557, 21)
        Me.cboFuncionario.TabIndex = 2
        '
        'txtNumeroOS
        '
        Me.txtNumeroOS.Location = New System.Drawing.Point(88, 23)
        Me.txtNumeroOS.Name = "txtNumeroOS"
        Me.txtNumeroOS.Size = New System.Drawing.Size(121, 20)
        Me.txtNumeroOS.TabIndex = 1
        '
        'grdOrdemServico
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdOrdemServico.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grdOrdemServico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdOrdemServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdOrdemServico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.NomeCliente, Me.Funcionario, Me.Data, Me.Inicio, Me.Fim, Me.Traslado, Me.Situacao})
        Me.grdOrdemServico.Location = New System.Drawing.Point(6, 177)
        Me.grdOrdemServico.Name = "grdOrdemServico"
        Me.grdOrdemServico.Size = New System.Drawing.Size(992, 434)
        Me.grdOrdemServico.TabIndex = 0
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 70
        '
        'NomeCliente
        '
        Me.NomeCliente.HeaderText = "Cliente"
        Me.NomeCliente.Name = "NomeCliente"
        Me.NomeCliente.ReadOnly = True
        Me.NomeCliente.Width = 200
        '
        'Funcionario
        '
        Me.Funcionario.HeaderText = "Funcionário"
        Me.Funcionario.Name = "Funcionario"
        Me.Funcionario.ReadOnly = True
        Me.Funcionario.Width = 200
        '
        'Data
        '
        Me.Data.DataPropertyName = "Data"
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        Me.Data.ReadOnly = True
        Me.Data.Width = 80
        '
        'Inicio
        '
        Me.Inicio.DataPropertyName = "Inicio"
        Me.Inicio.HeaderText = "Início"
        Me.Inicio.Name = "Inicio"
        Me.Inicio.ReadOnly = True
        Me.Inicio.Width = 80
        '
        'Fim
        '
        Me.Fim.DataPropertyName = "Fim"
        Me.Fim.HeaderText = "Fim"
        Me.Fim.Name = "Fim"
        Me.Fim.ReadOnly = True
        Me.Fim.Width = 80
        '
        'Traslado
        '
        Me.Traslado.DataPropertyName = "Traslado"
        Me.Traslado.HeaderText = "Traslado"
        Me.Traslado.Name = "Traslado"
        Me.Traslado.ReadOnly = True
        '
        'Situacao
        '
        Me.Situacao.HeaderText = "Situação"
        Me.Situacao.Name = "Situacao"
        Me.Situacao.ReadOnly = True
        Me.Situacao.Width = 150
        '
        'tabDetalhamento
        '
        Me.tabDetalhamento.Controls.Add(Me.groupAtendimento)
        Me.tabDetalhamento.Controls.Add(Me.groupDetalhesHoras)
        Me.tabDetalhamento.Controls.Add(Me.groupGeral)
        Me.tabDetalhamento.Location = New System.Drawing.Point(4, 22)
        Me.tabDetalhamento.Name = "tabDetalhamento"
        Me.tabDetalhamento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetalhamento.Size = New System.Drawing.Size(1021, 654)
        Me.tabDetalhamento.TabIndex = 1
        Me.tabDetalhamento.Text = "Detalhamento"
        Me.tabDetalhamento.UseVisualStyleBackColor = True
        '
        'groupAtendimento
        '
        Me.groupAtendimento.Controls.Add(Me.txtObservacao)
        Me.groupAtendimento.Controls.Add(Me.lblObservacao)
        Me.groupAtendimento.Controls.Add(Me.lblAtendimento)
        Me.groupAtendimento.Controls.Add(Me.txtAtendimento)
        Me.groupAtendimento.Controls.Add(Me.btnEnviar)
        Me.groupAtendimento.Location = New System.Drawing.Point(16, 270)
        Me.groupAtendimento.Name = "groupAtendimento"
        Me.groupAtendimento.Size = New System.Drawing.Size(983, 358)
        Me.groupAtendimento.TabIndex = 3
        Me.groupAtendimento.TabStop = False
        Me.groupAtendimento.Text = "Informações do Atendimento"
        '
        'txtObservacao
        '
        Me.txtObservacao.Location = New System.Drawing.Point(16, 212)
        Me.txtObservacao.Multiline = True
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(938, 111)
        Me.txtObservacao.TabIndex = 9
        '
        'lblObservacao
        '
        Me.lblObservacao.AutoSize = True
        Me.lblObservacao.Location = New System.Drawing.Point(16, 196)
        Me.lblObservacao.Name = "lblObservacao"
        Me.lblObservacao.Size = New System.Drawing.Size(68, 13)
        Me.lblObservacao.TabIndex = 8
        Me.lblObservacao.Text = "Observação:"
        '
        'lblAtendimento
        '
        Me.lblAtendimento.AutoSize = True
        Me.lblAtendimento.Location = New System.Drawing.Point(16, 20)
        Me.lblAtendimento.Name = "lblAtendimento"
        Me.lblAtendimento.Size = New System.Drawing.Size(69, 13)
        Me.lblAtendimento.TabIndex = 7
        Me.lblAtendimento.Text = "Atendimento:"
        '
        'txtAtendimento
        '
        Me.txtAtendimento.Location = New System.Drawing.Point(19, 36)
        Me.txtAtendimento.Multiline = True
        Me.txtAtendimento.Name = "txtAtendimento"
        Me.txtAtendimento.Size = New System.Drawing.Size(938, 146)
        Me.txtAtendimento.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Location = New System.Drawing.Point(832, 329)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(125, 23)
        Me.btnEnviar.TabIndex = 4
        Me.btnEnviar.Text = "Enviar (F6)"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'groupDetalhesHoras
        '
        Me.groupDetalhesHoras.Controls.Add(Me.lblData)
        Me.groupDetalhesHoras.Controls.Add(Me.dtpDataAtendimento)
        Me.groupDetalhesHoras.Controls.Add(Me.txtTraslado)
        Me.groupDetalhesHoras.Controls.Add(Me.txtFim)
        Me.groupDetalhesHoras.Controls.Add(Me.txtInicio)
        Me.groupDetalhesHoras.Controls.Add(Me.lblTraslado)
        Me.groupDetalhesHoras.Controls.Add(Me.lblFim)
        Me.groupDetalhesHoras.Controls.Add(Me.lblInicio)
        Me.groupDetalhesHoras.Controls.Add(Me.lblTipoHora)
        Me.groupDetalhesHoras.Controls.Add(Me.cboTipoHora)
        Me.groupDetalhesHoras.Location = New System.Drawing.Point(16, 168)
        Me.groupDetalhesHoras.Name = "groupDetalhesHoras"
        Me.groupDetalhesHoras.Size = New System.Drawing.Size(983, 87)
        Me.groupDetalhesHoras.TabIndex = 1
        Me.groupDetalhesHoras.TabStop = False
        Me.groupDetalhesHoras.Text = "Detalhes das Horas"
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(11, 26)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(33, 13)
        Me.lblData.TabIndex = 17
        Me.lblData.Text = "Data:"
        '
        'dtpDataAtendimento
        '
        Me.dtpDataAtendimento.Location = New System.Drawing.Point(10, 43)
        Me.dtpDataAtendimento.Name = "dtpDataAtendimento"
        Me.dtpDataAtendimento.Size = New System.Drawing.Size(243, 20)
        Me.dtpDataAtendimento.TabIndex = 16
        '
        'txtTraslado
        '
        Me.txtTraslado.Location = New System.Drawing.Point(841, 44)
        Me.txtTraslado.Mask = "00:00"
        Me.txtTraslado.Name = "txtTraslado"
        Me.txtTraslado.Size = New System.Drawing.Size(128, 20)
        Me.txtTraslado.TabIndex = 15
        Me.txtTraslado.ValidatingType = GetType(Date)
        '
        'txtFim
        '
        Me.txtFim.Location = New System.Drawing.Point(707, 44)
        Me.txtFim.Mask = "00:00"
        Me.txtFim.Name = "txtFim"
        Me.txtFim.Size = New System.Drawing.Size(128, 20)
        Me.txtFim.TabIndex = 14
        Me.txtFim.ValidatingType = GetType(Date)
        '
        'txtInicio
        '
        Me.txtInicio.Location = New System.Drawing.Point(565, 44)
        Me.txtInicio.Mask = "00:00"
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(128, 20)
        Me.txtInicio.TabIndex = 13
        Me.txtInicio.ValidatingType = GetType(Date)
        '
        'lblTraslado
        '
        Me.lblTraslado.AutoSize = True
        Me.lblTraslado.Location = New System.Drawing.Point(838, 26)
        Me.lblTraslado.Name = "lblTraslado"
        Me.lblTraslado.Size = New System.Drawing.Size(51, 13)
        Me.lblTraslado.TabIndex = 9
        Me.lblTraslado.Text = "Traslado:"
        '
        'lblFim
        '
        Me.lblFim.AutoSize = True
        Me.lblFim.Location = New System.Drawing.Point(704, 26)
        Me.lblFim.Name = "lblFim"
        Me.lblFim.Size = New System.Drawing.Size(26, 13)
        Me.lblFim.TabIndex = 8
        Me.lblFim.Text = "Fim:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Location = New System.Drawing.Point(562, 26)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(37, 13)
        Me.lblInicio.TabIndex = 7
        Me.lblInicio.Text = "Início:"
        '
        'lblTipoHora
        '
        Me.lblTipoHora.AutoSize = True
        Me.lblTipoHora.Location = New System.Drawing.Point(267, 27)
        Me.lblTipoHora.Name = "lblTipoHora"
        Me.lblTipoHora.Size = New System.Drawing.Size(57, 13)
        Me.lblTipoHora.TabIndex = 6
        Me.lblTipoHora.Text = "Tipo Hora:"
        '
        'cboTipoHora
        '
        Me.cboTipoHora.FormattingEnabled = True
        Me.cboTipoHora.Location = New System.Drawing.Point(270, 43)
        Me.cboTipoHora.Name = "cboTipoHora"
        Me.cboTipoHora.Size = New System.Drawing.Size(284, 21)
        Me.cboTipoHora.TabIndex = 3
        '
        'groupGeral
        '
        Me.groupGeral.Controls.Add(Me.txtDetalhamentoNumeroOS)
        Me.groupGeral.Controls.Add(Me.lblNumeroDetalhamentoOS)
        Me.groupGeral.Controls.Add(Me.chkFaturado)
        Me.groupGeral.Controls.Add(Me.lblProjeto)
        Me.groupGeral.Controls.Add(Me.lblClienteDetalhamento)
        Me.groupGeral.Controls.Add(Me.lblSituacao)
        Me.groupGeral.Controls.Add(Me.cboProjeto)
        Me.groupGeral.Controls.Add(Me.cboClienteDetalhamento)
        Me.groupGeral.Controls.Add(Me.cboSituacao)
        Me.groupGeral.Location = New System.Drawing.Point(16, 25)
        Me.groupGeral.Name = "groupGeral"
        Me.groupGeral.Size = New System.Drawing.Size(983, 128)
        Me.groupGeral.TabIndex = 0
        Me.groupGeral.TabStop = False
        Me.groupGeral.Text = "Geral"
        '
        'chkFaturado
        '
        Me.chkFaturado.AutoSize = True
        Me.chkFaturado.Location = New System.Drawing.Point(886, 22)
        Me.chkFaturado.Name = "chkFaturado"
        Me.chkFaturado.Size = New System.Drawing.Size(68, 17)
        Me.chkFaturado.TabIndex = 6
        Me.chkFaturado.Text = "Faturado"
        Me.chkFaturado.UseVisualStyleBackColor = True
        '
        'lblProjeto
        '
        Me.lblProjeto.AutoSize = True
        Me.lblProjeto.Location = New System.Drawing.Point(7, 90)
        Me.lblProjeto.Name = "lblProjeto"
        Me.lblProjeto.Size = New System.Drawing.Size(43, 13)
        Me.lblProjeto.TabIndex = 5
        Me.lblProjeto.Text = "Projeto:"
        '
        'lblClienteDetalhamento
        '
        Me.lblClienteDetalhamento.AutoSize = True
        Me.lblClienteDetalhamento.Location = New System.Drawing.Point(7, 53)
        Me.lblClienteDetalhamento.Name = "lblClienteDetalhamento"
        Me.lblClienteDetalhamento.Size = New System.Drawing.Size(42, 13)
        Me.lblClienteDetalhamento.TabIndex = 5
        Me.lblClienteDetalhamento.Text = "Cliente:"
        '
        'lblSituacao
        '
        Me.lblSituacao.AutoSize = True
        Me.lblSituacao.Location = New System.Drawing.Point(291, 27)
        Me.lblSituacao.Name = "lblSituacao"
        Me.lblSituacao.Size = New System.Drawing.Size(52, 13)
        Me.lblSituacao.TabIndex = 4
        Me.lblSituacao.Text = "Situação:"
        '
        'cboProjeto
        '
        Me.cboProjeto.FormattingEnabled = True
        Me.cboProjeto.Location = New System.Drawing.Point(87, 82)
        Me.cboProjeto.Name = "cboProjeto"
        Me.cboProjeto.Size = New System.Drawing.Size(870, 21)
        Me.cboProjeto.TabIndex = 2
        '
        'cboClienteDetalhamento
        '
        Me.cboClienteDetalhamento.FormattingEnabled = True
        Me.cboClienteDetalhamento.Location = New System.Drawing.Point(87, 50)
        Me.cboClienteDetalhamento.Name = "cboClienteDetalhamento"
        Me.cboClienteDetalhamento.Size = New System.Drawing.Size(870, 21)
        Me.cboClienteDetalhamento.TabIndex = 1
        '
        'cboSituacao
        '
        Me.cboSituacao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Location = New System.Drawing.Point(361, 19)
        Me.cboSituacao.Name = "cboSituacao"
        Me.cboSituacao.Size = New System.Drawing.Size(504, 21)
        Me.cboSituacao.TabIndex = 0
        '
        'epPreencimentoCampo
        '
        Me.epPreencimentoCampo.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.epPreencimentoCampo.ContainerControl = Me
        '
        'lblNumeroDetalhamentoOS
        '
        Me.lblNumeroDetalhamentoOS.AutoSize = True
        Me.lblNumeroDetalhamentoOS.Location = New System.Drawing.Point(11, 23)
        Me.lblNumeroDetalhamentoOS.Name = "lblNumeroDetalhamentoOS"
        Me.lblNumeroDetalhamentoOS.Size = New System.Drawing.Size(65, 13)
        Me.lblNumeroDetalhamentoOS.TabIndex = 7
        Me.lblNumeroDetalhamentoOS.Text = "Número OS:"
        '
        'txtDetalhamentoNumeroOS
        '
        Me.txtDetalhamentoNumeroOS.Enabled = False
        Me.txtDetalhamentoNumeroOS.Location = New System.Drawing.Point(87, 19)
        Me.txtDetalhamentoNumeroOS.Name = "txtDetalhamentoNumeroOS"
        Me.txtDetalhamentoNumeroOS.Size = New System.Drawing.Size(198, 20)
        Me.txtDetalhamentoNumeroOS.TabIndex = 8
        '
        'lblTotalLinhas
        '
        Me.lblTotalLinhas.AutoSize = True
        Me.lblTotalLinhas.Location = New System.Drawing.Point(3, 626)
        Me.lblTotalLinhas.Name = "lblTotalLinhas"
        Me.lblTotalLinhas.Size = New System.Drawing.Size(159, 13)
        Me.lblTotalLinhas.TabIndex = 17
        Me.lblTotalLinhas.Text = "Total de Registros Encontrados:"
        '
        'txtTotalLinhas
        '
        Me.txtTotalLinhas.Enabled = False
        Me.txtTotalLinhas.Location = New System.Drawing.Point(168, 623)
        Me.txtTotalLinhas.Name = "txtTotalLinhas"
        Me.txtTotalLinhas.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalLinhas.TabIndex = 18
        '
        'OrdemServicoUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.guiasTab)
        Me.Name = "OrdemServicoUserControl"
        Me.Size = New System.Drawing.Size(1029, 680)
        Me.guiasTab.ResumeLayout(False)
        Me.tabConsultaOS.ResumeLayout(False)
        Me.tabConsultaOS.PerformLayout()
        CType(Me.grdOrdemServico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDetalhamento.ResumeLayout(False)
        Me.groupAtendimento.ResumeLayout(False)
        Me.groupAtendimento.PerformLayout()
        Me.groupDetalhesHoras.ResumeLayout(False)
        Me.groupDetalhesHoras.PerformLayout()
        Me.groupGeral.ResumeLayout(False)
        Me.groupGeral.PerformLayout()
        CType(Me.epPreencimentoCampo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents guiasTab As System.Windows.Forms.TabControl
    Friend WithEvents tabConsultaOS As System.Windows.Forms.TabPage
    Friend WithEvents txtNumeroOS As System.Windows.Forms.TextBox
    Friend WithEvents grdOrdemServico As System.Windows.Forms.DataGridView
    Friend WithEvents tabDetalhamento As System.Windows.Forms.TabPage
    Friend WithEvents btnPesquisar As System.Windows.Forms.Button
    Friend WithEvents dtpAte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAte As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblFuncionario As System.Windows.Forms.Label
    Friend WithEvents lblNumeroOS As System.Windows.Forms.Label
    Friend WithEvents cboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cboFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents groupAtendimento As System.Windows.Forms.GroupBox
    Friend WithEvents groupDetalhesHoras As System.Windows.Forms.GroupBox
    Friend WithEvents lblTraslado As System.Windows.Forms.Label
    Friend WithEvents lblFim As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents lblTipoHora As System.Windows.Forms.Label
    Friend WithEvents cboTipoHora As System.Windows.Forms.ComboBox
    Friend WithEvents groupGeral As System.Windows.Forms.GroupBox
    Friend WithEvents lblProjeto As System.Windows.Forms.Label
    Friend WithEvents lblClienteDetalhamento As System.Windows.Forms.Label
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents cboProjeto As System.Windows.Forms.ComboBox
    Friend WithEvents cboClienteDetalhamento As System.Windows.Forms.ComboBox
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents btnRelatorioListagem As System.Windows.Forms.Button
    Friend WithEvents btnRelatorioHorasGastas As System.Windows.Forms.Button
    Friend WithEvents txtTraslado As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFim As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtInicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chkFaturado As System.Windows.Forms.CheckBox
    Friend WithEvents epPreencimentoCampo As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacao As System.Windows.Forms.Label
    Friend WithEvents lblAtendimento As System.Windows.Forms.Label
    Friend WithEvents txtAtendimento As System.Windows.Forms.TextBox
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Funcionario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Traslado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Situacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents dtpDataAtendimento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDetalhamentoNumeroOS As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDetalhamentoOS As System.Windows.Forms.Label
    Friend WithEvents txtTotalLinhas As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalLinhas As System.Windows.Forms.Label

End Class
