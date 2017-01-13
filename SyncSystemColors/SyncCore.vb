Option Strict On

Imports System.Resources 'Tempo
Imports SyncSystemColors.Generic
Imports SyncSystemColors.xRay.Toolkit.Utilities

Public Class SyncCore
    Public Shared Function SyncNow(ByVal pAddDelay As Boolean, ByRef pShowConfimation As Boolean, Optional ByRef pAccent As Color = Nothing) As Boolean
        Dim LocRM As New ResourceManager("SyncSystemColors.Resource1", GetType(SystemColor).Assembly) 'Tempo. Juste en attendant que je finisse de réorganiser le code pour que les fonctions externes envoient juste des code d'erreur et que seul les forms accèssent aux strings d'affichage. Ne pas oublier d'effacer le Imports System.Resources.

        If pAddDelay = True Then
            Threading.Thread.Sleep(1000)
        End If

        'If the accent color is empty (the parameter is optional, after all) try to get it and if it can't be obtained, return False
        If pAccent.IsEmpty = True Then
            pAccent = GetAccentColor(DirectCast(My.Settings.General_AccentSource, AccentSources))
            If pAccent.IsEmpty Then
                MsgBox(LocRM.GetString("AccentInvalidError"), MsgBoxStyle.Critical)
                Return False
            End If
        End If

        'Declare the lists that will be extended as we check which color is configured to be synced.
        Dim lsColorIndexesList As List(Of Int32) = New List(Of Int32)
        Dim lsNewColorsList As List(Of Int32) = New List(Of Int32)

        'ActiveCaption
        If AppSettings.Settings.ActiveCaption.Sync Then
            'Create Final color and string
            Dim FinalActiveCaptionColor As Color
            If AppSettings.Settings.ActiveCaption.SetBrit = True Then
                FinalActiveCaptionColor = RGBHSL.SetBrightness(pAccent, AppSettings.Settings.ActiveCaption.UsrBrit)
            Else
                FinalActiveCaptionColor = pAccent
            End If

            lsColorIndexesList.Add(SystemColorIndexes.ActiveCaption)
            lsNewColorsList.Add(RGB(FinalActiveCaptionColor.R, FinalActiveCaptionColor.G, FinalActiveCaptionColor.B))

        End If

        'ActiveCaptionGradient
        If AppSettings.Settings.ActiveCaptionGradient.Sync Then
            'Create Final color and string
            Dim FinalActiveCaptionGradientColor As Color
            If AppSettings.Settings.ActiveCaptionGradient.SetBrit = True Then
                FinalActiveCaptionGradientColor = RGBHSL.SetBrightness(pAccent, AppSettings.Settings.ActiveCaptionGradient.UsrBrit)
            Else
                FinalActiveCaptionGradientColor = pAccent
            End If

            lsColorIndexesList.Add(SystemColorIndexes.GradientActiveCaption)
            lsNewColorsList.Add(RGB(FinalActiveCaptionGradientColor.R, FinalActiveCaptionGradientColor.G, FinalActiveCaptionGradientColor.B))
        End If

        'Hilight
        If AppSettings.Settings.Hilight.Sync Then
            'Create Final color and string
            Dim FinalHilightColor As Color
            If AppSettings.Settings.Hilight.SetBrit = True Then
                FinalHilightColor = RGBHSL.SetBrightness(pAccent, AppSettings.Settings.Hilight.UsrBrit)
            Else
                FinalHilightColor = pAccent
            End If

            lsColorIndexesList.Add(SystemColorIndexes.Highlight)
            lsNewColorsList.Add(RGB(FinalHilightColor.R, FinalHilightColor.G, FinalHilightColor.B))
        End If

        'MenuHilight
        If AppSettings.Settings.MenuHilight.Sync Then
            'Create Final color and string
            Dim FinalMenuHilightColor As Color
            If AppSettings.Settings.MenuHilight.SetBrit = True Then
                FinalMenuHilightColor = RGBHSL.SetBrightness(pAccent, AppSettings.Settings.MenuHilight.UsrBrit)
            Else
                FinalMenuHilightColor = pAccent
            End If

            lsColorIndexesList.Add(SystemColorIndexes.MenuHilight)
            lsNewColorsList.Add(RGB(FinalMenuHilightColor.R, FinalMenuHilightColor.G, FinalMenuHilightColor.B))
        End If

        'HotTracking
        If AppSettings.Settings.HotTracking.Sync Then
            Dim FinalHotTrackingColor As Color
            If AppSettings.Settings.HotTracking.SetBrit = True Then
                FinalHotTrackingColor = RGBHSL.SetBrightness(pAccent, AppSettings.Settings.HotTracking.UsrBrit)
            Else
                FinalHotTrackingColor = pAccent
            End If

            lsColorIndexesList.Add(SystemColorIndexes.Hotlight)
            lsNewColorsList.Add(RGB(FinalHotTrackingColor.R, FinalHotTrackingColor.G, FinalHotTrackingColor.B))
        End If

        'Declare and set values of the arrays that will be sent to ApplyAndSaveColor
        Dim ColorIndexes() As Int32 = lsColorIndexesList.ToArray
        Dim NewColors() As Int32 = lsNewColorsList.ToArray


        If (ColorIndexes.Length And NewColors.Length) >= 1 Then
            'Apply and save changes
            If ApplyAndSaveColor(ColorIndexes.Length, ColorIndexes, NewColors) Then
                If pShowConfimation Then
                    MsgBox(LocRM.GetString("SyncSuccessful"), MsgBoxStyle.Information)
                End If
                Return True
            Else 'ApplyAndSaveColor function returned false
                MsgBox("This is a bug. Error: The ApplyAndSaveColor function returned false.")
                Return False
            End If
        Else
            MsgBox(LocRM.GetString("NoSysColorSelectedWarning"), MsgBoxStyle.Exclamation)
            Return False
        End If
    End Function
End Class
