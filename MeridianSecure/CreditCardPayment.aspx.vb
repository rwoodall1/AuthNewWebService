Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Data

Partial Public Class CreditCardPayment
	Inherits System.Web.UI.Page


	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			Session.Add("Company", "MER")
			Dim dvSql As New DataView
			Dim drvSql As DataRowView
			Dim emailaddress As String
			Dim orderid As Integer = Request.QueryString("orderid")
			Dim amount As Decimal
			'dstemporders.SelectParameters.Clear()
			'dstemporders.SelectParameters.Add("@orderid", orderid)
			Try
				dvSql = CType(dstemporders.Select(DataSourceSelectArguments.Empty), Data.DataView)
				If dvSql.Count = 0 Then
					Response.Write("<script language='javascript'>window.alert('Yourn order was not found. Contact Meridian Customer Service at 1-888-724-8512.');" _
					 & "window.location='https://www.securepaymentportal.com/MeridianSecure/Error.aspx';</script>")
				End If
				For Each drvSql In dvSql
					emailaddress = drvSql("emailaddress").ToString()
					amount = drvSql("total")
				Next

			Catch ex As Exception

			End Try
			Session.Add("orderid", orderid)
			Session.Add("amount", amount)
			lblamount.Text = amount.ToString("N2")
			lblorderid.Text = orderid
		End If
	End Sub
	Protected Sub btncc_Click(sender As Object, e As System.EventArgs) Handles btncc.Click

		If IsNothing(Session("numtrys")) Then
			Session.Add("numtrys", 1)
		Else
			Session("numtrys") = Session("numtrys") + 1
		End If
		Dim orderid As Integer = Session("orderid")

		'live_________________________________________________________________________________________________
		Dim submission As New submission
		Dim response As New Response

		Dim info As New AuthReq
		''_______________________________________________________________________________________________________

		Dim total As String = Session("amount")
		Dim emailaddress As String = Session("emailaddress")

		'cc info and submission
		info.CardNum = x_card_num.Text
		info.SecurityCode = x_card_code.Text
		info.CardFname = x_first_name.Text
		info.CardLname = x_last_name.Text
		info.ExpDate = ddlmonth.SelectedValue & "/" & ddlyear.SelectedValue
		info.OrderId = CStr(orderid)
		info.Custid = ""
		info.Amount = total
		info.Email = emailaddress
		info.Method = "CC"
		info.TransType = "AUTH_CAPTURE"
		info.SiteName = "Meridian"

		response = submission.Capture(info)

		If response.Approved Then

			Session.Add("transid", response.TransId)
			Session.Add("authcode", response.AuthCode)
			Session.Add("ccnum", x_card_num.Text.Substring(x_card_num.Text.Length - 4))

			WriteOrder()

		Else 'card not approved
			MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & response.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "yessubmit"), New EO.Web.MsgBoxButton("No", "", "nosubmit"))
			If Session("numtrys") = 3 Then
				'we need to make order a po
				UpdateOrdertoPO()

			Else

				MsgBox1.Show("Credit Card Submission Error", "Your Credit Card Company returned the following error:" & response.Message & "Do you wish to try again?", Nothing, New EO.Web.MsgBoxButton("Yes", "", "tryagain"), New EO.Web.MsgBoxButton("No", "", "nosubmit"))

			End If


		End If


	End Sub
	Protected Sub WriteOrder()
		Dim orderid As String = Request.QueryString("orderid")
		Dim connection1 As New MySqlConnection(dstemporders.ConnectionString)
		Dim cmd As MySqlCommand = connection1.CreateCommand()
		Try
			connection1.Open()
			Dim trans As MySqlTransaction = connection1.BeginTransaction()
			If InsertOrder(orderid, cmd) Then
				If InsertDetails(orderid, cmd) Then
					If InsertPayment(orderid, cmd) Then
						trans.Commit()

						Dim time As TimeSpan = Date.Now.TimeOfDay
						Response.Redirect("receipt.aspx?orderid=" & orderid & "&secval=" & time.ToString)
						'Response.Redirect("http://memserver/Orders/receipt.aspx?orderid=" & orderid & "&secval=" & time.ToString)
					Else 'payment not made
						trans.Rollback()
						connection1.Close()
					End If
				Else 'orderdetail
					trans.Rollback()
					connection1.Close()
				End If


			Else 'orderid
				trans.Rollback()
				connection1.Close()
			End If


		Catch ex As Exception

		End Try
	End Sub
	Sub DeleteTempOrder()
		'dstemporders.Delete()
		'dstempdetailorder.Delete()
	End Sub

	'Private Sub WriteToFile(sText As String)
	'    Dim sPath As String = HttpContext.Current.Server.MapPath("error.txt")
	'    Try
	'        Dim fs As New FileStream(sPath, FileMode.Append, FileAccess.Write)
	'        Dim writer As New StreamWriter(fs)
	'        writer.Write(sText)
	'        writer.Close()
	'        fs.Close()
	'    Catch generatedExceptionName As Exception
	'    End Try
	'End Sub
	'Protected Sub UpdatePayment()
	'	Dim paymentmade As Boolean = False
	'	Dim orderid As Integer = Session("orderid")
	'	Dim connection1 As New MySqlConnection(dspayment.ConnectionString)
	'	connection1.Open()

	'	Dim cmd As MySqlCommand = connection1.CreateCommand()


	'	Dim commandtext As String = "insert into payment (orderid,paydate,amount,paytype,transid,authcode,ccnum)" _
	'	   & "values(@orderid,@paydate,@amount,@paytype,@transid,@authcode,@ccnum);"
	'	cmd.Parameters.Clear()
	'	cmd.Parameters.AddWithValue("@orderid", orderid)
	'	cmd.Parameters.AddWithValue("@paydate", Now)
	'	cmd.Parameters.AddWithValue("@amount", Session("amount"))
	'	cmd.Parameters.AddWithValue("@paytype", "CC")
	'	cmd.Parameters.AddWithValue("@transid", Session("transid"))
	'	cmd.Parameters.AddWithValue("@authcode", Session("authcode"))
	'	cmd.Parameters.AddWithValue("@ccnum", Session("ccnum"))
	'	Session.Remove("transid")
	'	Session.Remove("authcode")
	'	Session.Remove("ccnum")
	'	cmd.CommandText = commandtext

	'	Try
	'		cmd.ExecuteNonQuery()

	'		paymentmade = True
	'	Catch ex As Exception
	'		'send email


	'		Dim objMM As New MailMessage()
	'		Dim tomail As String = ""
	'		Dim smtpclient As String = ""
	'		Dim cpassword As String = ""
	'		Dim cuser As String = ""

	'		tomail = "randy@woodalldevelopment.com"


	'		smtpclient = ConfigurationManager.AppSettings("smtpserver")
	'		cuser = ConfigurationManager.AppSettings("smtpuser")
	'		cpassword = ConfigurationManager.AppSettings("smtppassword")
	'		'Set the properties
	'		objMM.From = New MailAddress(ConfigurationManager.AppSettings("FromAddrmer"), ConfigurationManager.AppSettings("FromNamemer"))
	'		'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddrmer"))
	'		Try
	'			objMM.To.Add(tomail) 'customer address if address bad try statement in send will catch
	'		Catch ex1 As Exception

	'		End Try	'ex1

	'		'Send the email in text format
	'		objMM.IsBodyHtml = True

	'		'Set the subject
	'		objMM.Subject = "Update Error"

	'		objMM.Body = "There was an error updating the following fields for order " & orderid & "</br> Pay Date=" & Now.ToString _
	'		 & "</br> Amount=" & Session("amount") & "</br> Pay Type=CC </br> TransId=" & Session("transid") & "</br> AuthCode=" & Session("authode") _
	'		 & "</br> Credit Card Num=" & Session("ccnum")

	'		Dim smtp As New SmtpClient(smtpclient)
	'		smtp.Credentials = New NetworkCredential(cuser, cpassword)

	'		Try
	'			'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
	'			smtp.Send(objMM)
	'		Catch ex2 As Exception

	'		Finally

	'		End Try	'ex2
	'	End Try	'ex

	'	If paymentmade = True Then
	'		Dim time As TimeSpan = Date.Now.TimeOfDay
	'		Response.Redirect("http://www.meridianplanners.com/Orders/receipt.aspx?orderid=" & orderid & "&secval=" & time.ToString)
	'		'Response.Redirect("http://memserver/Orders/receipt.aspx?orderid=" & orderid & "&secval=" & time.ToString)
	'	Else
	'		Return
	'	End If

	'End Sub

	Protected Sub UpdateOrdertoPO()
		Dim orderid As String = Request.QueryString("orderid")
		Dim connection1 As New MySqlConnection(dspayment.ConnectionString)
		connection1.Open()

		Dim cmd As MySqlCommand = connection1.CreateCommand()


		Dim commandtext As String = "update orders set po=1 where orderid=" & Session("orderid").ToString & ";"
		
		cmd.CommandText = commandtext

		Try
			cmd.ExecuteNonQuery()
			connection1.Close()


		Catch ex As Exception 'update failed
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
			'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddrmer"))
			Try
				objMM.To.Add(tomail) 'customer address if address bad try statement in send will catch
			Catch ex1 As Exception

			End Try	'ex1

			'Send the email in text format
			objMM.IsBodyHtml = True

			'Set the subject
			objMM.Subject = "PO Update Error"

			objMM.Body = "There was an error updating the PO field for order " & orderid

			Dim smtp As New SmtpClient(smtpclient)
			smtp.Credentials = New NetworkCredential(cuser, cpassword)

			Try
				'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
				smtp.Send(objMM)
			Catch ex2 As Exception

			Finally

			End Try	'ex2
		End Try	'ex


	End Sub

	Protected Sub MsgBox1_ButtonClick(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles MsgBox1.ButtonClick
		Dim orderid As String = Session("orderid")
		Dim time As TimeSpan = Date.Now.TimeOfDay
		If e.CommandName = "nosubmit" Then
			UpdateOrdertoPO()
			Response.Write("<script language='javascript'>window.alert('Your credit card was not accepted, your order is being processed as a PO. \n You will be contacted by Meridian customer service.');" _
	& "window.location='http://www.meridianplanners.com/Orders/receipt.aspx?orderid=" & orderid & "&secval=" & time.ToString & "';</script>")


		End If
		If e.CommandName = "tryagain" Then
			If Session("numtrys") = 3 Then
				'we need to make order a po
				UpdateOrdertoPO()
				Response.Write("<script language='javascript'>window.alert('Your credit card was not accepted, your order is being processed as a PO. \n You will be contacted by Meridian customer servervice.');" _
				   & "window.location='http://www.meridianplanners.com/Orders/receipt.aspx?orderid=" & orderid & "&secval=" & time.ToString & "';</script>")
			Else
				'do nothing


			End If
		End If
	End Sub
	Private Function InsertOrder(orderid As Integer, cmd As MySqlCommand) As Boolean
		Dim retval As Boolean = False
		dstemporders.SelectCommand = "select * from temporders where orderid=" & orderid
		Dim dvSql As New DataView
		Dim drvSql As DataRowView
		cmd.CommandText = "INSERT INTO orders(orderid, fname, lname, address, address2, city, state, zipcode, emailaddress, sfname," _
		 & "slname, saddress, saddress2, scity, sstate, szipcode, shipdate, orderdate, company, scompany, phonenumber, subtotal," _
		 & "shippingcost, total, po, notes, custid, weight) VALUES (@orderid, @fname, @lname, @address, @address2, @city, @state," _
		 & "@zipcode, @emailaddress, @sfname, @slname, @saddress, @saddress2, @scity, @sstate, @szipcode, @shipdate, @orderdate," _
		 & "@company, @scompany, @phonenumber, @subtotal, @shippingcost, @total, @po, @notes, @custid, @weight)"
		'get tmporder loop through and copy to real order (orderid is in querystring)

		Try
			dvSql = CType(Me.dstemporders.Select(DataSourceSelectArguments.Empty), Data.DataView)
			For Each drvSql In dvSql 'should only be one record

				cmd.Parameters.Clear()
				cmd.Parameters.AddWithValue("@orderid", orderid)
				cmd.Parameters.AddWithValue("@fname", drvSql("fname"))
				cmd.Parameters.AddWithValue("@lname", drvSql("lname"))
				cmd.Parameters.AddWithValue("@address", drvSql("address"))
				cmd.Parameters.AddWithValue("@address2", drvSql("address2"))
				cmd.Parameters.AddWithValue("@city", drvSql("city"))
				cmd.Parameters.AddWithValue("@state", drvSql("state"))
				cmd.Parameters.AddWithValue("@zipcode", drvSql("zipcode"))
				cmd.Parameters.AddWithValue("@emailaddress", drvSql("emailaddress"))
				cmd.Parameters.AddWithValue("@sfname", drvSql("sfname"))
				cmd.Parameters.AddWithValue("@slname", drvSql("slname"))
				cmd.Parameters.AddWithValue("@saddress", drvSql("saddress"))
				cmd.Parameters.AddWithValue("@saddress2", drvSql("saddress2"))
				cmd.Parameters.AddWithValue("@scity", drvSql("scity"))
				cmd.Parameters.AddWithValue("@sstate", drvSql("sstate"))
				cmd.Parameters.AddWithValue("@szipcode", drvSql("szipcode"))
				cmd.Parameters.AddWithValue("@shipdate", drvSql("shipdate"))
				cmd.Parameters.AddWithValue("@orderdate", drvSql("orderdate"))
				cmd.Parameters.AddWithValue("@company", drvSql("company"))
				cmd.Parameters.AddWithValue("@scompany", drvSql("scompany"))
				cmd.Parameters.AddWithValue("@phonenumber", drvSql("phonenumber"))
				cmd.Parameters.AddWithValue("@subtotal", drvSql("subtotal"))
				cmd.Parameters.AddWithValue("@shippingcost", drvSql("shippingcost"))
				cmd.Parameters.AddWithValue("@total", drvSql("total"))
				cmd.Parameters.AddWithValue("@po", drvSql("po"))
				cmd.Parameters.AddWithValue("@notes", drvSql("notes"))
				cmd.Parameters.AddWithValue("@custid", drvSql("custid"))
				cmd.Parameters.AddWithValue("@weight", drvSql("weight"))
				Try
					cmd.ExecuteNonQuery()
					retval = True

				Catch ex As Exception
					'create the mail message
					Dim mail As New MailMessage()
					'set the addresses
					'set the addresses
					mail.From = New MailAddress(ConfigurationManager.AppSettings("FromAddr"))
					mail.To.Add("randy@woodalldevelopment.com")
					'set the content
					mail.Subject = "Mysql Error:Inserting Meridian Order " & drvSql("company") & "(" & drvSql("orderid") & ")"
					mail.Body = "An error occured inserting a order record into the Mysql database server. The following data was not recorded in the order table.<br/>" _
					  & "First name:" & drvSql("fname") & "<br/>" _
					 & "Last Name:" & drvSql("lname") & "<br/>" _
					  & "Address:" & drvSql("address") & "<br/>" _
					  & "Address2:" & drvSql("address2") & "<br/>" _
					  & "City:" & drvSql("city") & "<br/>" _
					  & "State:" & drvSql("state") & "<br/>" _
					  & "ZipCode:" & drvSql("zipcode") & "<br/>" _
					  & "Email Address:" & drvSql("emailaddress") & "<br/>" _
					  & "Ship First Name:" & drvSql("sfname") & "<br/>" _
					  & "Ship Last Name:" & drvSql("slname") & "<br/>" _
					  & "Ship Address:" & drvSql("saddress") & "<br/>" _
					  & "Ship Address2:" & drvSql("saddress2") & "<br/>" _
					  & "Ship City:" & drvSql("scity") & "<br/>" _
					  & "Ship State:" & drvSql("sstate") & "<br/>" _
					  & "Ship ZipCode:" & drvSql("szipcode") & "<br/>" _
					  & "Ship Date:" & drvSql("shipdate") & "<br/>" _
					& "OrderDate:" & drvSql("orderdate") & "<br/>" _
					 & "Phone Number :" & drvSql("phonenumber") & "<br/>" _
					 & "SubTotal:" & drvSql("subtotal") & "<br/>" _
					 & "PO:" & drvSql("po") & "<br/>" _
					 & "custid:" & drvSql("custid") & "<br/>" _
					 & "weight:" & drvSql("weight") & "<br/>" _
					 & "notes:" & drvSql("notes") & "<br/>" _
					 & "Total:" & drvSql("total") & "<br/>" _
					  & "Shipping Cost:" & drvSql("shippingcost") & "<br/><br/>" _
					  & "Mysql Exception Code:" & ex.Message
					mail.IsBodyHtml = True
					'send the message
					Dim smtp As New SmtpClient(ConfigurationManager.AppSettings("SmtpServer"))
					smtp.Credentials = New NetworkCredential(ConfigurationManager.AppSettings("smtpuser"), ConfigurationManager.AppSettings("smtppassword"))
					'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some serves
					smtp.Send(mail)
					retval = False
				End Try	 'endtry excute query

			Next
		Catch ex As Exception  'system/program error take to a error page
			Dim handler As New XC.Web.ErrorHandler(Nothing)
			handler.HandleException()
			Response.Redirect("~/MBCSecure/error.aspx")
		End Try	'end of loop in temporders
		Return retval
	End Function
	Private Function InsertDetails(orderid As Integer, cmd As MySqlCommand) As Boolean
		Dim retval As Boolean = False
		dstemporders.SelectCommand = "select * from temporderdetail where orderid=" & orderid
		Dim dvSql As New DataView
		Dim drvSql As DataRowView
        cmd.CommandText = "INSERT INTO orderdetail(orderid,schtype,quantity,price,totalprice,prodcode)" _
         & "VALUES (@orderid, @schtype, @quantity, @price, @totalprice,@prodcode)"
		'get tmpdetailorder loop through and copy to real detailorder (orderid is in querystring)

		Try
			dvSql = CType(Me.dstemporders.Select(DataSourceSelectArguments.Empty), Data.DataView)
			For Each drvSql In dvSql 'should only be one record

				cmd.Parameters.Clear()
				cmd.Parameters.AddWithValue("@orderid", orderid)
				cmd.Parameters.AddWithValue("@schtype", drvSql("schtype"))
				cmd.Parameters.AddWithValue("@quantity", drvSql("quantity"))
				cmd.Parameters.AddWithValue("@price", drvSql("price"))
				cmd.Parameters.AddWithValue("@totalprice", drvSql("totalprice"))
                cmd.Parameters.AddWithValue("@prodcode", drvSql("prodcode"))
				Try
					cmd.ExecuteNonQuery()
					retval = True

				Catch ex As Exception
					'create the mail message
					Dim mail As New MailMessage()
					'set the addresses
					'set the addresses
					mail.From = New MailAddress(ConfigurationManager.AppSettings("FromAddr"))
					mail.To.Add("randy@woodalldevelopment.com")
					'set the content
					mail.Subject = "Mysql Error:Inserting Meridian Detail Order " & drvSql("orderid")
					mail.Body = "An error occured inserting a order record into the Mysql database server. The following data was not recorded in the order table.<br/>" _
					  & "Orderid:" & orderid & "<br/>" _
					  & "detailid:" & drvSql("detailid") & "<br/>" _
					  & "schtype:" & drvSql("schtype") & "<br/>" _
					  & "quantity:" & drvSql("quantity") & "<br/>" _
					  & "price:" & drvSql("price") & "<br/>" _
					  & "total price:" & drvSql("totalprice") & "<br/><br/>" _
					  & "Mysql Exception Code:" & ex.Message
					mail.IsBodyHtml = True
					'send the message
					Dim smtp As New SmtpClient(ConfigurationManager.AppSettings("SmtpServer"))
					smtp.Credentials = New NetworkCredential(ConfigurationManager.AppSettings("smtpuser"), ConfigurationManager.AppSettings("smtppassword"))
					'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some serves
					smtp.Send(mail)
					retval = False
				End Try	 'endtry excute query

			Next
		Catch ex As Exception  'system/program error take to a error page
			Dim handler As New XC.Web.ErrorHandler(Nothing)
			handler.HandleException()
			Response.Redirect("~/MBCSecure/error.aspx")
		End Try	'end of loop in temporders
		Return retval
	End Function
	Private Function InsertPayment(orderid As Integer, cmd As MySqlCommand) As Boolean
		Dim retval As Boolean = False
		Dim commandtext As String = "insert into payment (orderid,paydate,amount,paytype,transid,authcode,ccnum)" _
		& "values(@orderid,@paydate,@amount,@paytype,@transid,@authcode,@ccnum);"
		cmd.Parameters.Clear()
		cmd.Parameters.AddWithValue("@orderid", orderid)
		cmd.Parameters.AddWithValue("@paydate", Now)
		cmd.Parameters.AddWithValue("@amount", Session("amount"))
		cmd.Parameters.AddWithValue("@paytype", "CC")
		cmd.Parameters.AddWithValue("@transid", Session("transid"))
		cmd.Parameters.AddWithValue("@authcode", Session("authcode"))
		cmd.Parameters.AddWithValue("@ccnum", Session("ccnum"))
		Session.Remove("transid")
		Session.Remove("authcode")
		Session.Remove("ccnum")
		cmd.CommandText = commandtext

		Try
			cmd.ExecuteNonQuery()
			retval = True

		Catch ex As Exception
			'send email
			retval = False

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
			'objMM.Bcc.Add(ConfigurationManager.AppSettings("FromAddrmer"))
			Try
				objMM.To.Add(tomail) 'customer address if address bad try statement in send will catch
			Catch ex1 As Exception

			End Try	'ex1

			'Send the email in text format
			objMM.IsBodyHtml = True

			'Set the subject
			objMM.Subject = "Update Error"

			objMM.Body = "There was an error updating the following fields for order " & orderid & "</br> Pay Date=" & Now.ToString _
			 & "</br> Amount=" & Session("amount") & "</br> Pay Type=CC </br> TransId=" & Session("transid") & "</br> AuthCode=" & Session("authode") _
			 & "</br> Credit Card Num=" & Session("ccnum")

			Dim smtp As New SmtpClient(smtpclient)
			smtp.Credentials = New NetworkCredential(cuser, cpassword)

			Try
				'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
				smtp.Send(objMM)
			Catch ex2 As Exception

			Finally

			End Try	'ex2
		End Try	'ex


		Return retval

	End Function

	
End Class