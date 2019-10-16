Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls.TextBox
Imports System.Web.UI.WebControls.DropDownList
Imports System.Web.Configuration
Imports System.Xml
Imports System.Xml.Linq
Imports System.Drawing
Imports System.IO
Public Class Users
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Giris") = "Evet" Then
            Response.Cookies.Add(New HttpCookie("returnUrl", Request.Url.PathAndQuery))
            Response.Redirect("login.aspx")
        End If
        If (IsPostBack) = False Then
            FIRMALAR_GRIDLE()

            'FIYAT_LISTESI_GRIDLE()
            'MALZEME_LISTESI_GRIDLE()
        Else

        End If

    End Sub
    Private Sub FIRMALAR_GRIDLE()
        Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("XML/Firmalar.xml"))
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub
    Private Sub BtnKullaniciAra_Click(sender As Object, e As EventArgs) Handles BtnKullaniciAra.Click
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(Server.MapPath("XML/Firmalar.xml"), New XmlReaderSettings())
        Dim ds As DataSet = New DataSet()
        'Dim dv As DataView
        ds.ReadXml(xmlFile)
        'dv = New DataView(ds.Tables(0), "den teks", "Firma_Adi", DataViewRowState.CurrentRows)
        'ds.Tables(0).DefaultView.RowFilter = "Firma_Adi ='" + TxtAra.Text + "'"
        Dim dataView As DataView = ds.Tables(0).DefaultView
        dataView.RowFilter = "Firma_Adi Like '%" & TxtAra.Text & "%'"

        GridView1.DataSource = dataView
        GridView1.DataBind()
    End Sub
    Protected Sub secilenirenklendir(sender As Object, e As EventArgs)
        For Each row As GridViewRow In GridView1.Rows
            If row.RowIndex = GridView1.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            End If
        Next
    End Sub
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        'mouse üzerine gelice satır renklendirmek için
        If e.Row.RowType = System.Web.UI.WebControls.DataControlRowType.DataRow Then
            ' when mouse is over the row, save original color to new attribute, and change it to highlight color
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#AFAFAF'")
            ' when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;")
        End If

        '//////gridview kolon gizleme//////
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(2).Visible = False
            Next
        End If
        '//////gridview kolon gizleme//////

    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Kullanici_id.Text = GridView1.SelectedRow.Cells(2).Text
    End Sub
    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "BtnGridKullaniciGuncelle" Then
            If Kullanici_id.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_SECINIZ_GUNCELLE();", True)
                Exit Sub
            End If
            Dim txtFIRMA_KULLANICI_ADI As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtFirma_Kullanici_Adi"), TextBox)
            Dim txtFirma_Sifre As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtFirma_Sifre"), TextBox)
            Dim txtFirma_Adi As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtFirma_Adi"), TextBox)
            Dim txtFirma_Adresi As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtFirma_Adresi"), TextBox)


            Dim relPath As String = "XML/Firmalar.xml"
            Dim absPath As String = Server.MapPath(relPath)


            Dim x As XDocument = XDocument.Load(absPath)
            Dim node As XElement = x.Element("Firmalar").Elements("FirmaBilgileri").FirstOrDefault(Function(a) a.Element("Firma_id").Value.Trim() = Kullanici_id.Text)

            If node IsNot Nothing Then
                node.SetElementValue("Firma_Kullanici_Adi", txtFIRMA_KULLANICI_ADI.Text)
                node.SetElementValue("Firma_Sifre", txtFirma_Sifre.Text)
                node.SetElementValue("Firma_Adi", txtFirma_Adi.Text)
                node.SetElementValue("Firma_Adresi", txtFirma_Adresi.Text)
                x.Save(absPath)
            End If
            FIRMALAR_GRIDLE() ' Yeni kaydı ekranda göstermek için verileri ekrana döken yordam çağrılıyor.
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_GUNCELLENDI();", True)
            Kullanici_id.Text = ""
        End If

        ' BU BOLUM KAPATILDI ACILAN FIRMAYA EVRAK EKLENDIĞI ICIN SILINMEMESI GEREK
        'If e.CommandName = "BtnKullaniciSil" Then
        '    If Kullanici_id.Text = "" Then
        '        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_SECINIZ();", True)
        '        Exit Sub
        '    End If
        '    Dim relPath As String = "XML/Firmalar.xml"
        '    Dim absPath As String = Server.MapPath(relPath)
        '    Dim xml As XDocument = XDocument.Load(absPath)
        '    xml.Root.Elements().Where(Function(a) a.Element("Firma_id").Value = Kullanici_id.Text).Remove()
        '    xml.Save(absPath)
        '    Response.Redirect("Users.aspx")
        'End If
    End Sub
    Private Sub BtnKullaniciEkle_ServerClick(sender As Object, e As EventArgs) Handles BtnKullaniciEkle.ServerClick
        Div_Kullanicilar_Grid.Visible = False
        Div_KullaniciEkle.Visible = True
        TxtAra.Visible = False
        BtnKullaniciAra.Visible = False
        BtnKullaniciEkle.Visible = False
    End Sub

    Private Sub BtnKullaniciIptal_Click(sender As Object, e As EventArgs) Handles BtnKullaniciIptal.Click
        Response.Redirect("Users.aspx")
    End Sub
    Private Sub BtnKullaniciKaydet_Click(sender As Object, e As EventArgs) Handles BtnKullaniciKaydet.Click
        If TXT_KULLANICI_ADI.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_ADI();", True)
            Exit Sub
        End If
        If TXT_PAROLA.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_PAROLA();", True)
            Exit Sub
        End If


        Dim xmlyol As String = Server.MapPath("XML/Firmalar.xml") ' verilerin olduğu xml dosyasının yolu alınıyor
        Dim ds As New DataSet
        ds.ReadXml(xmlyol) ' Dataset nesnesi tarafından okunan yoldaki xml veri dosyası okunuyor ve dataset olusturuluyor.
        Dim Firma_id As Integer
        Dim sonsatirno As Integer = ds.Tables(0).Rows.Count - 1 'xml dosyasındaki son kayıt bulunuyor.
        Firma_id = ds.Tables(0).Rows(sonsatirno)(0) + 1 ' Bulunan kayıtın ID numarasına 1 eklenerek yeni ID no olusturuluyor.
        Dim yenikayit As DataRow = ds.Tables(0).NewRow ' yeni bir kayıt satırı oluşturuluyor
        yenikayit("Firma_id") = Firma_id
        yenikayit("Firma_Kullanici_Adi") = TXT_KULLANICI_ADI.Text
        yenikayit("Firma_Sifre") = TXT_PAROLA.Text
        yenikayit("Firma_Adi") = TXT_FIRMA_ADI.Text
        yenikayit("Firma_Adresi") = TXT_FIRMA_ADRESI.Text

        ds.Tables(0).Rows.Add(yenikayit) ' Kayıt satırına eşitlenen bilgiler toplam bir satır olarak dataset nesnesine ekleniyor.
        ds.WriteXml(xmlyol) 'Yeni kayıt eklendikten sonra xml dosyasının yeni hali tekrar yazılarak kayıt yapılmış oluyor.
        FIRMALAR_GRIDLE() ' Yeni kaydı ekranda göstermek için verileri ekrana döken yordam çağrılıyor.


        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_EKLENDI();", True)
        Div_KullaniciEkle.Visible = False
        Div_Kullanicilar_Grid.Visible = True
        TXT_FIRMA_ADI.Text = ""
        TXT_KULLANICI_ADI.Text = ""
        TXT_PAROLA.Text = ""
        TXT_FIRMA_ADRESI.Text = ""
    End Sub
End Class