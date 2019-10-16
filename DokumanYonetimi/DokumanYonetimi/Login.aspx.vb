Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.Configuration
Imports System.Xml
Imports System.Xml.Linq
Imports System.Web.Services.Description
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Threading
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Giris") = "Evet" Then
            Response.Cookies.Add(New HttpCookie("returnUrl", Request.Url.PathAndQuery))
            'Response.Redirect("Login.aspx")
        End If
        If (IsPostBack) = False Then
            TxtKullaniciAdi.Focus()
        Else
        End If

    End Sub
    Private Sub BtnGiris_Click(sender As Object, e As EventArgs) Handles BtnGiris.Click
        If TxtKullaniciAdi.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "Kullanici();", True)
            Exit Sub
        End If
        If TxtSifre.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "Parola();", True)
            Exit Sub
        End If

        Dim username As String
        Dim pwd As String
        Dim CurrentUser As String = ""
        Dim CurrentPwd As String = ""
        Dim LoginStatus As Boolean = False
        username = TxtKullaniciAdi.Text
        pwd = TxtSifre.Text
        Dim xmxdoc As XmlDocument = New XmlDocument()
        xmxdoc.Load(Server.MapPath("XML/Login.xml"))
        Dim xmlnodelist As XmlNodeList = xmxdoc.GetElementsByTagName("Kullanicilar")

        For Each xn As XmlNode In xmlnodelist
            Dim xmlnl As XmlNodeList = xn.ChildNodes
            For Each xmln As XmlNode In xmlnl
                If xmln.Name = "KullaniciAdi" Then
                    If xmln.InnerText = username Then
                        CurrentUser = username
                    End If
                End If
                If xmln.Name = "Sifre" Then
                    If xmln.InnerText = pwd Then
                        CurrentPwd = pwd
                    End If
                End If
            Next
            If (CurrentUser <> "") And (CurrentPwd <> "") Then
                LoginStatus = True
            End If
        Next
        If LoginStatus = True Then
            Session("UserAuthentication") = username
            Session.Timeout = 1
            Session("Giris") = "Evet"
            Response.Redirect("menu.aspx")
        Else
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "ParolaYanlis();", True)
        End If
    End Sub
End Class