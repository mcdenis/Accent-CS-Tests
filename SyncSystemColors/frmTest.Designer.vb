<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UcDialogCommandPanel1 = New SyncSystemColors.ucDialogCommandPanel()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 34)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UcDialogCommandPanel1
        '
        Me.UcDialogCommandPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UcDialogCommandPanel1.Location = New System.Drawing.Point(11, 194)
        Me.UcDialogCommandPanel1.Margin = New System.Windows.Forms.Padding(5)
        Me.UcDialogCommandPanel1.Name = "UcDialogCommandPanel1"
        Me.UcDialogCommandPanel1.SeparatorStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcDialogCommandPanel1.Size = New System.Drawing.Size(351, 48)
        Me.UcDialogCommandPanel1.TabIndex = 0
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 252)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UcDialogCommandPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmTest"
        Me.Padding = New System.Windows.Forms.Padding(11, 10, 11, 10)
        Me.Text = "frmTest"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcDialogCommandPanel1 As ucDialogCommandPanel
    Friend WithEvents Button1 As Button
End Class
