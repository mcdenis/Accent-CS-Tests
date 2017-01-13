<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAboutBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelProductNameAndVersion As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAboutBox))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelProductNameAndVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.lbtWebsite = New System.Windows.Forms.LinkLabel()
        Me.lbtLicense = New System.Windows.Forms.LinkLabel()
        Me.lblLogo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 3
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.54567!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.28103!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.76091!))
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductNameAndVersion, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 2, 4)
        Me.TableLayoutPanel.Controls.Add(Me.lbtWebsite, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.lbtLicense, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.lblLogo, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 11)
        Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 5
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(427, 215)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'LabelProductNameAndVersion
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.LabelProductNameAndVersion, 2)
        Me.LabelProductNameAndVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductNameAndVersion.Location = New System.Drawing.Point(100, 2)
        Me.LabelProductNameAndVersion.Margin = New System.Windows.Forms.Padding(8, 2, 4, 2)
        Me.LabelProductNameAndVersion.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelProductNameAndVersion.Name = "LabelProductNameAndVersion"
        Me.LabelProductNameAndVersion.Size = New System.Drawing.Size(323, 21)
        Me.LabelProductNameAndVersion.TabIndex = 0
        Me.LabelProductNameAndVersion.Text = "Product Name + Version"
        Me.LabelProductNameAndVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.LabelCopyright, 2)
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Location = New System.Drawing.Point(100, 27)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(8, 2, 4, 2)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(323, 21)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TableLayoutPanel.SetColumnSpan(Me.TextBoxDescription, 2)
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Location = New System.Drawing.Point(100, 52)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(8, 2, 4, 2)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(323, 22)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(323, 184)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 27)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'lbtWebsite
        '
        Me.lbtWebsite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbtWebsite.AutoSize = True
        Me.lbtWebsite.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.lbtWebsite.Location = New System.Drawing.Point(100, 196)
        Me.lbtWebsite.Margin = New System.Windows.Forms.Padding(8, 2, 4, 2)
        Me.lbtWebsite.Name = "lbtWebsite"
        Me.lbtWebsite.Size = New System.Drawing.Size(152, 17)
        Me.lbtWebsite.TabIndex = 1
        Me.lbtWebsite.TabStop = True
        Me.lbtWebsite.Text = "Visit project homepage"
        '
        'lbtLicense
        '
        Me.lbtLicense.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbtLicense.AutoSize = True
        Me.TableLayoutPanel.SetColumnSpan(Me.lbtLicense, 2)
        Me.lbtLicense.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.lbtLicense.Location = New System.Drawing.Point(100, 117)
        Me.lbtLicense.Margin = New System.Windows.Forms.Padding(8, 10, 4, 0)
        Me.lbtLicense.Name = "lbtLicense"
        Me.lbtLicense.Size = New System.Drawing.Size(315, 17)
        Me.lbtLicense.TabIndex = 2
        Me.lbtLicense.TabStop = True
        Me.lbtLicense.Text = "This software is published under the MIT license."
        '
        'lblLogo
        '
        Me.lblLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLogo.Font = New System.Drawing.Font("Segoe MDL2 Assets", 40.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogo.Location = New System.Drawing.Point(3, 0)
        Me.lblLogo.Name = "lblLogo"
        Me.lblLogo.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.TableLayoutPanel.SetRowSpan(Me.lblLogo, 5)
        Me.lblLogo.Size = New System.Drawing.Size(86, 215)
        Me.lblLogo.TabIndex = 3
        Me.lblLogo.Text = ""
        Me.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(451, 237)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAboutBox"
        Me.Padding = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AboutBox1"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbtWebsite As LinkLabel
    Friend WithEvents lbtLicense As LinkLabel
    Friend WithEvents lblLogo As Label
End Class
