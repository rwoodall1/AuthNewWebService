Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Net.Mail
Imports System.Net
Imports MySql.Data.MySqlClient
Imports AuthorizeNet
Imports System.IO
Partial Class MilPayment
    Inherits System.Web.UI.Page
    Dim retval As Boolean = True

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0")
        Page.MaintainScrollPositionOnPostBack = True
        LoadLic()
       

        If Not IsPostBack Then
            Session.Add("ordergood", False)
            Session.Add("Company", "MBC")
            ' Dim orderid As String = Request.QueryString("orderid")
            Dim orderid As String = "9062"
            Session.Add("orderid", orderid)

            Dim dvSql As New DataView
            Dim drvSql As DataRowView
            Dim emailaddress As String = ""
            Dim itemtotal As Decimal = 0
            Dim schinvoicenumber As String = ""
            Dim schcode As String = ""
            Dim schname As String = ""
            dsorder.SelectCommand = "SELECT distinct schcode,schname,schinvoicenumber,emailaddress,sum(itemtotal) as itemtotal FROM `orders` o where orderid=" & orderid & ";"
            Try
                dvSql = CType(Me.dsorder.Select(DataSourceSelectArguments.Empty), Data.DataView)
                For Each drvSql In dvSql 'should only be one record
                    schcode = drvSql("schcode")
                    schname = drvSql("schname")
                    schinvoicenumber = drvSql("schinvoicenumber").ToString
                    emailaddress = drvSql("EmailAddress")
                    itemtotal = drvSql("itemtotal")
                Next
                lblamount.Text = itemtotal.ToString

                lblemailaddress.Text = emailaddress
                lblorderid.Text = orderid
                hfschcode.Value = schcode
                hfschinvoicenumber.Value = schinvoicenumber
            Catch ex As Exception
                Response.Redirect("error.aspx")
            End Try

        End If

    End Sub

    Protected Sub rbpaytype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbpaytype.SelectedIndexChanged
        If rbpaytype.SelectedValue = "CC" Then
            CCPanel.Visible = True
            ECPanel.Visible = False
            BlankFields("CC")
            hfpaytype.Value = "CC"
        Else
            hfpaytype.Value = "EC"
            CCPanel.Visible = False
            ECPanel.Visible = True
            BlankFields("EC")
        End If
    End Sub
    Private Sub BlankFields(paytype As String)
        If paytype = "CC" Then
            x_card_num.Text = ""
            x_card_code.Text = ""
            x_first_name.Text = ""
            x_last_name.Text = ""
        Else
            x_bank_acct_name.Text = ""
            x_bank_aba_code.Text = ""
            x_bank_acct_num.Text = ""

            x_bank_name.Text = ""
        End If
    End Sub
    
    Private Sub UpdatePayment(ByVal transid As String, ByVal authcode As String, ByVal ccnum As String)
        Dim connection1 As New MySqlConnection(dsorder.ConnectionString)

        connection1.Open()

        Dim cmd As MySqlCommand = connection1.CreateCommand()


        Dim commandtext As String = "insert into payment (orderid,custemail,ddate,poamt,paytype,transid,authcode,ccnum,invno,schcode,parentpay)" _
                    & "values(@orderid,@custemail,@ddate,@poamt,@paytype,@transid,@authcode,@ccnum,@invno,@schcode,1);"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@orderid", lblorderid.Text)
        cmd.Parameters.AddWithValue("@custemail", lblemailaddress.Text)
        cmd.Parameters.AddWithValue("@ddate", Now)
        cmd.Parameters.AddWithValue("@poamt", lblamount.Text)
        cmd.Parameters.AddWithValue("@paytype", hfpaytype.Value)
        cmd.Parameters.AddWithValue("@transid", transid)
        cmd.Parameters.AddWithValue("@authcode", authcode)
        cmd.Parameters.AddWithValue("@ccnum", ccnum)
        cmd.Parameters.AddWithValue("@invno", hfschinvoicenumber.Value)
        cmd.Parameters.AddWithValue("@schcode", hfschcode.Value)
        cmd.CommandText = commandtext

        Try
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            'send email


            Dim objMM As New MailMessage()
            Dim tomail As String = ""
            Dim smtpclient As String = ""
            Dim cpassword As String = ""
            Dim cuser As String = ""

            tomail = "randy@woodalldevelopment.com"


            smtpclient = ConfigurationManager.AppSettings("smtpserver")
            cuser = ConfigurationManager.AppSettings("smtpuser")
            cpassword = ConfigurationManager.AppSettings("smtppassword")
            'Set the properties
            objMM.From = New MailAddress("authnet@memorybook.com", "Developer")
            'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddr"))
            Try
                objMM.To.Add("randy@woodalldevelopment.com")
            Catch ex1 As Exception

            End Try


            objMM.IsBodyHtml = True

            'Set the subject
            objMM.Subject = "Update Error"

            objMM.Body = "There was an error inserting the following fields for order payment " & lblorderid.Text & "</br> Pay Date=" & Now.ToString _
                & "</br> Amount=" & lblamount.Text & "</br> Pay Type=CC </br> TransId=" & transid & "</br> AuthCode=" & authcode & "</br> School Invoice No.=" & hfschinvoicenumber.Value _
                & "</br> Credit Card Num=" & ccnum & "</br> Schcode=" & hfschcode.Value

            Dim smtp As New SmtpClient(smtpclient)
            smtp.Credentials = New NetworkCredential(cuser, cpassword)

            Try
                'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
                smtp.Send(objMM)
            Catch ex2 As Exception

            Finally

            End Try

        End Try

    End Sub
    Private Sub DeleteOrder()
        Dim connection1 As New MySqlConnection(dsorder.ConnectionString)
        connection1.Open()

        Dim cmd As MySqlCommand = connection1.CreateCommand()


        Dim commandtext As String = "DELETE FROM `orders`WHERE orderid=" & lblorderid.Text & ";"

        cmd.CommandText = commandtext

        Try
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            'send email

        End Try
    End Sub
    Protected Sub MsgBox1_ButtonClick(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles MsgBox1.ButtonClick

        If e.CommandName = "no" Then

            DeleteOrder()

            Response.Redirect("http://www.militaryyearbookprinting.com/index.html")
        End If
    End Sub
    Protected Sub ecsubmit_Click(sender As Object, e As EventArgs)
        Page.Validate()
        Dim someScript1 As String = "alertMe"
        If Page.IsValid = False Then
            'turns off overlay that was startd with onclient click
            If (Not ClientScript.IsStartupScriptRegistered(Me.GetType(), someScript1)) Then
                ClientScript.RegisterStartupScript(Me.GetType(), someScript1, "<script 'javascript'>javascript:void(0)</script>")
            End If

        Else
            If IsNothing(Session("numtrys")) Then
                Session.Add("numtrys", 1)
            Else
                Session("numtrys") = Session("numtrys") + 1
            End If
            Dim orderid As Integer = Session("orderid")

            'live_________________________________________________________________________________________________
            'Dim submission As New payportal.AuthorizenetSubmission
            'Dim authresponse As New payportal.Response
            'Dim info As New payportal.AuthReq
            Dim submission As New submission
            Dim authresponse As New Response
            Dim info As New AuthReq
            ''_______________________________________________________________________________________________________

            Dim total As String = lblamount.Text
            Dim emailaddress As String = lblemailaddress.Text

            If CDec(total) > 0 Then
                'echeck info and submission
                info.bankname = x_bank_name.Text
                info.bankcustomername = x_bank_acct_name.Text
                info.bankaccounttype = x_bank_acct_type.Text
                info.bankaccountnumber = x_bank_acct_num.Text
                info.bankabacode = x_bank_aba_code.Text
                info.CardFname = x_first_name.Text
                info.CardLname = x_last_name.Text
                info.OrderId = lblorderid.Text
                info.Custid = hfschcode.Value
                info.Amount = total
                info.Email = emailaddress
                info.Method = "ECHECK"
                info.echecktype = "WEB"
                info.SiteName = "Mbc"
                authresponse = submission.Capture(info)

                If authresponse.Approved Then
                    Session("ordergood") = "TRUE"
                    'Session.Add("transid", authresponse.TransId)
                    'Session.Add("authcode", authresponse.AuthCode)
                    'Session.Add("ccnum", x_card_num.Text.Substring(x_card_num.Text.Length - 4))
                    UpdatePayment(authresponse.TransId, authresponse.AuthCode, "")
                    Dim time As TimeSpan = Date.Now.TimeOfDay
                    'type determine if email is sent when receipt page is accessed
                    Response.Redirect("http://www.militaryyearbookprinting.com/online-pay/receipt.aspx?orderid=" & lblorderid.Text & "&type=1&secval=" & time.ToString)

                Else 'card not approved
                    Session("ordergood") = "FALSE"
                    MsgBox1.Show("Check Submission Error", "Your bank returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))
                    If Session("numtrys") = 3 Then
                        'they have had 3 tries call it  quits
                        MsgBox1.Show("Check Submission Error", "Your bank returned the following error:" & authresponse.Message & "Your order has not been processed. Please contact your Credit Card Company for help.", Nothing, New EO.Web.MsgBoxButton("OK"))
                        DeleteOrder()
                        Response.Redirect("http://www.militaryyearbookprinting.com/index.html")

                    Else

                        MsgBox1.Show("Check Submission Error", "Your bank returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))

                    End If


                End If
            Else 'total not greater than 0

            End If 'total greater than 0
        End If 'pagevalidate
    End Sub
    Private Sub LoadLic()
        EO.Web.Runtime.AddLicense( _
         "b/8goVnt6QMe6KjlwbPcsGenprHavUaBpLHLn1mXpLHn4J3bpAUk7560puQX" + _
         "6J3c0fYZ9FuX+vYd8qLm8s7NsGqltLPLrneEjrHLn1mXpLHLu5rb6LEf+Knc" + _
         "wbP/4JvK+AMU71uX+vYd8qLm8s7NsGqltLPLrneEjrHLn1mXpLHLu5rb6LEf" + _
         "+KncwbP/8Z7c2voQ9luX+vYd8qLm8s7NsGqltLPLrneEjrHLn1mXpLHLu5rb" + _
         "6LEf+KncwbP49KXr7eEM5p6ZpAcQ8azg8//ooWqossHNn2i1kZvLn1mXpLHL" + _
         "n3XY6PXL87Ln6c7Nwprj6f8P4KuZpAcQ8azg8//ooWqossHNn2i1kZvLn1mX" + _
         "pLHLn3XY6PXL87Ln6c7Nwprj8PMM4qSZpAcQ8azg8//ooWqossHNn2i1kZvL" + _
         "n1mXpLHLn3XY6PXL87Ln6c7NwIO43OYb66jY6PYdoVnt6QMe6KjlwbPcsGen" + _
         "prHavUaBpLHLn1mXpLHn4J3bpAUk7560ptUU4KXm67PL9Z7p9/oa7XaZtcLZ" + _
         "r1uXs8+4iVmXpLHLn1mXwPIP41nr/QEQvFvK9P0U863c9rPL9Z7p9/oa7XaZ" + _
         "tcLZr1uXs8+4iVmXpLHLn1mXwPIP41nr/QEQvFvE5QQW5J286PofoVnt6QMe" + _
         "6KjlwbPcsGenprHavUaBpLHLn1mXpLHn4J3bpAUk7560ptgd6J2ZpAcQ8azg" + _
         "8//ooWqossHNn2i1kZvLn1mXpLHLn3XY6PXL87Ln6c7Nwqjj8wP76Jzi6QPN" + _
         "n6/c9gQU7qe0psLcrWmZpMDpjEOXpLHLn1mXpM0M452X+Aob5HaZ1wEQ66W6" + _
         "7PYO6p7pprEh5Kvq7QAZvFuotb/boVmmwp61n1mXpLHLn1mz5fUPn63w9Pbo" + _
         "oX7b7QUa8VuX+vYd8qLm8s7NsGqltLPLrneEjrHLn1mXpLHLu5rb6LEf+Knc" + _
         "wbP07Jre6esa7qaZpAcQ8azg8//ooWqossHNn2i1kZvLn1mXpLHLn3XY6PXL" + _
         "87Ln6c7Nw6ju8v0a4J3c9rPL9Z7p9/oa7XaZtcLZr1uXs8+4iVmXpLHLn1mX" + _
         "wPIP41nr/QEQvFu98AAM857pprEh5Kvq7QAZvFuotb/boVmmwp61n1mXpLHL" + _
         "n1mz5fUPn63w9PbooYzj7fUQoVnt6QMe6KjlwbPcsGenprHavUaBpLHLn1mX" + _
         "pLHn4J3bpAUk7560ptcX+Kjs+LPL9Z7p9/oa7XaZtcLZr1uXs8+4iVmXpLHL" + _
         "n1mXwPIP41nr/QEQvFu86Pof4Jvj6d0M4Z7jprEh5Kvq7QAZvFuotb/boVmm" + _
         "wp61n1mXpLHLn1mz5fUPn63w9PbooYXg9wXt7rGZpAcQ8azg8//ooWqossHN" + _
         "n2i1kZvLn1mXpLHLn3XY6PXL87Ln6c7Nwqjk5gDt7rGZpAcQ8azg8//ooWqo" + _
         "ssHNn2i1kZvLn1mXpLHLn3XY6PXL87Ln6c7Nwprn+PQT4FuX+vYd8qLm8s7N" + _
         "sGqltLPLrneEjrHLn1mXpLHLu5rb6LEf+KncwbP/7qjj2PoboVnt6QMe6Kjl" + _
         "wbPcsGenprHavUaBpLHLn1mXpLHn4J3bpAUk7560puMM86Ll67PL9Z7p9/oa" + _
         "7XaZtcLZr1uXs8+4iVmXpLHLn1mXwPIP41nr/QEQvFvK8PoP5KuZpAcQ8azg" + _
         "8//ooWqossHNn2i1kZvLn1mXwMAM66Xm+8+4iVmXpLHn7qvb6QP07Z/mpPUM" + _
         "8560psPasXCmtsHcsluX+vYd8qLm8s7NsGmZpMDpjEOXpLHLu6zg6/8M867p" + _
         "6c8a2HDs8bzi56PFt9wU12nQ0QAl4pvewc7nrqzg6/8M867p6c+4iXWm8PoO" + _
         "5Kfq6c+4iXXj7fQQ7azcwp61n1mXpM0X6Jzc8gQQyJ21ucHfsW+vtMjgtnWm" + _
         "8PoO5Kfq6doPvUaBpLHLn3Xj7fQQ7azc6c/nrqXg5/YZ8p7cwp61n1mXpM0M" + _
         "66Xm+8+4iVmXpLHLn1mXwPIP41nr/QEQvFvE6Q==")
    End Sub

    Protected Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload
        If IsPostBack Then
            Session.Add("Refresh", "TRUE")
        Else
            Session.Add("Refresh", "FALSE")
        End If

    End Sub
    
    
    Protected Sub ccsubmit_Click1(sender As Object, e As System.EventArgs) Handles ccsubmit.Click
       
        Page.Validate()
        Dim someScript1 As String = "alertMe"
        If Page.IsValid = False Then
            'turns off overlay that was startd with onclient click
            If (Not ClientScript.IsStartupScriptRegistered(Me.GetType(), someScript1)) Then
                ClientScript.RegisterStartupScript(Me.GetType(), someScript1, "<script 'javascript'>javascript:void(0)</script>")
            End If

        Else


            If IsNothing(Session("numtrys")) Then
                Session.Add("numtrys", 1)
            Else
                Session("numtrys") = Session("numtrys") + 1
            End If


            'live_________________________________________________________________________________________________
            'Dim submission As New payportal.AuthorizenetSubmission
            'Dim authresponse As New payportal.Response
            'Dim info As New payportal.AuthReq
            Dim submission As New submission
            Dim authresponse As New Response
            Dim info As New AuthReq
            ''_______________________________________________________________________________________________________

            Dim total As String = lblamount.Text
            Dim emailaddress As String = lblemailaddress.Text

            If CDec(total) > 0 Then
                'cc info and submission
                info.CardNum = x_card_num.Text
                info.SecurityCode = x_card_code.Text
                info.CardFname = x_first_name.Text
                info.CardLname = x_last_name.Text
                info.ExpDate = ddlmonth.SelectedValue & "/" & ddlyear.SelectedValue
                info.OrderId = lblorderid.Text
                info.Custid = hfschcode.Value
                info.Amount = total
                info.Email = emailaddress
                info.Method = hfpaytype.Value
                info.TransType = "AUTH_CAPTURE"
                info.SiteName = "Mbc"

                authresponse = submission.Capture(info)

                If authresponse.Approved Then
                    Session("ordergood") = "TRUE"
                    'Session.Add("transid", authresponse.TransId)
                    'Session.Add("authcode", authresponse.AuthCode)
                    'Session.Add("ccnum", x_card_num.Text.Substring(x_card_num.Text.Length - 4))
                    UpdatePayment(authresponse.TransId, authresponse.AuthCode, x_card_num.Text.Substring(x_card_num.Text.Length - 4))
                    Dim time As TimeSpan = Date.Now.TimeOfDay
                    'type determine if email is sent when receipt page is accessed
                    Session.Abandon()
                    Response.Redirect("http://www.militaryyearbookprinting.com/online-pay/receipt.aspx?orderid=" & lblorderid.Text & "&type=1&secval=" & time.ToString)

                Else 'card not approved
                    Session("ordergood") = "FALSE"


                    MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))
                    If Session("numtrys") = 3 Then
                        'they have had 3 tries call it  quits
                        MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & authresponse.Message & "Your order has not been processed. Please contact your Credit Card Company for help.", Nothing, New EO.Web.MsgBoxButton("OK"))
                        DeleteOrder()
                        Response.Redirect("http://www.militaryyearbookprinting.com/index.html")

                    Else

                        MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))

                    End If


                End If
            Else 'total not greater than 0

            End If 'total greater than 0
        End If 'is valid
    End Sub

    
End Class





