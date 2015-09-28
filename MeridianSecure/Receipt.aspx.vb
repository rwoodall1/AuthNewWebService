Imports Microsoft.VisualBasic
Imports System.Data

Imports System.Net.Mail
Imports System.IO

Imports System.Net
Partial Class Receipt
    Inherits EmailReadyPage
    Private okToSendMarkup As Boolean = False
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        If okToSendMarkup Then
            'EmailReceipt()
        End If


        MyBase.Render(writer)
        ' ALTERNATE OPTION:
        ' Remove EmailReceipt(); from above, and instead do: okToSendMarkup = True
        ' Then, in the Render() method, the markup will be generated and emailed
        ' If this alternate option is used, you do not need to disable event validation since
        ' the control is being rendered during the Render stage. Therefore, event validation
        ' can proceed as expected.
    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            If CheckIfEmailed() Then

            Else
                Session.Clear()
                EmailReceipt()

            End If
        End If
    End Sub

    Protected Sub DetailsView2_DataBound(sender As Object, e As System.EventArgs) Handles DetailsView2.DataBound
        Dim a As String = DetailsView2.DataKey("orderid")
        Label4.Text = "Your order# is " & DetailsView2.DataKey("orderid")
    End Sub
    Sub EmailReceipt()
        'Dim cart As Cart = Session("Cart")
        'Save the position of the DataGrid in the myForm Controls collection
        Dim SB As New StringBuilder()
        Dim SW As New StringWriter(SB)
        Dim htmlTW As New HtmlTextWriter(SW)
        gv1.AllowPaging = False
        gv1.RenderControl(htmlTW)

        Dim thegrid As String = SB.ToString
        SB.Clear()

        DetailsView1.RenderControl(htmlTW)
        Dim thefirstdetailview As String = SB.ToString
        SB.Clear()
        DetailsView2.RenderControl(htmlTW)
        Dim theseconddetailview As String = SB.ToString
        SB.Clear()
        FormView2.RenderControl(htmlTW)
        Dim thesecondformview As String = SB.ToString
        'Have to get totals for email. Totals in formview use div classes that are not available to html email
        Dim TextBox17 As TextBox
        Dim TextBox1 As TextBox
        Dim txtsubtotal As TextBox
        Dim txtshipping As TextBox
        Dim txttotal As TextBox
        Try
            TextBox17 = FormView2.FindControl("TextBox17") 'Notes
            TextBox1 = FormView2.FindControl("TextBox1") 'transid
            txtsubtotal = FormView2.FindControl("txtsubtotal")
            txtshipping = FormView2.FindControl("txtshipping")
            txttotal = FormView2.FindControl("txttotal")
        Catch ex As Exception
            Return
        End Try


        'Now, send the email
        'Create an instance of the MailMessage class
        Dim objMM As New MailMessage()
        Dim tomail As String = ""
        Dim smtpclient As String = ""
        Dim cpassword As String = ""
        Dim cuser As String = ""
        If Directory.Exists("F:\IsDev") Then 'set dev settings
            'smtpclient = "cmain1.wdfm.net" '"mail.woodalldevelopment.com"
            'cuser = "rwoodall@wdfm.net"
            'cpassword = "Briggitte1"
            tomail = "wdalfarm@woodalldevelopment.com"
        Else 'live
            'SmtpClient = "192.168.1.245"
            'cuser = "authnet@memorybook.com"
            'cpassword = "authnet"
            Dim email As String = DetailsView1.Rows(8).Cells(1).Text

            tomail = Trim(email)


        End If

        smtpclient = ConfigurationManager.AppSettings("smtpserver")
        cuser = ConfigurationManager.AppSettings("smtpuser")
        cpassword = ConfigurationManager.AppSettings("smtppassword")
        'Set the properties
        objMM.From = New MailAddress(ConfigurationManager.AppSettings("FromAddrmer"), ConfigurationManager.AppSettings("FromNamemer"))

        Try
            objMM.To.Add(tomail) 'customer address if address bad try statement in send will catch
            If Not IsNothing(Session("PO")) Then
                objMM.Bcc.Add("sales@meridianplanners.com")
                objMM.Bcc.Add("hedwards@printlynx.com")
            Else
                objMM.Bcc.Add("sales@meridianplanners.com")

                objMM.Bcc.Add("hedwards@printlynx.com")
                'objMM.Bcc.Add("warehouse@meridianplanners.com")
            End If
        Catch ex As Exception

        End Try
        Dim ddate As String = DetailsView2.Rows(9).Cells(1).Text

        'Send the email in text format
        objMM.IsBodyHtml = True

        'Set the subject
        objMM.Subject = "Meridian Planners Order Confirmation  " & Now

        objMM.Body = "<table class='style1' width=840px align='center'> <tr><td align='center' width=420px colspan='2' style='font-weight: bolder'>Thank you! Your order# is " & DetailsView2.DataKey("orderid") _
         & "<br /> Your order was placed on " & ddate & "</td></tr> <tr><td align='center' style='font-weight: bolder'>Billing Information</td><td align='center' width=420px style='font-weight: bold'>Shipping Information</td></tr>" _
         & "<tr><td width=420px >" & thefirstdetailview & "</td><td width=420px>" & theseconddetailview & "</td></tr><tr><td colspan='2'>" _
         & thegrid & "</td> </tr><tr><td><td><tr> <tr><td align='center' colspan='2'>" _
         & "<table style='width:835px;'><tr><td style='text-align:right; vertical-align:top;width:125px'  rowspan='2'>Notes:</td><td" _
         & " rowspan=2 style='vertical-align:Top';width:230px'>" & TextBox17.Text & "</td>" _
         & "<td style='text-align: right;width:180'>Subtotal:</td><td style='width:80'>" & txtsubtotal.Text & "</td></tr>" _
          & " <tr><td style='text-align: right'>Shipping:</td><td>" & txtshipping.Text & "</td></tr>" _
        & "<tr><td class='auto-style2' style='text-align: right'>Transaction ID:</td><td >" & TextBox1.Text & "</td>" _
        & "<td  style='text-align: right'>Total:</td>" _
         & "<td >" & txttotal.Text & "</td></tr></table>" _
         & "</td></tr><tr><td align='center' colspan='2'><br/><br/>" _
         & " Thank you for shopping at Meridian Planners. <br/> Visit us again at <a href='http://www.meridianplanners.com/ ' >www.meridianplanners.com/. </a></td><tr></table>"

        Dim smtp As New SmtpClient(smtpclient)
        smtp.Credentials = New NetworkCredential(cuser, cpassword)

        Try
            'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
            smtp.Send(objMM)
            SetCsEmailTrue()
        Catch ex As Exception
            MsgBox1.Show("Email Error", "Your confirmation email was not sent because of the following error:" & ex.Message & "Your order has been received and will be processed. No further action is needed.", Nothing, New EO.Web.MsgBoxButton("OK"))
            Dim objMM1 As New MailMessage
            Dim orderid As String = Request.QueryString("orderid")
            smtpclient = ConfigurationManager.AppSettings("smtpserver")
            cuser = ConfigurationManager.AppSettings("smtpuser")
            cpassword = ConfigurationManager.AppSettings("smtppassword")
            Dim smtperror As New SmtpClient(smtpclient)
            smtperror.Credentials = New NetworkCredential(cuser, cpassword)
            objMM1.From = New MailAddress(ConfigurationManager.AppSettings("FromAddr"), ConfigurationManager.AppSettings("FromName"))
            objMM1.To.Add("sales@meridianplanners.comm")
            'objMM1.CC.Add("")
            objMM1.Subject = "Meridian Planners Order Email Error Order Id:" & orderid
            objMM1.IsBodyHtml = True
            objMM1.Body = "The customer did not receive an email because of the following error:" & ex.Message
            Try
                smtperror.Send(objMM1)
            Catch ex2 As Exception

            End Try


        Finally

        End Try



    End Sub
    Private Function CheckIfEmailed() As Boolean
        Dim dvSql As New DataView
        Dim drvSql As DataRowView
        Dim a As Integer
        Dim sstring As String = dsorder.SelectCommand
        Dim retval As Boolean = False
        dsorder.SelectCommand = "SELECT distinct csemailed FROM orders  WHERE orderid=@orderid;"
        dsorder.SelectParameters.Clear()
        dsorder.SelectParameters.Add("@orderid", Request.QueryString("orderid"))
        Try
            dvSql = CType(Me.dsorder.Select(DataSourceSelectArguments.Empty), Data.DataView)
            For Each drvSql In dvSql 'only one record
                a = drvSql("csemailed")
                If a = 0 Then
                    retval = False
                ElseIf a = 1 Then
                    retval = True
                End If
            Next
        Catch ex As Exception

        End Try
        dsorder.SelectCommand = sstring
        Return retval
    End Function
    Protected Sub SetCsEmailTrue()
        dsOrder.UpdateCommand = "update orders set csemailed=1 where orderid=@orderid;"
        dsOrder.UpdateParameters.Clear()
        dsOrder.UpdateParameters.Add("@orderid", Request.QueryString("orderid"))
        Try
            dsOrder.Update()

        Catch ex As Exception

        End Try

    End Sub

End Class
