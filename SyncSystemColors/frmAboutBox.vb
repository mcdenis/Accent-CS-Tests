Option Strict On

Imports System.Drawing.Drawing2D

Public NotInheritable Class frmAboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductNameAndVersion.Text = String.Format("{0} {1}", My.Application.Info.ProductName, My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.TextBoxDescription.Text = My.Application.Info.Description

        '---

        'Configure the LinkLabels
        lbtWebsite.Links(0).LinkData = My.Settings.ExternalResources_ProjectURL
        lbtLicense.Links.Add(37, 11, Application.StartupPath + "\License.rtf")
    End Sub

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub lblLogo_Paint(sender As Object, e As PaintEventArgs) Handles lblLogo.Paint
        If Not SystemInformation.HighContrast Then
            Dim rect As Rectangle = lblLogo.ClientRectangle
            Using b As New LinearGradientBrush(rect, Color.Transparent, SystemColors.ControlDark, LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, rect)
            End Using
        End If
    End Sub

    Private Sub Generic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbtWebsite.LinkClicked, lbtLicense.LinkClicked
        Dim link As LinkLabel.Link = e.Link
        Dim stPath As String = DirectCast(link.LinkData, String)

        'Sets the visited link as visited.
        link.Visited = True

        'Opens the URL with the default browser.
        Try
            Process.Start(stPath)
        Catch ex As Exception
            MsgBox(stPath + Environment.NewLine + Environment.NewLine + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
