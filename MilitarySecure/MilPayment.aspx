<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MilPayment.aspx.vb" Inherits="MilPayment" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Payment</title>
<style>
.black_overlay
{

display:none;
position: absolute;
top: 0%;
left: 0%;
width: 100%;
height: 250%;
background-color:black;
z-index:2001;
-moz-opacity: 0.1;
opacity:.10;
filter: alpha(opacity=10);
}
.white_content 
{

display:none;
z-index:4;
position: absolute;
top: 60%;
left: 45%;
width: 500px;
height:500px;
padding: 0px;
text-align:center;
background-color: transparent;
z-index:2002;
overflow: auto;
}
.label
{font-size:22px;
 
}

</style>
<link href="css/authnet_forms_mil.css" rel="stylesheet" type="text/css" />
<link href="css/Military_web_styles.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#004080">
<div id="light" class="white_content">  
    <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/MilitarySecure/Images/loading.gif" Height="62px" Width="74px" /><br /><br />
     <div class="label"><i> Contacting payment portal.....</i></div>
          </div>
<div id="fade" class="black_overlay"></div>
<div id="page">
<div class="header"><img src="Images/membookmilitarybanner.jpg" width="900" height="120" alt="Military Memory Book" /></div>
<div class="wrapper">
    <ul id="nav">
      <li><a href="http://www.militaryyearbookprinting.com/index.html">Home</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/army-yearbooks.html">Army</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/navy-yearbooks.html">Navy</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/air-force-yearbooks.html">Air Force</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/marines-yearbooks.htmll">Marines</a>  </li>
      <li><a href="http://www.militaryyearbookprinting.com/coast-guard-yearbooks.html">Coast Guard</a></li>
      <li class="MenuBarItemSubmenu"><a href="http://www.militaryyearbookprinting.com/military-reunion-book.html">Reunions</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/about-us.html">About Us</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/create-your-military-yearbook.html">Create</a></li>
      <li><a href="http://www.militaryyearbookprinting.com/covers-bindings.html" class="MenuBarItemSubmenu">Covers/Binding</a>
         <ul>
            <li><a href="http://www.militaryyearbookprinting.com/yearbook-cover-designs.html">Covers</a></li>
            <li><a href="http://www.militaryyearbookprinting.com/yearbook-binding-designs.html">Binding</a></li>
            <li><a href="http://www.militaryyearbookprinting.com/enhancements.html">Enhancements</a></li>
         </ul>
      </li>
    </ul>
</div>
<div style="clear:both"></div>
    <div class="container">
        <div class="Col_one_fullpad"><span class="redtext"> <strong>&nbsp;</strong></span></div>
<!--Get unit code from sending html form -->
<form id="form1" runat="server">
<div class="form_element">
     <div align="left" style="height: 108px">
     <div style="width: 414px; float: left; height: 75px;">
         <asp:Label ID="Label3" runat="server" Text="Amount To Be Charged:" 
             Font-Size="Medium"></asp:Label> 
         <asp:Label ID="lblamount" runat="server" Text="0.00" Font-Bold="True"></asp:Label> 
     
         <br />
         <asp:Label ID="Label5" runat="server" Text="Order Id:" Font-Size="Medium"></asp:Label>
         <asp:Label ID="lblorderid" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
         <br />
         <asp:Label ID="Label6" runat="server" Text="Email Address:" Font-Size="Medium"></asp:Label>
         <asp:Label ID="lblemailaddress" runat="server" Font-Bold="True" 
             Font-Size="Medium"></asp:Label>
     </div>
    <div style="width: 237px; float: right;">
    
<script type="text/javascript" language="javascript">    var ANS_customer_id = "83749ad4-12da-4e7c-8d95-aa6fa3961da4";</script>
<script type="text/javascript" language="javascript" src="//verify.authorize.net/anetseal/seal.js" >
</script> <a href="http://www.authorize.net/" id="AuthorizeNetText" target="_blank">Electronic Commerce</a><br />
<br /><img src="Images/Verisign-Secured.png" alt="" width="58" height="29"/>

    </div>
         
     </div>
     
