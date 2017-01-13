<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColorSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmColorSettings))
        Me.SetBritCheckBox = New System.Windows.Forms.CheckBox()
        Me.ColorBritLabel = New System.Windows.Forms.Label()
        Me.ChangeForeColorButton = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.UcDialogCommandPanel1 = New SyncSystemColors.ucDialogCommandPanel()
        Me.ColorBritFloatTrackBar = New SyncSystemColors.MyControls.TrackBarEx()
        CType(Me.ColorBritFloatTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SetBritCheckBox
        '
        resources.ApplyResources(Me.SetBritCheckBox, "SetBritCheckBox")
        Me.SetBritCheckBox.Name = "SetBritCheckBox"
        Me.SetBritCheckBox.UseVisualStyleBackColor = True
        '
        'ColorBritLabel
        '
        resources.ApplyResources(Me.ColorBritLabel, "ColorBritLabel")
        Me.ColorBritLabel.Name = "ColorBritLabel"
        '
        'ChangeForeColorButton
        '
        resources.ApplyResources(Me.ChangeForeColorButton, "ChangeForeColorButton")
        Me.ChangeForeColorButton.Name = "ChangeForeColorButton"
        Me.ChangeForeColorButton.UseVisualStyleBackColor = True
        '
        'ColorDialog1
        '
        Me.ColorDialog1.FullOpen = True
        '
        'UcDialogCommandPanel1
        '
        resources.ApplyResources(Me.UcDialogCommandPanel1, "UcDialogCommandPanel1")
        Me.UcDialogCommandPanel1.Name = "UcDialogCommandPanel1"
        '
        'ColorBritFloatTrackBar
        '
        resources.ApplyResources(Me.ColorBritFloatTrackBar, "ColorBritFloatTrackBar")
        Me.ColorBritFloatTrackBar.LargeChange = 0.1R
        Me.ColorBritFloatTrackBar.Maximum = 1.0R
        Me.ColorBritFloatTrackBar.Minimum = 0R
        Me.ColorBritFloatTrackBar.Name = "ColorBritFloatTrackBar"
        Me.ColorBritFloatTrackBar.Precision = 0.01R
        Me.ColorBritFloatTrackBar.SmallChange = 0.01R
        Me.ColorBritFloatTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ColorBritFloatTrackBar.Value = 0R
        '
        'frmColorSettings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcDialogCommandPanel1)
        Me.Controls.Add(Me.ChangeForeColorButton)
        Me.Controls.Add(Me.ColorBritFloatTrackBar)
        Me.Controls.Add(Me.ColorBritLabel)
        Me.Controls.Add(Me.SetBritCheckBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmColorSettings"
        Me.ShowInTaskbar = False
        CType(Me.ColorBritFloatTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SetBritCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ColorBritLabel As System.Windows.Forms.Label
    Friend WithEvents ChangeForeColorButton As System.Windows.Forms.Button
    Friend WithEvents ColorBritFloatTrackBar As SyncSystemColors.MyControls.TrackBarEx
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents UcDialogCommandPanel1 As ucDialogCommandPanel
End Class
