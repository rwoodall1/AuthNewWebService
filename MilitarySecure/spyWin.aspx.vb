
Partial Class spyWin
    Inherits System.Web.UI.Page

    
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim script As String = "<script type='text/javascript' " _
           & "language= 'javascript'> " _
           & " function check_opener() { " _
           & " if (opener && opener.closed){ " _
           & " parent.opener=null; " _
           & " parent.close(); " _
           & " } " _
           & " else{ " _
           & " parent.opener=null; " _
           & " parent.close(); " _
           & " } " _
           & "} " _
           & " onload = function() { " _
           & " self.blur(); " _
          & " setTimeout('check_opener()',0); " _
           & " } " _
             & " </script>"
        Me.Controls.Add(New LiteralControl(script))
        Try
            If Session("Refresh") <> "TRUE" Then


                If Session("ordergood") = "False" Then
                    dsorder.Delete()
                    Session.Abandon()
                End If
            Else 'session was true now change back
                Session("Refresh") = "FALSE"
            End If
        Catch ex As Exception

        End Try


    End Sub
   
End Class
