<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Receipt1.aspx.vb" Inherits="Receipt1" %>


<!DOCTYPE html>
<html lang="en"><!-- InstanceBegin template="/Templates/meridian_temp.dwt" codeOutsideHTMLIsLocked="false" -->
<head>
<!-- InstanceBeginEditable name="doctitle" -->
<title>Meridian Student Planner</title>
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
<style type="text/css">
@media print {
    .navbar-right {display:none;}
    .main-footer .container{display:none}
}

</style>
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
          <ul class="nav navbar-nav navbar-right" > 
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
<form id="form1" runat="server">
	<div class="container cust-container">
    <h1>Receipt</h1>
    <div class="title_center">
    <asp:Label ID="Label4" runat="server" 
            Text="Thank you for your payment to Meridian Student Planners"></asp:Label>
	<br />
    </div>
	<div style="margin:0 auto;width:949px">			
     <p><%Response.Write(Session("addressinfo"))%>&nbsp;</p>   
     <p><%Response.Write(Session("ordermessage")) %>&nbsp;</p>    
    </div>	




	</div>   

</form>

<!-- InstanceEndEditable -->
    <!-- End e-Planner Content -->
     

<!-- Student Planner Content -->
<!-- InstanceBeginEditable name="Content2" -->
<div class="container">
  <div class="row">
    
    </div>
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
    
<!-- Footer -->
    <footer class="main-footer">
    <div class="container">         
	  <div class="row">
        <div class="col-sm-3">
           <div class="msp-logo"></div>
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
          
        </div>
        </div>
      </div>
</footer>
<!-- End of Footer --> 

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