<div style="height: 28px" >
<asp:RadioButtonList ID="rbpaytype" runat="server" 
        RepeatDirection="Horizontal" AutoPostBack="True" 
        onselectedindexchanged="rbpaytype_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="CC">Pay With Credit Card</asp:ListItem>
        <asp:ListItem Value="EC">Pay With E-Check</asp:ListItem>
    </asp:RadioButtonList>
     </div>

<div id="feature1"></div>
<div id="feature2"></div>
 <asp:Panel ID="CCPanel" runat="server">
 <div style="height: 35px" >
<img src="Images/visa1_37x23_a.jpg" alt="Visa" height="22" border="0" /> 
<img src="Images/mc_accpt_023_gif.jpg" alt="Master Card" height="20" border="0" /> 
<img src="Images/discover.jpg" alt="Discover" border="0" style="width: 36px; height: 20px" /> 
<img src="Images/pay_logo_amex.gif" width="33" height="20" border="0" />
</div>
 <div style="height: 47px">
 Credit Card Number:&nbsp;
        <asp:TextBox ID="x_card_num" runat="server" Width="143px" MaxLength="16"></asp:TextBox>
  &nbsp;&nbsp;<span class="Text" style="margin-bottom:6px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Security Code</span>:&nbsp;
        <asp:TextBox ID="x_card_code" runat="server" Width="51px" MaxLength="16"></asp:TextBox>
        <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
         ControlToValidate="x_card_code" ErrorMessage="Enter a card number"></asp:RequiredFieldValidator>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
          ControlToValidate="x_card_code" ErrorMessage="Enter a security code"></asp:RequiredFieldValidator>
 </div>
 <div style="height: 46px">
 First Name:&nbsp;</span>
        <asp:TextBox ID="x_first_name" class="Test" runat="server" Width="200px" 
             CausesValidation="True"></asp:TextBox>
       &nbsp;&nbsp;&nbsp;<span class="Text" style="margin-bottom:6px">Last Name:</span>&nbsp;
        <asp:TextBox ID="x_last_name" class="Text" runat="server" Width="200px" 
             CausesValidation="True"></asp:TextBox>
       &nbsp;
    
        <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
          ControlToValidate="x_first_name" ErrorMessage="Enter a first name"></asp:RequiredFieldValidator>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
          ControlToValidate="x_last_name" ErrorMessage="Enter last name"></asp:RequiredFieldValidator>
 </div>
 <div style="height: 46px">
 Enter Card Expiration Date:&nbsp;&nbsp;
     <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True" 
         causesvalidation="True" CssClass="Text" validationgroup="1" Width="55px">
         <asp:ListItem></asp:ListItem>
         <asp:ListItem>01</asp:ListItem>
         <asp:ListItem>02</asp:ListItem>
         <asp:ListItem>03</asp:ListItem>
         <asp:ListItem>04</asp:ListItem>
         <asp:ListItem>05</asp:ListItem>
         <asp:ListItem>06</asp:ListItem>
         <asp:ListItem>07</asp:ListItem>
         <asp:ListItem>08</asp:ListItem>
         <asp:ListItem>09</asp:ListItem>
         <asp:ListItem>10</asp:ListItem>
         <asp:ListItem>11</asp:ListItem>
         <asp:ListItem>12</asp:ListItem>
     </asp:DropDownList>
     &nbsp;Month&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList AutoPostBack="True" CssClass="Text" ID="ddlyear" 
          runat="server" causesvalidation="True" validationgroup="1" Height="16px" 
         Width="68px">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>2012</asp:ListItem>
            <asp:ListItem>2013</asp:ListItem>
            <asp:ListItem>2014</asp:ListItem>
            <asp:ListItem>2015</asp:ListItem>
            <asp:ListItem>2016</asp:ListItem>
            <asp:ListItem>2017</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            <asp:ListItem>2021</asp:ListItem>
        </asp:DropDownList>
