Public Class TableroC
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If CType(Me.Master, Site1).IdInstalacion = -1 Then
            Response.Redirect("Inicio.aspx")
        End If


    End Sub

    Private Sub Tablero_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Tablero()


    End Sub


    Public Sub Tablero()
        Dim Query As String = "  SELECT s.id_requisito,s.Nivel1,s.Nivel2,s.Nivel3,s.Requisito,r.id_Evidencia, CONVERT(varchar,r.fecha_registro,105) Fecha
  ,CASE WHEN r.estado=0 THEN 'Pendiente de Aprobación' ELSE CASE WHEN r.estado=1 THEN 'Aprobada' ELSE CASE WHEN r.estado=2 THEN 'Rechazada' ELSE CASE WHEN r.estado=3 THEN 'No Aplica' ELSE '' END END END END AS 'Estado'  FROM   (SELECT  r.id_requisito, max(r.id_Evidencia) AS max_score FROM    Op_Ev_Req_E2 r WHERE r.id_Instalacion=" + CType(Me.Master, Site1).IdInstalacion.ToString() + " AND r.activado IS NULL GROUP BY r.id_requisito) d JOIN  Op_Ev_Req_E2 r ON r.id_requisito = d.id_requisito AND r.id_Evidencia = d.max_score FULL JOIN  Cat_Menu_V3 s ON  s.id_requisito = r.id_requisito WHERE s.Activado IS NULL AND s.id_requisito BETWEEN 24 AND 90 ORDER BY s.Nivel2_no, s.Nivel3 ASC"

        gridTablero.DataSource = obj.Consultar(Query)
        gridTablero.DataBind()
        For Each row As GridViewRow In gridTablero.Rows
            Dim IdRequisito As Integer = gridTablero.DataKeys(row.RowIndex).Value

            Dim link As HyperLink = CType(row.FindControl("hyRequisito"), HyperLink)
            Dim IdEvidencia As Label = CType(row.FindControl("lblIdEvidencia"), Label)
            Dim Estado As Label = CType(row.FindControl("lblEstado"), Label)

            Dim IconAprobada As HtmlControl = CType(row.FindControl("IconAprobada"), HtmlControl)
            Dim IconEnAprobacion As HtmlControl = CType(row.FindControl("IconEnAprobacion"), HtmlControl)
            Dim IconNoAplica As HtmlControl = CType(row.FindControl("IconNoAplica"), HtmlControl)
            Dim IconRojoe As HtmlControl = CType(row.FindControl("IconRojo"), HtmlControl)
            Dim IconNoAplica2 As HtmlControl = CType(row.FindControl("IconNoAplica2"), HtmlControl)

            Dim RequisitoLink As HyperLink = CType(row.FindControl("Requisitohy"), HyperLink)

            If IdEvidencia.Text = "" Then
                link.Visible = False
            Else
                link.Visible = True
                link.Target = "_blank"


                'link.NavigateUrl = "https://er2020.blob.core.windows.net/erdocs/" & IdEvidencia.Text & ".pdf"
                Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEvidencia.Text)))
                Dim encodedString2 As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdRequisito.ToString())))

                link.NavigateUrl = "Evidencia.aspx?id=" + encodedString


            End If

            Dim encodedStringId As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdRequisito.ToString())))
            Dim encodedStringReq = System.Text.Encoding.UTF8.GetBytes(RequisitoLink.Text)
            Dim s = System.Convert.ToBase64String(encodedStringReq)

            RequisitoLink.NavigateUrl = "RequisitoC.aspx?id=" + encodedStringId + "&req=" + s


            If Estado.Text = "Aprobada" Then
                IconAprobada.Visible = True
            ElseIf Estado.Text = "Rechazada" Then
                IconRojoe.Visible = True
            ElseIf Estado.Text = "Pendiente de Aprobación" Then
                IconEnAprobacion.Visible = True
            ElseIf Estado.Text = "No Aplica" Then
                IconNoAplica2.Visible = True
                link.Visible = False
            Else

                IconRojoe.Visible = True
            End If

        Next
    End Sub

    Protected Sub gridTablero_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

        End If

    End Sub
End Class