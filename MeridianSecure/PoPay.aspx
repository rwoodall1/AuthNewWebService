<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PoPay.aspx.vb" Inherits="PoPay" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<!DOCTYPE html>
<html lang="en"><!-- InstanceBegin template="/Templates/meridian_temp.dwt" codeOutsideHTMLIsLocked="false" -->
<head>

<!-- InstanceBeginEditable name="doctitle" -->
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
top: 45%;
left: 30%;
width: 500px;
height:500px;
padding: 0px;
text-align:center;
background-color: transparent;
z-index:2002;
overflow: auto;
}
.label
{font-size:16px;
 
}
    #mb
    {
        height: 199px;
        width: 995px;
    }
    .style1
    {
        width: 672px;
    }
    .style2
    {
        height: 29px;
    }
    .style3
    {
        width: 672px;
        height: 29px;
    }
    </style>
<!-- InstanceEndEditable -->
	<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
       <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    <link href="css/my-styles.css" rel="stylesheet" media="screen">
    <link href="css/bootstrap-theme.css" rel="stylesheet" type="text/css">
   
  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
      <link href="../css/ifIE8.css" rel="stylesheet">
    <![endif]-->
<!-- InstanceBeginEditable name="head" -->


<meta name="Keywords" content="planner cover, planner covers, student planner cover, student planner covers, best student planner covers" />
<meta name="Description" content="Select a standard planner and receive a free professionally-designed cover." />
<meta name="google-site-verification" content="Y2yOlQO1VkohmVhTwU_e-g6nzby-1rzEoxHcKH2mKc8" />
<link href="CSS/MER_online_pay.css" rel="stylesheet" type="text/css" />

<!-- InstanceEndEditable -->


    </head>

<body>

       

<!-- Navbar -->

    <div class="navbar navbar-default navbar-fixed-top">
      <div class="container">
      <div class="phone-number pull-right visible-lg"><b class="glyphicon glyphicon-phone-alt"></b>&nbsp;&nbsp;1-888-724-8512</div>     
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand main-logo" href="../index.html"></a>
        <div class="collapse navbar-collapse">
          <ul class="nav navbar-nav navbar-right">
            <!-- InstanceBeginEditable name="activeLink1" -->
            <li><a href="../index.html">home</a></li>
            <!-- InstanceEndEditable -->
			<!-- InstanceBeginEditable name="activeLink2" -->
            <li class="dropdown">
            <!-- InstanceEndEditable --> 
            	<a data-toggle="dropdown" href="#">eplanners<b class="caret"></b></a>
              <ul class="dropdown-menu">
                <li><a href="../prime-main.html">Meridian PRIME&#8482; eplanner</a></li>
                <li class="divider"></li>
                <li><a href="../prime-for-students.html">for students</a></li>
                <li><a href="../prime-for-teachers.html">for teachers</a></li>
                <li><a href="../prime-for-admin.html">for administrators</a></li>
                <li><a href="../prime-for-parent.html">for parents</a></li>
            </ul>
            </li>
            <!-- InstanceBeginEditable name="activeLink3" -->
            <li class="dropdown">
            <!-- InstanceEndEditable -->
              <a data-toggle="dropdown" href="#">printed planners<b class="caret"></b></a>
              <ul class="dropdown-menu">
                <li><a href="../meridian-student-planners.html">Meridian Student Planners</a></li>
                <li class="divider"></li>
                <li><a href="../primary-student-planner.html">primary school planner</a></li>
                <li><a href="../elementary-student-planner.html">elementary school planner</a></li>
                <li><a href="../middle-school-student-planner.html">middle school planner</a></li>
                <li><a href="../high-school-student-planner.html">high school student planner</a></li>
                <li class="divider"></li>
                <li><a href="../covers.html">covers</a></li>
                <li><a href="../folders-wall_charts/index.html">folders/wall charts</a></li>
                <li><a href="../accessories.html">accessories</a></li>
              </ul>
            </li>
            <!-- InstanceBeginEditable name="activeLink4" -->
            <li class="dropdown active">
            <!-- InstanceEndEditable -->
              <a data-toggle="dropdown" href="#">orders<b class="caret"></b></a>
              <ul class="dropdown-menu">
                <li><a href="http://www.meridianplanners.com/quote/">personalized quote</a></li>
                <li><a href="http://www.meridianplanners.com/Orders/">standard planners</a></li>
                <li><a href="http://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Doffice-products&field-keywords=meridian+student+planner&rh=n%3A1064954%2Ck%3Ameridian+student+planner" target='_blank'>Amazon</a></li>
                <li class="divider"></li>
                <li><a href="../customercenter.html">customer center</a></li>
              </ul>
              
            </li>

          </ul>
        </div>
      </div> 
