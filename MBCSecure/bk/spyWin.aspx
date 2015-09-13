<%@ Page Language="VB" AutoEventWireup="false" CodeFile="spyWin.aspx.vb" Inherits="spyWin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsorder" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MbcConn %>" 
            DeleteCommand="DELETE FROM orders WHERE (orderid = @orderid)" 
            ProviderName="<%$ ConnectionStrings:MbcConn.ProviderName %>">
            <DeleteParameters>
                <asp:SessionParameter DefaultValue="0" Name="orderid" SessionField="orderid" />
            </DeleteParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
