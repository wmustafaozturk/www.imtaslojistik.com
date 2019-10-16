<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HaberGiris.aspx.vb" Inherits="DokumanYonetimi.HaberGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Döküman Yönetimi Haber Giriş</title>
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
		<link rel="shortcut icon" href="../favicon.ico"/>
		<link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script>


<script type="text/javascript">
    function KULLANICI_ARA() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Aradığınız Kayıt Bulunamadı"
        });
    }

    function KULLANICI_SIL() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Kayıt Silinmiştir."
        });
    }

    function HABER_SECINIZ() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Lütfen silmek istediğiniz haberi seçiniz."
        });
    }
    function HABER_SECINIZ_GUNCELLE() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Lütfen güncellemek istediğiniz Kaydı seçiniz."
        });
    }

    function HABER_GUNCELLENDI() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Kayıt Güncellenmiştir."
        });
    }

    function MSG_FIRMA_ARA() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Aradığınız Kayıt Bulunamadı"
        });
    }
    function KULLANICI_EKLENDI() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Kayıt Eklenmiştir."
        });
    }

    function HABER_BASLIK() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Haber Başlığını Yazınız."
        });
    }

    function HABER_DETAY() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Haber Detayını Yazınız."
        });
    }

    function KULLANICI_FIRMA_ADI() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Kullanıcı firma seçin."
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

         <div class="container">
             <ul id="gn-menu" class="gn-menu-main">
				<li class="gn-trigger">
					<a class="gn-icon gn-icon-menu"><span>Menu</span></a>
					<!---<nav class="gn-menu-wrapper">
						<div class="gn-scroller">
							<ul class="gn-menu">
								
								<li><a runat="server" id="BtnYonetimRapor"  title="Yönetim Raporu">YRaporu</a></li>  
                             
								
								
							</ul>
						</div>
					</nav>-->
				</li>   
     
        
         <li>
                <asp:TextBox ID="TxtAra" runat="server" CssClass="TxtAra"></asp:TextBox>
                <asp:Button ID="BtnAra" runat="server" CssClass="BtnAra" ToolTip="Ara"/>               
                <asp:Label ID="Kayit_id" runat="server" Font-Bold="True" Visible="false" ></asp:Label>       
           

         </li>
         <li><a class="codrops-icon " runat="server" id="BtnHaberEkle"  title="Haber Ekle" name="Kaydet">Haber Ekle</a></li>
         <li><a class="codrops-icon " href="menu.aspx"><img src="images/home.png" /></a></li>

                                                                                        
             
   </ul>
<%--<div style="position:fixed;height:5px; width:100%; background-color:#0094ff;"></div>--%>
</div><!--end container-->

         <div id="Div_Kullanicilar_Grid" class="grid" runat="server" ><%--div başlangıç--%>

                 <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    AllowPaging="True"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                     OnSelectedIndexChanged = "secilenirenklendir"
                    AlternatingRowStyle-CssClass="alt" PageSize="50">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.png" ShowSelectButton="True" SelectText="Seç"  />
                         <asp:templatefield  headertext="GÜNCELLE"  >                             
                              
                             <ItemTemplate>                                
                                 <asp:Button ID="BtnGridGuncelle" runat="server" ToolTip="Guncelle"  CssClass="BtnGridGuncelle" CommandName="BtnGridGuncelle" />
                                 <asp:Button ID="BtnSil" runat="server" ToolTip="Sil"  CssClass="BtnSil" CommandName="BtnSil" />                                 
                             </ItemTemplate>
                          </asp:templatefield>

                        <asp:BoundField DataField="Kayit_id" HeaderText="ID"  />                                                
                        <asp:TemplateField  HeaderText ="HABER BAŞLIK"><ItemTemplate><asp:TextBox ID="txtHaber_Baslik"  runat="server" Text='<%# Bind("Haber_Baslik")%>' ></asp:TextBox></ItemTemplate></asp:TemplateField>                       
                        <asp:TemplateField  HeaderText ="HABER DETAY"><ItemTemplate><asp:TextBox ID="txtHaber_Detay"  runat="server" Text='<%# Bind("Haber_Detay")%>' ></asp:TextBox></ItemTemplate></asp:TemplateField>
                        <asp:TemplateField  HeaderText ="HABER YAYINLAMA TARİHİ" ><ItemTemplate><asp:TextBox ID="txtHaber_Yayinlama_Tarihi"    runat="server" Text='<%# Bind("Haber_Detay_Yayinlama_Tarihi")%>' ></asp:TextBox></ItemTemplate></asp:TemplateField>                        
                        
                        
                    </Columns>

                    <PagerStyle CssClass="pgr"></PagerStyle>
                </asp:GridView>
</div><%--div bitiş--%>




 <div id="Div_Haber_Ekle" class="KullaniciGiris" runat="server" visible="false" >
            
                <table class="mGrid">
                
                    <tr>
                        <td>Haber Başlık :</td>
                        <td>
                            <asp:TextBox ID="TXT_HABER_BASLIK" runat="server" CssClass="Tracking_Text1"></asp:TextBox></td>
                    </tr>   
                    <tr> 
                       <td>Haber Detay :</td>
                        <td>
                            <asp:TextBox ID="TXT_HABER_DETAY" runat="server" CssClass="Tracking_Text1"></asp:TextBox></td>
                    </tr>
                 
                    <tr>
                        <td>Haber Yayınlama Tarihi:</td>
                        <td>
                            <asp:TextBox ID="TXT_HABER_YAYINLAMA_TARIHI" runat="server" CssClass="Tracking_Text1"  ></asp:TextBox>
                         </td> 
                    </tr>
                   

                        <tr>
                            <td>
                                <asp:Button ID="BtnHaberKaydet" runat="server" CssClass="Tracking_Buttons" Text="Kaydet" />
                                <asp:Button ID="BtnHaberGuncelleKaydet" runat="server" CssClass="Tracking_Buttons" Text="Güncelle" Visible="False" />
                                <asp:Button ID="BtnHaberIptal" runat="server" CssClass="Tracking_Buttons" Text="İptal" />
                            </td>
                    </tr>
               
                </table>

    </div>
       
<%--IHRACAT BOLUM BITIS///////////////////////////////////////////////////////////////////////////////////////////////////--%>
        </ContentTemplate>
</asp:UpdatePanel>
       </div><!-- /container -->
    </form>
</body>
</html>
