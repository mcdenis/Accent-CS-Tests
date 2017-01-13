<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppSettings))
        Me.gbxSaveSettingsOnExit = New SyncSystemColors.MyControls.GroupBoxEx()
        Me.chkSaveSettingsOnExit = New System.Windows.Forms.CheckBox()
        Me.lblSaveSettingsOnExitDesc = New SyncSystemColors.MyControls.LabelEX()
        Me.gbxAccentSource = New SyncSystemColors.MyControls.GroupBoxEx()
        Me.cboAccentSource = New System.Windows.Forms.ComboBox()
        Me.lblAccentSourceDesc = New SyncSystemColors.MyControls.LabelEX()
        Me.UcDialogCommandPanel1 = New SyncSystemColors.ucDialogCommandPanel()
        Me.gbxSaveSettingsOnExit.SuspendLayout()
        Me.gbxAccentSource.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxSaveSettingsOnExit
        '
        resources.ApplyResources(Me.gbxSaveSettingsOnExit, "gbxSaveSettingsOnExit")
        Me.gbxSaveSettingsOnExit.Controls.Add(Me.chkSaveSettingsOnExit)
        Me.gbxSaveSettingsOnExit.Controls.Add(Me.lblSaveSettingsOnExitDesc)
        Me.gbxSaveSettingsOnExit.DrawTopBorderOnly = True
        Me.gbxSaveSettingsOnExit.Name = "gbxSaveSettingsOnExit"
        Me.gbxSaveSettingsOnExit.TabStop = False
        '
        'chkSaveSettingsOnExit
        '
        resources.ApplyResources(Me.chkSaveSettingsOnExit, "chkSaveSettingsOnExit")
        Me.chkSaveSettingsOnExit.Name = "chkSaveSettingsOnExit"
        Me.chkSaveSettingsOnExit.UseVisualStyleBackColor = True
        '
        'lblSaveSettingsOnExitDesc
        '
        resources.ApplyResources(Me.lblSaveSettingsOnExitDesc, "lblSaveSettingsOnExitDesc")
        Me.lblSaveSettingsOnExitDesc.Name = "lblSaveSettingsOnExitDesc"
        Me.lblSaveSettingsOnExitDesc.NoPadding = True
        '
        'gbxAccentSource
        '
        Me.gbxAccentSource.Controls.Add(Me.cboAccentSource)
        Me.gbxAccentSource.Controls.Add(Me.lblAccentSourceDesc)
        resources.ApplyResources(Me.gbxAccentSource, "gbxAccentSource")
        Me.gbxAccentSource.DrawTopBorderOnly = True
        Me.gbxAccentSource.Name = "gbxAccentSource"
        Me.gbxAccentSource.TabStop = False
        '
        'cboAccentSource
        '
        resources.ApplyResources(Me.cboAccentSource, "cboAccentSource")
        Me.cboAccentSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccentSource.FormattingEnabled = True
        Me.cboAccentSource.Name = "cboAccentSource"
        '
        'lblAccentSourceDesc
        '
        resources.ApplyResources(Me.lblAccentSourceDesc, "lblAccentSourceDesc")
        Me.lblAccentSourceDesc.Name = "lblAccentSourceDesc"
        Me.lblAccentSourceDesc.NoPadding = True
        '
        'UcDialogCommandPanel1
        '
        resources.ApplyResources(Me.UcDialogCommandPanel1, "UcDialogCommandPanel1")
        Me.UcDialogCommandPanel1.Name = "UcDialogCommandPanel1"
        '
        'frmAppSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxSaveSettingsOnExit)
        Me.Controls.Add(Me.gbxAccentSource)
        Me.Controls.Add(Me.UcDialogCommandPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAppSettings"
        Me.ShowInTaskbar = False
        Me.gbxSaveSettingsOnExit.ResumeLayout(False)
        Me.gbxAccentSource.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UcDialogCommandPanel1 As ucDialogCommandPanel
    Friend WithEvents gbxAccentSource As SyncSystemColors.MyControls.GroupBoxEx
    Friend WithEvents gbxSaveSettingsOnExit As SyncSystemColors.MyControls.GroupBoxEx
    Friend WithEvents chkSaveSettingsOnExit As CheckBox
    Friend WithEvents lblSaveSettingsOnExitDesc As SyncSystemColors.MyControls.LabelEX
    Friend WithEvents cboAccentSource As ComboBox
    Friend WithEvents lblAccentSourceDesc As SyncSystemColors.MyControls.LabelEX
End Class
