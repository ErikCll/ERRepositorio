Public Class Evidencia
    Inherits System.Web.UI.Page


    Private Sub Evidencia_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim decodeRequisito = System.Convert.FromBase64String(Request.QueryString("rn"))
        'Dim requisito = System.Text.Encoding.UTF8.GetString(decodeRequisito)

        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString
        'Dim decodedString2 As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("req")))
        'Dim IdRequisito As String = decodedString2
        'Dim Id_Instalacion = Request.QueryString("ins")
        'frame.Src = "https://er2020.blob.core.windows.net/erdocs/" & id.ToString() & ".pdf"

        'Select Case IdRequisito
        '    Case 1
        '        frame.Src = "~/Requisito/FichaBasica.aspx?ins=" + Id_Instalacion + "&reqn=" + Requisito

        '    Case 18
        '        frame.Src = "~/Requisito/PoligonoInfluencia.aspx?ins=" + Id_Instalacion + "&reqn=" + Requisito

        '    Case 19
        '        frame.Src = "~/Requisito/MercadoPotencial.aspx?ins=" + Id_Instalacion + "&reqn=" + Requisito

        '    Case 20
        '        frame.Src = "~/Requisito/InfrLog.aspx?ins=" + Id_Instalacion + "&reqn=" + requisito

        '    Case Else
        '        'frame.Src = "https://eregional.blob.core.windows.net/ereg/" & id.ToString() & ".pdf"
        '        frame.Src = "https://er2020.blob.core.windows.net/erdocs/" & id.ToString() & ".pdf"


        'End Select

        frame.Src = "https://eregional.blob.core.windows.net/ereg/" & id.ToString() & ".pdf"
        'frame.Src = "https://er2020.blob.core.windows.net/erdocs/" & id.ToString() & ".pdf"

    End Sub

End Class