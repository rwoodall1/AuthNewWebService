
Partial Class _Error
    Inherits System.Web.UI.Page

    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session.Clear()
    End Sub
End Class
