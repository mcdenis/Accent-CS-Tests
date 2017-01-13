Option Strict On

Imports System.Resources
Imports SyncSystemColors.Generic

Public Module SystemColor
    Private LocRM As New ResourceManager("SyncSystemColors.Resource1", GetType(SystemColor).Assembly) 'Tempo. Juste en attendant que je finisse de réorganiser le code pour que les fonctions externes envoient juste des code d'erreur et que seul les forms accèssent aux strings d'affichage. Ne pas oublier d'effacer le Imports System.Resources.

    Private Declare Function SetSysColors Lib "user32.dll" (ByVal nChanges As Int32,
        ByRef lpSysColor As Int32, ByRef lpColorValues As Int32) As Int32

    Public Enum SystemColorIndexes As Integer
        ActiveCaption = 2
        ActiveCaptionText = 9
        Highlight = 13
        HighlightText = 14
        Hotlight = 26
        GradientActiveCaption = 27
        MenuHilight = 29
    End Enum

    ''' <summary>
    ''' Restore the default colors for all system colors supported by the application.
    ''' </summary>
    Public Sub RestoreDefaultColors()
        'Registry fallback
        Const inCOLOR_ACTIVECAPTION_FALLBACK As Integer = 13743257
        Const inCOLOR_ACTIVECAPTIONGRADIENT_FALLBACK As Integer = 15389113
        Const inCOLOR_HILIGHT_FALLBACK As Integer = 16750899
        Const inCOLOR_MENUHILIGHT_FALLBACK As Integer = 16750899
        Const inCOLOR_HOTLIGHT_FALLBACK As Integer = 13395456

        Const inCOLOR_TITLETEXT_FALLBACK As Integer = 0
        Const inCOLOR_HILIGHTTEXT_FALLBACK As Integer = 16777215

        'Declare variables that store decimal colors directly from the registry.
        Dim inActiveCaption As Integer
        Dim inActiveCaptionGradient As Integer
        Dim inHilight As Integer
        Dim inMenuHilight As Integer
        Dim inHotLight As Integer

        Dim inTitleText As Integer
        Dim inHilightText As Integer

        If Environment.OSVersion.Version.Build < 14361 Then
            'Read the default colors from the registry.
            Dim regKeyDefaults As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\DefaultColors\Standard", False)
            Try
                inActiveCaption = DirectCast(regKeyDefaults.GetValue("ActiveTitle", inCOLOR_ACTIVECAPTION_FALLBACK), Integer)

                'BTW the default color for this system color does not actually exist in the registry on W8.x or 10, so the fallback will be most likely used.
                inActiveCaptionGradient = DirectCast(regKeyDefaults.GetValue("GradientActiveTitle", inCOLOR_ACTIVECAPTIONGRADIENT_FALLBACK), Integer)

                inHilight = DirectCast(regKeyDefaults.GetValue("Hilight", inCOLOR_HILIGHT_FALLBACK), Integer)

                inMenuHilight = DirectCast(regKeyDefaults.GetValue("MenuHilight", inCOLOR_MENUHILIGHT_FALLBACK), Integer)

                inHotLight = DirectCast(regKeyDefaults.GetValue("HotTrackingColor", inCOLOR_HOTLIGHT_FALLBACK), Integer)

                'Foreground
                inTitleText = DirectCast(regKeyDefaults.GetValue("TitleText", inCOLOR_TITLETEXT_FALLBACK), Integer)

                inHilightText = DirectCast(regKeyDefaults.GetValue("HilightText", inCOLOR_HILIGHTTEXT_FALLBACK), Integer)

            Catch ex As Exception
                Select Case MsgBox(LocRM.GetString("ResetRegKeyError"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel)
                    Case MsgBoxResult.Ok
                        'Assign Fallback values if reg key does not exist.
                        inActiveCaption = inCOLOR_ACTIVECAPTION_FALLBACK
                        inActiveCaptionGradient = inCOLOR_ACTIVECAPTIONGRADIENT_FALLBACK
                        inHilight = inCOLOR_HILIGHT_FALLBACK
                        inMenuHilight = inCOLOR_MENUHILIGHT_FALLBACK
                        inHotLight = inCOLOR_HOTLIGHT_FALLBACK

                        inTitleText = inCOLOR_TITLETEXT_FALLBACK
                        inHilightText = inCOLOR_HILIGHTTEXT_FALLBACK
                    Case Else
                        Exit Sub
                End Select

            Finally
                If regKeyDefaults IsNot Nothing Then
                    regKeyDefaults.Dispose()
                End If
            End Try
        Else
            'In the Anniversary Update, the default color of Hilight and MenuHilight was changed, 
            'but the reg values were not updated. The only way left (that I am aware of) 
            'would be to read the current MSStyle, but that's way beyond my scope of competence! 
            'Instead, we just hard code the color.
            inActiveCaption = inCOLOR_ACTIVECAPTION_FALLBACK
            inActiveCaptionGradient = inCOLOR_ACTIVECAPTIONGRADIENT_FALLBACK
            inHilight = 14120960
            inMenuHilight = 14120960
            inHotLight = inCOLOR_HOTLIGHT_FALLBACK

            inTitleText = inCOLOR_TITLETEXT_FALLBACK
            inHilightText = inCOLOR_HILIGHTTEXT_FALLBACK
        End If

        'The Reg key exists and is accessible
        '   1.Value does not exist -> Fallback for this system color only
        '   2.Value exists, but permission issue maybe and GetValue throw exception. -> Fallback for all color (makes sense because if one value exists, but cannot be accessed, the problem is likely weird wtf and the other values will likely have the same issue.        
        'The Reg key exists, permission issue maybe and OpenSubKey throw exception
        '   Unhandled exception
        'The Reg key does not exist
        '   Fallback for all colors



        'Create arrays (les indexes et la couleur qui y est respectivement associée doit absolument être dans le même ordre.)
        Dim ColorIndexes(6) As Int32
        ColorIndexes(0) = SystemColorIndexes.ActiveCaption
        ColorIndexes(1) = SystemColorIndexes.GradientActiveCaption
        ColorIndexes(2) = SystemColorIndexes.Highlight
        ColorIndexes(3) = SystemColorIndexes.MenuHilight
        ColorIndexes(4) = SystemColorIndexes.Hotlight

        ColorIndexes(5) = SystemColorIndexes.ActiveCaptionText
        ColorIndexes(6) = SystemColorIndexes.HighlightText


        Dim NewColors(6) As Int32
        NewColors(0) = inActiveCaption
        NewColors(1) = inActiveCaptionGradient
        NewColors(2) = inHilight
        NewColors(3) = inMenuHilight
        NewColors(4) = inHotLight

        NewColors(5) = inTitleText
        NewColors(6) = inHilightText



        'Apply changes
        If ApplyAndSaveColor(7, ColorIndexes, NewColors) Then
            MsgBox(LocRM.GetString("ResetSuccessful"), MsgBoxStyle.Information)
        End If
    End Sub

    'Write changes to registry.
    Private Function SaveSysColor(ColorResIndex() As Int32, NewColor() As Int32) As Boolean
        Dim SystemColorKey = My.Computer.Registry.CurrentUser.OpenSubKey("Control Panel\Colors", True)
        Dim i As Integer = 0
        For Each cIndex As Integer In ColorResIndex
            Dim DefaultColor As Color = RegDecimal2Color(NewColor(i))
            Dim DefaultString As String = CreateRGBString(DefaultColor)
            Select Case cIndex
                Case SystemColorIndexes.ActiveCaption
                    SystemColorKey.SetValue("ActiveTitle", DefaultString)
                Case SystemColorIndexes.GradientActiveCaption
                    SystemColorKey.SetValue("GradientActiveTitle", DefaultString)
                Case SystemColorIndexes.Highlight
                    SystemColorKey.SetValue("Hilight", DefaultString)
                Case SystemColorIndexes.MenuHilight
                    SystemColorKey.SetValue("MenuHilight", DefaultString)
                Case SystemColorIndexes.Hotlight
                    SystemColorKey.SetValue("HotTrackingColor", DefaultString)

                Case SystemColorIndexes.ActiveCaptionText
                    SystemColorKey.SetValue("TitleText", DefaultString)
                Case SystemColorIndexes.HighlightText
                    SystemColorKey.SetValue("HilightText", DefaultString)
            End Select
            i = i + 1
        Next
        SystemColorKey.Close()

        Return True

    End Function

    ''' <summary>
    ''' Changes the specified system colors.
    ''' </summary>
    ''' <param name="n">Amount of system colors to change.</param>
    ''' <param name="ColorResIndex">Array of the indexes of the system colors to change.</param>
    ''' <param name="NewColor">Array of the new colors to apply.</param>
    ''' <returns></returns>
    Public Function ApplyAndSaveColor(n As Int32, ColorResIndex() As Int32, NewColor() As Int32) As Boolean
        'If no color are sent or arrays are messed up, return False, because no change were made
        If (n Or ColorResIndex.Length Or NewColor.Length) < 1 Or n <> ColorResIndex.Count Or ColorResIndex.Count <> NewColor.Count Then
            Return False
        End If

        Dim SetSysColorSuccess As Integer = SetSysColors(n, ColorResIndex(0), NewColor(0))
        Dim SaveSysColorSucess As Boolean = SaveSysColor(ColorResIndex, NewColor)

        If SetSysColorSuccess = 1 And SaveSysColorSucess = True Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
