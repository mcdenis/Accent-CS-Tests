Option Strict On

Imports System.ComponentModel
Public Class ucDialogCommandPanel

    'Properties
    'Redirect the buttons events as the User Control's events.
    <Category("Behavior"), DefaultValue(True)>
    Public Property OKButtonVisible As Boolean
        Get
            Return btnOK.Visible
        End Get
        Set(value As Boolean)
            btnOK.Visible = value
        End Set
    End Property

    <Category("Behavior"), DefaultValue(True)>
    Public Property CancelButtonVisible As Boolean
        Get
            Return btnCancel.Visible
        End Get
        Set(value As Boolean)
            btnCancel.Visible = value
        End Set
    End Property

    <Category("Appearance"), DefaultValue(BorderStyle.Fixed3D)>
    Public Property SeparatorStyle As BorderStyle
        Get
            Return Label1.BorderStyle
        End Get
        Set(value As BorderStyle)
            Label1.BorderStyle = value

            'Change la hauteur du séparateur selon le style pcq hauteur de 2 laid avec une simple ligne,
            'mais hauteur de 1 insuffisant pour une bordure 3D.
            Select Case value
                Case BorderStyle.FixedSingle
                    Label1.Height = 1
                Case BorderStyle.Fixed3D
                    Label1.Height = 2
            End Select
        End Set
    End Property

    'Events
    'Redirect the buttons' click events as the User Control's events.
    <Category("Action")>
    Public Event OKButtonClick As EventHandler
    <Category("Action")>
    Public Event CancelButtonClick As EventHandler

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        RaiseEvent OKButtonClick(sender, e)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent CancelButtonClick(sender, e)
    End Sub

    'Configure the parent form to use the User Control's button as its dialog buttons.
    Private Sub ucDialogCommandPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TypeOf Me.TopLevelControl Is Form Then
            DirectCast(Me.TopLevelControl, Form).AcceptButton = btnOK
            DirectCast(Me.TopLevelControl, Form).CancelButton = btnCancel
        End If
    End Sub
End Class