&nbsp;Year&nbsp;&nbsp;<span class="error_text"><br /> <asp:RequiredFieldValidator 
          ControlToValidate="ddlmonth" 
          ErrorMessage="Enter a month for expiration date" ID="RequiredFieldValidator8" runat="server" candrag="error_text"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
   
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
          ControlToValidate="ddlyear" 
          ErrorMessage="Enter a year for expiration date"></asp:RequiredFieldValidator>
  </div>
  <div style="height: 57px">
  Enter email address for receipt to your inbox: 
        <asp:TextBox ID="txtcustemail" runat="server" Width="391px"></asp:TextBox>
   
        <br />
   
        <asp:RegularExpressionValidator ID="emailvalidator" runat="server" 
          ControlToValidate="txtcustemail" ErrorMessage="Invalid format for email address" 
          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
          Display="Dynamic" Enabled="False"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
          runat="server" ControlToValidate="txtcustemail" 
          ErrorMessage="Email address is required." Display="Dynamic"></asp:RequiredFieldValidator>
  </div>

  <div align="right">
    
      <asp:Button ID="ccsubmit" runat="server" Text="Submit Payment" 
          style="margin-left: 48px" Width="114px" onclientclick="showoverlay()" />

  
  </div>

 </asp:Panel>

    <asp:Panel ID="ECPanel" runat="server" Visible="False">
  
<div style="height: 46px">
Customer's Name (as it appears on bank account):<br />
    <asp:TextBox ID="x_bank_acct_name" runat="server" Width="360px"></asp:TextBox> &nbsp; <asp:RequiredFieldValidator ID="rfCustName" runat="server" 
              ControlToValidate="x_bank_acct_name" 
              ErrorMessage="Bank customer name is required"></asp:RequiredFieldValidator>
</div>
<div style="height: 46px">
Bank Name: 
    <br />
    <asp:TextBox ID="x_bank_name" runat="server" Width="360px" 
              ToolTip="Name of bank"></asp:TextBox>&nbsp; <asp:RequiredFieldValidator ID="rfbankname" runat="server" 
              ControlToValidate="x_bank_name" ErrorMessage="Bank name is required"></asp:RequiredFieldValidator>
</div>
<div style="height: 46px">
Bank Account Type: (choose one) 
    <br />
    <asp:DropDownList ID="x_bank_acct_type" runat="server" 
            Height="25px" Width="360px" AutoPostBack="True">
            <asp:ListItem Selected="True"></asp:ListItem>
            <asp:ListItem>CHECKING</asp:ListItem>
            <asp:ListItem Value="BUSINESSCHECKING">BUSINESS CHECKING</asp:ListItem>
            <asp:ListItem>SAVINGS</asp:ListItem>
        </asp:DropDownList>&nbsp; <asp:RequiredFieldValidator ID="rfacctype" runat="server" 
              ControlToValidate="x_bank_acct_type" ErrorMessage="Account type is required"></asp:RequiredFieldValidator>
</div>
<div style="height: 46px">
Bank's ABA Routing Number: <span class="Textlink" onmouseover="MM_showHideLayers('feature1','','show')" onmouseout="MM_showHideLayers('feature1','','hide')">What's This<br />
    </span><asp:TextBox ID="x_bank_aba_code" runat="server" Width="360px" 
            causesvalidation="True" MaxLength="9" 
        ToolTip="First nine digits on check"></asp:TextBox> &nbsp; <asp:RequiredFieldValidator ID="rfRoutingnume" runat="server" 
            ControlToValidate="x_bank_aba_code" ErrorMessage="Routing number is required"></asp:RequiredFieldValidator>
</div>

<div style="height: 46px">
Bank Account Number: &nbsp; <span class="Textlink" onmouseover="MM_showHideLayers('feature2','','show')" onmouseout="MM_showHideLayers('feature2','','hide')">What's This</span> 
    <br />
    <asp:TextBox ID="x_bank_acct_num" runat="server" Width="360px" MaxLength="16" 
              ToolTip="Last section of digits on check"></asp:TextBox> &nbsp; <asp:RequiredFieldValidator ID="rfBankAcc" runat="server" 
              ControlToValidate="x_bank_acct_num" 
              ErrorMessage="Bank account number is required"></asp:RequiredFieldValidator>
