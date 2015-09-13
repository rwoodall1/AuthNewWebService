Imports System

<Serializable()> Public Class Response

    Private _approved As Boolean
    Private _amount As String
    Private _authcode As String
    Private _transid As String
    Private _cardnum As String
    Private _message As String
    Private _transactiontype As String
    Private _method As String
    Private _email As String
    Private _cardtype As String
    Private _custid As String

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
    Public Property CardType As String
        Get
            Return _cardtype
        End Get
        Set(value As String)
            _cardtype = value
        End Set
    End Property
    Public Property TransActionType As String
        Get
            Return _transactiontype
        End Get
        Set(value As String)
            _transactiontype = value
        End Set
    End Property
    Public Property Approved As Boolean
        Get
            Return _approved
        End Get
        Set(value As Boolean)
            _approved = value
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
    Public Property AuthCode As String
        Get
            Return _authcode
        End Get
        Set(value As String)
            _authcode = value
        End Set
    End Property
    Public Property TransId As String
        Get
            Return _transid
        End Get
        Set(value As String)
            _transid = value
        End Set
    End Property
    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
        End Set
    End Property
    Public Property Method As String
        Get
            Return _method
        End Get
        Set(value As String)
            _method = value
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
    Public Property CardNum As String
        Get
            Return _cardnum
        End Get
        Set(value As String)
            _cardnum = value
        End Set
    End Property
    Public Function GetText(val As String) As String
        Dim retval As String = ""
        Select Case val
            Case "1"
                retval = "Approved"
            Case "2"
                retval = "Declined"
            Case "3"
                retval = "Error"
            Case "4"
                retval = "Held for Review"

        End Select
        Return retval
    End Function
End Class
