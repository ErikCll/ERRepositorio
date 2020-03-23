Imports System.IO
Public Class Requisito
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        Me.scrScript.RegisterPostBackControl(btnGuardar)


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("req")))
            lblRequisito.Text = decodedString
            MostrarGridEvidencia()
            MostrarGridEvidencia2()
        End If

    End Sub

    Public Sub MostrarGridEvidencia()

        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString
        Dim Query = "SELECT TOP 1 id_evidencia,id_requisito,estado FROM Op_Ev_Req WHERE id_requisito=" + id.ToString() + "AND  estado in (1,2,0) ORDER BY id_evidencia DESC"

        gridEvidencia.DataSource = obj.Consultar(Query)
        gridEvidencia.DataBind()
        If gridEvidencia.Rows.Count = 0 Then
            frame.Src = "~/EstatusPDF/SinEvidencia.pdf"
            btnGuardar.Visible = True
        Else
            For Each row As GridViewRow In gridEvidencia.Rows
                Dim estado = row.Cells(2).Text


                If estado = 0 Then
                    frame.Src = "~/EstatusPDF/EvidenciaEnAprobacion.pdf"
                    btnGuardar.Visible = False
                ElseIf estado = 1 Then
                    frame.Src = "~/EvidenciaPDF/" & id.ToString() & ".pdf"
                    btnGuardar.Visible = False
                ElseIf estado = 2 Then

                    frame.Src = "~/EstatusPDF/EvidenciaRechazada.pdf"

                End If



            Next
        End If



    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Dim File1 As HttpPostedFile = Request.Files("File1")
        'Dim objHttpPostedFile As HttpPostedFile = File1.PostedFile
        'Dim ProfilePic_fileName As String = File1.PostedFile.FileName

        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect(Request.UrlReferrer.ToString())
        End If
        Dim IdUsuario = objUs.Id_usuario


        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString


        Dim nombre As String = File1.FileName
            Dim fileExt As String = System.IO.Path.GetExtension(File1.FileName)

        If File1.HasFile Then

            If fileExt = ".pdf" Or fileExt = ".PDF" Then
                Dim sqlQuery As String = "INSERT INTO Op_Ev_Req(id_requisito,estado,Observaciones,id_usuario,activado) VALUES(" + id.ToString() + ",0,'" + txtDesc.Value + "'," + IdUsuario.ToString() + ",NULL)"
                If obj.Insertar(sqlQuery) Then
                    File1.SaveAs(Server.MapPath("~/EvidenciaPDF/" & id.ToString() & ".pdf"))
                    MostrarGridEvidencia()
                    txtDesc.Value = String.Empty

                    'Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se cargó la evidencia correctamente, en espera de aprobación.")
                    'scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    Dim script As String = "alert('Se cargó la evidencia correctamente, en espera de aprobación.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                Else
                    'Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al cargar la evidencia.")
                    'scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    Dim script As String = "alert('Ocurrió un error al cargar la evidencia.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                End If
            End If
        End If

        'btnPost_Click(Nothing, Nothing)

    End Sub

    Public Sub MostrarGridEvidencia2()
        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString
        Dim Query As String = "SELECT TOP 1 id_evidencia, CASE WHEN estado=0 THEN 'En aprobación' WHEN estado=1 THEN 'Aprobada' ELSE 'Rechazada' END Estado, Acceso, CONVERT(varchar,fecha_registro,105) Fecha,observaciones FROM Op_Ev_Req Op JOIN Usuario us on op.id_usuario=us.Id_usuario WHERE Op.id_requisito=" + id.ToString() + "  ORDER BY Op.id_Evidencia DESC"
        gridEvidencia2.DataSource = obj.Consultar(Query)
        gridEvidencia2.DataBind()
        For Each row As GridViewRow In gridEvidencia2.Rows
            Dim link As HyperLink = CType(row.FindControl("link1"), HyperLink)
            Dim btnAprobar As LinkButton = CType(row.FindControl("btnAprobar"), LinkButton)
            Dim btnRechazar As LinkButton = CType(row.FindControl("btnRechazar"), LinkButton)
            Dim btnEliminar As LinkButton = CType(row.FindControl("btnEliminar"), LinkButton)

            link.Target = "_blank"

            link.NavigateUrl = "~/EvidenciaPDF/" & id.ToString() & ".pdf"
            Dim estado = row.Cells(3).Text
            If estado = "En aprobación" Then
                btnAprobar.Visible = True
                btnRechazar.Visible = True

            ElseIf estado = "Aprobada" Then
                btnAprobar.Visible = False
                btnEliminar.Visible = True
            ElseIf estado = "Rechazada" Then
                btnAprobar.Visible = False
                btnRechazar.Visible = False
                btnEliminar.Visible = True
            Else
                btnAprobar.Visible = True
                btnRechazar.Visible = True
            End If
        Next

    End Sub

    Protected Sub gridEvidencia2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Aprobar" Then
            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())
            End If
            Dim IdUsuario = objUs.Id_usuario
            If obj.AutenticarAdministrador(IdUsuario) Then
                Dim ctl = e.CommandSource
                Dim row As GridViewRow = ctl.NamingContainer
                Dim IdEvidencia As Integer = gridEvidencia2.DataKeys(row.RowIndex).Value


                Dim Query As String = "UPDATE Op_Ev_Req SET Estado=1 WHERE id_evidencia=" + IdEvidencia.ToString() + ""
                If obj.Modificar(Query) Then
                    MostrarGridEvidencia()
                    MostrarGridEvidencia2()

                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se aprobó correctamente la evidencia.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    itemConsulta.Attributes("class") = "active"
                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al aprobar la evidencia.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                End If

            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede realizar esta acción.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If

        ElseIf e.CommandName = "Rechazar" Then
            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())
            End If
            Dim IdUsuario = objUs.Id_usuario
            If obj.AutenticarAdministrador(IdUsuario) Then
                Dim ctl = e.CommandSource
                Dim row As GridViewRow = ctl.NamingContainer
                Dim IdEvidencia As Integer = gridEvidencia2.DataKeys(row.RowIndex).Value


                Dim Query As String = "UPDATE Op_Ev_Req SET Estado=2 WHERE id_evidencia=" + IdEvidencia.ToString() + ""
                If obj.Modificar(Query) Then
                    MostrarGridEvidencia()
                    MostrarGridEvidencia2()
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se rechazó correctamente la evidencia.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al rechazar la evidencia.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                End If

            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede realizar esta acción.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Eliminar" Then
            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())
            End If
            Dim IdUsuario = objUs.Id_usuario
            If obj.AutenticarAdministrador(IdUsuario) Then
                Dim ctl = e.CommandSource
                Dim row As GridViewRow = ctl.NamingContainer
                Dim IdEvidencia As Integer = gridEvidencia2.DataKeys(row.RowIndex).Value
                Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
                Dim id As String = decodedString


                Dim Query As String = "DELETE FROM Op_Ev_req WHERE id_requisito=" + id.ToString() + ""
                If obj.Modificar(Query) Then
                    MostrarGridEvidencia()
                    MostrarGridEvidencia2()
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente la evidencia.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar la evidencia.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                End If

            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede realizar esta acción.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If


        Else


        End If
    End Sub


End Class