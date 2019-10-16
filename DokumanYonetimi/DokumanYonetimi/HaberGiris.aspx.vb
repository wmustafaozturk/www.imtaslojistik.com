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
Public Class HaberGiris
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Giris") = "Evet" Then
            Response.Cookies.Add(New HttpCookie("returnUrl", Request.Url.PathAndQuery))
            Response.Redirect("login.aspx")
        End If
        If (IsPostBack) = False Then
            HABERLER_GRIDLE()

            'FIYAT_LISTESI_GRIDLE()
            'MALZEME_LISTESI_GRIDLE()
        Else

        End If
    End Sub
    Private Sub HABERLER_GRIDLE()
        Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("XML/Haberler.xml"))
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub
    Private Sub BtnAra_Click(sender As Object, e As EventArgs) Handles BtnAra.Click
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(Server.MapPath("XML/Haberler.xml"), New XmlReaderSettings())
        Dim ds As DataSet = New DataSet()
        'Dim dv As DataView
        ds.ReadXml(xmlFile)
        'dv = New DataView(ds.Tables(0), "den teks", "Firma_Adi", DataViewRowState.CurrentRows)
        'ds.Tables(0).DefaultView.RowFilter = "Firma_Adi ='" + TxtAra.Text + "'"
        Dim dataView As DataView = ds.Tables(0).DefaultView
        dataView.RowFilter = "Haber_Baslik Like '%" & TxtAra.Text & "%'"

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
        Kayit_id.Text = GridView1.SelectedRow.Cells(2).Text
    End Sub
    Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "BtnGridGuncelle" Then
            If Kayit_id.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "HABER_SECINIZ_GUNCELLE();", True)
                Exit Sub
            End If

            Dim txtHaber_Baslik As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtHaber_Baslik"), TextBox)
            Dim txtHaber_Detay As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtHaber_Detay"), TextBox)
            Dim txtHaber_Yayinlama_Tarihi As TextBox = DirectCast(GridView1.SelectedRow.Cells(0).FindControl("txtHaber_Yayinlama_Tarihi"), TextBox)

            Dim T2 As DateTime = txtHaber_Yayinlama_Tarihi.Text
            Dim TX2 As String = T2.Year & "/" & T2.Month & "/" & T2.Day


            Dim relPath As String = "XML/Haberler.xml"
            Dim absPath As String = Server.MapPath(relPath)


            Dim x As XDocument = XDocument.Load(absPath)
            Dim node As XElement = x.Element("Haberler").Elements("Haber").FirstOrDefault(Function(a) a.Element("Kayit_id").Value.Trim() = Kayit_id.Text)

            If node IsNot Nothing Then
                node.SetElementValue("Haber_Baslik", txtHaber_Baslik.Text)
                node.SetElementValue("Haber_Detay", txtHaber_Detay.Text)
                node.SetElementValue("Haber_Detay_Yayinlama_Tarihi", TX2)
                x.Save(absPath)
            End If
            HABERLER_GRIDLE() ' Yeni kaydı ekranda göstermek için verileri ekrana döken yordam çağrılıyor.
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "HABER_GUNCELLENDI();", True)
            Kayit_id.Text = ""
        End If


        If e.CommandName = "BtnSil" Then
            If Kayit_id.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "HABER_SECINIZ();", True)
                Exit Sub
            End If
            Dim relPath As String = "XML/Haberler.xml"
            Dim absPath As String = Server.MapPath(relPath)
            Dim xml As XDocument = XDocument.Load(absPath)
            xml.Root.Elements().Where(Function(a) a.Element("Kayit_id").Value = Kayit_id.Text).Remove()
            xml.Save(absPath)
            Response.Redirect("HaberGiris.aspx")
        End If
    End Sub
    Private Sub BtnHaberEkle_ServerClick(sender As Object, e As EventArgs) Handles BtnHaberEkle.ServerClick
        Div_Kullanicilar_Grid.Visible = False
        Div_Haber_Ekle.Visible = True
        TxtAra.Visible = False
        BtnAra.Visible = False
        BtnHaberEkle.Visible = False
    End Sub

    Private Sub BtnHaberIptal_Click(sender As Object, e As EventArgs) Handles BtnHaberIptal.Click
        Response.Redirect("Haberler.aspx")
    End Sub
    Private Sub BtnHaberKaydet_Click(sender As Object, e As EventArgs) Handles BtnHaberKaydet.Click
        If TXT_HABER_BASLIK.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "HABER_BASLIK();", True)
            Exit Sub
        End If
        If TXT_HABER_DETAY.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "HABER_DETAY();", True)
            Exit Sub
        End If

        Dim xmlyol As String = Server.MapPath("XML/Haberler.xml") ' verilerin olduğu xml dosyasının yolu alınıyor
        Dim ds As New DataSet
        ds.ReadXml(xmlyol) ' Dataset nesnesi tarafından okunan yoldaki xml veri dosyası okunuyor ve dataset olusturuluyor.
        Dim Kayit_id As Integer
        Dim sonsatirno As Integer = ds.Tables(0).Rows.Count - 1 'xml dosyasındaki son kayıt bulunuyor.
        Kayit_id = ds.Tables(0).Rows(sonsatirno)(0) + 1 ' Bulunan kayıtın ID numarasına 1 eklenerek yeni ID no olusturuluyor.
        Dim yenikayit As DataRow = ds.Tables(0).NewRow ' yeni bir kayıt satırı oluşturuluyor
        yenikayit("Kayit_id") = Kayit_id
        yenikayit("Haber_Baslik") = TXT_HABER_BASLIK.Text
        yenikayit("Haber_Detay") = TXT_HABER_DETAY.Text
        yenikayit("Haber_Detay_Yayinlama_Tarihi") = TXT_HABER_YAYINLAMA_TARIHI.Text


        ds.Tables(0).Rows.Add(yenikayit) ' Kayıt satırına eşitlenen bilgiler toplam bir satır olarak dataset nesnesine ekleniyor.
        ds.WriteXml(xmlyol) 'Yeni kayıt eklendikten sonra xml dosyasının yeni hali tekrar yazılarak kayıt yapılmış oluyor.
        HABERLER_GRIDLE() ' Yeni kaydı ekranda göstermek için verileri ekrana döken yordam çağrılıyor.


        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "KULLANICI_EKLENDI();", True)
        Div_Haber_Ekle.Visible = False
        Div_Kullanicilar_Grid.Visible = True
        TXT_HABER_BASLIK.Text = ""
        TXT_HABER_DETAY.Text = ""
        TXT_HABER_YAYINLAMA_TARIHI.Text = ""
    End Sub
End Class