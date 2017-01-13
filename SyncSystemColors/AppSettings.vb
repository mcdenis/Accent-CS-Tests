Option Strict On

Imports System.Globalization

Public Class AppSettings
    'This class is used to store the user configurable settings that are used by the application and that vary depending of the advanced mode state. 
    'The properties in My.Settings are applied to these when the advanced mode is enabled. When the advanced mode is disabled, the default values (which are also 
    'stored in My.Settings) are applied instead.

    Private Shared instance As AppSettings = Nothing

    Public ReadOnly Property ActiveCaption As ActiveCaptionSettings
    Public ReadOnly Property ActiveCaptionGradient As ActiveCaptionGradientSettings
    Public ReadOnly Property Hilight As HilightSettings
    Public ReadOnly Property MenuHilight As MenuHilightSettings
    Public ReadOnly Property HotTracking As HotlightSettings

    Public Shared ReadOnly Property Settings As AppSettings
        Get
            If instance Is Nothing Then
                instance = New AppSettings
            End If

            Return instance
        End Get
    End Property


    Private Sub New()
        'Initialize an instance of each inner classes
        ActiveCaption = New ActiveCaptionSettings
        ActiveCaptionGradient = New ActiveCaptionGradientSettings
        Hilight = New HilightSettings
        MenuHilight = New MenuHilightSettings
        HotTracking = New HotlightSettings

        'Applies the correct values to AppSettings
        RefreshAppSettings()

        'Monitors My.Settings and AppSettings synced. 
        AddHandler My.Settings.PropertyChanged, AddressOf Settings_PropertyChanged
    End Sub

    Private Sub Settings_PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs)
        If My.Settings.General_AdvancedModeEnabled Then
            Select Case e.PropertyName

                'Active Caption
                Case "ActiveCaption_Sync"
                    ActiveCaption.Sync = My.Settings.ActiveCaption_Sync
                Case "ActiveCaption_SetBrit"
                    ActiveCaption.SetBrit = My.Settings.ActiveCaption_SetBrit
                Case "ActiveCaption_UsrBrit"
                    ActiveCaption.UsrBrit = My.Settings.ActiveCaption_UsrBrit

                    'Active Caption Gradient
                Case "ActiveCaptionGradient_Sync"
                    ActiveCaptionGradient.Sync = My.Settings.ActiveCaptionGradient_Sync
                Case "ActiveCaptionGradient_SetBrit"
                    ActiveCaptionGradient.SetBrit = My.Settings.ActiveCaptionGradient_SetBrit
                Case "ActiveCaptionGradient_UsrBrit"
                    ActiveCaptionGradient.UsrBrit = My.Settings.ActiveCaptionGradient_UsrBrit

                    'Hilight
                Case "Hilight_Sync"
                    Hilight.Sync = My.Settings.Hilight_Sync
                Case "Hilight_SetBrit"
                    Hilight.SetBrit = My.Settings.Hilight_SetBrit
                Case "Hilight_UsrBrit"
                    Hilight.UsrBrit = My.Settings.Hilight_UsrBrit

                    'Menu Hilight
                Case "MenuHilight_Sync"
                    MenuHilight.Sync = My.Settings.MenuHilight_Sync
                Case "MenuHilight_SetBrit"
                    MenuHilight.SetBrit = My.Settings.MenuHilight_SetBrit
                Case "MenuHilight_UsrBrit"
                    MenuHilight.UsrBrit = My.Settings.MenuHilight_UsrBrit

                    'Hot Tracking
                Case "HotTracking_Sync"
                    HotTracking.Sync = My.Settings.HotTracking_Sync
                Case "HotTracking_SetBrit"
                    HotTracking.SetBrit = My.Settings.HotTracking_SetBrit
                Case "HotTracking_UsrBrit"
                    HotTracking.UsrBrit = My.Settings.HotTracking_UsrBrit

                    'Other

            End Select
        End If

        'Apply the correct values to AppSettings when the advanced mode state is changed.
        If e.PropertyName = "General_AdvancedModeEnabled" Then
            RefreshAppSettings()
        End If

    End Sub

    ''' <summary>
    ''' Applies the right values to all of AppSettings' properties depending of the advanced mode state.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshAppSettings()
        If My.Settings.General_AdvancedModeEnabled Then
            '********Set settings that will be used********
            'Wether the color is synced
            ActiveCaption.Sync = My.Settings.ActiveCaption_Sync
            ActiveCaptionGradient.Sync = My.Settings.ActiveCaptionGradient_Sync
            Hilight.Sync = My.Settings.Hilight_Sync
            MenuHilight.Sync = My.Settings.MenuHilight_Sync
            HotTracking.Sync = My.Settings.HotTracking_Sync

            'Brightness override enabled/disabled
            ActiveCaption.SetBrit = My.Settings.ActiveCaption_SetBrit
            ActiveCaptionGradient.SetBrit = My.Settings.ActiveCaptionGradient_SetBrit
            Hilight.SetBrit = My.Settings.Hilight_SetBrit
            MenuHilight.SetBrit = My.Settings.MenuHilight_SetBrit
            HotTracking.SetBrit = My.Settings.HotTracking_SetBrit

            'New brightness level
            ActiveCaption.UsrBrit = My.Settings.ActiveCaption_UsrBrit
            ActiveCaptionGradient.UsrBrit = My.Settings.ActiveCaptionGradient_UsrBrit
            Hilight.UsrBrit = My.Settings.Hilight_UsrBrit
            MenuHilight.UsrBrit = My.Settings.MenuHilight_UsrBrit
            HotTracking.UsrBrit = My.Settings.HotTracking_UsrBrit

            'Other settings

        Else
            '********Set settings that will be used******** (when advanced mode is disabled, the user has no control over these settings, so they must be always the same.)
            'Wether the color is synced
            ActiveCaption.Sync = Boolean.Parse(DirectCast(My.Settings.PropertyValues("ActiveCaption_Sync").Property.DefaultValue, String))
            ActiveCaptionGradient.Sync = Boolean.Parse(DirectCast(My.Settings.PropertyValues("ActiveCaptionGradient_Sync").Property.DefaultValue, String))
            Hilight.Sync = Boolean.Parse(DirectCast(My.Settings.PropertyValues("Hilight_Sync").Property.DefaultValue, String))
            MenuHilight.Sync = Boolean.Parse(DirectCast(My.Settings.PropertyValues("MenuHilight_Sync").Property.DefaultValue, String))
            HotTracking.Sync = Boolean.Parse(DirectCast(My.Settings.PropertyValues("HotTracking_Sync").Property.DefaultValue, String))

            'Brightness override enabled/disabled
            ActiveCaption.SetBrit = Boolean.Parse(DirectCast(My.Settings.PropertyValues("ActiveCaption_SetBrit").Property.DefaultValue, String))
            ActiveCaptionGradient.SetBrit = Boolean.Parse(DirectCast(My.Settings.PropertyValues("ActiveCaptionGradient_SetBrit").Property.DefaultValue, String))
            Hilight.SetBrit = Boolean.Parse(DirectCast(My.Settings.PropertyValues("Hilight_SetBrit").Property.DefaultValue, String))
            MenuHilight.SetBrit = Boolean.Parse(DirectCast(My.Settings.PropertyValues("MenuHilight_SetBrit").Property.DefaultValue, String))
            HotTracking.SetBrit = Boolean.Parse(DirectCast(My.Settings.PropertyValues("HotTracking_SetBrit").Property.DefaultValue, String))

            'New brightness level (pas nécessaire puisque brightness override est désactivé par défaut!)
            'First, we cast the Object to a String (which is what it actually is)
            'Secondly, we parse the String to a Double with the CultureInfo.InvariantCulture cause configuration files is culture invariant while parsing is culture variant by default, which causes an unhandled exception when the decimal separator is not a period!
            ActiveCaption.UsrBrit = Double.Parse(DirectCast(My.Settings.PropertyValues("ActiveCaption_UsrBrit").Property.DefaultValue, String), CultureInfo.InvariantCulture)
            ActiveCaptionGradient.UsrBrit = Double.Parse(DirectCast(My.Settings.PropertyValues("ActiveCaptionGradient_UsrBrit").Property.DefaultValue, String), CultureInfo.InvariantCulture)
            Hilight.UsrBrit = Double.Parse(DirectCast(My.Settings.PropertyValues("Hilight_UsrBrit").Property.DefaultValue, String), CultureInfo.InvariantCulture)
            MenuHilight.UsrBrit = Double.Parse(DirectCast(My.Settings.PropertyValues("MenuHilight_UsrBrit").Property.DefaultValue, String), CultureInfo.InvariantCulture)
            HotTracking.UsrBrit = Double.Parse(DirectCast(My.Settings.PropertyValues("HotTracking_UsrBrit").Property.DefaultValue, String), CultureInfo.InvariantCulture)

            'Other settings

        End If
    End Sub

    Public Class ActiveCaptionSettings
        Public Property Sync As Boolean
        Public Property SetBrit As Boolean
        Public Property UsrBrit As Double
    End Class

    Public Class ActiveCaptionGradientSettings
        Public Property Sync As Boolean
        Public Property SetBrit As Boolean
        Public Property UsrBrit As Double
    End Class

    Public Class HilightSettings
        Public Property Sync As Boolean
        Public Property SetBrit As Boolean
        Public Property UsrBrit As Double
    End Class

    Public Class MenuHilightSettings
        Public Property Sync As Boolean
        Public Property SetBrit As Boolean
        Public Property UsrBrit As Double
    End Class

    Public Class HotlightSettings
        Public Property Sync As Boolean
        Public Property SetBrit As Boolean
        Public Property UsrBrit As Double
    End Class

End Class