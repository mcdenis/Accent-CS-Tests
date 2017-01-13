Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles

Namespace MyControls

    ''' <summary>
    ''' Toolstrip renderer that follows the system theme. Has support for visual styles, including the light and dark immersive styles.
    ''' </summary>
    Public Class ToolStripSystemRendererEx
        Inherits ToolStripSystemRenderer

        'Différences avec myRenderer7 :
        'Render menu item background et renderItem text n'utilisaient pas le bon rectangle! C'est pourquoi augmenter le padding fourrait toutes les affaires! Arrangé ça en m'inspirant du code de .Net Reference Source.
        'Dans OnRenderMenuItemBackground, pas vérifier si Toolstrip IsDropDown. Plutôt vérifier si Item IsOnDropDown.

        Private Const stSTANDARD_VS_CLASS As String = "Menu"
        Private Const stIMMERSIVE_LIGHT_VS_CLASS As String = "ImmersiveStart::Menu"
        Private Const stIMMERSIVE_DARK_VS_CLASS As String = "ImmersiveStartDark::Menu"

        Private os As OperatingSystem = Environment.OSVersion
        Private vsClass As String
        Private boIsImmersive As Boolean
        Private symbolFont As Font

        Public Sub New()
            'Set the appropriate symbol font depending of the OS.
            If os.Version.Major >= 10 Then
                symbolFont = New Font("Segoe MDL2 Assets", SystemFonts.MenuFont.Size)
            Else
                symbolFont = New Font("Segoe UI Symbol", SystemFonts.MenuFont.Size - 2)
            End If

            'Set the default value for the Theme property (we can't just assign a value to the thTheme variable cause we also want to run the code that determine the Visual Style class.
            Theme = Themes.Standard
        End Sub

        Public Enum Themes
            Standard
            ImmersiveLight
            ImmersiveDark
        End Enum
        Private thTheme As Themes
        <DefaultValue(Themes.Standard)>
        Public Property Theme As Themes 'À faire : améliorer les fallbacks pour Win7 qui n'a pas les thèmes Immersive!
            Get
                Return thTheme
            End Get
            Set(value As Themes)
                thTheme = value

                'Set the appropriate visual style class and the IsImmersive field.
                'Since some classes are not available in older versions of Windows,
                'we automatically change the vs class if the new value won't 
                'work in the current OS.
                Select Case value
                    Case Themes.Standard
                        vsClass = stSTANDARD_VS_CLASS
                        boIsImmersive = False

                    Case Themes.ImmersiveLight
                        'The ImmersiveLight theme is supported on Windows 8.1 Update 1 or newer. (Here, we assume that everyone using 8.1 has the update installed. In the worst case, the menu text will look weird.)
                        If os.Version.Build >= 9600 Then
                            vsClass = stIMMERSIVE_LIGHT_VS_CLASS
                            boIsImmersive = True
                        Else
                            vsClass = stSTANDARD_VS_CLASS
                            boIsImmersive = False
                        End If

                    Case Themes.ImmersiveDark
                        'The ImmersiveDark theme is supported on Windows 10 TH2 or newer.
                        'If Windows 8.1, we use the ImmersiveLight theme. Otherwise, we use 
                        'the standard theme.
                        If os.Version.Build >= 10532 Then
                            vsClass = stIMMERSIVE_DARK_VS_CLASS
                            boIsImmersive = True
                        ElseIf os.Version.Build >= 9600 Then
                            vsClass = stIMMERSIVE_LIGHT_VS_CLASS
                            boIsImmersive = True
                        Else
                            vsClass = stSTANDARD_VS_CLASS
                            boIsImmersive = False
                        End If
                End Select
            End Set
        End Property

        Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
            If ToolStripManager.VisualStylesEnabled = False Or e.ToolStrip.IsDropDown = False Then
                MyBase.OnRenderToolStripBackground(e)
                Exit Sub
            End If

            'We create the visual style element
            Dim vsElement As VisualStyleElement = VisualStyleElement.CreateElement(vsClass, 9, 0)

            'We check if the vs element is defined. If it isn't, we just draw the classic menu and we exit.
            If VisualStyleRenderer.IsElementDefined(vsElement) = False Then
                MyBase.OnRenderToolStripBackground(e)
                Exit Sub
            End If

            'Initialize the visual style renderer
            Dim popupBackVSRenderer As VisualStyleRenderer = New VisualStyleRenderer(vsElement)
            'Do the drawing depending if a Immersive theme is used.
            If boIsImmersive = False Then
                popupBackVSRenderer.DrawBackground(e.Graphics, e.AffectedBounds)
            Else
                Dim popupBackColor As Color = popupBackVSRenderer.GetColor(ColorProperty.FillColor)
                e.Graphics.FillRectangle(New SolidBrush(popupBackColor), e.AffectedBounds)
            End If
        End Sub

        'We would normally not need to override the border drawing method, but there is a bug in the original .Net code :
        'The border is painted 3D or flat depending if drop shadows and visual styles are enabled, which
        'is just wrong. The IsFlatMenuEnabled property should be used instead.
        Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
            Dim bounds As Rectangle = e.AffectedBounds

            'Principalement copié du code de .Net Reference Source.
            If TypeOf e.ToolStrip Is ToolStripDropDown Then
                'Paint the border for the window depending on whether or not flat menus are enabled.
                If SystemInformation.IsFlatMenuEnabled Then
                    bounds.Width -= 1
                    bounds.Height -= 1
                    e.Graphics.DrawRectangle(SystemPens.ControlDark, bounds)
                Else
                    ControlPaint.DrawBorder3D(e.Graphics, bounds, Border3DStyle.Raised)
                End If
            Else
                MyBase.OnRenderToolStripBorder(e)
            End If
        End Sub

        ''' <summary>
        ''' Retourne le Visual Style Element d'un menu item avec le state approprié.
        ''' </summary>
        ''' <param name="ItemSelected"></param>
        ''' <param name="ItemEnabled"></param>
        ''' <returns></returns>
        Private Function GetItemBackgroundVSElement(ItemSelected As Boolean, ItemEnabled As Boolean) As VisualStyleElement
            If ItemSelected Then
                If ItemEnabled Then
                    'Hot
                    Return VisualStyleElement.CreateElement(vsClass, 14, 2)
                Else
                    'DisabledHot
                    Return VisualStyleElement.CreateElement(vsClass, 14, 4)
                End If
            Else
                If ItemEnabled Then
                    'Normal
                    Return VisualStyleElement.CreateElement(vsClass, 14, 1)
                Else
                    'Disabled
                    Return VisualStyleElement.CreateElement(vsClass, 14, 3)
                End If
            End If
        End Function

        Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
            Dim item As ToolStripMenuItem = TryCast(e.Item, ToolStripMenuItem)
            Dim g As Graphics = e.Graphics

            If ToolStripManager.VisualStylesEnabled = False Then
                MyBase.OnRenderMenuItemBackground(e)
                Exit Sub
            End If


            If item IsNot Nothing Then
                'We create and setup the rectangle where we will draw. Mainly copied & pasted from .Net Reference Source.
                Dim fillRect As New Rectangle(Point.Empty, item.Size)
                If item.IsOnDropDown Then
                    ' VSWhidbey 518568: scoot in by 2 pixels when selected
                    fillRect.X += 2
                    'its already 1 away from the right edge
                    fillRect.Width -= 3
                End If

                'We create the visual style element
                Dim vsElement As VisualStyleElement = GetItemBackgroundVSElement(item.Selected, item.Enabled)

                'We check if the vs element is defined. If it isn't, we let MyBase handle the problem.
                If VisualStyleRenderer.IsElementDefined(vsElement) = False Then
                    MyBase.OnRenderMenuItemBackground(e)
                    Exit Sub
                End If

                'We initialize the visual style renderer and we draw the visual style.
                Dim vsRenderer As VisualStyleRenderer = New VisualStyleRenderer(vsElement)
                vsRenderer.DrawBackground(g, fillRect)
            End If
        End Sub

        Private Sub DrawClassicText(e As ToolStripItemTextRenderEventArgs, rect As Rectangle)
            Dim TextColor As Color
            If e.Item.Selected Then
                If e.Item.Enabled Then
                    'Hot
                    TextColor = SystemColors.HighlightText
                Else
                    'DisabledHot
                    TextColor = SystemColors.GrayText
                End If
            Else
                If e.Item.Enabled Then
                    'Normal
                    TextColor = e.Item.ForeColor
                Else
                    'Disabled
                    TextColor = SystemColors.GrayText
                End If
            End If
            TextRenderer.DrawText(e.Graphics, e.Text, e.Item.Font, rect, TextColor, TextFormatFlags.Left)
        End Sub

        Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
            'We owner draw the text even if visual styles are disabled cause the TextRectangle is vertically aligned at the top which is terrible if the item is taller than the default.

            'We only override in a situation where we know what we are doing : when drawing a popup menu text and when that text is horizontal. I just don't have enought knowledge to deal with the more complex situation!
            If e.ToolStrip.IsDropDown = False Or e.TextDirection <> ToolStripTextDirection.Horizontal Then
                MyBase.OnRenderItemText(e)
                Exit Sub
            End If


            'Creates a vertically aligned rectangle where the text will be drawn
            Dim yTextRect As Double = (e.Item.Height / 2) - (TextRenderer.MeasureText(e.Text, e.Item.Font).Height / 2) '+ 1
            Dim textRect As Rectangle = New Rectangle(New Point(e.TextRectangle.Location.X, yTextRect), e.TextRectangle.Size)

            'Does the drawing depending af the theme used.
            If ToolStripManager.VisualStylesEnabled = False Then
                DrawClassicText(e, textRect)
            Else
                'We create the visual style element
                Dim vsElement As VisualStyleElement = GetItemBackgroundVSElement(e.Item.Selected, e.Item.Enabled)

                'We check if the vs element is defined. If it isn't, we just draw the classic menu and we exit.
                If VisualStyleRenderer.IsElementDefined(vsElement) = False Then
                    DrawClassicText(e, textRect)
                    Exit Sub
                End If



                'We initialize the visual style renderer
                Dim foreVSRenderer As VisualStyleRenderer = New VisualStyleRenderer(vsElement)

                'Does the drawing depending if a Immersive theme is used or not.
                If boIsImmersive = False Then
                    'The visual style renderer can't draw the standard menu text for some reason so we manually draw the text with the visual style color.
                    TextRenderer.DrawText(e.Graphics, e.Text, e.Item.Font, textRect, foreVSRenderer.GetColor(ColorProperty.TextColor), e.TextFormat)
                Else
                    foreVSRenderer.DrawText(e.Graphics, textRect, e.Text, False, e.TextFormat)
                End If
            End If




            'e.Graphics.DrawRectangle(Pens.Blue, e.Item.ContentRectangle)
            'e.Graphics.DrawRectangle(Pens.Green, e.TextRectangle)
            'e.Graphics.DrawRectangle(Pens.Yellow, textRect)

        End Sub

        Private Function GetSubMenuArrowVSElement(pEnabled As Boolean) As VisualStyleElement
            If pEnabled Then
                Return VisualStyleElement.CreateElement(vsClass, 16, 1)
            Else
                Return VisualStyleElement.CreateElement(vsClass, 16, 2)
            End If
        End Function

        Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
            If ToolStripManager.VisualStylesEnabled = False Then
                MyBase.OnRenderArrow(e)
                Exit Sub
            End If

            'The standard context menu uses visual styles for its arrow. Immersive context menus use a font icon.
            If boIsImmersive = False Then
                Dim vsElement As VisualStyleElement = GetSubMenuArrowVSElement(e.Item.Enabled)
                If VisualStyleRenderer.IsElementDefined(vsElement) Then
                    'Initialize the visual style renderer
                    Dim arrowVSRenderer As VisualStyleRenderer = New VisualStyleRenderer(vsElement)
                    'Create a the appropriate rectangle for the arrow (the one that comes in the ToolStripArrowRenderEventArgs is too big!)
                    Dim arrowRect As Rectangle = New Rectangle(e.ArrowRectangle.Location, arrowVSRenderer.GetPartSize(e.Graphics, ThemeSizeType.True))
                    'Center the rectangle vertically
                    arrowRect.Y = e.ArrowRectangle.Y + (e.ArrowRectangle.Height - arrowRect.Height) / 2 + 1
                    'Draw the visual style
                    arrowVSRenderer.DrawBackground(e.Graphics, arrowRect)
                Else
                    'Draw classic arrow
                    MyBase.OnRenderArrow(e)
                    Exit Sub
                End If
            Else 'Btw, Immersive arrow does not support states.
                Dim arrowColor As Color
                'Determine the right color for the arrow rectangle.
                'We could also obtain the TextColor property from the visual style part, but Microsoft's own stupid implementation does not do that and we want to be as much faitful as possible to the real thing.
                If vsClass = stIMMERSIVE_DARK_VS_CLASS Then
                    arrowColor = Color.White
                Else
                    arrowColor = Color.Black
                End If
                TextRenderer.DrawText(e.Graphics, "", symbolFont, e.ArrowRectangle, arrowColor)

            End If
        End Sub

        Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)

            'Dim b As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(e.AffectedBounds.Width, 0), Color.Red, Color.Blue)
            'e.Graphics.FillRectangle(b, e.AffectedBounds)

            'Vite fait. À arranger. Surtout pour Immersive qui sont peut-être pas un cas particulier.

            'We only need to draw the gutter background for the standard visually styled menu item.
            If Not ToolStripManager.VisualStylesEnabled Or boIsImmersive Then
                MyBase.OnRenderImageMargin(e)
                Exit Sub
            End If

            Dim vsElement As VisualStyleElement = VisualStyleElement.CreateElement(vsClass, 13, 0)

            If Not VisualStyleRenderer.IsElementDefined(vsElement) Then
                MyBase.OnRenderImageMargin(e)
                Exit Sub
            End If

            'Initialize the visual style renderer
            Dim popupBackVSRenderer As VisualStyleRenderer = New VisualStyleRenderer(vsElement)
            'Draw the visual style
            popupBackVSRenderer.DrawBackground(e.Graphics, e.AffectedBounds)
        End Sub
    End Class
End Namespace