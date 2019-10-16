'------------------------------------------------------------------------------
' <otomatik üretildi>
'     Bu kod bir araç tarafından oluşturuldu.
'
'     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
'     kod tekrar üretildi. 
' </otomatik üretildi>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Users
    
    '''<summary>
    '''form1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents form1 As Global.System.Web.UI.HtmlControls.HtmlForm
    
    '''<summary>
    '''ScriptManager1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents ScriptManager1 As Global.System.Web.UI.ScriptManager
    
    '''<summary>
    '''UpdatePanel1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents UpdatePanel1 As Global.System.Web.UI.UpdatePanel
    
    '''<summary>
    '''BtnYonetimRapor denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnYonetimRapor As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''TxtAra denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TxtAra As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''BtnKullaniciAra denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnKullaniciAra As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Kullanici_id denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Kullanici_id As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''BtnKullaniciEkle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnKullaniciEkle As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''Div_Kullanicilar_Grid denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Kullanicilar_Grid As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''GridView1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents GridView1 As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Div_KullaniciEkle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_KullaniciEkle As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''TXT_KULLANICI_ADI denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_KULLANICI_ADI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_PAROLA denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_PAROLA As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_FIRMA_ADI denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_FIRMA_ADI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_FIRMA_ADRESI denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_FIRMA_ADRESI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''BtnKullaniciKaydet denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnKullaniciKaydet As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''BtnKullaniciGuncelleKaydet denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnKullaniciGuncelleKaydet As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''BtnKullaniciIptal denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnKullaniciIptal As Global.System.Web.UI.WebControls.Button
End Class
