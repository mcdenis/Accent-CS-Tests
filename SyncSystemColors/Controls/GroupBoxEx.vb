Imports System.ComponentModel

Namespace MyControls

    ''' <summary>
    ''' Standard groupbox that can also only draw a top border.
    ''' </summary>
    Public Class GroupBoxEx
        Inherits GroupBox

        Private boSingleLineBorderPropty As Boolean = False
        <DefaultValue(False)>
        Public Property DrawTopBorderOnly As Boolean
            Get
                Return boSingleLineBorderPropty
            End Get
            Set(value As Boolean)
                boSingleLineBorderPropty = value
            End Set
        End Property

        Private sizeText As Size
        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e)
            CalculateTextSize()
        End Sub

        Protected Overrides Sub OnFontChanged(e As EventArgs)
            MyBase.OnFontChanged(e)
            CalculateTextSize()
        End Sub

        Private Sub CalculateTextSize()
            sizeText = TextRenderer.MeasureText(Text, Font)
        End Sub

        Private penHeaderLine As Pen = SystemPens.ControlDark
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            If DrawTopBorderOnly Then
                'Text
                Dim rectHeaderText As New Rectangle(ClientRectangle.Location, sizeText)
                TextRenderer.DrawText(e.Graphics, Text, Font, rectHeaderText, ForeColor)

                'e.Graphics.DrawRectangle(Pens.Red, rectHeaderText)


                'Line
                Dim inLineY As Integer = sizeText.Height / 2 'Centré verticalement
                'Dim rectHeaderLine As New Rectangle(ClientRectangle.X + sizeText.Width, ClientRectangle.Y, ClientRectangle.Width - sizeText.Width, sizeText.Height)
                e.Graphics.DrawLine(SystemPens.ControlDark, ClientRectangle.X + sizeText.Width, inLineY, ClientRectangle.Right, inLineY)
            Else
                MyBase.OnPaint(e)
            End If
        End Sub

    End Class
End Namespace