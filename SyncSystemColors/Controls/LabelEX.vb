Imports System.ComponentModel

Namespace MyControls

    ''' <summary>
    ''' Standard label that supports the NoPadding flag.
    ''' </summary>
    Public Class LabelEX
        Inherits Label 'Private textAlign As

        Private flags As TextFormatFlags = TextFormatFlags.WordBreak
        Private boBasePainting As Boolean = False

        Private _noPadding As Boolean = False
        <Category("Layout"), Description("Remove the base padding.")>
        Public Property NoPadding As Boolean
            Get
                Return _noPadding
            End Get
            Set(value As Boolean)
                _noPadding = value

                If value = True Then
                    CreateFlags()
                End If

                Me.Invalidate()
            End Set
        End Property

        Public Shadows Property RightToLeft As System.Windows.Forms.RightToLeft
            Get
                Return MyBase.RightToLeft
            End Get
            Set(value As System.Windows.Forms.RightToLeft)
                MyBase.RightToLeft = value

                If NoPadding = True Then
                    CreateFlags()
                    Me.Invalidate()
                End If
            End Set
        End Property

        Public Shadows Property TextAlign As System.Drawing.ContentAlignment
            Get
                Return MyBase.TextAlign
            End Get
            Set(value As System.Drawing.ContentAlignment)
                MyBase.TextAlign = value

                If NoPadding = True Then
                    CreateFlags()
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private Sub CreateFlags()
            flags = TextFormatFlags.WordBreak
            If _noPadding = True Then
                flags = flags Or TextFormatFlags.NoPadding
            End If


            'Right to left. Marche pas trop
            If Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes Then
                flags = flags Or TextFormatFlags.RightToLeft
            End If


            'Text alignement
            'Top
            If Me.TextAlign = ContentAlignment.TopLeft Or Me.TextAlign = ContentAlignment.TopCenter Or Me.TextAlign = ContentAlignment.TopRight Then
                'flags = flags Or TextFormatFlags.Top 'Pas nécessaire puisque Top est le défaut.
            End If
            'Middle
            If Me.TextAlign = ContentAlignment.MiddleLeft Or Me.TextAlign = ContentAlignment.MiddleCenter Or Me.TextAlign = ContentAlignment.MiddleRight Then
                flags = flags Or TextFormatFlags.VerticalCenter
            End If
            'Bottom
            If Me.TextAlign = ContentAlignment.BottomLeft Or Me.TextAlign = ContentAlignment.BottomCenter Or Me.TextAlign = ContentAlignment.BottomRight Then
                flags = flags Or TextFormatFlags.Bottom
            End If

            'Left
            If Me.TextAlign = ContentAlignment.BottomLeft Or Me.TextAlign = ContentAlignment.MiddleLeft Or Me.TextAlign = ContentAlignment.TopLeft Then
                flags = flags Or TextFormatFlags.Left 'Pas nécessaire puisque Left est le default. PAS VRAI
            End If
            'Center
            If Me.TextAlign = ContentAlignment.BottomCenter Or Me.TextAlign = ContentAlignment.MiddleCenter Or Me.TextAlign = ContentAlignment.TopCenter Then
                flags = flags Or TextFormatFlags.HorizontalCenter
            End If
            'Right
            If Me.TextAlign = ContentAlignment.BottomRight Or Me.TextAlign = ContentAlignment.MiddleRight Or Me.TextAlign = ContentAlignment.TopRight Then
                flags = flags Or TextFormatFlags.Right
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            If NoPadding Then
                RaisePaintEvent(New Object, e)
                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, Me.ClientRectangle, Me.ForeColor, flags)
            Else
                MyBase.OnPaint(e)
            End If
        End Sub
    End Class

End Namespace