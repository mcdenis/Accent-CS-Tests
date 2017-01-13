Option Strict On

Imports System.Resources

'N'ouvrir le designer qu'à 96dpi!
Public Class frmColorSettings
    Dim LocRM As New ResourceManager("SyncSystemColors.Resource1", GetType(frmMain).Assembly)
    Dim myForeColor As Integer = -1

    Public ReadOnly Property NewSetBritValue As Boolean
        Get
            Return SetBritCheckBox.Checked
        End Get
    End Property

    Public ReadOnly Property NewUsrBritValue As Double
        Get
            Return ColorBritFloatTrackBar.Value
        End Get
    End Property

    Public ReadOnly Property NewForeColor As Integer
        Get
            Return myForeColor
        End Get
    End Property

    Private ReadOnly Property CurrentSystemColor As SystemColorIndexes

    'We keep a constructor with no argument for the designer.
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(pSystemColor As SystemColorIndexes)
        ' This call is required by the designer.
        InitializeComponent()

        CurrentSystemColor = pSystemColor

        'Set the initial values for the form's controls.
        Select Case CurrentSystemColor
            Case SystemColorIndexes.ActiveCaption
                Me.Text = LocRM.GetString("ActiveCaption_ColSetDlgTitle")

                With SetBritCheckBox
                    .Checked = My.Settings.ActiveCaption_SetBrit
                    .Enabled = frmMain.CurrentActiveCaptionLabel.Checked
                End With

                ColorBritFloatTrackBar.Value = My.Settings.ActiveCaption_UsrBrit
                If frmMain.CurrentActiveCaptionLabel.Checked And SetBritCheckBox.Checked Then
                    ColorBritFloatTrackBar.Enabled = True
                Else
                    ColorBritFloatTrackBar.Enabled = False
                End If

                ColorDialog1.Color = SystemColors.ActiveCaptionText
            Case SystemColorIndexes.GradientActiveCaption
                Me.Text = LocRM.GetString("ActiveCaptionGradient_ColSetDlgTitle")

                With SetBritCheckBox
                    .Checked = My.Settings.ActiveCaptionGradient_SetBrit
                    .Enabled = frmMain.CurrentActiveCaptionGradientLabel.Checked
                End With

                ColorBritFloatTrackBar.Value = My.Settings.ActiveCaptionGradient_UsrBrit
                If frmMain.CurrentActiveCaptionGradientLabel.Checked And SetBritCheckBox.Checked Then
                    ColorBritFloatTrackBar.Enabled = True
                Else
                    ColorBritFloatTrackBar.Enabled = False
                End If

                ColorDialog1.Color = SystemColors.ActiveCaptionText
            Case SystemColorIndexes.Highlight
                Me.Text = LocRM.GetString("Hilight_ColSetDlgTitle")

                With SetBritCheckBox
                    .Checked = My.Settings.Hilight_SetBrit
                    .Enabled = frmMain.CurrentHilightLabel.Checked
                End With

                ColorBritFloatTrackBar.Value = My.Settings.Hilight_UsrBrit
                If frmMain.CurrentHilightLabel.Checked And SetBritCheckBox.Checked Then
                    ColorBritFloatTrackBar.Enabled = True
                Else
                    ColorBritFloatTrackBar.Enabled = False
                End If

                ColorDialog1.Color = SystemColors.HighlightText
            Case SystemColorIndexes.MenuHilight
                Me.Text = LocRM.GetString("MenuHilight_ColSetDlgTitle")

                With SetBritCheckBox
                    .Checked = My.Settings.MenuHilight_SetBrit
                    .Enabled = frmMain.CurrentMenuHilightLabel.Checked
                End With

                ColorBritFloatTrackBar.Value = My.Settings.MenuHilight_UsrBrit
                If frmMain.CurrentMenuHilightLabel.Checked And SetBritCheckBox.Checked Then
                    ColorBritFloatTrackBar.Enabled = True
                Else
                    ColorBritFloatTrackBar.Enabled = False
                End If

                ColorDialog1.Color = SystemColors.HighlightText
            Case SystemColorIndexes.Hotlight
                Me.Text = LocRM.GetString("HotTracking_ColSetDlgTitle")

                With SetBritCheckBox
                    .Checked = My.Settings.HotTracking_SetBrit
                    .Enabled = frmMain.CurrentHotTrackingLabel.Checked
                End With

                ColorBritFloatTrackBar.Value = My.Settings.HotTracking_UsrBrit
                If frmMain.CurrentHotTrackingLabel.Checked And SetBritCheckBox.Checked Then
                    ColorBritFloatTrackBar.Enabled = True
                Else
                    ColorBritFloatTrackBar.Enabled = False
                End If

                ChangeForeColorButton.Visible = False
        End Select

        With ColorBritLabel
            .Text = ColorBritFloatTrackBar.Value.ToString
            .Enabled = ColorBritFloatTrackBar.Enabled
        End With
    End Sub

    Private Sub ColorBritFloatTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles ColorBritFloatTrackBar.ValueChanged
        ColorBritLabel.Text = ColorBritFloatTrackBar.Value.ToString
    End Sub

    Private Sub SetBritCheckBox_CheckStateChanged(sender As Object, e As EventArgs) Handles SetBritCheckBox.CheckStateChanged
        ColorBritFloatTrackBar.Enabled = SetBritCheckBox.Checked
        ColorBritLabel.Enabled = SetBritCheckBox.Checked
    End Sub

    Private Sub ChangeForeColorButton_Click(sender As Object, e As EventArgs) Handles ChangeForeColorButton.Click
        If ColorDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim c As Color = ColorDialog1.Color
            myForeColor = RGB(c.R, c.G, c.B)
        End If
    End Sub

    Private Sub frmColorSettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Applies changes if OK clicked
        If DialogResult = DialogResult.OK Then
            Select Case CurrentSystemColor
                Case SystemColorIndexes.ActiveCaption
                    My.Settings.ActiveCaption_SetBrit = NewSetBritValue
                    My.Settings.ActiveCaption_UsrBrit = NewUsrBritValue

                    If NewForeColor <> -1 Then
                        Dim newForeColorIndexArray() As Integer = {SystemColorIndexes.ActiveCaptionText}
                        Dim newForeColorColorArray() As Integer = {NewForeColor}
                        ApplyAndSaveColor(1, newForeColorIndexArray, newForeColorColorArray)
                    End If
                Case SystemColorIndexes.GradientActiveCaption
                    My.Settings.ActiveCaptionGradient_SetBrit = NewSetBritValue
                    My.Settings.ActiveCaptionGradient_UsrBrit = NewUsrBritValue

                    If NewForeColor <> -1 Then
                        Dim newForeColorIndexArray() As Integer = {SystemColorIndexes.ActiveCaptionText}
                        Dim newForeColorColorArray() As Integer = {NewForeColor}
                        ApplyAndSaveColor(1, newForeColorIndexArray, newForeColorColorArray)
                    End If
                Case SystemColorIndexes.Highlight
                    My.Settings.Hilight_SetBrit = NewSetBritValue
                    My.Settings.Hilight_UsrBrit = NewUsrBritValue

                    If NewForeColor <> -1 Then
                        Dim newForeColorIndexArray() As Integer = {SystemColorIndexes.HighlightText}
                        Dim newForeColorColorArray() As Integer = {NewForeColor}
                        ApplyAndSaveColor(1, newForeColorIndexArray, newForeColorColorArray)
                    End If
                Case SystemColorIndexes.MenuHilight
                    My.Settings.MenuHilight_SetBrit = NewSetBritValue
                    My.Settings.MenuHilight_UsrBrit = NewUsrBritValue

                    If NewForeColor <> -1 Then
                        Dim newForeColorIndexArray() As Integer = {SystemColorIndexes.HighlightText}
                        Dim newForeColorColorArray() As Integer = {NewForeColor}
                        ApplyAndSaveColor(1, newForeColorIndexArray, newForeColorColorArray)
                    End If
                Case SystemColorIndexes.Hotlight
                    My.Settings.HotTracking_SetBrit = NewSetBritValue
                    My.Settings.HotTracking_UsrBrit = NewUsrBritValue
            End Select
        End If
    End Sub
End Class