<!-- End navbar -->
</div>

    <!-- Jumbotron -->
<!-- InstanceBeginEditable name="jumbotron" -->
 
<!-- InstanceEndEditable -->
    <!-- End Jumbotron -->

	<!-- e-Planner Content -->
<!-- InstanceBeginEditable name="Content1" -->
<div id="light" class="white_content" runat="server">  
    <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/MeridianSecure/Images/loading.gif" Height="62px" Width="74px" /><br /><br />
     <div class="label"><i> Contacting payment portal.....</i></div>
          </div>

<div id="fade" class="black_overlay"></div>
<form id="form1" runat="server">
  
	<div class="container cust-container">
    <h1>Payment</h1>
    <div class="title_center">
    <asp:HiddenField ID="hfschcode" runat="server" />
     <asp:HiddenField ID="hfpaytype" runat="server" Value="CC" />
	    <asp:Label ID="lblname" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lbladdress" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblcitystatezip" runat="server"></asp:Label>
	<br />
	
    </div>
	<div>
   <div id="body1">
 <div style="height: 36px">  
    <asp:RadioButtonList ID="rbpaytype" runat="server" 
        RepeatDirection="Horizontal" AutoPostBack="True" Height="16px" 
         Width="414px">
        <asp:ListItem Selected="True" Value="CC">Pay With Credit Card</asp:ListItem>
        <asp:ListItem Value="EC">Pay With E-Check</asp:ListItem>
    </asp:RadioButtonList> 
       
      </div>
   
 <div id="databody" style="height: 124px">
 <div id="datadesc" style="width: 1338px; float: left; height: 198px;">

 <div id="mb">
 <div style="width: 857px; float: left; height: 109px;">
 <table>
 <tr>
 <td align="right"> 
     <asp:Label ID="Label3" runat="server" 
             Text="Amount To Be Paid:" Font-Size="Small"></asp:Label>  </td> 
     <td class="style1">
         <asp:TextBox ID="txtamount" runat="server" Width="270px" Height="23px" 
        MaxLength="10" Font-Size="Small"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator 
             ID="RequiredFieldValidator9" runat="server" 
             ControlToValidate="txtamount" Display="Dynamic" 
             ErrorMessage="Amount is required" Font-Bold="True" ValidationGroup="gv1" 
             EnableClientScript="False" Font-Size="Smaller"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="cvamount" runat="server" ControlToValidate="txtamount" 
                 Display="Dynamic" Font-Bold="True" Font-Size="Smaller">Do not use currency symbols or Seperators.</asp:CustomValidator> </td>
 </tr>
 <tr>
 <td align="right"><asp:Label ID="Label6" runat="server" Text="Email Address:" 
         Font-Size="Small"></asp:Label> </td> <td class="style1">  <asp:TextBox ID="txtemail" 
             runat="server" Width="270px" 
        MaxLength="45" Font-Size="Small"></asp:TextBox>  
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
  ControlToValidate="txtemail" Display="Dynamic" 
  ErrorMessage="Email Address is Required" Font-Bold="True" 
  ValidationGroup="gv1" EnableClientScript="False" Font-Size="Smaller"></asp:RequiredFieldValidator>  </td>
 </tr>
 <tr>
 <td align="right" class="style2"> <asp:Label ID="Label11" runat="server" Text="Invoice/Po Number:" 
         Font-Size="Small"></asp:Label>  </td> <td class="style3">  
         <asp:TextBox ID="txtPo" 
             runat="server" Width="270px" Font-Size="Small"></asp:TextBox>  </td>
 </tr>
 </table>
</div>
  <div style="float: right; height: 110px; width: 134px;">
  
<script type="text/javascript" language="javascript">    var ANS_customer_id = "83749ad4-12da-4e7c-8d95-aa6fa3961da4";</script>
<script type="text/javascript" language="javascript" src="//verify.authorize.net/anetseal/seal.js" >
</script> <a href="http://www.authorize.net/" id="AuthorizeNetText" target="_blank">Electronic Commerce</a><br />
<br /><img src="Images/Verisign-Secured.png" alt=""/>
</div>

 </div>

 </div> 


 
    </div>
         
 
 <div>

  <asp:Panel ID="CCPanel" runat="server">
