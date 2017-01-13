Option Strict On

Namespace My
    
    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings
        'Event used by the form so that it can configure itself (layout, etc.) when the advanced mode state is changed.
        Public Event AdvancedModeSettingChanged As EventHandler

        Protected Overrides Sub OnPropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs)
            MyBase.OnPropertyChanged(sender, e)

            If e.PropertyName = "General_AdvancedModeEnabled" Then
                RaiseEvent AdvancedModeSettingChanged(sender, e)
            End If
        End Sub

        ''' <summary>
        ''' Delete the config file from the disk.
        ''' </summary>
        Public Sub DeleteSettings()

            Dim LocalAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            Dim DirToDelete As String = LocalAppDataPath & "\SyncSystemColors"
            If IO.Directory.Exists(DirToDelete) = True Then
                Try
                    IO.Directory.Delete(DirToDelete, True)
                    'MsgBox("Configuration file deleted.", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox("The configuration file could not be deleted because it either does not exist or it is currently in use.", MsgBoxStyle.Exclamation)
                End Try
            End If
        End Sub

    End Class
End Namespace
