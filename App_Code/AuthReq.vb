Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema

<Serializable()> Public Class AuthReq

    Private _amount As String
    Private _expdate As String
    Private _cardfname As String
    Private _cardlname As String
    Private _code As String
    Private _cardnum As String
    Private _type As String
    Private _method As String
    Private _address As String
    Private _state As String
    Private _zip As String
    Private _orderid As String
    Private _email As String
    Private _site As String
    Private _custid As String
    Private _bankcustomername As String
    Private _bankname As String
    Private _bankaccounttype As String
    Private _bankaccountnumber As String
    Private _bankabacode As String
    Private _echecktype As String
    Private _city As String
    Public Sub New()

    End Sub
    Public Property Custid As String
        Get
            Return _custid
        End Get
        Set(value As String)
            _custid = value
        End Set
    End Property

    Public Property SiteName As String
        Get
            Return _site
        End Get
        Set(value As String)
            _site = value
        End Set
    End Property
    Public Property Address As String
        Get
            Return _address
        End Get
        Set(value As String)
            _address = value
        End Set
    End Property
    Public Property State As String
        Get
            Return _state
        End Get
        Set(value As String)
            _state = value
        End Set
    End Property
    Public Property City As String
        Get
            Return _city
        End Get
        Set(value As String)
            _city = value
        End Set
    End Property
    Public Property Zip As String
        Get
            Return _zip
        End Get
        Set(value As String)
            _zip = value
        End Set
    End Property
    Public Property OrderId As String
        Get
            Return _orderid
        End Get
        Set(value As String)
            _orderid = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property
    Public Property Method As String 'CC , EC
        Get
            Return _method
        End Get
        Set(value As String)
            _method = value
        End Set
    End Property
    Public Property echecktype As String
        Get
            Return _echecktype
        End Get
        Set(value As String)
            _echecktype = value
        End Set
    End Property
    Public Property TransType As String 'Auth_Cap,Auth_Only ect
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property
    Public Property bankaccounttype As String
        Get
            Return _bankaccounttype
        End Get
        Set(value As String)
            _bankaccounttype = value
        End Set
    End Property
    Public Property bankname As String
        Get
            Return _bankname
        End Get
        Set(value As String)
            _bankname = value
        End Set
    End Property
    Public Property bankcustomername As String
        Get
            Return _bankcustomername
        End Get
        Set(value As String)
            _bankcustomername = value
        End Set
    End Property
    Public Property bankaccountnumber As String
        Get
            Return _bankaccountnumber
        End Get
        Set(value As String)
            _bankaccountnumber = value
        End Set
    End Property
    Public Property bankabacode As String
        Get
            Return _bankabacode
        End Get
        Set(value As String)
            _bankabacode = value
        End Set
    End Property
    Public Property CardNum As String
        Get
            Return _cardnum
        End Get
        Set(value As String)
            _cardnum = value
        End Set
    End Property
    Public Property SecurityCode As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set
    End Property
    Public Property Amount As String
        Get
            Return _amount
        End Get
        Set(value As String)
            _amount = value
        End Set
    End Property
    Public Property ExpDate As String
        Get
            Return _expdate
        End Get
        Set(value As String)
            _expdate = value
        End Set
    End Property
    Public Property CardFname As String
        Get
            Return _cardfname
        End Get
        Set(value As String)
            _cardfname = value
        End Set
    End Property
    Public Property CardLname As String
        Get
            Return _cardlname
        End Get
        Set(value As String)
            _cardlname = value
        End Set
    End Property
End Class
