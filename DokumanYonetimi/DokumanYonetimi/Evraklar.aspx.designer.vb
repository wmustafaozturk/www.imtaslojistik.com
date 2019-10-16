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


Partial Public Class Evraklar
    
    '''<summary>
    '''form1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents form1 As Global.System.Web.UI.HtmlControls.HtmlForm
    
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
    '''Btn_Evrak_Ara denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Evrak_Ara As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Btn_Firma_Sec_Ara denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Firma_Sec_Ara As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Btn_Evrak_Ekle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Evrak_Ekle As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''Btn_iptal denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_iptal As Global.System.Web.UI.HtmlControls.HtmlAnchor
    
    '''<summary>
    '''LblId denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents LblId As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Label1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''LblDosyaAdi denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents LblDosyaAdi As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Beyanname_id denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Beyanname_id As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Div_Beyannameler denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Beyannameler As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''GridView1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents GridView1 As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Div_Evrak_Ekle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Evrak_Ekle As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''TXT_FIRMA_ID denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_FIRMA_ID As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Btn_Evrak_Ekle_Firma_Sec denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Evrak_Ekle_Firma_Sec As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''TXT_FIRMA_ADI denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents TXT_FIRMA_ADI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''FileUpload1 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents FileUpload1 As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Btn_Evrak_Yukle denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Evrak_Yukle As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Btn_Beyanname_Kaydet_Iptal denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Btn_Beyanname_Kaydet_Iptal As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Div_Beyanname_Sec denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents Div_Beyanname_Sec As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''GridView2 denetimi.
    '''</summary>
    '''<remarks>
    '''Otomatik üretilmiş alan.
    '''Değiştirmek için, alan bildirimini tasarımcı dosyasından arka plan kod dosyasına taşıyın.
    '''</remarks>
    Protected WithEvents GridView2 As Global.System.Web.UI.WebControls.GridView
End Class
