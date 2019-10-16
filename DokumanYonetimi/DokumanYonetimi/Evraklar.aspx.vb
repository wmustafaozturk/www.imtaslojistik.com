Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration
Imports System.Xml
Imports System.Xml.Linq
Imports System.Web.UI
Imports System.Net
Imports System.Net.Dns
Imports System.IO
Imports System.Drawing
Public Class Evraklar
    Inherits System.Web.UI.Page
    Dim uzanti As String = ""
    Dim dosya_adi As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Giris") = "Evet" Then
            Response.Cookies.Add(New HttpCookie("returnUrl", Request.Url.PathAndQuery))
            Response.Redirect("login.aspx")
        End If
        If (IsPostBack) = False Then
            EVRAK_GRIDLE()
        Else
        End If
        'STR_KULLANICI_ADI = Session("KULLANICI_ADI").ToString()
    End Sub
    Private Sub EVRAK_GRIDLE()
        Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("XML/Evraklar.xml"))
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub
    Private Sub Btn_Evrak_Ara_Click(sender As Object, e As EventArgs) Handles Btn_Evrak_Ara.Click
        EVRAK_ARA()
    End Sub
    Public Sub EVRAK_ARA()
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(Server.MapPath("XML/Evraklar.xml"), New XmlReaderSettings())
        Dim ds As DataSet = New DataSet()
        'Dim dv As DataView
        ds.ReadXml(xmlFile)
        'dv = New DataView(ds.Tables(0), "den teks", "Firma_Adi", DataViewRowState.CurrentRows)
        'ds.Tables(0).DefaultView.RowFilter = "Firma_Adi ='" + TxtAra.Text + "'"
        Dim dataView As DataView = ds.Tables(0).DefaultView
        dataView.RowFilter = "Firma_Adi Like '%" & TxtAra.Text & "%'"

        GridView1.DataSource = dataView
        GridView1.DataBind()
        If GridView1.Rows.Count = 0 Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "Evrak_Bulunamadi();", True)
        End If
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
                ' e.Row.Cells(0).Visible = False
            Next
        End If
        '//////gridview kolon gizleme//////

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

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        LblId.Text = GridView1.SelectedRow.Cells(0).Text
        LblDosyaAdi.Text = GridView1.SelectedRow.Cells(2).Text
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        EVRAK_GRIDLE()
    End Sub
    Protected Sub download(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        'If e.CommandName = "download" Then
        '    If LblId.Text = "" Then
        '        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_INDIR_SECINIZ();", True)
        '        Exit Sub
        '    End If

        '    'Daha sonra gridview’un "RowCommand" evetinde "CommandName" sorgulatıyoruz. İstediğimiz button’dan geliyorsa "CommandArgument"deki değeri rowindex olarak kullanıp panel kontrolüne ulaşıyoruz.

        '    Dim rowindex As Integer = Convert.ToInt32(e.CommandArgument)
        '    Label1.Text = rowindex.ToString
        '    Dim dosya As String = LblDosyaAdi.Text
        '    Response.Clear()


        '    Dim yol As String = Request.PhysicalApplicationPath + "Files/" + dosya
        '    Dim dosya_nesne As New FileInfo(yol)
        '    If dosya_nesne.Exists Then
        '        Label1.Text = rowindex.ToString
        '        Response.Clear()
        '        Response.ContentType = "Application/x-images"
        '        Response.AddHeader("Content-Disposition", "Attachment;Filename=" + dosya)
        '        Response.WriteFile(Server.MapPath("Files") + "/" + dosya)
        '        Response.End()
        '        Response.Write("Dosya İndirildi")
        '    Else
        '        Label1.Text = "Dosya Bulunamadi !!"
        '    End If


        '    If GridView1.Rows(rowindex).FindControl("indir").Visible Then
        '        GridView1.Rows(rowindex).FindControl("indir").Visible = False
        '    Else
        '        GridView1.Rows(rowindex).FindControl("indir").Visible = True
        '    End If
        'End If

        If e.CommandName = "BtnDosyaSil" Then
            If LblId.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SIL_SECINIZ();", True)
                Exit Sub
            End If
            Dim relPath As String = "XML/Evraklar.xml"
            Dim absPath As String = Server.MapPath(relPath)
            Dim xml As XDocument = XDocument.Load(absPath)
            xml.Root.Elements().Where(Function(a) a.Element("Evrak_id").Value = LblId.Text).Remove()
            xml.Save(absPath)
            'Response.Redirect("Evraklar.aspx")

            'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM
            Dim dosya_ismi As String = LblDosyaAdi.Text
            Dim kaynak As String = Server.MapPath("") + "/files/" + dosya_ismi
            Dim dosya As New FileInfo(kaynak)
            dosya.Delete()
            'BURADA KLASÖRDEKİ DOSYAYI SİLİYORUM

            EVRAK_GRIDLE()

            LblId.Text = ""
            LblDosyaAdi.Text = ""
            Btn_iptal.Visible = True
            EVRAK_GRIDLE()
        End If
    End Sub

    'Protected Sub download(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    'Aşağıdaki aspx.vb sayfası örneğinde öncelikle gridview’un "RowDataBound" eventinde row’daki "indir" isimli Button kontrolümüzü bulup, "CommandArgument" özelliğine o anki satırın index numarasını atıyoruz.
    '    If True Then
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            Dim Button1 As Button = DirectCast(e.Row.FindControl("indir"), Button)
    '            Button1.CommandArgument = e.Row.RowIndex.ToString()
    '        End If
    '    End If
    'End Sub
    Public Sub FIRMA_SEC_ARA()
        Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("XML/Firmalar.xml"))

        GridView2.DataSource = ds
        GridView2.DataBind()
    End Sub
    Private Sub Btn_Evrak_Ara_Load(sender As Object, e As EventArgs) Handles Btn_Evrak_Ara.Load
        FIRMA_SEC_ARA()
    End Sub
    Private Sub Btn_Evrak_Ekle_ServerClick(sender As Object, e As EventArgs) Handles Btn_Evrak_Ekle.ServerClick
        Div_Beyannameler.Visible = False
        Div_Evrak_Ekle.Visible = True
    End Sub
    Private Sub Btn_Evrak_Ekle_Firma_Sec_Click(sender As Object, e As EventArgs) Handles Btn_Evrak_Ekle_Firma_Sec.Click
        Div_Evrak_Ekle.Visible = False
        Div_Beyanname_Sec.Visible = True
        Btn_Firma_Sec_Ara.Visible = True
        Btn_Evrak_Ara.Visible = False
    End Sub
    Private Sub Btn_Evrak_Yukle_Click(sender As Object, e As EventArgs) Handles Btn_Evrak_Yukle.Click
        If TXT_FIRMA_ID.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "FIRMA_SECINIZ();", True)
            Exit Sub
        End If

        If FileUpload1.FileName = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_SECINIZ();", True)
            Exit Sub
        End If

        ' FileUploand kontrolümüzde HasFile kodu ile dosya olup olmadığını kontrol ediyoruz...

        Dim filepath As String = Server.MapPath("files/")
        Dim uploadedFiles As HttpFileCollection = Request.Files
        For i As Integer = 0 To uploadedFiles.Count - 1
            Dim userPostedFile As HttpPostedFile = uploadedFiles(i)

            Try

                If userPostedFile.ContentLength > 0 Then
                    userPostedFile.SaveAs(filepath & "/" & Path.GetFileName(userPostedFile.FileName))
                    dosya_adi = userPostedFile.FileName
                    Dim xmlyol As String = Server.MapPath("XML/Evraklar.xml") ' verilerin olduğu xml dosyasının yolu alınıyor
                    Dim ds As New DataSet
                    ds.ReadXml(xmlyol) ' Dataset nesnesi tarafından okunan yoldaki xml veri dosyası okunuyor ve dataset olusturuluyor.
                    Dim Evrak_id As Integer
                    Dim sonsatirno As Integer = ds.Tables(0).Rows.Count - 1 'xml dosyasındaki son kayıt bulunuyor.
                    Evrak_id = ds.Tables(0).Rows(sonsatirno)(0) + 1 ' Bulunan kayıtın ID numarasına 1 eklenerek yeni ID no olusturuluyor.
                    Dim yenikayit As DataRow = ds.Tables(0).NewRow ' yeni bir kayıt satırı oluşturuluyor

                    yenikayit("Evrak_id") = Evrak_id
                    yenikayit("dosya_adi") = dosya_adi
                    'yenikayit("dosya_uzt") = uzanti
                    yenikayit("Firma_id") = TXT_FIRMA_ID.Text
                    yenikayit("Firma_Adi") = TXT_FIRMA_ADI.Text

                    ds.Tables(0).Rows.Add(yenikayit) ' Kayıt satırına eşitlenen bilgiler toplam bir satır olarak dataset nesnesine ekleniyor.
                    ds.WriteXml(xmlyol) 'Yeni kayıt eklendikten sonra xml dosyasının yeni hali tekrar yazılarak kayıt yapılmış oluyor.
                    EVRAK_GRIDLE()
                End If

            Catch Ex As Exception
                Label1.Text = "Dosya seçimi yapılmadı !!!"
            End Try
        Next
        Response.Redirect("Evraklar.aspx")
    End Sub
    Private Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        TXT_FIRMA_ID.Text = GridView2.SelectedRow.Cells(1).Text
        TXT_FIRMA_ADI.Text = GridView2.SelectedRow.Cells(2).Text

        Div_Beyanname_Sec.Visible = False
        TxtAra.Visible = False
        Div_Evrak_Ekle.Visible = True

    End Sub
    Private Sub Btn_Beyanname_Kaydet_Iptal_Click(sender As Object, e As EventArgs) Handles Btn_Beyanname_Kaydet_Iptal.Click
        Response.Redirect("evraklar.aspx")
    End Sub
    Private Sub Btn_iptal_ServerClick(sender As Object, e As EventArgs) Handles Btn_iptal.ServerClick
        Response.Redirect("evraklar.aspx")
    End Sub

End Class