Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Namespace MyControls

    'Credit: http://stackoverflow.com/a/10491958

    ''' <summary>
    ''' Standard button with support for the CommandLink style.
    ''' </summary>
    Public Class ButtonEx : Inherits Button

        Private _commandLink As Boolean
        Private _commandLinkNote As String

        Public Sub New()
            MyBase.New()
            'Set default property values on the base class to avoid the Obsolete warning
            MyBase.FlatStyle = FlatStyle.System
        End Sub

        <Category("Appearance")>
        <DefaultValue(False)>
        <Description("Specifies this button should use the command link style. " &
                 "(Only applies under Windows Vista and later.)")>
        Public Property CommandLink As Boolean
            Get
                Return _commandLink
            End Get
            Set(ByVal value As Boolean)
                If _commandLink <> value Then
                    _commandLink = value
                    Me.UpdateCommandLink()
                End If
            End Set
        End Property

        <Category("Appearance")>
        <DefaultValue("")>
        <Description("Sets the description text for a command link button. " &
                 "(Only applies under Windows Vista and later.)")>
        Public Property CommandLinkNote As String
            Get
                Return _commandLinkNote
            End Get
            Set(value As String)
                If _commandLinkNote <> value Then
                    _commandLinkNote = value
                    Me.UpdateCommandLink()
                End If
            End Set
        End Property

        <Browsable(False)> <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        <Obsolete("This property is not supported on the ButtonEx control.")>
        <DefaultValue(GetType(FlatStyle), "System")>
        Public Shadows Property FlatStyle As FlatStyle
            'Set the default flat style to "System", and hide this property because
            'none of the custom properties will work without it set to "System"
            Get
                Return MyBase.FlatStyle
            End Get
            Set(ByVal value As FlatStyle)
                MyBase.FlatStyle = value
            End Set
        End Property

#Region "P/Invoke Stuff"
        Private Const BS_COMMANDLINK As Integer = &HE
        Private Const BCM_SETNOTE As Integer = &H1609

        <DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=False)>
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr,
                                        <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As IntPtr
        End Function

        Private Sub UpdateCommandLink()
            Me.RecreateHandle()
            SendMessage(Me.Handle, BCM_SETNOTE, IntPtr.Zero, _commandLinkNote)
        End Sub

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams

                If Me.CommandLink Then
                    cp.Style = cp.Style Or BS_COMMANDLINK
                End If

                Return cp
            End Get
        End Property
#End Region

    End Class
End Namespace