<div align="left" style="margin: 15px; height: 88px">
    <asp:Label ID="Label1" runat="server" Text="Credit Card Information" 
        Font-Bold="True" Font-Size="Large"></asp:Label>
    <br />
    <br />
    </div>
<div align="left" style="margin: 15px; height: 32px"> <img src="Images/visa1_37x23_a.jpg" alt="Visa" height="22" border="0" />
<img src="Images/mc_accpt_023_gif.jpg" alt="Master Card" height="20" border="0" />
<img src="Images/discover.jpg" alt="Discover" border="0" style="width: 36px; height: 20px" /> 
<img src="Images/pay_logo_amex.gif" alt="Amerex" width="33" height="20" border="0" /> 
    <br />
    </div>
<div id="ccinfo" style="margin: 15px">
<div id="labels" 
        style="float:left;text-align:right; height: 163px; padding-right: 5px;">
 <asp:Label ID="Label4" runat="server" Text="Credit Card Number:" Height="25px"></asp:Label>
 <br />
 <br />
<asp:Label ID="Label5" runat="server" Text="Security Code:" Height="25px"></asp:Label>
 <br />
 <br />

<asp:Label ID="Label7" runat="server" Text="First Name:" Height="25px"></asp:Label>
 <br />
 <br />
<asp:Label ID="Label8" runat="server" Text="Last Name:" Height="25px"></asp:Label>
 <br />
 <br />
<asp:Label ID="Label9" runat="server" Text="Enter Card Expiration Date:" 
        Height="25px"></asp:Label>

</div>
<div id="txtbox" style="float:left; width: 635px;">
<asp:TextBox ID="x_card_num" runat="server" Width="207px" MaxLength="16" 
        Height="25px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
        ID="RequiredFieldValidator3" runat="server" ControlToValidate="x_card_code" 
        Display="Dynamic" EnableClientScript="False" ErrorMessage="Enter a card number" 
        ValidationGroup="gv1" Font-Bold="True"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TextBox ID="x_card_code" runat="server" Height="25px" MaxLength="16" 
        Width="72px"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="x_card_code" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Enter a security code" ValidationGroup="gv1" 
        Font-Bold="True"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TextBox ID="x_first_name" runat="server" CausesValidation="True" 
        Height="25px" Width="200px" MaxLength="37"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator 
        ID="RequiredFieldValidator5" runat="server" ControlToValidate="x_first_name" 
        Display="Dynamic" EnableClientScript="False" ErrorMessage="Enter a first name" 
        ValidationGroup="gv1" Font-Bold="True"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TextBox ID="x_last_name" runat="server" CausesValidation="True" 
        Height="25px" Width="200px" MaxLength="37"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="x_last_name" Display="Dynamic" EnableClientScript="False" 
        ErrorMessage="Enter last name" ValidationGroup="gv1" Font-Bold="True"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True" 
        causesvalidation="True" CssClass="Text" Height="25px" validationgroup="1">
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
    &nbsp;<asp:Label ID="Label12" runat="server" Text="Month"></asp:Label>
        &nbsp;&nbsp; 
    <asp:DropDownList AutoPostBack="True" CssClass="Text" ID="ddlyear" 
          runat="server" causesvalidation="True" validationgroup="1" Height="25px">
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
            <asp:ListItem>2022</asp:ListItem>
            <asp:ListItem>2023</asp:ListItem>
        </asp:DropDownList> &nbsp;<asp:Label ID="Label10" runat="server" Text="Year"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator 
          ControlToValidate="ddlmonth" 
          ErrorMessage="Enter a month for expiration date" 
            ID="RequiredFieldValidator8" runat="server" candrag="error_text" 
            ValidationGroup="gv1" Display="Dynamic" EnableClientScript="False" 
        Font-Bold="True"></asp:RequiredFieldValidator>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
          ControlToValidate="ddlyear" 
          ErrorMessage="Enter a year for expiration date" ValidationGroup="gv1" 
            Display="Dynamic" EnableClientScript="False" Font-Bold="True"></asp:RequiredFieldValidator> 
</div>

<div style="clear:both">

</div>



</div>

 <div align="right">
     <asp:Button ID="ccsubmit" runat="server" Text="Submit Payment" Width="119px" 
        style="height: 26px" UseSubmitBehavior="False" ValidationGroup="gv1" 
         onclientclick="showoverlay()" />
        </div>
    </asp:Panel>
    <div id="feature1"></div>
