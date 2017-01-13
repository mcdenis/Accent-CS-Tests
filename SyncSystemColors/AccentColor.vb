Module AccentColor
    ''' <summary>
    ''' Return a color representing the accent color.
    ''' </summary>
    ''' <param name="source">The method to use to get the accent color.</param>
    ''' <returns></returns>
    Public Function GetAccentColor(source As AccentSources) As Color
        Select Case source
            Case AccentSources.AccentPalette
                Dim colPal As Color = GetAccentPaletteMainColor()
                If colPal.IsEmpty = False Then
                    Return colPal
                Else
                    'On utilise la ImmersiveAccentColor comme fallback.
                    Return GetImmersiveAccentColor()
                End If
            Case AccentSources.DWMAccent
                Dim colDWM As Color = GetDWMAccentColor()
                If colDWM.IsEmpty = False Then
                    Return colDWM
                Else
                    'On utilise la ImmersiveAccentColor comme fallback.
                    Return GetImmersiveAccentColor()
                End If
        End Select
    End Function

    Private Function GetAccentPaletteMainColor() As Color
        Dim objRegValue As Object = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentPalette", Nothing)

        'Si la valeur dans le régistre n'existe pas, retourner une couleur vide tout de suite.
        If objRegValue Is Nothing Then
            Return Color.Empty
        End If

        Dim byteArray As Byte() = CType(objRegValue, Byte())

        Dim hexString = String.Join("", byteArray.Select(Function(b) b.ToString("X2")))

        Dim SingleHexString As String = "#" & hexString.Substring(24, 6)
        Dim c As Color = ColorTranslator.FromHtml(SingleHexString)
        Return c
    End Function

    Private Function GetDWMAccentColor() As Color
        Dim DWMAccentRegValue = My.Computer.Registry.GetValue _
("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\DWM", "AccentColor", Nothing)
        If DWMAccentRegValue IsNot Nothing Then
            Return RegDecimal2Color(myDECIMAL:=DWMAccentRegValue)
        Else
            Return Color.Empty
        End If
    End Function

    Private Function GetImmersiveAccentColor() As Color
        Dim ImmersiveAccentRegValue = My.Computer.Registry.GetValue _
("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentColor", Nothing)
        If ImmersiveAccentRegValue IsNot Nothing Then
            Return RegDecimal2Color(myDECIMAL:=ImmersiveAccentRegValue)
        Else
            Return Color.Empty
        End If
    End Function
End Module
