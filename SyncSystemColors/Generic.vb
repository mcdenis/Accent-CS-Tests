Option Strict On

Imports System.Resources

Public Module Generic
    ''' <summary>
    ''' Enumeration of possible values for the accent source setting.
    ''' </summary>
    Public Enum AccentSources As Integer
        AccentPalette
        DWMAccent
    End Enum

    ''' <summary>
    ''' Returns a bitmap from a string. Useful to create an image from a font icon.
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="fontname"></param>
    ''' <param name="fontsize"></param>
    ''' <param name="bgcolor"></param>
    ''' <param name="fcolor"></param>
    ''' <param name="width">Width of the returned bitmap.</param>
    ''' <param name="Height">Height of the returned bitmap.</param>
    ''' <param name="txtposition">Point where the string begins on the bitmap.</param>
    ''' <returns></returns>
    Public Function ConvertTextToImage(txt As String, fontname As String, fontsize As Integer, bgcolor As Color, fcolor As Color, width As Integer,
    Height As Integer, txtposition As Point) As Bitmap
        Dim bmp As New Bitmap(width, Height)
        bmp.SetResolution(96.0F, 96.0F) 'Set a fixed dpi so that 256x256px is always 256x256px.
        Using graphics__1 As Graphics = Graphics.FromImage(bmp)

            Dim font As New Font(fontname, fontsize)
            graphics__1.FillRectangle(New SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height)
            graphics__1.DrawString(txt, font, New SolidBrush(fcolor), txtposition)
            graphics__1.Flush()
            font.Dispose()
            graphics__1.Dispose()
        End Using
        Return bmp
    End Function

    ''' <summary>
    ''' Gets a value indicating if colored title bars are enabled in Windows.
    ''' </summary>
    ''' <returns></returns>
    Public Function WindowsColoredTitleBar() As Integer
        Return DirectCast(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\DWM\", "ColorPrevalence", 1), Integer)
    End Function

    ''' <summary>
    ''' Returns a Color from a 32Bit DWORD from the registry.
    ''' </summary>
    ''' <param name="myDECIMAL">Decimal value of the Color.</param>
    ''' <returns></returns>
    Public Function RegDecimal2Color(ByVal myDECIMAL As Integer) As Color
        Dim C As Color = Color.FromArgb(myDECIMAL)
        Return Color.FromArgb(255, C.B, C.G, C.R)
    End Function

    ''' <summary>
    ''' Returns a string in the "R G B" format that can be written
    ''' in the HKCU/Control Panel/Colors registry key or shown to the user.
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Public Function CreateRGBString(ByRef c As Color) As String
        Dim R As Integer = c.R
        Dim G As Integer = c.G
        Dim B As Integer = c.B
        Return R.ToString & " " & G.ToString & " " & B.ToString
    End Function

    ''' <summary>
    ''' Show a modal dialog with the right properties depending if the parent is visible or not.
    ''' </summary>
    ''' <param name="createForm"></param>
    ''' <param name="pOwner">Owner of the form to show.</param>
    ''' <returns></returns>
    Public Function ShowDialog(createForm As Func(Of Form), pOwner As Form) As DialogResult
        Using frm = createForm()

            Dim dlgResult As DialogResult
            If pOwner.WindowState <> FormWindowState.Minimized And pOwner.Visible Then
                dlgResult = frm.ShowDialog(pOwner)
            Else
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = True
                dlgResult = frm.ShowDialog()
            End If
            Return dlgResult

        End Using
    End Function

End Module
