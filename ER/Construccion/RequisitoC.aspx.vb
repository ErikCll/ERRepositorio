Imports System.IO
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Blob
Imports Microsoft.WindowsAzure.Storage.File
Imports Microsoft.WindowsAzure.Common
Imports System.Globalization

Public Class RequisitoC
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()
    Dim correo As New Correo()
    Dim Ins As New Admin()

    Private Sub Requisito_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        'Me.scrScript.RegisterPostBackControl(btnGuardar)

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If (Request.QueryString("req")) = Nothing Then
            Response.Redirect("Inicio.aspx")

        End If
        If CType(Me.Master, Site1).IdInstalacion = -1 Then
            Response.Redirect("Inicio.aspx")
        End If
        Dim Id_Instalacion = CType(Me.Master, Site1).IdInstalacion


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim IDD = CType(Me.Master, Site1).IdInstalacion

        Dim decodedString = System.Convert.FromBase64String(Request.QueryString("req"))
        Dim requisito = System.Text.Encoding.UTF8.GetString(decodedString)

        'Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("req")))

        lblRequisito.Text = requisito
        MostrarGridEvidencia()
        MostrarGridEvidencia2()
        If Not IsPostBack Then
            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())
            End If
            If objUs.Rol = "Cliente" Or objUs.Rol = "Consultor" Then
                DivInsertar.Visible = False
                lnk_Agregar.Visible = False
            Else

            End If
        End If
    End Sub

    Public Sub MostrarGridEvidencia()

        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString
        Dim Query = "SELECT TOP 1 id_evidencia,id_requisito,estado FROM Op_Ev_Req_E2 WHERE Id_Instalacion=" + CType(Me.Master, Site1).IdInstalacion.ToString() + " AND Id_requisito=" + id.ToString() + " AND estado in (1,2,0,3) AND activado IS NULL ORDER BY id_evidencia DESC"

        gridEvidencia.DataSource = obj.Consultar(Query)
        gridEvidencia.DataBind()
        If gridEvidencia.Rows.Count = 0 Then


        Else

            Dim Id_Evidencia As String = gridEvidencia.Rows(0).Cells(0).Text


            frame.Src = "https://eregional.blob.core.windows.net/consdocs/" & Id_Evidencia.ToString() & ".pdf"
            'frame.Src = "https://er2020.blob.core.windows.net/consdocs/" & Id_Evidencia.ToString() & ".pdf"

            frame.Visible = True

            Dim estado = gridEvidencia.Rows(0).Cells(2).Text


            If estado = 0 Then
                'frame.Src = "~/EstatusPDF/EvidenciaEnAprobacion.pdf"
                'btnGuardar.Visible = False
                lblEnAprobacion.Visible = True
                lblSinEvidencia.Visible = False
            ElseIf estado = 1 Then
                'frame.Src = "~/EvidenciaPDF/" & id.ToString() & ".pdf"
                'btnGuardar.Visible = False
                lblAprobada.Visible = True
                lblSinEvidencia.Visible = False

            ElseIf estado = 2 Then

                'frame.Src = "~/EstatusPDF/EvidenciaRechazada.pdf"
                lblRechazada.Visible = True
                lblSinEvidencia.Visible = False

            ElseIf estado = 3 Then
                lblNoAplica.Visible = True
                lblSinEvidencia.Visible = False
                frame.Visible = False
            End If



        End If



    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click


        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect(Request.UrlReferrer.ToString())
        End If
        Dim IdUsuario = objUs.Id_usuario
        'Dim IdInstalacion = objUs.Id_Instalacion

        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString
        Dim decodedString2 = System.Convert.FromBase64String(Request.QueryString("req"))
        Dim Requisito = System.Text.Encoding.UTF8.GetString(decodedString2)

        If chkRequisito.Checked = True Then
            Dim sqlQuery As String = "INSERT INTO Op_Ev_Req_E2(id_requisito,estado,Observaciones,id_usuario,activado,id_Instalacion) VALUES(" + id.ToString() + ",3,'" + txtDesc.Value + "'," + IdUsuario.ToString() + ",NULL," + CType(Me.Master, Site1).IdInstalacion.ToString() + ")"
            If obj.Insertar(sqlQuery) Then
                MostrarGridEvidencia()
                MostrarGridEvidencia2()
                Dim script As String = "alert('Se marcó como No Aplica el requisito.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
            Else

                Dim script As String = "alert('Ocurrió un error al registrar requisito como No Aplica.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

            End If

        Else
            Dim nombre As String = File1.FileName
            Dim fileExt As String = System.IO.Path.GetExtension(File1.FileName)
            'Dim AccountName As String = "er2020"
            'Dim AccountKey As String = "yhDHxitC9NvUx5p3vLHwUJWxWx7rdLw47/PI88KVsS8/2EIdN2ZAM+ATi8PWKyB7zXGEXE2mFAAgw1MHw3z/JA=="

            Dim AccountName As String = "eregional"
            Dim AccountKey As String = "Yz7goqjHkr1u/fYG0NkHjZC/Z4aK21B7ihNqJzPRVYJF0h+DeI//hig0uXsLDJcWEWvVKpnDunb4bD1Kbl2YeA=="
            'Dim ruta As String = Server.MapPath(File1.PostedFile.FileName)


            If File1.HasFile Then

                If fileExt = ".pdf" Or fileExt = ".PDF" Then
                    Dim sqlQuery As String = "INSERT INTO Op_Ev_Req_E2(id_requisito,estado,Observaciones,id_usuario,activado,id_Instalacion,fecha_registro) VALUES(" + id.ToString() + ",0,'" + txtDesc.Value + "'," + IdUsuario.ToString() + ",NULL," + CType(Me.Master, Site1).IdInstalacion.ToString() + ",DATEADD(HH, -5, GETDATE()))"
                    If obj.Insertar(sqlQuery) Then
                        MostrarGridEvidencia()
                        MostrarGridEvidencia2()
                        Dim Query = "SELECT TOP 1 id_evidencia FROM Op_Ev_Req_E2 WHERE Id_Instalacion=" + CType(Me.Master, Site1).IdInstalacion.ToString() + " AND Id_requisito=" + id.ToString() + " AND estado in (1,2,0) ORDER BY id_evidencia DESC"
                        obj.ObtenerIdEvidencia(Query)
                        Dim Id_Evidencia = obj.IdEvidencia
                        Dim creds As StorageCredentials = New StorageCredentials(AccountName, AccountKey)
                        Dim account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + AccountName + ";AccountKey=" + AccountKey)
                        Dim client As CloudBlobClient = account.CreateCloudBlobClient()
                        Dim sampleContainer As CloudBlobContainer = client.GetContainerReference("consdocs")
                        sampleContainer.CreateIfNotExists()


                        Dim blob As CloudBlockBlob = sampleContainer.GetBlockBlobReference("" & Id_Evidencia.ToString() & ".pdf")  'nombre de archivo con el cual se copiara
                        blob.Properties.ContentType = "application/pdf"

                        Using (File1.PostedFile.InputStream)

                            blob.UploadFromStream(File1.PostedFile.InputStream)
                        End Using



                        'Dim dt = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToLongDateString, "dddd, MMMM dd, yyyy", New CultureInfo("en-US"))

                        'Dim Fecha As String = dt.ToString("D", New CultureInfo("es-ES"))



                        Dim mensaje As String = "<!doctype html> <html>" &
                            "<body>Evidencia cargada para el requisito: <b>" + Requisito + "</b>, Intalación: <b>" + CType(Me.Master, Site1).Instalacion.ToString() + "<b>, Etapa: <b>Construcción ES</b><hr>" &
                            "<br>Creado por el usuario: <b>" + Page.User.Identity.Name.ToString() + "</b>, el día <b>" + DateTime.Now.AddHours(-5).ToLongDateString() + ".</b><br>" &
                          "Observaciones: <b>" + txtDesc.Value.ToString() + "</b></body></html>"

                        Dim queryCorreo As String = "SELECT Email FROM Usuario us JOIN Op_UsIns ins on us.Id_usuario=ins.Id_Usuario WHERE ins.Id_Instalacion=" + CType(Me.Master, Site1).IdInstalacion.ToString() + " AND us.EsCliente=1 AND us.Activado IS NULL"


                        correo.EnviarCorreoAdministrador(mensaje, queryCorreo)


                        txtDesc.Value = String.Empty


                        Dim script As String = "alert('Se cargó la evidencia correctamente, en espera de aprobación.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"

                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                    Else

                        Dim script As String = "alert('Ocurrió un error al cargar la evidencia.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                    End If
                End If


            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar archivo PDF.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If


        End If




    End Sub

    Public Sub MostrarGridEvidencia2()
        Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
        Dim id As String = decodedString
        Dim Query As String = "SELECT id_evidencia, CASE WHEN estado=0 THEN 'Pendiente de aprobación' WHEN estado=1 THEN 'Aprobada' WHEN estado=2 THEN 'Rechazada' ELSE 'No Aplica' END Estado, Acceso,Email, CONVERT(varchar,fecha_registro,105) Fecha,observaciones FROM Op_Ev_Req_E2 Op JOIN Usuario us on op.id_usuario=us.Id_usuario WHERE Op.Id_instalacion=" + CType(Me.Master, Site1).IdInstalacion.ToString() + " AND op.Id_requisito=" + id.ToString() + " AND Op.Activado IS NULL ORDER BY Op.id_Evidencia DESC"
        gridEvidencia2.DataSource = obj.Consultar(Query)
        gridEvidencia2.DataBind()
        For Each row As GridViewRow In gridEvidencia2.Rows
            Dim link As HyperLink = CType(row.FindControl("link1"), HyperLink)
            Dim btnAprobar As LinkButton = CType(row.FindControl("btnAprobar"), LinkButton)
            Dim btnRechazar As LinkButton = CType(row.FindControl("btnRechazar"), LinkButton)
            Dim btnEliminar As LinkButton = CType(row.FindControl("btnEliminar"), LinkButton)







            Dim IdEvidencia As Integer = Convert.ToInt32(gridEvidencia2.DataKeys(row.RowIndex).Values("id_evidencia"))


            link.Target = "_blank"

            'link.NavigateUrl = "https://er2020.blob.core.windows.net/erdocs/" & IdEvidencia.ToString() & ".pdf"
            Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEvidencia.ToString())))

            link.NavigateUrl = "Evidencia.aspx?id=" + encodedString
            Dim estado = row.Cells(3).Text
            If estado = "Pendiente de aprobación" Then
                btnAprobar.Visible = True
                btnRechazar.Visible = True

            ElseIf estado = "Aprobada" Then
                btnAprobar.Visible = False
                btnEliminar.Visible = True
            ElseIf estado = "Rechazada" Then
                btnAprobar.Visible = False
                btnRechazar.Visible = False
                btnEliminar.Visible = True

            ElseIf estado = "No Aplica" Then
                btnAprobar.Visible = False
                btnRechazar.Visible = False
                btnEliminar.Visible = True
                link.Visible = False

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
            Dim Email = obj.Email

            If objUs.Rol = "Cliente" Or objUs.Rol = "Administrador" Then
                Dim ctl = e.CommandSource
                Dim row As GridViewRow = ctl.NamingContainer
                Dim IdEvidencia As Integer = gridEvidencia2.DataKeys(row.RowIndex).Value
                Dim CorreoUsuario As Label = CType(row.FindControl("lblEmail"), Label)
                Dim decodedString2 = System.Convert.FromBase64String(Request.QueryString("req"))
                Dim Requisito = System.Text.Encoding.UTF8.GetString(decodedString2)

                Dim Query As String = "UPDATE Op_Ev_Req_E2 SET Estado=1 WHERE id_evidencia=" + IdEvidencia.ToString() + ""
                If obj.Modificar(Query) Then
                    'Dim dt = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToLongDateString, "dddd, MMMM dd, yyyy", New CultureInfo("en-US"))

                    'Dim Fecha As String = dt.ToString("D", New CultureInfo("es-ES"))
                    Dim mensaje As String = "La evidencia para el requisito <b>" + Requisito + "</b> fue <b>Aprobada</b>, Intalación: <b>" + CType(Me.Master, Site1).Instalacion.ToString() + "<b>, Etapa: <b>Construcción ES</b><hr>" &
            "<br>Aprobada por: <b>" + Page.User.Identity.Name.ToString() + "</b>, el día <b>" + DateTime.Now.AddHours(-5).ToLongDateString() + ".</b><br>"

                    correo.EnviarCorreoUsuario(mensaje, CorreoUsuario.Text)

                    Dim script As String = "alert('Se aprobó correctamente la evidencia.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                    itemConsulta.Attributes("class") = "active"
                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al aprobar la evidencia.")
                    ScriptManager.RegisterClientScriptBlock(litControl2, litControl.GetType(), "script", txtJS, False)

                End If

            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "No cuentas con el rol para realizar este proceso.")
                ScriptManager.RegisterClientScriptBlock(litControl2, litControl.GetType(), "script", txtJS, False)

            End If

        ElseIf e.CommandName = "Rechazar" Then
            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())
            End If

            Dim IdUsuario = objUs.Id_usuario
            Dim Email = obj.Email

            If objUs.Rol = "Cliente" Or objUs.Rol = "Administrador" Then
                Dim ctl = e.CommandSource
                Dim row As GridViewRow = ctl.NamingContainer
                Dim IdEvidencia As Integer = gridEvidencia2.DataKeys(row.RowIndex).Value
                Dim CorreoUsuario As Label = CType(row.FindControl("lblEmail"), Label)
                Dim decodedString2 = System.Convert.FromBase64String(Request.QueryString("req"))
                Dim Requisito = System.Text.Encoding.UTF8.GetString(decodedString2)

                Dim Query As String = "UPDATE Op_Ev_Req_E2 SET Estado=2 WHERE id_evidencia=" + IdEvidencia.ToString() + ""
                If obj.Modificar(Query) Then


                    'Dim dt = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToLongDateString, "dddd, MMMM dd, yyyy", New CultureInfo("en-US"))

                    'Dim Fecha As String = dt.ToString("D", New CultureInfo("es-ES"))
                    Dim mensaje As String = "La evidencia para el requisito <b>" + Requisito + "</b> fue <b>Rechazada</b>, Intalación: <b>" + CType(Me.Master, Site1).Instalacion.ToString() + "<b>, Etapa: <b>Construcción ES</b><hr>" &
            "<br>Rechazada por: <b>" + Page.User.Identity.Name.ToString() + "</b>, el día <b>" + DateTime.Now.AddHours(-5).ToLongDateString() + ".</b><br>"


                    correo.EnviarCorreoUsuario(mensaje, CorreoUsuario.Text)


                    Dim script As String = "alert('Se rechazó correctamente la evidencia.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al rechazar la evidencia.")
                    ScriptManager.RegisterClientScriptBlock(litControl2, litControl.GetType(), "script", txtJS, False)
                End If

            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "No cuentas con el rol para realizar este proceso.")
                ScriptManager.RegisterClientScriptBlock(litControl2, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Eliminar" Then
            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())
            End If
            Dim IdUsuario = objUs.Id_usuario
            Dim Email = obj.Email

            If objUs.Rol = "Cliente" Or objUs.Rol = "Administrador" Then
                Dim ctl = e.CommandSource
                Dim row As GridViewRow = ctl.NamingContainer
                Dim IdEvidencia As Integer = gridEvidencia2.DataKeys(row.RowIndex).Value
                Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("id")))
                Dim id As String = decodedString


                Dim Query As String = "UPDATE Op_Ev_Req_E2 SET ACTIVADO=1 WHERE Id_evidencia=" + IdEvidencia.ToString() + ""
                If obj.Modificar(Query) Then

                    Dim script As String = "alert('Se eliminó correctamente la evidencia.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar la evidencia.")
                    ScriptManager.RegisterClientScriptBlock(litControl2, litControl.GetType(), "script", txtJS, False)
                End If

            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "No cuentas con el rol para realizar este proceso.")
                ScriptManager.RegisterClientScriptBlock(litControl2, litControl.GetType(), "script", txtJS, False)
            End If


        Else


        End If
    End Sub

    Protected Sub gridEvidencia2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridEvidencia2.PageIndex = e.NewPageIndex

        MostrarGridEvidencia2()

    End Sub


End Class