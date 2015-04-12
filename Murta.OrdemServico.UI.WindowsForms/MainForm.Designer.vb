<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.menuTree = New System.Windows.Forms.TreeView()
        Me.pnlModulo = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'menuTree
        '
        Me.menuTree.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.menuTree.Location = New System.Drawing.Point(12, 12)
        Me.menuTree.Name = "menuTree"
        Me.menuTree.Size = New System.Drawing.Size(259, 393)
        Me.menuTree.TabIndex = 0
        '
        'pnlModulo
        '
        Me.pnlModulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlModulo.Location = New System.Drawing.Point(277, 12)
        Me.pnlModulo.Name = "pnlModulo"
        Me.pnlModulo.Size = New System.Drawing.Size(554, 393)
        Me.pnlModulo.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 417)
        Me.Controls.Add(Me.pnlModulo)
        Me.Controls.Add(Me.menuTree)
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents menuTree As System.Windows.Forms.TreeView
    Friend WithEvents pnlModulo As System.Windows.Forms.Panel
End Class
