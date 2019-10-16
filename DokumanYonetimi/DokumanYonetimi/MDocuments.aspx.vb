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

Public Class MDocuments
    Inherits System.Web.UI.Page
    Dim uzanti As String = ""
    Dim dosya_adi As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Firma_Giris") = "Firma_Evet" Then
            Response.Cookies.Add(New HttpCookie("returnUrl", Request.Url.PathAndQuery))
            Response.Redirect("MDocuments_Login.aspx")
        End If
        If (IsPostBack) = False Then
            EVRAK_GRIDLE()
        Else
        End If

    End Sub
    Private Sub EVRAK_GRIDLE()
        Try
            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create(Server.MapPath("XML/Evraklar.xml"), New XmlReaderSettings())
            Dim ds As DataSet = New DataSet()
            'Dim dv As DataView
            ds.ReadXml(xmlFile)
            Dim dataView As DataView = ds.Tables(0).DefaultView
            dataView.RowFilter = "Firma_id= '" & Session("Firma_id").ToString() & "'" ' KULLANICI GİRİŞİ YAPAN FİRMA ID YE GORE VERILER LISTELENIYOR

            GridView1.DataSource = dataView
            GridView1.DataBind()
            If GridView1.Rows.Count = 0 Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "Evrak_Bulunamadi();", True)
            End If

        Catch ex As Exception

        End Try
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
        dataView.RowFilter = "dosya_adi Like '%" & TxtAra.Text & "%' AND Firma_id='" + Session("Firma_id").ToString() + "'"

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
        LblId.Text = GridView1.SelectedRow.Cells(2).Text
        LblDosyaAdi.Text = GridView1.SelectedRow.Cells(4).Text
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        EVRAK_GRIDLE()
    End Sub
    Protected Sub download(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "download" Then
            If LblId.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "DOSYA_INDIR_SECINIZ();", True)
                Exit Sub
            End If

            'Daha sonra gridview’un "RowCommand" evetinde "CommandName" sorgulatıyoruz. İstediğimiz button’dan geliyorsa "CommandArgument"deki değeri rowindex olarak kullanıp panel kontrolüne ulaşıyoruz.

            Dim rowindex As Integer = Convert.ToInt32(e.CommandArgument)
            Label1.Text = rowindex.ToString
            Dim dosya As String = HttpUtility.HtmlDecode(LblDosyaAdi.Text)
            Response.Clear()


            Dim yol As String = Request.PhysicalApplicationPath + "Files/" + dosya
            Dim dosya_nesne As New FileInfo(yol)
            If dosya_nesne.Exists Then
                Label1.Text = rowindex.ToString
                Response.Clear()
                Response.ContentType = "Application/x-images"
                Response.AddHeader("Content-Disposition", "Attachment;Filename=" + dosya)
                Response.WriteFile(Server.MapPath("Files") + "/" + dosya)
                Response.End()
                Response.Write("Dosya İndirildi")
            Else
                Label1.Text = "Dosya Bulunamadi !!"
            End If


            If GridView1.Rows(rowindex).FindControl("indir").Visible Then
                GridView1.Rows(rowindex).FindControl("indir").Visible = False
            Else
                GridView1.Rows(rowindex).FindControl("indir").Visible = True
            End If
        End If


    End Sub

    Protected Sub download(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Aşağıdaki aspx.vb sayfası örneğinde öncelikle gridview’un "RowDataBound" eventinde row’daki "indir" isimli Button kontrolümüzü bulup, "CommandArgument" özelliğine o anki satırın index numarasını atıyoruz.
        If True Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim Button1 As Button = DirectCast(e.Row.FindControl("indir"), Button)
                Button1.CommandArgument = e.Row.RowIndex.ToString()
            End If
        End If
    End Sub


    Private Sub Btn_iptal_ServerClick(sender As Object, e As EventArgs) Handles Btn_iptal.ServerClick
        Response.Redirect("MDocuments.aspx")
    End Sub
End Class