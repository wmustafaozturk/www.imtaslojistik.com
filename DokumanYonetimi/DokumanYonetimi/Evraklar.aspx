<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Evraklar.aspx.vb" Inherits="DokumanYonetimi.Evraklar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Döküman Yönetimi</title>
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
    
    function DOSYA_INDIR_SECINIZ() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Lütfen indirmek istediğiniz dosyayı seçiniz."
        });
    }

    function DOSYA_SIL_SECINIZ() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Lütfen Silmek istediğiniz dosyayı seçiniz."
        });
    }

    function Evrak_Bulunamadi() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Aradığınız Evrak Bulunamadı."
        });
    }

    

    function DOSYA_SECINIZ() {

        $.msgBox({
            title: "Döküman Yönetimi",
            content: "Dosya Seçiniz."
        });
    }
</script>
</head>
<body>
    <form id="form1" runat="server">

         <div class="container">
             <ul id="gn-menu" class="gn-menu-main" >
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
     
         <li> <asp:TextBox ID="TxtAra" runat="server" CssClass="Tracking_Text1"></asp:TextBox>               
              <asp:Button ID="Btn_Evrak_Ara" runat="server"    CssClass="BtnAra"  ToolTip="Ara"/>
                 <asp:Button ID="Btn_Firma_Sec_Ara" runat="server" CssClass="BtnBeyanname_Ara"  Visible="false"  ToolTip="Ara"/></li>
         
              
               
                  <li><a class="codrops-icon" id="Btn_Evrak_Ekle" runat="server" >EVRAK EKLE</a></li>                 
                   <li><a class="codrops-icon" id="Btn_iptal" runat="server" >İŞLEM İPTAL</a></li>


                 <asp:Label ID="LblId" runat="server" Font-Bold="false"></asp:Label>                                         
                 <asp:Label ID="Label1" runat="server" Font-Bold="false"></asp:Label>
                 <asp:Label ID="LblDosyaAdi" runat="server" Font-Bold="false"></asp:Label>
                 <li><asp:Label ID="Beyanname_id" runat="server" Font-Bold="true" Visible="true" ></asp:Label></li>
                 <li><a class="codrops-icon " href="menu.aspx"><img src="images/home.png" /></a></li>
                 
             
   </ul>

</div><!--end container-->

<div id="Div_Beyannameler" runat="server" class="grid">

                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    AllowPaging="True"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    OnSelectedIndexChanged = "secilenirenklendir"
                    AlternatingRowStyle-CssClass="alt" PageSize="100">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

                    <Columns>
                        <asp:BoundField DataField="Evrak_id" HeaderText="ID"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>  
                        <asp:BoundField DataField="Firma_Adi" HeaderText="Firma Adı"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>                         
                        <asp:BoundField DataField="dosya_adi" HeaderText="DOSYA ADI"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField> 
                        <%--<asp:BoundField DataField="dosya_uzt" HeaderText="dosya_uzt"><HeaderStyle BackColor="#006699" ForeColor="White" /></asp:BoundField>    --%>                     
                <asp:TemplateField >
                <ItemTemplate >
                    <%--<asp:Button ID="indir" CommandName="download" runat="server" CssClass="Tracking_Buttons" Text="INDIR" Visible="true"   />--%>
                    <asp:Button ID="BtnDosyaSil" CommandName="BtnDosyaSil" runat="server" CssClass="Tracking_Buttons" Text="Sil"  Visible="true"  />
                </ItemTemplate>
                </asp:TemplateField>                   
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/9.png" ShowSelectButton="True"  SelectText="Seç" />                        
                </Columns>
                    <FooterStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />                
                </asp:GridView>
</div>
        





<%--evrak ekle ///////////////////////////////////////////////////////////////////////////////////////////////--%>
 <div id="Div_Evrak_Ekle" class="KullaniciGiris" runat="server" visible="false" >
            
                <table class="mGrid">
                 <tr>
                        <td>FIRMA ID :</td>
                        <td>
                            <asp:TextBox ID="TXT_FIRMA_ID" runat="server" CssClass="Tracking_Text1" Enabled="false" ></asp:TextBox>
                         <asp:Button ID="Btn_Evrak_Ekle_Firma_Sec" runat="server" CssClass="Tracking_Buttons" Text="Firma Seç" ToolTip="Ara"/></td>
                    </tr>
                 <asp:TextBox ID="TXT_FIRMA_ADI" runat="server" CssClass="Tracking_Text1" VISIBLE="false"  ></asp:TextBox>
                    <tr> 
                       <td>Dosya :</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Tracking_Text1" AllowMultiple="true"/>                           
                            </td>
                    </tr>                   

                        <tr>
                            <td>
                                <asp:Button ID="Btn_Evrak_Yukle" runat="server" CssClass="Tracking_Buttons" Text="Kaydet" />                                
                                <asp:Button ID="Btn_Beyanname_Kaydet_Iptal" runat="server" CssClass="Tracking_Buttons" Text="İptal" />
                            </td>
                    </tr>
               
                </table>

    </div>
<%--evrak ekle  BITIS///////////////////////////////////////////////////////////////////////////////////////////////////--%>

<%--evrak ekleme firma seç////////////////////////////////////////////////////////////////////////////////////--%>
 <div id="Div_Beyanname_Sec" class="grid" runat="server" visible="false" >
    <asp:GridView ID="GridView2" runat="server"
                    AutoGenerateColumns="False"
                    GridLines="None"
                    AllowPaging="True"
                    CssClass="mGrid"
                    PagerStyle-CssClass="pgr"
                    
                    AlternatingRowStyle-CssClass="alt" PageSize="50">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="images/9.png"  ShowSelectButton="True" SelectText="Seç"/>
                    
                        <asp:BoundField DataField="Firma_id" HeaderText="ID"   />                        
                        <asp:BoundField DataField="Firma_Adi" HeaderText="BEYANNAME NUMARASI"/>                                           
                          
                    </Columns>

                    <PagerStyle CssClass="pgr"></PagerStyle>
                </asp:GridView>
					

</div>
<%--evrak ekleme firma seç////////////////////////////////////////////////////////////////////////////////////--%>

</form>
</body>
</html>
