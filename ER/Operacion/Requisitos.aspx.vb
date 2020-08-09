Public Class Requisitos1
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Private Sub Requisitos_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If CType(Me.Master, Site2).IdInstalacion = -1 Then
            Response.Redirect("Inicio.aspx")
        End If


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not IsPostBack Then
            Dim decodedString = System.Convert.FromBase64String(Request.QueryString("reg"))
            Dim Regulador = System.Text.Encoding.UTF8.GetString(decodedString)
            lblRegulador.Text = Regulador
            Tablero()
        End If

    End Sub


    Public Sub Tablero()
        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim Id_Regulador = decodedString


        Dim Query As String = "Select s.id_requisito,doc.Nombre 'Documento',s.Nombre,r.id_Evidencia,
            Convert(varchar, r.fecha_registro, 105) FechaCreacion, Convert(varchar, r.fecha_requisito, 105) FechaRequisito, s.VigenciaReg, s.VigenciaOpe, CASE WHEN s.TieneVigencia=1 THEN 'Si' ELSE '' END TieneVigencia ,CASE WHEN r.estado=0 THEN 'Pendiente de Aprobación' ELSE CASE WHEN r.estado=1 THEN 'Aprobada' ELSE CASE WHEN r.estado=2 THEN 'Rechazada' ELSE CASE WHEN r.estado=3 THEN 'No Aplica' ELSE '' END END END END AS 'Estado' FROM(SELECT  r.id_requisito, max(r.id_Evidencia) As max_score FROM  Op_Ev_Req_E3 r WHERE r.id_Instalacion=" + CType(Me.Master, Site2).IdInstalacion.ToString() + " And r.activado Is NULL GROUP BY r.id_requisito) d Join  Op_Ev_Req_E3 r ON r.id_requisito = d.id_requisito And r.id_Evidencia = d.max_score FULL Join  Cat_Requisito s ON  s.id_requisito = r.id_requisito Join Cat_DocRegulador doc on s.Id_DocRegulador=doc.Id_DocRegulador Join Cat_Regulador reg on doc.Id_Regulador=reg.Id_Regulador  WHERE reg.Id_Regulador = " + Id_Regulador.ToString() + " And s.Activado Is NULL And reg.Activado Is NULL And doc.Activado Is NULL  ORDER BY s.Id_Requisito DESC"

        gridTablero.DataSource = obj.Consultar(Query)
        gridTablero.DataBind()
        For Each row As GridViewRow In gridTablero.Rows
            Dim IdRequisito As Integer = gridTablero.DataKeys(row.RowIndex).Value

            Dim link As HyperLink = CType(row.FindControl("hyRequisito"), HyperLink)
            Dim IdEvidencia As Label = CType(row.FindControl("lblIdEvidencia"), Label)
            Dim FechaRequisito As Label = CType(row.FindControl("lblFechaRequisito"), Label)
            Dim VigenciaReg As Label = CType(row.FindControl("lblVigenciaReg"), Label)
            Dim VigenciaOpe As Label = CType(row.FindControl("lblVigenciaOpe"), Label)
            Dim FechaVigenciaRegulatoria As Label = CType(row.FindControl("lblFechaReg"), Label)
            Dim FechaVigenciaOperativa As Label = CType(row.FindControl("lblFechaOpe"), Label)

            Dim FechaActual As Date = Date.ParseExact(DateTime.Now.AddHours(-5).ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)
            'Dim FechaActual = Fecha.ToString("dd-MM-yyyy")

            'Dim TieneVigencia As Label = CType(row.FindControl("lblTieneVigencia"), Label)
            Dim Estado As Label = CType(row.FindControl("lblEstado"), Label)

            If IdEvidencia.Text > "1" And Estado.Text <> "No Aplica" And VigenciaOpe.Text > "0" And VigenciaReg.Text > "0" Then
                Dim Vig As HtmlControl = CType(row.FindControl("Vigente"), HtmlControl)
                Dim Apr As HtmlControl = CType(row.FindControl("Apunto"), HtmlControl)
                Dim Ven As HtmlControl = CType(row.FindControl("Vencido"), HtmlControl)


                Dim MesesReg As Integer = VigenciaReg.Text
                Dim MesesOpe As Integer = VigenciaOpe.Text

                Dim Fecha_Requisito As Date = Date.ParseExact(FechaRequisito.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)

                Dim FechaRegulatoria As Date = Fecha_Requisito.AddMonths(MesesReg)
                Dim FechaOperativa As Date = Fecha_Requisito.AddMonths(MesesOpe)
                FechaVigenciaRegulatoria.Text = FechaRegulatoria.ToString("dd-MM-yyyy")
                FechaVigenciaOperativa.Text = FechaOperativa.ToString("dd-MM-yyyy")
                'Dim FechaDeVigencia As Date = Fecha_Requisito.AddMonths(MesesOpe)
                'Dim FechaApunto As Date = FechaDeVigencia.AddDays(-7)

                If FechaRegulatoria = FechaOperativa And FechaActual < FechaRegulatoria Then
                    Vig.Visible = True




                ElseIf FechaRegulatoria = FechaOperativa And FechaActual > FechaRegulatoria Then
                    Ven.Visible = True

                ElseIf FechaActual >= FechaOperativa And FechaActual <= FechaRegulatoria Then
                    Apr.Visible = True

                ElseIf FechaActual <= FechaRegulatoria Then
                    Vig.Visible = True


                ElseIf FechaActual <= FechaOperativa Then
                    Vig.Visible = True



                ElseIf FechaActual > FechaRegulatoria Then
                    Ven.Visible = True

                    'FechaVigencia.Text = FechaDeVigencia.ToString("dd-MM-yyyy")

                    '    If Fecha_Requisito < FechaApunto Then
                    '    Vig.Visible = True
                    'ElseIf Fecha_Requisito >= FechaApunto And Fecha_Requisito < FechaDeVigencia Then
                    '    Apr.Visible = True
                    'ElseIf Fecha_Requisito >= FechaDeVigencia Then
                    '    Ven.Visible = True
                    'End If
                End If


            End If


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

                link.NavigateUrl = "Evidencias.aspx?id=" + encodedString


            End If

            Dim encodedStringId As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdRequisito.ToString())))
            Dim encodedStringReq = System.Text.Encoding.UTF8.GetBytes(RequisitoLink.Text)
            Dim s = System.Convert.ToBase64String(encodedStringReq)

            RequisitoLink.NavigateUrl = "Evidencia.aspx?id=" + encodedStringId + "&req=" + s


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
End Class