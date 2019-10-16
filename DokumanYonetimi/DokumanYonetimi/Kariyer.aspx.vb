Imports System
Imports System.Configuration
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Security
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Linq
Imports System.Xml.Linq
Imports System.Web.Script
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Public Class Kariyer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub BtnKaydet_Click(sender As Object, e As EventArgs) Handles BtnKaydet.Click
        Try



            Dim yuklenecekDosya As HttpPostedFile = FileUpload1.PostedFile
            If yuklenecekDosya IsNot Nothing Then
                Dim dosyaBilgisi As New FileInfo(yuklenecekDosya.FileName)
                Dim klasor As String = "cv"
                Dim yuklemeYeri As String = Server.MapPath((Convert.ToString("~/") & klasor) + "/" + dosyaBilgisi.Name)
                FileUpload1.SaveAs(yuklemeYeri)
            End If
            'Response.Redirect("http://www.hh.com")
            Label1.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class