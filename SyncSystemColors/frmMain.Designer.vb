<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.CurrentAccentLabel = New System.Windows.Forms.Label()
        Me.AdvancedModeColorTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CurrentHotTrackingLabel = New System.Windows.Forms.CheckBox()
        Me.CurrentMenuHilightLabel = New System.Windows.Forms.CheckBox()
        Me.CurrentHilightLabel = New System.Windows.Forms.CheckBox()
        Me.CurrentActiveCaptionGradientLabel = New System.Windows.Forms.CheckBox()
        Me.CurrentActiveCaptionLabel = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.AccentPreviewPanel = New System.Windows.Forms.Button()
        Me.ActiveCaptionPreviewPanel = New System.Windows.Forms.Button()
        Me.ActiveCaptionGradientPreviewPanel = New System.Windows.Forms.Button()
        Me.HilightPreviewPanel = New System.Windows.Forms.Button()
        Me.MenuHilightPreviewPanel = New System.Windows.Forms.Button()
        Me.HotTrackingPreviewPanel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AutoSyncButton = New SyncSystemColors.MyControls.ButtonEx()
        Me.SyncButton = New SyncSystemColors.MyControls.ButtonEx()
        Me.RestoreDefaultButton = New SyncSystemColors.MyControls.ButtonEx()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsNotifyIcon = New SyncSystemColors.MyControls.ContextMenuSystemStrip()
        Me.tmiNotifyIcon_Restore = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmiNotifyIcon_AppSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmiNotifyIcon_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.sepNotifyIcon1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tmiNotifyIcon_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.SwitchModeLink = New System.Windows.Forms.LinkLabel()
        Me.SpacePanel = New System.Windows.Forms.Panel()
        Me.SpamPreventionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BasicModeColorTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.BasicModeAccentLabel = New SyncSystemColors.MyControls.LabelEX()
        Me.BasicModeHighlightLabel = New SyncSystemColors.MyControls.LabelEX()
        Me.BasicModeHotTrackingLabel = New SyncSystemColors.MyControls.LabelEX()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AdvancedModeContainer = New System.Windows.Forms.Panel()
        Me.BasicModeContainer = New System.Windows.Forms.GroupBox()
        Me.ExplanationLabel = New SyncSystemColors.MyControls.LabelEX()
        Me.cmsMain = New SyncSystemColors.MyControls.ContextMenuSystemStrip()
        Me.tmiMain_AppSettings = New SyncSystemColors.MyControls.ToolStripMenuItemEx()
        Me.tmiMain_About = New SyncSystemColors.MyControls.ToolStripMenuItemEx()
        Me.AdvancedModeColorTableLayoutPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.cmsNotifyIcon.SuspendLayout()
        Me.BasicModeColorTableLayoutPanel.SuspendLayout()
        Me.AdvancedModeContainer.SuspendLayout()
        Me.BasicModeContainer.SuspendLayout()
        Me.cmsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'CurrentAccentLabel
        '
        resources.ApplyResources(Me.CurrentAccentLabel, "CurrentAccentLabel")
        Me.CurrentAccentLabel.Name = "CurrentAccentLabel"
        '
        'AdvancedModeColorTableLayoutPanel
        '
        resources.ApplyResources(Me.AdvancedModeColorTableLayoutPanel, "AdvancedModeColorTableLayoutPanel")
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.CurrentHotTrackingLabel, 0, 5)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.CurrentMenuHilightLabel, 0, 4)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.CurrentHilightLabel, 0, 3)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.CurrentActiveCaptionGradientLabel, 0, 2)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.CurrentActiveCaptionLabel, 0, 1)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.Panel2, 0, 0)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.AccentPreviewPanel, 1, 0)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.ActiveCaptionPreviewPanel, 1, 1)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.ActiveCaptionGradientPreviewPanel, 1, 2)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.HilightPreviewPanel, 1, 3)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.MenuHilightPreviewPanel, 1, 4)
        Me.AdvancedModeColorTableLayoutPanel.Controls.Add(Me.HotTrackingPreviewPanel, 1, 5)
        Me.AdvancedModeColorTableLayoutPanel.Name = "AdvancedModeColorTableLayoutPanel"
        '
        'CurrentHotTrackingLabel
        '
        resources.ApplyResources(Me.CurrentHotTrackingLabel, "CurrentHotTrackingLabel")
        Me.CurrentHotTrackingLabel.Checked = Global.SyncSystemColors.My.MySettings.Default.HotTracking_Sync
        Me.CurrentHotTrackingLabel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CurrentHotTrackingLabel.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SyncSystemColors.My.MySettings.Default, "HotTracking_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CurrentHotTrackingLabel.Name = "CurrentHotTrackingLabel"
        Me.CurrentHotTrackingLabel.UseVisualStyleBackColor = True
        '
        'CurrentMenuHilightLabel
        '
        resources.ApplyResources(Me.CurrentMenuHilightLabel, "CurrentMenuHilightLabel")
        Me.CurrentMenuHilightLabel.Checked = Global.SyncSystemColors.My.MySettings.Default.MenuHilight_Sync
        Me.CurrentMenuHilightLabel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CurrentMenuHilightLabel.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SyncSystemColors.My.MySettings.Default, "MenuHilight_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CurrentMenuHilightLabel.Name = "CurrentMenuHilightLabel"
        Me.CurrentMenuHilightLabel.UseVisualStyleBackColor = True
        '
        'CurrentHilightLabel
        '
        resources.ApplyResources(Me.CurrentHilightLabel, "CurrentHilightLabel")
        Me.CurrentHilightLabel.Checked = Global.SyncSystemColors.My.MySettings.Default.Hilight_Sync
        Me.CurrentHilightLabel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CurrentHilightLabel.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SyncSystemColors.My.MySettings.Default, "Hilight_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CurrentHilightLabel.Name = "CurrentHilightLabel"
        Me.CurrentHilightLabel.UseVisualStyleBackColor = True
        '
        'CurrentActiveCaptionGradientLabel
        '
        resources.ApplyResources(Me.CurrentActiveCaptionGradientLabel, "CurrentActiveCaptionGradientLabel")
        Me.CurrentActiveCaptionGradientLabel.Checked = Global.SyncSystemColors.My.MySettings.Default.ActiveCaptionGradient_Sync
        Me.CurrentActiveCaptionGradientLabel.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SyncSystemColors.My.MySettings.Default, "ActiveCaptionGradient_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CurrentActiveCaptionGradientLabel.Name = "CurrentActiveCaptionGradientLabel"
        Me.CurrentActiveCaptionGradientLabel.UseVisualStyleBackColor = True
        '
        'CurrentActiveCaptionLabel
        '
        resources.ApplyResources(Me.CurrentActiveCaptionLabel, "CurrentActiveCaptionLabel")
        Me.CurrentActiveCaptionLabel.Checked = Global.SyncSystemColors.My.MySettings.Default.ActiveCaption_Sync
        Me.CurrentActiveCaptionLabel.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SyncSystemColors.My.MySettings.Default, "ActiveCaption_Sync", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CurrentActiveCaptionLabel.Name = "CurrentActiveCaptionLabel"
        Me.CurrentActiveCaptionLabel.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CurrentAccentLabel)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'AccentPreviewPanel
        '
        resources.ApplyResources(Me.AccentPreviewPanel, "AccentPreviewPanel")
        Me.AccentPreviewPanel.Name = "AccentPreviewPanel"
        Me.AccentPreviewPanel.UseVisualStyleBackColor = False
        '
        'ActiveCaptionPreviewPanel
        '
        Me.ActiveCaptionPreviewPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        resources.ApplyResources(Me.ActiveCaptionPreviewPanel, "ActiveCaptionPreviewPanel")
        Me.ActiveCaptionPreviewPanel.Name = "ActiveCaptionPreviewPanel"
        Me.ActiveCaptionPreviewPanel.UseVisualStyleBackColor = False
        '
        'ActiveCaptionGradientPreviewPanel
        '
        Me.ActiveCaptionGradientPreviewPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        resources.ApplyResources(Me.ActiveCaptionGradientPreviewPanel, "ActiveCaptionGradientPreviewPanel")
        Me.ActiveCaptionGradientPreviewPanel.Name = "ActiveCaptionGradientPreviewPanel"
        Me.ActiveCaptionGradientPreviewPanel.UseVisualStyleBackColor = False
        '
        'HilightPreviewPanel
        '
        Me.HilightPreviewPanel.BackColor = System.Drawing.SystemColors.Highlight
        resources.ApplyResources(Me.HilightPreviewPanel, "HilightPreviewPanel")
        Me.HilightPreviewPanel.Name = "HilightPreviewPanel"
        Me.HilightPreviewPanel.UseVisualStyleBackColor = False
        '
        'MenuHilightPreviewPanel
        '
        Me.MenuHilightPreviewPanel.BackColor = System.Drawing.SystemColors.MenuHighlight
        resources.ApplyResources(Me.MenuHilightPreviewPanel, "MenuHilightPreviewPanel")
        Me.MenuHilightPreviewPanel.Name = "MenuHilightPreviewPanel"
        Me.MenuHilightPreviewPanel.UseVisualStyleBackColor = False
        '
        'HotTrackingPreviewPanel
        '
        Me.HotTrackingPreviewPanel.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.HotTrackingPreviewPanel, "HotTrackingPreviewPanel")
        Me.HotTrackingPreviewPanel.Name = "HotTrackingPreviewPanel"
        Me.HotTrackingPreviewPanel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.AutoSyncButton)
        Me.Panel1.Controls.Add(Me.SyncButton)
        Me.Panel1.Controls.Add(Me.RestoreDefaultButton)
        Me.Panel1.Name = "Panel1"
        '
        'AutoSyncButton
        '
        resources.ApplyResources(Me.AutoSyncButton, "AutoSyncButton")
        Me.AutoSyncButton.CommandLink = True
        Me.AutoSyncButton.CommandLinkNote = "Hide this app in the system tray and sync colors whenever the accent color is cha" &
    "nged."
        Me.AutoSyncButton.Name = "AutoSyncButton"
        Me.AutoSyncButton.UseVisualStyleBackColor = True
        '
        'SyncButton
        '
        resources.ApplyResources(Me.SyncButton, "SyncButton")
        Me.SyncButton.CommandLink = True
        Me.SyncButton.CommandLinkNote = Nothing
        Me.SyncButton.Name = "SyncButton"
        Me.SyncButton.UseVisualStyleBackColor = True
        '
        'RestoreDefaultButton
        '
        resources.ApplyResources(Me.RestoreDefaultButton, "RestoreDefaultButton")
        Me.RestoreDefaultButton.CommandLink = True
        Me.RestoreDefaultButton.CommandLinkNote = "Set back colors to default scheme."
        Me.RestoreDefaultButton.Name = "RestoreDefaultButton"
        Me.RestoreDefaultButton.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.cmsNotifyIcon
        resources.ApplyResources(Me.NotifyIcon1, "NotifyIcon1")
        '
        'cmsNotifyIcon
        '
        Me.cmsNotifyIcon.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmiNotifyIcon_Restore, Me.tmiNotifyIcon_AppSettings, Me.tmiNotifyIcon_About, Me.sepNotifyIcon1, Me.tmiNotifyIcon_Exit})
        Me.cmsNotifyIcon.Name = "cmsNotifyIcon"
        resources.ApplyResources(Me.cmsNotifyIcon, "cmsNotifyIcon")
        '
        'tmiNotifyIcon_Restore
        '
        Me.tmiNotifyIcon_Restore.Name = "tmiNotifyIcon_Restore"
        resources.ApplyResources(Me.tmiNotifyIcon_Restore, "tmiNotifyIcon_Restore")
        '
        'tmiNotifyIcon_AppSettings
        '
        Me.tmiNotifyIcon_AppSettings.Name = "tmiNotifyIcon_AppSettings"
        resources.ApplyResources(Me.tmiNotifyIcon_AppSettings, "tmiNotifyIcon_AppSettings")
        '
        'tmiNotifyIcon_About
        '
        Me.tmiNotifyIcon_About.Name = "tmiNotifyIcon_About"
        resources.ApplyResources(Me.tmiNotifyIcon_About, "tmiNotifyIcon_About")
        '
        'sepNotifyIcon1
        '
        Me.sepNotifyIcon1.Name = "sepNotifyIcon1"
        resources.ApplyResources(Me.sepNotifyIcon1, "sepNotifyIcon1")
        '
        'tmiNotifyIcon_Exit
        '
        Me.tmiNotifyIcon_Exit.Name = "tmiNotifyIcon_Exit"
        resources.ApplyResources(Me.tmiNotifyIcon_Exit, "tmiNotifyIcon_Exit")
        '
        'SwitchModeLink
        '
        resources.ApplyResources(Me.SwitchModeLink, "SwitchModeLink")
        Me.SwitchModeLink.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.SwitchModeLink.Name = "SwitchModeLink"
        Me.SwitchModeLink.TabStop = True
        '
        'SpacePanel
        '
        resources.ApplyResources(Me.SpacePanel, "SpacePanel")
        Me.SpacePanel.Name = "SpacePanel"
        '
        'SpamPreventionTimer
        '
        Me.SpamPreventionTimer.Interval = 500
        '
        'BasicModeColorTableLayoutPanel
        '
        resources.ApplyResources(Me.BasicModeColorTableLayoutPanel, "BasicModeColorTableLayoutPanel")
        Me.BasicModeColorTableLayoutPanel.Controls.Add(Me.BasicModeAccentLabel, 0, 0)
        Me.BasicModeColorTableLayoutPanel.Controls.Add(Me.BasicModeHighlightLabel, 0, 1)
        Me.BasicModeColorTableLayoutPanel.Controls.Add(Me.BasicModeHotTrackingLabel, 0, 2)
        Me.BasicModeColorTableLayoutPanel.Name = "BasicModeColorTableLayoutPanel"
        '
        'BasicModeAccentLabel
        '
        resources.ApplyResources(Me.BasicModeAccentLabel, "BasicModeAccentLabel")
        Me.BasicModeAccentLabel.Name = "BasicModeAccentLabel"
        Me.BasicModeAccentLabel.NoPadding = True
        '
        'BasicModeHighlightLabel
        '
        resources.ApplyResources(Me.BasicModeHighlightLabel, "BasicModeHighlightLabel")
        Me.BasicModeHighlightLabel.Name = "BasicModeHighlightLabel"
        Me.BasicModeHighlightLabel.NoPadding = True
        '
        'BasicModeHotTrackingLabel
        '
        resources.ApplyResources(Me.BasicModeHotTrackingLabel, "BasicModeHotTrackingLabel")
        Me.BasicModeHotTrackingLabel.Name = "BasicModeHotTrackingLabel"
        Me.BasicModeHotTrackingLabel.NoPadding = True
        '
        'AdvancedModeContainer
        '
        resources.ApplyResources(Me.AdvancedModeContainer, "AdvancedModeContainer")
        Me.AdvancedModeContainer.Controls.Add(Me.AdvancedModeColorTableLayoutPanel)
        Me.AdvancedModeContainer.Name = "AdvancedModeContainer"
        '
        'BasicModeContainer
        '
        resources.ApplyResources(Me.BasicModeContainer, "BasicModeContainer")
        Me.BasicModeContainer.Controls.Add(Me.BasicModeColorTableLayoutPanel)
        Me.BasicModeContainer.Name = "BasicModeContainer"
        Me.BasicModeContainer.TabStop = False
        '
        'ExplanationLabel
        '
        resources.ApplyResources(Me.ExplanationLabel, "ExplanationLabel")
        Me.ExplanationLabel.Name = "ExplanationLabel"
        Me.ExplanationLabel.NoPadding = True
        '
        'cmsMain
        '
        Me.cmsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmiMain_AppSettings, Me.tmiMain_About})
        Me.cmsMain.Name = "cmsMain"
        resources.ApplyResources(Me.cmsMain, "cmsMain")
        '
        'tmiMain_AppSettings
        '
        Me.tmiMain_AppSettings.Name = "tmiMain_AppSettings"
        resources.ApplyResources(Me.tmiMain_AppSettings, "tmiMain_AppSettings")
        '
        'tmiMain_About
        '
        Me.tmiMain_About.Name = "tmiMain_About"
        resources.ApplyResources(Me.tmiMain_About, "tmiMain_About")
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ContextMenuStrip = Me.cmsMain
        Me.Controls.Add(Me.SwitchModeLink)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SpacePanel)
        Me.Controls.Add(Me.AdvancedModeContainer)
        Me.Controls.Add(Me.BasicModeContainer)
        Me.Controls.Add(Me.ExplanationLabel)
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.AdvancedModeColorTableLayoutPanel.ResumeLayout(False)
        Me.AdvancedModeColorTableLayoutPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.cmsNotifyIcon.ResumeLayout(False)
        Me.BasicModeColorTableLayoutPanel.ResumeLayout(False)
        Me.BasicModeColorTableLayoutPanel.PerformLayout()
        Me.AdvancedModeContainer.ResumeLayout(False)
        Me.AdvancedModeContainer.PerformLayout()
        Me.BasicModeContainer.ResumeLayout(False)
        Me.BasicModeContainer.PerformLayout()
        Me.cmsMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CurrentAccentLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SyncButton As SyncSystemColors.MyControls.ButtonEx
    Friend WithEvents RestoreDefaultButton As SyncSystemColors.MyControls.ButtonEx
    Friend WithEvents AutoSyncButton As SyncSystemColors.MyControls.ButtonEx
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents CurrentHotTrackingLabel As System.Windows.Forms.CheckBox
    Friend WithEvents CurrentMenuHilightLabel As System.Windows.Forms.CheckBox
    Friend WithEvents CurrentHilightLabel As System.Windows.Forms.CheckBox
    Friend WithEvents CurrentActiveCaptionGradientLabel As System.Windows.Forms.CheckBox
    Friend WithEvents CurrentActiveCaptionLabel As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SwitchModeLink As System.Windows.Forms.LinkLabel
    Friend WithEvents SpacePanel As System.Windows.Forms.Panel
    Friend WithEvents SpamPreventionTimer As System.Windows.Forms.Timer
    Friend WithEvents AdvancedModeColorTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BasicModeColorTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BasicModeAccentLabel As SyncSystemColors.MyControls.LabelEX
    Friend WithEvents BasicModeHighlightLabel As SyncSystemColors.MyControls.LabelEX
    Friend WithEvents BasicModeHotTrackingLabel As SyncSystemColors.MyControls.LabelEX
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents AccentPreviewPanel As System.Windows.Forms.Button
    Friend WithEvents ActiveCaptionPreviewPanel As System.Windows.Forms.Button
    Friend WithEvents ActiveCaptionGradientPreviewPanel As System.Windows.Forms.Button
    Friend WithEvents HilightPreviewPanel As System.Windows.Forms.Button
    Friend WithEvents MenuHilightPreviewPanel As System.Windows.Forms.Button
    Friend WithEvents HotTrackingPreviewPanel As System.Windows.Forms.Button
    Friend WithEvents AdvancedModeContainer As System.Windows.Forms.Panel
    Friend WithEvents BasicModeContainer As System.Windows.Forms.GroupBox
    Friend WithEvents ExplanationLabel As SyncSystemColors.MyControls.LabelEX
    Friend WithEvents cmsMain As SyncSystemColors.MyControls.ContextMenuSystemStrip
    Friend WithEvents tmiMain_AppSettings As SyncSystemColors.MyControls.ToolStripMenuItemEx
    Friend WithEvents tmiMain_About As SyncSystemColors.MyControls.ToolStripMenuItemEx
    Friend WithEvents cmsNotifyIcon As SyncSystemColors.MyControls.ContextMenuSystemStrip
    Friend WithEvents tmiNotifyIcon_Restore As ToolStripMenuItem
    Friend WithEvents tmiNotifyIcon_AppSettings As ToolStripMenuItem
    Friend WithEvents tmiNotifyIcon_About As ToolStripMenuItem
    Friend WithEvents sepNotifyIcon1 As ToolStripSeparator
    Friend WithEvents tmiNotifyIcon_Exit As ToolStripMenuItem
End Class
