Imports System.ComponentModel

Namespace MyControls

    ''' <summary>
    ''' Standard context menu with improved touch support.
    ''' Note: Don't change the menu item padding. It will be overriden.
    ''' </summary>
    Public Class ContextMenuSystemStrip
        Inherits ContextMenuStrip

        Private Const inTOUCH_ADDITIONNAL_PADDING As Integer = 10
        Private Const inNORMAL_BASE_PADDING As Integer = 1
        Private Const inTASKBAR_BASE_PADDING As Integer = 6

        Private inBasePadding As Integer = inNORMAL_BASE_PADDING
        Private boCurrentViewIsTouch As Boolean
        Private boInitialSizeApplied As Boolean = False

        Private _isTaskbarMenu As Boolean = False
        ''' <summary>
        ''' True means that the menu is attached to a control on the Windows desktop Taskbar.
        ''' In practice, this causes the menu items to be taller on Windows TH2 and above.
        ''' </summary>
        ''' <returns></returns>
        <DefaultValue(False)>
        Public Property IsTaskbarMenu As Boolean
            Get
                Return _isTaskbarMenu
            End Get
            Set(value As Boolean)
                If value <> _isTaskbarMenu Then
                    Dim os As OperatingSystem = Environment.OSVersion
                    If os.Version.Build > 10532 And value = True Then
                        inBasePadding = inTASKBAR_BASE_PADDING
                    Else
                        inBasePadding = inNORMAL_BASE_PADDING
                    End If

                    _isTaskbarMenu = value
                End If
            End Set
        End Property



        Protected Overrides Sub OnOpened(e As EventArgs)
            If TouchDetect.GetMouseEventSource() <> TouchDetect.MouseEventSource.Mouse Then
                'Calculates and creates the padding to apply
                Dim inPad As Integer = inBasePadding + inTOUCH_ADDITIONNAL_PADDING
                Dim pad As New Padding(0)
                pad.Top = inPad
                pad.Bottom = inPad

                'Applies the padding to all menu items
                For Each mi As ToolStripItem In Items
                    mi.Padding = pad
                Next
                '
                boCurrentViewIsTouch = True

            ElseIf boInitialSizeApplied = False Then
                'Applies the initial base padding if it has not been applied yet.
                'Creates the padding to apply
                Dim pad As New Padding(0)
                pad.Top = inBasePadding
                pad.Bottom = inBasePadding

                'Applies the padding to all menu items
                For Each mi As ToolStripItem In Items
                    mi.Padding = pad
                Next
                '
                boInitialSizeApplied = True
            End If

            MyBase.OnOpened(e)
        End Sub

        Protected Overrides Sub OnClosed(e As ToolStripDropDownClosedEventArgs)
            MyBase.OnClosed(e)

            If boCurrentViewIsTouch Then
                For Each mi As ToolStripItem In Items
                    mi.Padding = New Padding(inBasePadding)
                Next

                boCurrentViewIsTouch = False
            End If
        End Sub
    End Class
End Namespace