<div id="feature2"></div>
  <asp:Panel ID="ECPanel" runat="server" Visible="False">
    <div align="left" style="margin: 15px; height: 110px">
        <asp:Label ID="Label2" runat="server" Text="E-Check Information" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
       
    </div>
    <div align="left">
   
       <ul>
        <li class="Text"><span class="Text">Customer&#39;s Name (as it appears on bank account)</span></li>
        <li class="error_text">
            <asp:TextBox ID="x_bank_acct_name" runat="server" Width="260px" Height="25px" 
                MaxLength="75"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfCustName" runat="server" 
                ControlToValidate="x_bank_acct_name" 
                ErrorMessage="Bank customer name is required" ValidationGroup="gv1" 
                Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
        </li>
        <li class="Text" style="margin-bottom:6px">Bank Name:</li>
        <li class="error_text">
            <asp:TextBox ID="x_bank_name" runat="server" ToolTip="Name of bank" 
                Width="260px" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfbankname" runat="server" 
                ControlToValidate="x_bank_name" ErrorMessage="Bank name is required" 
                ValidationGroup="gv1" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
        </li>
        <li class="Text" style="margin-bottom:6px">Bank Account Type: (choose one)</li>
        <li class="error_text">
            <asp:DropDownList ID="x_bank_acct_type" runat="server" AutoPostBack="True" 
                Height="25px" Width="260px">
                <asp:ListItem Selected="True"></asp:ListItem>
                <asp:ListItem>CHECKING</asp:ListItem>
                <asp:ListItem Value="BUSINESSCHECKING">BUSINESS CHECKING</asp:ListItem>
                <asp:ListItem>SAVINGS</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfacctype" runat="server" 
                ControlToValidate="x_bank_acct_type" 
                ErrorMessage="Account type is required" ValidationGroup="gv1" 
                Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
        </li>
        <li class="Text" style="margin-bottom:6px">Bank&#39;s ABA Routing Number:
            <span class="Textlink" onmouseout="MM_showHideLayers('feature1','','hide')" 
                onmouseover="MM_showHideLayers('feature1','','show')">What&#39;s This</span></li>
        <li class="error_text">
            <asp:TextBox ID="x_bank_aba_code" runat="server" causesvalidation="True" 
                MaxLength="9" ToolTip="First nine digits on check" Width="260px" 
                Height="25px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfRoutingnume" runat="server" 
                ControlToValidate="x_bank_aba_code" 
                ErrorMessage="Routing number is required" ValidationGroup="gv1" 
                Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
        </li>
        <li class="Text" style="margin-bottom:6px">Bank Account Number: &nbsp;
            <span class="Textlink" onmouseout="MM_showHideLayers('feature2','','hide')" 
                onmouseover="MM_showHideLayers('feature2','','show')">What&#39;s This</span></li>
        <li class="error_text">
            <asp:TextBox ID="x_bank_acct_num" runat="server" MaxLength="16" 
                ToolTip="Last section of digits on check" Width="260px" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfBankAcc" runat="server" 
                ControlToValidate="x_bank_acct_num" 
                ErrorMessage="Bank account number is required" ValidationGroup="gv1" 
                Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
        </li>
        </ul>
    </div>
    <div align="right">
        <asp:Button ID="ecsubmit" runat="server" Text="Submit Payment" Width="119px" 
        style="height: 26px" UseSubmitBehavior="False" ValidationGroup="gv1" 
            onclientclick="showoverlay()" />
        </div>
    </asp:Panel>
</div>


   </div> 

    </div>
 
	</div>   

    &nbsp;<!-- InstanceEndEditable --><!-- End e-Planner Content --><!-- Student Planner Content --><!-- InstanceBeginEditable name="Content2" --><div class="container">
 
  </div>
  
<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-6632598-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script><!-- InstanceEndEditable --><!-- End Student Planner Content -->    
  <script 'javascript'>
      function showoverlay() {
          document.getElementById('light').style.display = 'block'; document.getElementById('fade').style.display = 'block';
          setTimeout('hideoverlay()', 10000);
      }
      function hideoverlay() {
          document.getElementById('light').style.display = 'none'; document.getElementById('fade').style.display = 'none';
      }
