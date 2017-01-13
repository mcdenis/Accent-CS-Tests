Imports System.ComponentModel

Public Class frmAppSettings
    Private boSaveSettingsOnExitDirty As Boolean = False

    Private Sub chkSaveSettingsOnExit_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveSettingsOnExit.CheckedChanged
        boSaveSettingsOnExitDirty = True
    End Sub

    Private Sub frmAppSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If DialogResult = DialogResult.OK Then
            'Apply changes
            My.Settings.General_AccentSource = cboAccentSource.SelectedIndex
            My.Settings.General_SaveSettingsOnExit = chkSaveSettingsOnExit.Checked

            If boSaveSettingsOnExitDirty And chkSaveSettingsOnExit.Checked = False Then
                My.Settings.DeleteSettings()
            End If
        End If
    End Sub

    Private Sub frmAppSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set initial values for controls

        'Accent Source ComboBox
        cboAccentSource.DataSource = [Enum].GetValues(GetType(Generic.AccentSources))
        cboAccentSource.SelectedIndex = My.Settings.General_AccentSource

        'Save settings on exit checkbox
        chkSaveSettingsOnExit.Checked = My.Settings.General_SaveSettingsOnExit
    End Sub

End Class