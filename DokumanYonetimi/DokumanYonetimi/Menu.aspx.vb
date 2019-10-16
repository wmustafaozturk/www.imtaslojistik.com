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
Public Class Menu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Giris") = "Evet" Then
            Response.Cookies.Add(New HttpCookie("returnUrl", Request.Url.PathAndQuery))
            Response.Redirect("login.aspx")
        End If
    End Sub

End Class