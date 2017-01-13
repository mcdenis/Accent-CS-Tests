Option Strict On

Imports System.Resources
Imports SyncSystemColors.Generic
Imports SyncSystemColors.MyControls

'N'ouvrir le designer qu'à 120dpi!
Public Class frmMain
    Private LocRM As New ResourceManager("SyncSystemColors.Resource1", GetType(frmMain).Assembly)
    Private CurrentAccentColor As Color
    Private SafeToSync As Boolean = True
    Private toolstripRend As ToolStripSystemRendererEx

    Public Sub New()
        'We keep the commented out code line below in order to quickly test the form in another localization.
        'Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("fr-FR")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    'CONFIGURE THE FORM FOR THE AUTOSYNC STATE
    ''' <summary>
    ''' Don't call this method. Use the AutoSyncEnabled property instead.
    ''' </summary>
    Private Sub DisableAutoSync()
        Me.Visible = True
        NotifyIcon1.Visible = False
        AutoSyncEnabled = False
        If My.Settings.UI_ContextMenuStyle = 2 Then
            toolstripRend.Theme = ToolStripSystemRendererEx.Themes.ImmersiveLight
        End If
    End Sub

    ''' <summary>
    ''' Don't call this method. Use the AutoSyncEnabled property instead.
    ''' </summary>
    Private Sub EnableAutoSync()
        Me.Visible = False
        NotifyIcon1.Icon = Me.Icon
        If NotifyIcon1.Text = Nothing Then
            NotifyIcon1.Text = Me.Text
        End If
        NotifyIcon1.Visible = True
        If My.Settings.UI_ContextMenuStyle = 2 Then
            toolstripRend.Theme = ToolStripSystemRendererEx.Themes.ImmersiveDark
        End If
    End Sub

    Private _AutoSyncEnabled As Boolean
    ''' <summary>
    ''' Whether or not THIS FORM is configured for the autosync mode 
    ''' </summary>
    ''' <returns></returns>
    Private Property AutoSyncEnabled As Boolean
        Get
            Return _AutoSyncEnabled
        End Get
        Set(value As Boolean)
            If _AutoSyncEnabled <> value Then
                _AutoSyncEnabled = value
                If value = True Then
                    EnableAutoSync()
                Else
                    DisableAutoSync()
                End If
            End If
        End Set
    End Property




    'CONFIGURE THE FORM FOR THE ADVANCED MODE STATE

    ''' <summary>
    ''' Configures THIS FORM for the current value in My.Settings.
    ''' </summary>
    Private Sub Settings_AdvancedModeChanged(sender As Object, e As EventArgs)
        RefreshAdvancedModeFormLayout()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub RefreshAdvancedModeFormLayout()
        If My.Settings.General_AdvancedModeEnabled Then
            EnableAdvancedMode()
        Else
            DisableAdvancedMode()
        End If
    End Sub

    Private Sub EnableAdvancedMode()
        'Suspend layout for all containers.
        SuspendLayout()
        BasicModeColorTableLayoutPanel.SuspendLayout()
        AdvancedModeColorTableLayoutPanel.SuspendLayout()

        'TableLayoutPanel layour : move the preview panels in the AdvancedMode's TableLayoutPanel
        AccentPreviewPanel.Parent = AdvancedModeColorTableLayoutPanel
        HilightPreviewPanel.Parent = AdvancedModeColorTableLayoutPanel
        HotTrackingPreviewPanel.Parent = AdvancedModeColorTableLayoutPanel
        With AdvancedModeColorTableLayoutPanel
            .SetRow(AccentPreviewPanel, 0)
            .SetRow(HilightPreviewPanel, 3)
            .SetRow(HotTrackingPreviewPanel, 5)
        End With
        'Resume layout for TableLayoutPanels.
        BasicModeColorTableLayoutPanel.ResumeLayout(False)
        AdvancedModeColorTableLayoutPanel.ResumeLayout(False)

        'Enable preview buttons to permit color tweaks.
        AccentPreviewPanel.Enabled = True
        HilightPreviewPanel.Enabled = True
        HotTrackingPreviewPanel.Enabled = True

        'Form layout.
        BasicModeContainer.Visible = False
        AdvancedModeContainer.Visible = True
        SpacePanel.Visible = True
        'Resume Form layout.
        ResumeLayout(True)

        'Change text of various controls
        AutoSyncButton.CommandLinkNote = LocRM.GetString("ASButton_Note_AdvMode")
        RestoreDefaultButton.CommandLinkNote = LocRM.GetString("RSButton_Note_AdvMode")
        SwitchModeLink.Text = LocRM.GetString("ModeLink_AdvMode")
        ExplanationLabel.Text = LocRM.GetString("ExplLabel_AdvMode")
    End Sub
    Private Sub DisableAdvancedMode()
        'Suspend layout for all containers.
        SuspendLayout()
        BasicModeColorTableLayoutPanel.SuspendLayout()
        AdvancedModeColorTableLayoutPanel.SuspendLayout()

        'TablePanelLayout layout : move the preview panels in the BasicMode's TableLayoutPanel
        AccentPreviewPanel.Parent = BasicModeColorTableLayoutPanel
        HilightPreviewPanel.Parent = BasicModeColorTableLayoutPanel
        HotTrackingPreviewPanel.Parent = BasicModeColorTableLayoutPanel
        With BasicModeColorTableLayoutPanel
            .SetRow(AccentPreviewPanel, 0)
            .SetRow(HilightPreviewPanel, 1)
            .SetRow(HotTrackingPreviewPanel, 2)
        End With
        'Resume layout for TableLayoutPanels.
        BasicModeColorTableLayoutPanel.ResumeLayout(False)
        AdvancedModeColorTableLayoutPanel.ResumeLayout(False)

        'Disable preview buttons to prohibit color tweaks.
        AccentPreviewPanel.Enabled = False
        HilightPreviewPanel.Enabled = False
        HotTrackingPreviewPanel.Enabled = False

        'Form layout
        BasicModeContainer.Visible = True
        AdvancedModeContainer.Visible = False
        SpacePanel.Visible = False
        'Resume Form layout.
        ResumeLayout(True)

        'Change text of various controls
        AutoSyncButton.CommandLinkNote = LocRM.GetString("ASButton_Note_BscMode")
        RestoreDefaultButton.CommandLinkNote = LocRM.GetString("RSButton_Note_BscMode")
        SwitchModeLink.Text = LocRM.GetString("ModeLink_BscMode")
        ExplanationLabel.Text = LocRM.GetString("ExplLabel_BscMode")
    End Sub




    'REFRESH THE COLOR VALUES
    ''' <summary>
    ''' Refreshes THIS FORM's UI elements containing information related to the current accent colors. Also refreshes the CurrentAccentColor field which stores the accent color that is applied to system colors when synchronizing.
    ''' </summary>
    Private Sub RefreshAccentColorValues()
        'Get current accent, assign a value to the CurrentAccentColor field and show string in the label
        CurrentAccentColor = AccentColor.GetAccentColor(DirectCast(My.Settings.General_AccentSource, AccentSources))
        If CurrentAccentColor.IsEmpty = False Then
            AccentPreviewPanel.BackColor = CurrentAccentColor
            ToolTip1.SetToolTip(AccentPreviewPanel, CreateRGBString(AccentPreviewPanel.BackColor))
        Else
            AccentPreviewPanel.BackColor = Color.Transparent
            ToolTip1.SetToolTip(AccentPreviewPanel, LocRM.GetString("InvalidColor"))
        End If

    End Sub

    ''' <summary>
    ''' Refreshes THIS FORM's UI elements containing information related to the current system colors.
    ''' </summary>
    Private Sub RefreshSystemColorValues()
        'No need to refresh their preview panel since they are automatically refreshed when system colors are changed.
        'Get current Hilight and assign value to tooltip.
        ToolTip1.SetToolTip(HilightPreviewPanel, CreateRGBString(HilightPreviewPanel.BackColor))

        'Get current HotTrackingColor and assign value to tooltip.
        ToolTip1.SetToolTip(HotTrackingPreviewPanel, CreateRGBString(HotTrackingPreviewPanel.BackColor))

        'Get current MenuHilight and assign value to tooltip.
        ToolTip1.SetToolTip(MenuHilightPreviewPanel, CreateRGBString(MenuHilightPreviewPanel.BackColor))

        'Get current ActiveCaption and assign value to tooltip.
        ToolTip1.SetToolTip(ActiveCaptionPreviewPanel, CreateRGBString(ActiveCaptionPreviewPanel.BackColor))

        'Get current ActiveCaptionGradient and assign value to tooltip.
        ToolTip1.SetToolTip(ActiveCaptionGradientPreviewPanel, CreateRGBString(ActiveCaptionGradientPreviewPanel.BackColor))
    End Sub

    Private Sub Form1_SystemColorsChanged(sender As Object, e As EventArgs) Handles MyBase.SystemColorsChanged
        RefreshSystemColorValues()
    End Sub




    'DETECTS DWM COLOR CHANGES AND TRIGERS THE SYNCHRONIZATION PROCESS

    Private Sub SpamPreventionTimer_Tick(sender As Object, e As EventArgs) Handles SpamPreventionTimer.Tick
        SpamPreventionTimer.Stop()
        SafeToSync = True
    End Sub

    Private Const WM_DWMCOMPOSITIONCHANGED As Integer = 798
    Private Const WM_DWMNCRENDERINGCHANGED As Integer = 799
    Private Const WM_DWMCOLORIZATIONCOLORCHANGED As Integer = 800
    Private Const WM_DWMWINDOWMAXIMIZEDCHANGE As Integer = 801
    Protected Overloads Overrides Sub WndProc(ByRef msg As Message)
        'When DWM Colorization changed
        If msg.Msg = WM_DWMCOLORIZATIONCOLORCHANGED And SafeToSync Then
            SafeToSync = False

            RefreshAccentColorValues()
            If AutoSyncEnabled Then
                SyncCore.SyncNow(pAddDelay:=True, pShowConfimation:=False, pAccent:=CurrentAccentColor)
            End If
            SpamPreventionTimer.Start()
        End If

        MyBase.WndProc(msg)
    End Sub




    'VARIOUS STUFF THAT NEEDS TO BE DONE WHEN THE APP OR THE FORM STARTS

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Adapts the form design if colored title bars are not enabled.
        If WindowsColoredTitleBar() <> 1 Then
            Me.ShowIcon = False
            Me.Padding = New Padding(9) 'Reduces padding to align client text with the title bar text.
        End If

        'Adapts the form design to the classic theme.
        If Application.RenderWithVisualStyles = False Then
            Me.BackColor = SystemColors.Control
            Me.ForeColor = SystemColors.ControlText
        End If

        'Create and set the form's icon.
        If Application.RenderWithVisualStyles = False Or SystemInformation.HighContrast Then
            Using bmpIcon As Bitmap = ConvertTextToImage("", "Segoe MDL2 Assets", 204, SystemColors.Control, SystemColors.ControlText, 256, 256, New Point(-46, -25))
                Dim icoIcon As Icon = Icon.FromHandle(bmpIcon.GetHicon())
                Me.Icon = icoIcon
            End Using
        Else
            Using bmpIcon As Bitmap = ConvertTextToImage("", "Segoe MDL2 Assets", 204, Color.Transparent, Color.White, 256, 256, New Point(-46, -25))
                Dim icoIcon As Icon = Icon.FromHandle(bmpIcon.GetHicon())
                Me.Icon = icoIcon
            End Using
        End If

        'Bind the AdvancedModeEnabled setting.
        AddHandler My.Settings.AdvancedModeSettingChanged, AddressOf Settings_AdvancedModeChanged 'Reconfigure if changed in the future.
        RefreshAdvancedModeFormLayout() 'Initial configuration.

        'Make the Restore command of the cmsNotifyIcon bold cause it's the main command (the one that's triggered when the icon is double-clicked.)
        tmiNotifyIcon_Restore.Font = New Font(tmiNotifyIcon_Restore.Font, FontStyle.Bold)


        'Set the ToolstripRenderer for context menus

        'Meaning of the UI_ContextMenuStyle values:
        '0 = no custom renderer. We just use the .net provided system renderer.
        '1 = we use the custom renderer, but only with its standard theme.
        '2 = we use the custom renderer with the Immersive theme which can be light or dark.
        If My.Settings.UI_ContextMenuStyle > 0 Then
            toolstripRend = New ToolStripSystemRendererEx
            If My.Settings.UI_ContextMenuStyle = 2 Then
                toolstripRend.Theme = ToolStripSystemRendererEx.Themes.ImmersiveLight
                cmsNotifyIcon.IsTaskbarMenu = True
            End If
            cmsMain.Renderer = toolstripRend
            cmsNotifyIcon.Renderer = toolstripRend
        Else
            cmsMain.RenderMode = ToolStripRenderMode.System
            cmsNotifyIcon.RenderMode = ToolStripRenderMode.System
        End If

        RefreshAccentColorValues()
        RefreshSystemColorValues()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Support for command line arguments. This does not work in the Form_Load event. 
        'This should go in Sub Main, but we would need to disable the Application framework and loose the "single instance application" that vb.net gives us which would be complicated to reimplement.
        Dim cla As String() = Environment.GetCommandLineArgs()
        'The first element is always the executable path itself.
        If cla.Length > 1 Then
            'Look for specific arguments here.
            For Each arg As String In cla
                'Ignore the case of the argument.
                If String.Compare(arg, "/adv", True) = 0 Then
                    'Perform something.
                    My.Settings.General_AdvancedModeEnabled = True
                End If

                If String.Compare(arg, "/autosync", True) = 0 Then
                    'Perform something.
                    SyncCore.SyncNow(pAddDelay:=False, pShowConfimation:=False, pAccent:=CurrentAccentColor)
                    AutoSyncEnabled = True
                End If
            Next arg
        End If


        'Show error message if the current software configuration is innapropriate.
        'We put this in the Form_Shown event cause based on what I've read online, showing a message box before the Form is shown disrupts things.
        Dim stMsgDetails As String = ""

        Dim os As OperatingSystem = Environment.OSVersion
        Dim major = os.Version.Major
        If major < 10 Then
            stMsgDetails += Environment.NewLine + LocRM.GetString("UnsupportedOSWarning")
        End If

        If SystemInformation.HighContrast Then
            stMsgDetails += Environment.NewLine + LocRM.GetString("HighContrastWarning")
        End If

        If stMsgDetails <> "" And Debugger.IsAttached = False Then
            'Removes the ponctuation of the last item and we replace it with a period.
            stMsgDetails = stMsgDetails.Substring(0, stMsgDetails.Length - 1)
            stMsgDetails += "."
            'Shows the message.
            MsgBox(LocRM.GetString("StartupWarning") + stMsgDetails, MsgBoxStyle.Exclamation)
        End If
    End Sub

    'MISC
    ''' <summary>
    ''' Shows the app settings dialog. This method is prefered over opening the frmAppSettings directly!
    ''' </summary>
    Private Sub ShowAppSettingsDlg()
        If Generic.ShowDialog(Function() New frmAppSettings(), Me) = DialogResult.OK Then
            'Refresh the preview so if the setting makes a difference (it should not, but we are using undocumented reg values after all), the user can see it.
            RefreshAccentColorValues()
        End If
    End Sub

    ''' <summary>
    ''' Shows the About dialog. This method is prefered over opening the frmAboutBox directly!
    ''' </summary>
    Private Sub ShowAboutBoxDlg()
        Generic.ShowDialog(Function() New frmAboutBox(), Me)
    End Sub




    'CLICK EVENTS

    Private Sub SyncButton_Click(sender As Object, e As EventArgs) Handles SyncButton.Click
        SyncCore.SyncNow(pAddDelay:=False, pShowConfimation:=True, pAccent:=CurrentAccentColor)
    End Sub

    Private Sub AutoSyncButton_Click(sender As Object, e As EventArgs) Handles AutoSyncButton.Click
        If SyncCore.SyncNow(pAddDelay:=False, pShowConfimation:=False, pAccent:=CurrentAccentColor) = True Then
            AutoSyncEnabled = True
            NotifyIcon1.ShowBalloonTip(1000, LocRM.GetString("MonitoringNotificationTitle"), LocRM.GetString("MonitoringNotification"), ToolTipIcon.Info)
        End If
    End Sub

    Private Sub RestoreDefaultButton_Click(sender As Object, e As EventArgs) Handles RestoreDefaultButton.Click
        SystemColor.RestoreDefaultColors()
    End Sub

    Private Sub SwitchModeLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles SwitchModeLink.LinkClicked
        If My.Settings.General_AdvancedModeEnabled = True Then
            My.Settings.General_AdvancedModeEnabled = False
        Else
            My.Settings.General_AdvancedModeEnabled = True
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        AutoSyncEnabled = False
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        NotifyIcon1.Visible = False 'Juste pour être sûr
        NotifyIcon1.Dispose()
    End Sub

    'Preview rectangles click events

    Private Sub AccentPreviewPanel_Click(sender As Object, e As EventArgs) Handles AccentPreviewPanel.Click
        MsgBox(LocRM.GetString("UseSettingApp2ChangeAccentInfo"), MsgBoxStyle.Information)
    End Sub

    Private Sub ActiveCaptionPreviewPanel_Click(sender As Object, e As EventArgs) Handles ActiveCaptionPreviewPanel.Click
        Dim Dlg As frmColorSettings = New frmColorSettings(SystemColorIndexes.ActiveCaption)
        Dim DlgResult As DialogResult = Dlg.ShowDialog(Me)

        Dlg.Close()
    End Sub

    Private Sub ActiveCaptionGradientPreviewPanel_Click(sender As Object, e As EventArgs) Handles ActiveCaptionGradientPreviewPanel.Click
        Dim Dlg As frmColorSettings = New frmColorSettings(SystemColorIndexes.GradientActiveCaption)
        Dim DlgResult As DialogResult = Dlg.ShowDialog(Me)

        Dlg.Close()
    End Sub

    Private Sub HilightPreviewPanel_Click(sender As Object, e As EventArgs) Handles HilightPreviewPanel.Click
        Dim Dlg As frmColorSettings = New frmColorSettings(SystemColorIndexes.Highlight)
        Dim DlgResult As DialogResult = Dlg.ShowDialog(Me)

        Dlg.Close()
    End Sub

    Private Sub MenuHilightPreviewPanel_Click(sender As Object, e As EventArgs) Handles MenuHilightPreviewPanel.Click
        Dim Dlg As frmColorSettings = New frmColorSettings(SystemColorIndexes.MenuHilight)
        Dim DlgResult As DialogResult = Dlg.ShowDialog(Me)

        Dlg.Close()
    End Sub

    Private Sub HotTrackingPreviewPanel_Click(sender As Object, e As EventArgs) Handles HotTrackingPreviewPanel.Click
        Dim Dlg As frmColorSettings = New frmColorSettings(SystemColorIndexes.Hotlight)
        Dim DlgResult As DialogResult = Dlg.ShowDialog(Me)

        Dlg.Close()
    End Sub


    'Notify icon context menu item click events

    Private Sub tmiNotifyIcon_Restore_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_Restore.Click
        AutoSyncEnabled = False
    End Sub

    Private Sub tmiNotifyIcon_About_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_About.Click
        ShowAboutBoxDlg()
    End Sub

    Private Sub tmiNotifyIcon_Exit_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_Exit.Click
        Me.Close()
    End Sub

    Private Sub tmiNotifyIcon_AppSettings_Click(sender As Object, e As EventArgs) Handles tmiNotifyIcon_AppSettings.Click
        ShowAppSettingsDlg()
    End Sub

    'Form main context menu items click events

    Private Sub tmiMain_AppSettings_Click(sender As Object, e As EventArgs) Handles tmiMain_AppSettings.Click
        ShowAppSettingsDlg()
    End Sub

    Private Sub tmiMain_About_Click(sender As Object, e As EventArgs) Handles tmiMain_About.Click
        ShowAboutBoxDlg()
    End Sub



    'Should be in Application events
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Save settings on exit depending of the My.Settings value.
        My.Application.SaveMySettingsOnExit = My.Settings.General_SaveSettingsOnExit
    End Sub
End Class