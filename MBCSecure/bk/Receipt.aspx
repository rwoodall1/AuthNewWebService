<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Receipt.aspx.vb" Inherits="receipt" %>

<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Receipt</title>

<link href="css/authnet_forms.css" rel="stylesheet" type="text/css" />
<link href='http://fonts.googleapis.com/css?family=Titillium+Web:400,700italic,600italic,400italic,300italic,200italic,200,600,300,700,900' rel='stylesheet' type='text/css'/>
<link href='http://fonts.googleapis.com/css?family=Exo:400,800,900' rel='stylesheet' type='text/css'/>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
    </head>
<body background="Images/background.jpg" link="blue">
    <form id="form1" runat="server">
<div id="page">

<div id="headline">Thank you for your payment</div>
<div class="header">
    <a href="http://memorybook.com/">
        <img src="css/header2.png" alt="Memory Book Header" width="292" height="120" border="0"></a></div>
<div class="swoosh_container">
</div>
<div class="body_copy_container_Fullwidth" style="text-align:center; padding-bottom:30px">
<div>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="dsorder">
        <ItemTemplate>
            <table style="width: 832px">
<tr>
<td align="left" class="style1">School Name:  
    <asp:Label ID="lblschname" 
        runat="server" Text='<%# bind("schname") %>' Font-Bold="True"></asp:Label></td>
    <td align="left" class="style1">Schcode:
    <asp:Label ID="lblschcode" runat="server" Font-Bold="True" 
            Text='<%# bind("schcode") %>'></asp:Label> </td>
    <td class="style1" align="left">
        Order Date:<asp:Label ID="lblorderdate" runat="server" Font-Bold="True" 
            Text='<%# bind("orddate") %>'></asp:Label>
    </td>
</tr>
<tr>
<td align="left" class="style5">Email Address:
    <asp:Label ID="lblemail" runat="server" Font-Bold="True" 
        Text='<%# bind("emailaddress") %>'></asp:Label> </td> 
       <td class="style4" align="left"> Order Id:
        <asp:Label ID="lblorderid" runat="server" Font-Bold="True" 
               Text='<%# bind("orderid") %>'></asp:Label>  </td>
    <td align="left">
        Pay Type:<asp:Label ID="lblpaytype" runat="server" Font-Bold="True" 
            Text='<%# bind("paytype") %>'></asp:Label>
    </td>
</tr>
                <tr>
                    <td align="left" class="style5">
                        Transaction Id:<asp:Label ID="lbltansactionid" runat="server" 
                            Text='<%# bind("transid") %>' Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" class="style4">
                        Authorization Code:<asp:Label ID="lblauthcode" runat="server" Font-Bold="True" 
                            Text='<%# bind("authcode") %>'></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
</table> 
        </ItemTemplate>
    </asp:FormView>

</div>
<div align="left">
<asp:GridView ID="gv1" runat="server" Width="838px" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" DataSourceID="dsorder" BorderColor="Black" 
        BorderStyle="Solid" BorderWidth="3px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Qty">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("itemqty") %>'></asp:Label>
                    @<br />
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("itemamount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Student\Book Type">
                <EditItemTemplate>
                  
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("studentfname") %>'></asp:Label>
                    &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Bind("studentlname") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("booktype") %>'></asp:Label>
                    <br />
                </ItemTemplate>
                <ItemStyle Width="250px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Teacher\Grade">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("teacher") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("grade") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line 1 Text\Line 2 Text">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("perstext1") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("perstext2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Total">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("itemtotal") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="75px" HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

</div>
<div style="height: 35px">
<div style="float: left; font-style: italic;">
For questions about your yearbook order contact you schools yearbook advisor.
</div>
  
<div align="right" style="height: 31px; float: right;">

    <asp:FormView ID="FormView2" runat="server" DataSourceID="dstotal">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text="Total: "></asp:Label>
        <asp:TextBox ID="txttotal" runat="server" ReadOnly="True" Width="60px" 
                Text='<%# bind("total") %>'></asp:TextBox>
        </ItemTemplate>

    </asp:FormView>
  
    </div>
    <br />


    </div>
    <div align="right">
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="Blue">Email Receipt</asp:LinkButton>
    </div>
  <asp:SqlDataSource ID="dsorder" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MbcConn %>" 
            ProviderName="<%$ ConnectionStrings:MbcConn.ProviderName %>" 
            
            
            
            
        
        
        
        
        
        
        SelectCommand="SELECT invoiceinfo.schname, `orders`.id, `orders`.grade, `orders`.booktype, `orders`.teacher, `orders`.perstext1, `orders`.perstext2, `orders`.emailaddress, `orders`.schcode, `orders`.itemamount, `orders`.schinvoicenumber, `orders`.orderid, `orders`.itemqty, `orders`.orddate, `orders`.itemtotal, payment.authcode, payment.transid, payment.ccnum, payment.paytype, `orders`.studentlname, `orders`.studentfname FROM invoiceinfo INNER JOIN `orders` ON invoiceinfo.schcode = `orders`.schcode LEFT OUTER JOIN payment ON `orders`.orderid = payment.orderid WHERE (`orders`.orderid = @orderid)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="@orderid" 
                    QueryStringField="orderid" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dstotal" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MbcConn %>" 
            ProviderName="<%$ ConnectionStrings:MbcConn.ProviderName %>" 
            
            
            
            
        
        
        SelectCommand="SELECT SUM(itemtotal) AS total FROM `orders` WHERE (orderid = @orderid)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="17" Name="@orderid" 
                    QueryStringField="orderid" />
            </SelectParameters>
        </asp:SqlDataSource>

    <eo:MsgBox ID="MsgBox1" runat="server" BackColor="#EBEBEB" 
        CloseButtonUrl="00070301" ControlSkinID="None" HeaderHtml="Dialog Title" 
        Height="216px" Width="320px">
        <HeaderStyleActive CssText="padding-right: 3px; padding-left: 8px; font-weight: bold; font-size: 10pt; background-image: url(00020213); padding-bottom: 3px; color: white; padding-top: 0px; font-family: 'trebuchet ms';height:20px;" />
        <ContentStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma" />
        <FooterStyleActive CssText="padding-right: 4px; padding-left: 4px; font-size: 8pt; padding-bottom: 4px; padding-top: 4px; font-family: tahoma" />
        <BorderImages BottomBorder="00020212" BottomLeftCorner="00020207" 
            BottomRightCorner="00020208" LeftBorder="00020210" RightBorder="00020211" 
            TopBorder="00020209" TopLeftCorner="00020201" TopLeftCornerBottom="00020203" 
            TopLeftCornerRight="00020202" TopRightCorner="00020204" 
            TopRightCornerBottom="00020206" TopRightCornerLeft="00020205" />
    </eo:MsgBox> 



</div>

<div style="clear:left"></div>
<div class="orange_spacer"></div>

<div class="page_footer"> Memory Book Company • © Copyright 2013 • All rights reserved 
</div>
</div>

<script type="text/javascript">
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-355460-1']);
  _gaq.push(['_setDomainName', 'memorybook.com']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
</script>
    </form>
</body>
</html>