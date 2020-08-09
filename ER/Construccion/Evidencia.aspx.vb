Public Class Evidencia2
    Inherits System.Web.UI.Page
    Private Sub Evidencia_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString

        frame.Src = "https://eregional.blob.core.windows.net/consdocs/" & id.ToString() & ".pdf"


        'frame.Src = "https://er2020.blob.core.windows.net/consdocs/" & id.ToString() & ".pdf"



    End Sub
End Class