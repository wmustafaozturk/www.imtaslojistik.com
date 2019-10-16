<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="DokumanYonetimi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/reset.css" type="text/css" media="all"/>
      <link href='http://fonts.googleapis.com/css?family=Asap' rel='stylesheet' type='text/css'/>
       <link rel="stylesheet" href="css/grid.css" type="text/css" media="all" />
      <script type="text/javascript" src="js/jquery-1.6.js" ></script>
      <script type="text/javascript" src="js/script.js"></script>
      <script type="text/javascript" src="js/content_switch.js"></script>
      <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
      <script type="text/javascript" src="js/superfish.js"></script>
      <script type="text/javascript" src="js/forms.js"></script>
      <script type="text/javascript" src="js/bgStretch.js"></script>
      <script type="text/javascript" src="js/jquery.color.js"></script>
      <script type="text/javascript" src="js/jquery.mousewheel.js"></script>
      <script type="text/javascript" src="js/jquery-ui.js"></script>
      <script type="text/javascript" src="js/cScroll.js"></script>
      <script type="text/javascript" src="js/jcarousellite.js"></script>
      <script src="js/googleMap.js" type="text/javascript"></script>
      <script src="js/jquery.msgBox.js" type="text/javascript"></script>
      <link href="css/msgBoxLight.css" rel="stylesheet" type="text/css"/>
      <link rel="stylesheet" type="text/css" media="screen" href="ana_slider/css/slider.css"/>
        <script type="text/javascript" src="ana_slider/js/tms-0.4.x.js"></script>
        

    <meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
		
		<meta name="description" content="Döküman Yönetimi" />
		<meta name="keywords" content="Döküman Yönetimi" />
		<meta name="author" content="Codrops" />
		
		<link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script>


 <script type="text/javascript">

     function Kullanici() {
         $.msgBox({
             title: "Döküman Yönetimi",
             content: "Lütfen Kullanıcı Adını Yazınız..."
         });
     }

     

     function Parola() {
         $.msgBox({
             title: "Döküman Yönetimi",
             content: "Lütfen Parolayı Yazınız..."
         });
     }
     function ParolaYanlis() {
         $.msgBox({
             title: "Döküman Yönetimi",
             content: "Girdiğiniz Bilgiler Yanlış Kontrol Edip Tekrar Deneyiniz..."
         });
     }


    
</script>
 
</head>
<body>
     <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="container">
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>	
			<ul id="gn-menu" class="gn-menu-main">
				<li class="gn-trigger">
					<a class="gn-icon gn-icon-menu"><span>Menu</span></a>
					<nav class="gn-menu-wrapper">
						<div class="gn-scroller">
							<ul class="gn-menu">						
							</ul>
						</div><!-- /gn-scroller -->
					</nav>
				</li>               
				<li><a class="codrops-icon " href="#"><img src="images/home.png" alt=""/></a></li>
			</ul>
         

<div id="KullaniciGiris" class="IthalatGiris" runat="server">            
            <table class="mGrid">               
                <tr>
                    <td>Kullanıcı Adı :</td>
                    <td>
                        <asp:TextBox ID="TxtKullaniciAdi" runat="server" CssClass="Tracking_Text1"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Şifre :</td>
                 <td>  <asp:TextBox ID="TxtSifre" runat="server" TextMode="Password" CssClass="Tracking_Text1"></asp:TextBox>
                    <asp:Button ID="BtnGiris" runat="server" CssClass="Tracking_Buttons" Text="Giriş" /></td>                                              
                </tr>                
            </table>      
</div>
<div class="logo"></div>
              </ContentTemplate>
              </asp:UpdatePanel>
</div><!-- /container -->
</form>      
</body>
</html>