</script>  
<!-- Footer -->
    <footer class="main-footer">
    <div class="container">         
	  <div class="row">
        <div class="col-sm-3">
          
               <asp:SqlDataSource ID="cus11" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:MeridianConn %>" 
                   ProviderName="<%$ ConnectionStrings:MeridianConn.ProviderName %>" 
                   
                   
                   SelectCommand="SELECT schcode, schname, schaddr, schcity, schstate, schzip FROM cust WHERE (schcode = @schcode)"></asp:SqlDataSource>
         
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
         
              <div class="mission-text">
                Our mission is to provide your school with a planner that will guide students through the year, help them stay organized and encourage communication between parents and teachers. Our planners are offered in print or as an interactive eplanner.
              </div>
          </div>
        <div class="col-sm-3 col-sm-offset-1">
            <ul class="link-list">
              <li class="heading"><b class="glyphicon glyphicon-calendar"></b>Planner Solutions</li>
              <li><a href="../prime-main.html">Electronic Planners
</a></li>
				<ul class="sub-link-list">
                <li><a href="../prime-for-students.html">for students</a></li>
                <li><a href="../prime-for-teachers.html">for teachers</a></li>
                <li><a href="../prime-for-admin.html">for administrators</a></li>
                <li><a href="../prime-for-parent.html">for parents</a></li>
                </ul>
				<li><a href="../meridian-student-planners.html">Printed Planners</a></li>
              <ul class="sub-link-list">
              <li><a href="../primary-student-planner.html">Primary Planners</a></li>
              <li><a href="../elementary-student-planner.html">Elementary Planners</a></li>
              <li><a href="../middle-school-student-planner.html">Middle School Planners</a></li>
				<li><a href="../high-school-student-planner.html">High School Planners</a></li>
              </ul>
             </ul>            
          </div>
        <div class="col-sm-3">
            <ul class="link-list">
              <li class="heading"><b class="glyphicon glyphicon-home"></b>More About Us</li>
              <li><a href="../aboutus.html">About Us</a></li>
              <li><a href="../contact/index.html">Contact Us</a></li>
              <li><a href="../privacypolicy.html">Privacy Policy</a></li>
            </ul>
            <ul class="link-list">
              <li class="heading"><b class="glyphicon glyphicon-map-marker"></b>Get in touch</li>
              <li>Meridian Student Planners</li>
              <li>3131 W Main Street</li>
              <li>Sedalia, MO 65301</li>
              <li><a href="mailto:sales@meridianplanners.com">sales@meridianplanners.com</a></li>
              <li>1-888-724-8512</li>
            </ul>
          </div>
          <div class="col-sm-2">
            <ul class="link-list">
              <li class="heading"><b class="glyphicon glyphicon-calendar"></b>Order</li>
              <li><a href="http://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Doffice-products&field-keywords=meridian+student+planner&rh=n%3A1064954%2Ck%3Ameridian+student+planner" target="_blank">Planners on Amazon</a></li>
              <li><a href="http://www.meridianplanners.com/Orders/">Standard Planners</a></li>
              <li><a href="http://www.meridianplanners.com/quote">Personalized Planners</a></li>
            </ul>
            <ul class="link-list">
              <li class="heading"><b class="glyphicon glyphicon-user"></b>Customer Center</li>
              <li><a href="../customercenter.html">Forms and Templates</a></li>
            </ul>
            <ul class="link-list">
              <li class="heading"><b class="glyphicon glyphicon-plus-sign"></b><a href="#">Extras</a></li>
              <li><a href="../folders-wall_charts/index.html">Folder/Wall Charts</a></li>
              <li><a href="../covers.html">Cover Options</a></li>
              <li><a href="../accessories.html">Accessories</a></li>
            </ul>
          </div>
      	</div>
          
            <div class="copyright">&copy; 2014 Meridian Student Planners</div>
            <div style="font-family: 'Arial Black'; font-size: medium">
          

        </div>
      
</form>

   </footer>

<!-- End of Footer -->  
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
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-6632598-1']);
  _gaq.push(['_trackPageview']);
  _gaq.push(['_trackEvent', 'demo_home', 'submit', 'index']);
  _gaq.push(['_trackEvent', 'demo_main', 'submit', 'prime_main']);
  _gaq.push(['_trackEvent', 'demo_student', 'submit', 'student']);
  _gaq.push(['_trackEvent', 'demo_teacher', 'submit', 'teacher']);
  _gaq.push(['_trackEvent', 'demo_parent', 'submit', 'parent']);
  _gaq.push(['_trackEvent', 'demo_admin', 'submit', 'admin']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>
 

<script src="http://code.jquery.com/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
  </body>
<!-- InstanceEnd --></html>
