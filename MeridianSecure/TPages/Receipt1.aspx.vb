Imports Microsoft.VisualBasic
Imports System.Data

Imports System.Net.Mail
Imports System.IO

Imports System.Net
Partial Class Receipt1
	Inherits EmailReadyPage
	Private okToSendMarkup As Boolean = False

	Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		'If Not IsPostBack Then

		'Dim senttime As TimeSpan = TimeSpan.Parse(Request.QueryString("secval"))
		'Dim curtime As TimeSpan = Today.TimeOfDay
		'Dim timediff As TimeSpan = curtime - senttime
		'Dim diff As Integer = timediff.Seconds
		'	If diff < 14400 Then 'four hours then access is cut off
		'Session.Clear()
		'		EmailReceipt()
		'	Else
		'		Response.Redirect("www.meridianplanners.com/MeridianOrders")
		'	End If
		'End If
	End Sub

	
	Sub EmailReceipt()
		''Dim cart As Cart = Session("Cart")
		''Save the position of the DataGrid in the myForm Controls collection
		'Dim SB As New StringBuilder()
		'Dim SW As New StringWriter(SB)
		'Dim htmlTW As New HtmlTextWriter(SW)
		'gv1.AllowPaging = False
		'gv1.RenderControl(htmlTW)

		'Dim thegrid As String = SB.ToString
		'SB.Clear()

		'DetailsView1.RenderControl(htmlTW)
		'Dim thefirstdetailview As String = SB.ToString
		'SB.Clear()
		'DetailsView2.RenderControl(htmlTW)
		'Dim theseconddetailview As String = SB.ToString
		'SB.Clear()
		'FormView2.RenderControl(htmlTW)
		'Dim thesecondformview As String = SB.ToString

		''Now, send the email
		''Create an instance of the MailMessage class
		'Dim objMM As New MailMessage()
		'Dim tomail As String = ""
		'Dim smtpclient As String = ""
		'Dim cpassword As String = ""
		'Dim cuser As String = ""
		'If Directory.Exists("F:\IsDev") Then 'set dev settings
		'	'smtpclient = "cmain1.wdfm.net" '"mail.woodalldevelopment.com"
		'	'cuser = "rwoodall@wdfm.net"
		'	'cpassword = "Briggitte1"
		'	tomail = "randy@woodalldevelopment.com"
		'Else 'live
		'	'SmtpClient = "192.168.1.245"
		'	'cuser = "authnet@memorybook.com"
		'	'cpassword = "authnet"
		'	Dim email As String = DetailsView1.Rows(8).Cells(1).Text

		'	tomail = Trim(email)


		'End If

		'smtpclient = ConfigurationManager.AppSettings("smtpserver")
		'cuser = ConfigurationManager.AppSettings("smtpuser")
		'cpassword = ConfigurationManager.AppSettings("smtppassword")
		''Set the properties
		'objMM.From = New MailAddress(ConfigurationManager.AppSettings("FromAddrmer"), ConfigurationManager.AppSettings("FromNamemer"))

		'Try
		'	objMM.To.Add(tomail) 'customer address if address bad try statement in send will catch
		'	objMM.Bcc.Add("sales@meridianplanners.com")
		'	If Not IsNothing(Session("PO")) Then
		'		'objMM.Bcc.Add("warehouse@meridianplanners.com")
		'	End If
		'Catch ex As Exception

		'End Try


		''Send the email in text format
		'objMM.IsBodyHtml = True

		''Set the subject
		'objMM.Subject = "Meridian Planners Order Confirmation  " & Now

		'objMM.Body = "<table class='style1' align='center'> <tr><td align='center' colspan='2' style='font-weight: bolder'>Thank you! Your order# is " & DetailsView2.DataKey("orderid") _
		' & "<br /> Your order was placed on " & Now.ToString & "</td></tr> <tr><td align='center' style='font-weight: bolder'>Billing Information</td><td align='center' style='font-weight: bold'>Shipping Information</td></tr>" _
		' & "<tr><td align='right'>" & thefirstdetailview & "</td><td>" & theseconddetailview & "</td></tr><tr><td colspan='2'>" _
		' & thegrid & "</td> </tr> <tr><td align='center' colspan='2'>" & thesecondformview & " </td></tr><tr><td align='center' colspan='2'><br/><br/>" _
		' & " Thank you for shopping at Meridian Planners. <br/> Visit us again at <a href='http://www.meridianplanners.com/ ' >www.meridianplanners.com/. </a></td><tr></table>"

		'Dim smtp As New SmtpClient(smtpclient)
		'smtp.Credentials = New NetworkCredential(cuser, cpassword)

		'Try
		'	'smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis 'only works on some servers
		'	smtp.Send(objMM)
		'Catch ex As Exception
		'	MsgBox1.Show("Email Error", "Your confirmation email was not sent because of the following error:" & ex.Message & "Your order has been received and will be processed. No further action is needed.", Nothing, New EO.Web.MsgBoxButton("OK"))
		'	Dim objMM1 As New MailMessage
		'	Dim orderid As String = Request.QueryString("orderid")
		'	smtpclient = ConfigurationManager.AppSettings("smtpserver")
		'	cuser = ConfigurationManager.AppSettings("smtpuser")
		'	cpassword = ConfigurationManager.AppSettings("smtppassword")
		'	Dim smtperror As New SmtpClient(smtpclient)
		'	smtperror.Credentials = New NetworkCredential(cuser, cpassword)
		'	objMM1.From = New MailAddress(ConfigurationManager.AppSettings("FromAddr"), ConfigurationManager.AppSettings("FromName"))
		'	objMM1.To.Add("sales@meridianplanners.comm")
		'	'objMM1.CC.Add("")
		'	objMM1.Subject = "Meridian Planners Order Email Error Order Id:" & orderid
		'	objMM1.IsBodyHtml = True
		'	objMM1.Body = "The customer did not receive an email because of the following error:" & ex.Message
		'	Try
		'		smtperror.Send(objMM1)
		'	Catch ex2 As Exception

		'	End Try


		'Finally

		'End Try



	End Sub

End Class