</div>
<div>
Today's Payment Amount:<br />
    <asp:TextBox ID="x_amount" 
        runat="server" Width="360px" ReadOnly="True"></asp:TextBox> &nbsp; <asp:RequiredFieldValidator ID="rfpayment" runat="server" 
            ControlToValidate="x_amount" ErrorMessage="Payment amount is required"></asp:RequiredFieldValidator>
</div>
<div>
Email Address for receipt to be sent: 
    <br />
    <asp:TextBox ID="email1" 
              runat="server" Width="360px"></asp:TextBox>&nbsp; <asp:RequiredFieldValidator ID="rfEmail" runat="server" 
              ControlToValidate="email1" ErrorMessage="Email address is required"></asp:RequiredFieldValidator>
</div>
<div align="right">
    <asp:Button ID="ecpayment" runat="server" Text="Submit Payment" Width="116px" 
        onclientclick="showoverlay()" />
</div>
 </asp:Panel>
</div>
<div class="form_element_submitbutton">
<asp:SqlDataSource ID="dsorder" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MbcConn %>" 
        ProviderName="<%$ ConnectionStrings:MbcConn.ProviderName %>"></asp:SqlDataSource>
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
    <asp:HiddenField ID="x_schcode" runat="server" />
         <asp:HiddenField ID="hfschinvoicenumber" runat="server" />
          <asp:HiddenField ID="hfpaytype" runat="server" Value="CC" />

         <asp:HiddenField ID="hfschcode" runat="server" />

            <asp:SqlDataSource ID="cus11" runat="server" 
                    ConnectionString="Server=databases;User id=root;Password=3l3phant1;Persist Security Info=True;Database=mbc" 
                    ProviderName="MySql.Data.MySqlClient" 
                    SelectCommand="SELECT cust.* FROM cust"> </asp:SqlDataSource>
</div>

</form>
</div>

<div class="sidebar_right">
<div class="sidebar_time">
<script type="text/javascript">
    var d=new Date()
    var weekday=new Array("Sunday","Monday","Tuesday","Wednesday","Thursday",
                    "Friday","Saturday")
    var monthname=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug",
                    "Sep","Oct","Nov","Dec")
    document.write(weekday[d.getDay()] + ", ")
    document.write(monthname[d.getMonth()] + " ")
	document.write(d.getDate() + ", ")
    document.write(d.getFullYear())
          </script>
</div>
<div class="sidebar_sub" style="text-align:center; padding-top:10px; padding-bottom:10px; background-color:#666633">
  <strong class="Text10boldwhite">Printed In the USA/strong>
</div>
    </div>
<div style="clear:both"></div>
<div class="page_footer">
</div>
<div class="footer" id="copyright_footer">Memory Book Company &#8226; © Copyright 2012 &#8226; All rights reserved</div>
</div>
<script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">

try {
var pageTracker = _gat._getTracker("UA-355460-2");
pageTracker._trackPageview();
} catch (err) { }
</script>
<script type="text/javascript">
    onunload = launch_spyWin;
    function launch_spyWin() {
        spyWin = open('spyWin.aspx', 'spyWin',
        'width=1,height=1,left=0,top=0,status=0');
        spyWin.blur();
        window.focus;
    }

    function showoverlay() {
        document.getElementById('light').style.display = 'block'; document.getElementById('fade').style.display = 'block';
        setTimeout('hideoverlay()', 10000);
    }
    function hideoverlay() {
        document.getElementById('light').style.display = 'none'; document.getElementById('fade').style.display = 'none';
    }
</script>

<script type="text/javascript">
    function MM_showHideLayers() { //v9.0
        var i, p, v, obj, args = MM_showHideLayers.arguments;
        for (i = 0; i < (args.length - 2); i += 3)
            with (document) if (getElementById && ((obj = getElementById(args[i])) != null)) {
                v = args[i + 2];
                if (obj.style) { obj = obj.style; v = (v == 'show') ? 'visible' : (v == 'hide') ? 'hidden' : v; }
                obj.visibility = v;
            }
    }
</script>
</body>
</html>
