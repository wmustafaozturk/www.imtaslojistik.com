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


Partial Public Class HaberGiris
    
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
    '''BtnAra denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnAra As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Kayit_id denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Kayit_id As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''BtnHaberEkle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnHaberEkle As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
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
    '''Div_Haber_Ekle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Haber_Ekle As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''TXT_HABER_BASLIK denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_HABER_BASLIK As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_HABER_DETAY denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_HABER_DETAY As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''TXT_HABER_YAYINLAMA_TARIHI denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_HABER_YAYINLAMA_TARIHI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''BtnHaberKaydet denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnHaberKaydet As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''BtnHaberGuncelleKaydet denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnHaberGuncelleKaydet As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''BtnHaberIptal denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents BtnHaberIptal As Global.System.Web.UI.WebControls.Button
End Class
