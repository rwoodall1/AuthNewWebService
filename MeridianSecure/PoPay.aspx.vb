Imports Microsoft.VisualBasic


Imports System.Net
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail

Partial Class PoPay
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		Page.MaintainScrollPositionOnPostBack = True
		LoadLic()
		'resets the overlay div for this page
		Me.light.Attributes.Add("style", "top:60%;left:55%;")
		Page.Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate, post-check=0, pre-check=0")
        'Dim schcode As String = "124487"
        Dim schcode As String = Request.QueryString("schcode")
		cus11.SelectParameters.Clear()
		cus11.SelectParameters.Add("@schcode", schcode)
        'Dim schname As String = Request.QueryString("schname")
		'lblschname.Text = schname
		hfschcode.Value = schcode
		Dim dvSql As New DataView
		Dim drvSql As DataRowView
		Dim selectcmd As String = ""
		'Me.cus11.SelectCommand = selectcmd
		Try
			dvSql = CType(Me.cus11.Select(DataSourceSelectArguments.Empty), Data.DataView)
		Catch ex As Exception

		End Try
		Dim schname As String = ""
		Dim fname As String = ""
		Dim lname As String = ""
		Dim schaddr As String = ""
		Dim schcity As String = ""
		Dim schstate As String = ""
		Dim schzip As String = ""

		For Each drvSql In dvSql
			schname = drvSql("schname").ToString()
			'fname = drvSql("schname").ToString()
			'lname = drvSql("schname").ToString()
			schaddr = drvSql("schaddr").ToString
			schcity = drvSql("schcity").ToString
			schstate = drvSql("schstate").ToString
			schzip = drvSql("schzip").ToString
		Next
		If schname <> Nothing Then
			lblname.Text = schname.Trim
		Else
			lblname.Text = fname.Trim & " " & lname.Trim
		End If

		lbladdress.Text = schaddr.Trim
		lblcitystatezip.Text = schcity.Trim & "," & schstate.Trim & " " & schzip.Trim
	End Sub
	Protected Sub rbpaytype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbpaytype.SelectedIndexChanged
		If rbpaytype.SelectedValue = "CC" Then
			CCPanel.Visible = True
			ECPanel.Visible = False
			BlankFields("CC")
			hfpaytype.Value = "CC"
		Else
			CCPanel.Visible = False
			ECPanel.Visible = True
			BlankFields("EC")
			hfpaytype.Value = "EC"
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
	Protected Sub ccsubmit_Click(sender As Object, e As EventArgs) Handles ccsubmit.Click
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

			Dim submission As New submission
			Dim authresponse As New Response
			Dim info As New AuthReq
			'_______________________________________________________________________________________________________

			Dim total As String = txtamount.Text
			Dim emailaddress As String = txtemail.Text

			If CDec(total) > 0 Then
				'cc info and submission
				info.CardNum = x_card_num.Text
				info.SecurityCode = x_card_code.Text
				info.CardFname = x_first_name.Text
				info.CardLname = x_last_name.Text
				info.ExpDate = ddlmonth.SelectedValue & "/" & ddlyear.SelectedValue
				'info.OrderId = lblinvoice.Text
				info.Custid = hfschcode.Value
				info.Amount = total
				info.Email = emailaddress
				info.Method = hfpaytype.Value
				info.TransType = "AUTH_CAPTURE"
				info.SiteName = "Meridian"

				authresponse = submission.Capture(info)


				If authresponse.Approved Then
                    Session.Add("transid", authresponse.TransId.ToString()) 'for email
                    Session.Add("ordermessage", "Thank you! Payment has been submitted for the amount of " & authresponse.Amount _
					 & " to Meridian Planners." & "<br /> Transaction ID: " & authresponse.TransId & "<br />Card Number:" & authresponse.CardNum & IIf(txtPo.Text = Nothing, "", "<br />Invoice/PO:" & txtPo.Text))

					Session.Add("addressinfo", lblname.Text & "(Id:" & hfschcode.Value & ")<br />" & lbladdress.Text & "<br />" & lblcitystatezip.Text)

					UpdatePayment(authresponse.TransId, authresponse.AuthCode, x_card_num.Text.Substring(x_card_num.Text.Length - 4))
                    EmailReceipt(authresponse.TransId.ToString(), x_card_num.Text.Substring(x_card_num.Text.Length - 4), authresponse.Amount.ToString)
                    CSEmailReceipt(authresponse.TransId.ToString, x_card_num.Text.Substring(x_card_num.Text.Length - 4), authresponse.Amount.ToString)
					'Dim time As TimeSpan = Date.Now.TimeOfDay
					'type determine if email is sent when receipt page is accessed
					Response.Redirect("receipt1.aspx")
				Else 'card not approved
					MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))
					If Session("numtrys") = 3 Then
						'they have had 3 tries call it  quits
						MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & authresponse.Message & "Your order has not been processed. Please contact your Credit Card Company for help.", Nothing, New EO.Web.MsgBoxButton("OK", "", "no"))

						Response.Redirect("http://www.meridianplanners.com/Orders/")

					Else

						MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))

					End If


				End If
			Else 'total not greater than 0

			End If 'total greater than 0
		End If 'validation
	End Sub
	Protected Sub ecsubmit_Click(sender As Object, e As System.EventArgs) Handles ecsubmit.Click
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

			Dim total As String = txtamount.Text
			Dim emailaddress As String = txtemail.Text

			If CDec(total) > 0 Then
				'echeck info and submission
				info.bankname = x_bank_name.Text
				info.bankcustomername = x_bank_acct_name.Text
				info.bankaccounttype = x_bank_acct_type.Text
				info.bankaccountnumber = x_bank_acct_num.Text
				info.bankabacode = x_bank_aba_code.Text
				info.CardFname = x_first_name.Text
				info.CardLname = x_last_name.Text
				info.OrderId = "SchoolPay"
				info.Custid = hfschcode.Value
				info.Amount = total
				info.Email = emailaddress
				info.Method = "ECHECK"
				info.echecktype = "WEB"
				info.SiteName = "Meridian"
				authresponse = submission.Capture(info)

				If authresponse.Approved Then
					Session.Add("ordermessage", "Thank you! Payment has been submitted for the amount of " & authresponse.Amount _
					& "<br /> Transaction ID: " & authresponse.TransId)
					Session.Add("addressinfo", lblname.Text & "(Id:" & hfschcode.Value & ")<br />" & lbladdress.Text & "<br />" & lblcitystatezip.Text)
					UpdatePayment(authresponse.TransId, authresponse.AuthCode, "")
					EmailReceipt(authresponse.TransId.ToString, "", authresponse.Amount.ToString)
					CSEmailReceipt(authresponse.TransId.ToString, "", authresponse.Amount.ToString)
					
					Response.Redirect("receipt1.aspx")

				Else 'card not approved
					MsgBox1.Show("Check Submission Error", "Your bank returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))
					If Session("numtrys") = 3 Then
						'they have had 3 tries call it  quits
						MsgBox1.Show("Check Submission Error", "Your bank returned the following error:" & authresponse.Message & "Your order has not been processed. Please contact your bank for help.", Nothing, New EO.Web.MsgBoxButton("OK", "", "no"))



					Else

						MsgBox1.Show("Check Submission Error", "Your bank returned the following error:" & authresponse.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yes"), New EO.Web.MsgBoxButton("No", "", "no"))

					End If


				End If
			Else 'total not greater than 0

			End If 'total greater than 0
		End If 'validation
	End Sub

	Private Sub UpdatePayment(ByVal transid As String, ByVal authcode As String, ByVal ccnum As String)
		Dim connection1 As New MySqlConnection(cus11.ConnectionString)
		connection1.Open()
		Dim cmd As MySqlCommand = connection1.CreateCommand()
		Dim commandtext As String = "insert into payment (paydate,custemail,amount,transid, authcode, ccnum, schcode, schpay,paytype,payeename,notes)" _
  & " values(@paydate,@custemail,@amount,@transid,@authcode,@ccnum,@schcode,@schpay,@paytype,@payeename,@notes);"
		cmd.Parameters.Clear()
		cmd.Parameters.AddWithValue("@custemail", txtemail.Text)
		cmd.Parameters.AddWithValue("@paydate", Now)
		cmd.Parameters.AddWithValue("@amount", txtamount.Text)
		cmd.Parameters.AddWithValue("@paytype", hfpaytype.Value.ToString)
		cmd.Parameters.AddWithValue("@transid", transid)
		cmd.Parameters.AddWithValue("@authcode", authcode)
		cmd.Parameters.AddWithValue("@ccnum", ccnum)
		cmd.Parameters.AddWithValue("@schcode", hfschcode.Value.ToString)
		cmd.Parameters.AddWithValue("@schpay", "1")
		cmd.Parameters.AddWithValue("@notes", txtPo.Text)
		If rbpaytype.SelectedValue = "CC" Then
			cmd.Parameters.AddWithValue("@payeename", x_first_name.Text & " " & x_last_name.Text)
		Else 'EC
			cmd.Parameters.AddWithValue("@payeename", x_bank_acct_name.Text)
		End If
		cmd.CommandText = commandtext
		Try
			cmd.ExecuteNonQuery()
			connection1.Close()

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
			objMM.From = New MailAddress(ConfigurationManager.AppSettings("FromAddrmer"), ConfigurationManager.AppSettings("FromNamemer"))
			'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddr"))
			Try
				objMM.To.Add("randy@woodalldevelopment.com")
			Catch ex1 As Exception

			End Try	'ex1

			'Send the email in text format
			objMM.IsBodyHtml = True

			'Set the subject
			objMM.Subject = "Update Error School Payment"

			objMM.Body = "There was an error updating the following fields for  Pay Date=" & Now.ToString _
			 & "</br> Amount=" & txtamount.Text & "</br> PayType=" & hfpaytype.Value.ToString & " </br> TransId=" & transid & "</br> AuthCode=" & authcode _
			 & "</br> CreditCardNum=" & ccnum & "</br> Schcode=" & hfschcode.Value.ToString & "</br>Schname=" & lblname.Text & "Error Message:" & ex.Message

			Dim smtp As New SmtpClient(smtpclient)
			smtp.Credentials = New NetworkCredential(cuser, cpassword)

			Try
				'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
				smtp.Send(objMM)
			Catch ex2 As Exception

			Finally

			End Try	'ex2

		End Try

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
	Protected Sub EmailReceipt(transid As String, cardnum As String, amount As String)
		Dim objMM As New MailMessage()
		Dim tomail As String = ""
		Dim smtpclient As String = ""
		Dim cpassword As String = ""
		Dim cuser As String = ""
		If txtemail.Text <> Nothing Then
			tomail = txtemail.Text


			smtpclient = ConfigurationManager.AppSettings("smtpserver")
			cuser = ConfigurationManager.AppSettings("smtpuser")
			cpassword = ConfigurationManager.AppSettings("smtppassword")
			'Set the properties
			objMM.From = New MailAddress(ConfigurationManager.AppSettings("FromAddrmer"), ConfigurationManager.AppSettings("romNamemer"))
			'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddr"))
			Try
				objMM.To.Add(tomail)
			Catch ex1 As Exception

			End Try	'ex1

			'Send the email in text format
			objMM.IsBodyHtml = True

            'Set the subject
            objMM.Subject = "Receipt for payment to Meridian Student Planners (Transaction Id: " & transid & ")"
            Dim a As Decimal = CDec(amount)

			Dim camount As String = a.ToString("N2")
			If rbpaytype.SelectedValue = "CC" Then
				objMM.Body = "A payment using AuthorizeNet has been made with the following information:<br />" _
				 & lblname.Text & "(Id:" & hfschcode.Value & ")<br />" & lbladdress.Text & "<br />" & lblcitystatezip.Text _
				 & "<br /><br />" & "Thank you!<br /> Credit Card Payment has been submitted for the amount of " & camount _
				  & "<br /> Transaction ID: " & transid & "<br />Card Number:" & cardnum & IIf(txtPo.Text = Nothing, "", "<br />Invoice/PO:" & txtPo.Text)

			Else
				objMM.Body = "A payment using AuthorizeNet has been made with the following information:<br />" _
				  & lblname.Text & "(Id:" & hfschcode.Value & ")<br />" & lbladdress.Text & "<br />" & lblcitystatezip.Text _
				  & "<br />" & "Thank you!  Electronic Check Payment has been submitted for the amount of " & camount _
				& "<br /> Transaction ID: " & transid & IIf(txtPo.Text = Nothing, "", "<br />PO:" & txtPo.Text)

			End If

			Dim smtp As New SmtpClient(smtpclient)
			smtp.Credentials = New NetworkCredential(cuser, cpassword)

			Try
				'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
				smtp.Send(objMM)
			Catch ex2 As Exception

			Finally

			End Try	'ex2
		End If

	End Sub
	Protected Sub CSEmailReceipt(transid As String, cardnum As String, amount As String)
		Dim objMM As New MailMessage()
		Dim tomail As String = ""
		Dim smtpclient As String = ""
		Dim cpassword As String = ""
		Dim cuser As String = ""

		tomail = ConfigurationManager.AppSettings("FromAddrmer")
		' tomail = "randy@woodalldevelopment.com"

		smtpclient = ConfigurationManager.AppSettings("smtpserver")
		cuser = ConfigurationManager.AppSettings("smtpuser")
		cpassword = ConfigurationManager.AppSettings("smtppassword")
		'Set the properties
		objMM.From = New MailAddress(ConfigurationManager.AppSettings("FromAddrmer"), ConfigurationManager.AppSettings("FromNamemer"))
		'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddr"))
		Try
            objMM.To.Add(tomail)
            objMM.CC.Add("hedwards@printlynx.com")
		Catch ex1 As Exception

		End Try	'ex1

		'Send the email in text format
		objMM.IsBodyHtml = True

		'Set the subject
		objMM.Subject = "School payment to Meridian Student Planners (Transaction Id: " & Session("transid") & ")"
		Dim a As Decimal = CDec(amount)
		Dim camount As String = a.ToString("N2")
		If rbpaytype.SelectedValue = "CC" Then
			objMM.Body = "A payment using AuthorizeNet has been made with the following information:<br />" _
			  & lblname.Text & "(Id:" & hfschcode.Value & ")<br />" & lbladdress.Text & "<br />" & lblcitystatezip.Text _
			  & "<br /><br />" & "Thank you!<br /> Credit Card Payment has been submitted for the amount of " & camount _
			   & "<br /> Transaction ID: " & transid & "<br />Card Number:" & cardnum & IIf(txtPo.Text = Nothing, "", "<br />	PO:" & txtPo.Text)

		Else
			objMM.Body = "A payment using AuthorizeNet has been made with the following information:<br />" _
			   & lblname.Text & "(Id:" & hfschcode.Value & ")<br />" & lbladdress.Text & "<br />" & lblcitystatezip.Text _
			   & "<br />" & "Thank you!  Electronic Check Payment has been submitted for the amount of " & camount _
			 & "<br /> Transaction ID: " & transid & IIf(txtPo.Text = Nothing, "", "<br />	PO:" & txtPo.Text)

		End If

		Dim smtp As New SmtpClient(smtpclient)
		smtp.Credentials = New NetworkCredential(cuser, cpassword)

		Try
			'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
			smtp.Send(objMM)
		Catch ex2 As Exception

		Finally

		End Try	'ex2

	End Sub
	Protected Sub MsgBox1_ButtonClick(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles MsgBox1.ButtonClick

		If e.CommandName = "no" Then

			Response.Redirect("http://www.meridianplanners.com/Orders/")
		End If
		
	End Sub

	Protected Sub cvamount_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvamount.ServerValidate
		Dim retval As Boolean = True
		If IsNumeric(txtamount.Text) Then
			If txtamount.Text.Contains("$") Then
				cvamount.Text = "Currency symbols are not allowed."
				retval = False
			End If
			If txtamount.Text.Contains(",") Then
				cvamount.Text = "' , ' seperator symbols are not allowed."
				retval = False
			End If
		Else
			'not numeric
			cvamount.Text = "Only use numeric characters for amount."
			retval = False
		End If
		args.IsValid = retval
	End Sub
End Class
