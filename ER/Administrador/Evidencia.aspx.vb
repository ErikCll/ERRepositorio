Public Class Evidencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString

        frame.Src = "https://er2020.blob.core.windows.net/erdocs/" & id.ToString() & ".pdf"
    End Sub

End Class