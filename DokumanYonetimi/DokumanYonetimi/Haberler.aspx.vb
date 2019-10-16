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
Public Class Haberler
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        HABERLER_GRIDLE()


    End Sub
    Private Sub HABERLER_GRIDLE()
        Dim ds As New DataSet()
        ds.ReadXml(Server.MapPath("XML/Haberler.xml"))
        DataList1.DataSource = ds
        DataList1.DataBind()
    End Sub
End Class