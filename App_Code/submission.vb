﻿Imports System.Net
Imports System.IO
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Web


Public Class submission
    Public Function Capture(request As AuthReq) As Response


        ' By default, this sample code is designed to post to our test server for
        ' developer accounts: https://test.authorize.net/gateway/transact.dll
        ' for real accounts (even in test mode), please make sure that you are
        'posting to: https://secure.authorize.net/gateway/transact.dll
        Dim post_url As String
        post_url = ConfigurationManager.AppSettings("AuthUrl")
        ' post_url = "https://secure.authorize.net/gateway/transact.dll"

        Dim post_values As New Dictionary(Of String, String)
        Dim login As String = ConfigurationManager.AppSettings(request.SiteName & "ApiLogin")
        Dim Key As String = ConfigurationManager.AppSettings(request.SiteName & "TransactionKey")
        Dim test As String = ConfigurationManager.AppSettings("GatewayTest")
        'the API Login ID and Transaction Key must be replaced with valid values

        post_values.Add("x_version", "3.1")
        post_values.Add("x_login", login)
        post_values.Add("x_tran_key", Key)
        post_values.Add("x_delim_data", "TRUE")
        post_values.Add("x_delim_char", "|")
        post_values.Add("x_relay_response_array", "FALSE")
        post_values.Add("x_type", request.TransType) ' request.TransType AUTH_CAPTURE,AUTH_ONLY,PRIOR_AUTH_CAPTURE,CREDIT,VOID ect.
        post_values.Add("x_method", request.Method) 'CC,ECHECK
        post_values.Add("x_echeck_type", request.echecktype) 'web
        post_values.Add("x_card_num", request.CardNum)
        post_values.Add("x_exp_date", request.ExpDate)
        post_values.Add("x_card_code", request.SecurityCode)
        post_values.Add("x_recurring_billing", "FALSE") ' we don't use this so is always false
        post_values.Add("x_bank_acct_name", request.bankcustomername)
        post_values.Add("x_bank_name", request.bankname)
        post_values.Add("x_bank_acct_type", request.bankaccounttype) 'savings,checking,businesschecking
        post_values.Add("x_bank_aba_code", request.bankabacode)
        post_values.Add("x_bank_acct_num", request.bankaccountnumber)
        post_values.Add("x_amount", request.Amount)
        post_values.Add("x_description", "")
        'post_values.Add("x_test_request", ConfigurationManager.AppSettings("GatewayTest")) use this for submissions to live site only-----------------------------------------------------------------------------------------------------------------
        'post_values.Add("x_test_request", "FALSE")
        post_values.Add("x_cust_id", request.Custid)
        post_values.Add("x_first_name", request.CardFname)
        post_values.Add("x_last_name", request.CardLname)
        post_values.Add("x_address", request.Address)
        post_values.Add("x_state", request.State)
        post_values.Add("x_ city", request.State)
        post_values.Add("x_zip", request.Zip)
        post_values.Add("x_invoice_num", request.OrderId)
        post_values.Add("x_email", request.Email)
        post_values.Add("x_duplicate_window", "420") '7 minutes


        ' Additional fields can be added here as outlined in the AIM integration
        ' guide at: http://developer.authorize.net

        ' This section takes the input fields and converts them to the proper format
        ' for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)

        ' The following section provides an example of how to add line item details to
        ' the post string.  Because line items may consist of multiple values with the
        ' same key/name, they cannot be simply added into the above array.
        '
        ' This section is commented out by default.
        'Dim line_items() As String = { _
        '    "item1<|>golf balls<|><|>2<|>18.95<|>Y", _
        '    "item2<|>golf bag<|>Wilson golf carry bag, red<|>1<|>39.99<|>Y", _
        '    "item3<|>book<|>Golf for Dummies<|>1<|>21.99<|>Y"}
        '
        'For Each value As String In line_items
        '   post_string += "&x_line_item=" + HttpUtility.UrlEncode(value)
        'Next

        ' create an HttpWebRequest object to communicate with Authorize.net
        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"

        ' post data is sent as a stream
        Dim myWriter As StreamWriter = Nothing
        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()




        ' returned values are returned as a stream, then read into a string
        Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)
        Dim responseStream As New StreamReader(objResponse.GetResponseStream())
        Dim post_response As String = responseStream.ReadToEnd()
        responseStream.Close()

        ' the response_array string is broken into an array
        Dim response_array As Array = Split(post_response, post_values("x_delim_char"), -1)
        Dim Returnresponse_array As New Response
        Try
            'Returnresponse_array.Approved = Returnresponse_array.GetText(response_array(1)) '1,2,3,4 approved,declined,error,held for review
            Dim approvedret As Boolean
            Select Case response_array(0)
                Case "1"
                    approvedret = True
                Case Else
                    approvedret = False
            End Select
            Returnresponse_array.Approved = approvedret
            Returnresponse_array.Message = response_array(3)
            Returnresponse_array.AuthCode = response_array(4)
            Returnresponse_array.TransId = response_array(6)
            Dim r As String = response_array(7)
            Dim rr As String = response_array(5)
            Returnresponse_array.Amount = response_array(9)
            Returnresponse_array.Method = response_array(10)
            Returnresponse_array.TransActionType = response_array(11)
            Returnresponse_array.Custid = response_array(12)
            Returnresponse_array.Email = response_array(23)
            Returnresponse_array.CardNum = response_array(50)
            Returnresponse_array.CardType = response_array(51)
        Catch ex As Exception 'will fail if submission faisl and there are not enough elements

        End Try

        ' individual elements of the array could be accessed to read certain response_array
        ' fields.  For example, response_array_array(0) would return the response_array Code,
        ' response_array_array(2) would return the response_array Reason Code.
        ' for a list of response_array fields, please review the AIM Implementation Guide

        Return Returnresponse_array
    End Function
    Private Function GetApiLogin(ByRef site As String)
        Dim retval As String
        retval = ConfigurationManager.AppSettings(site & "ApiLogin")

        Return retval
    End Function
    Private Function GetTransactionKey(ByRef site As String)
        Dim retval As String

        retval = ConfigurationManager.AppSettings(site & "TransactionKey")
        Return retval
    End Function
End Class
