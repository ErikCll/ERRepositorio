Public Class DocRegulador
    Inherits System.Web.UI.Page
    Dim obj As New Conexion

    Private Sub DocRegulador_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Private Sub DocRegulador_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then


            If HttpContext.Current.User.Identity.IsAuthenticated Then
                Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
                Session("URL") = URL
                Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
                If objUs Is Nothing Then
                    FormsAuthentication.SignOut()
                    Response.Redirect(URL.ToString())
                End If
                Dim IdUsuario = objUs.Id_usuario

                If objUs.Rol = "Administrador" Then

                Else
                    Dim script As String = "alert('Solo el administrador puede acceder.'); window.location.href= 'Inicio.aspx';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                End If

                'If obj.EsAdministrador(IdUsuario) Then


                'Else
                '    If obj.RolUsuario(IdUsuario, URL) Then


                '    Else
                '        Dim script As String = "alert('No cuentas con el acceso para este apartado'); window.location.href= 'Index.aspx';"

                '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                '    End If

                'End If




            Else
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())


            End If
        End If

    End Sub




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.DefaultButton = btnBuscar.UniqueID

        If Not IsPostBack Then
            Regulador()
            MostrarGridRegulador()
        End If
    End Sub


    Public Sub MostrarGridRegulador()
        Dim Query = "SELECT doc.Id_DocRegulador,reg.Nombre 'Regulador',doc.Nombre 'Documento' FROM Cat_DocRegulador doc JOIN Cat_Regulador reg on doc.Id_Regulador=reg.Id_Regulador WHERE doc.Activado IS NULL AND reg.Activado IS NULL ORDER BY doc.Id_DocRegulador DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query = "SELECT doc.Id_DocRegulador,reg.Nombre 'Regulador',doc.Nombre 'Documento' FROM Cat_DocRegulador doc JOIN Cat_Regulador reg on doc.Id_Regulador=reg.Id_Regulador WHERE doc.Activado IS NULL AND reg.Activado IS NULL AND doc.Nombre LIKE '%" + txtSearch.Text.Trim() + "%' ORDER BY doc.Id_DocRegulador DESC"
        End If

        gridDocRegulador.DataSource = obj.Consultar(Query)

        gridDocRegulador.DataBind()
    End Sub

    Public Sub Regulador()
        ddl_Regulador.DataSource = obj.LlenarDropDownList("SELECT Id_Regulador,Nombre FROM Cat_Regulador WHERE Activado IS NULL")

        ddl_Regulador.DataBind()
        ddl_Regulador.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

    Protected Sub gridDocRegulador_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridDocRegulador.PageIndex = e.NewPageIndex

        MostrarGridRegulador()
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridRegulador()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim sqlQuery = "INSERT INTO Cat_DocRegulador (Id_Regulador,Nombre,Activado) VALUES(" + ddl_Regulador.SelectedValue + ",'" + txt_Regulador.Text + "',NULL)"
        If obj.Insertar(sqlQuery) Then


            Limpiar()

            MostrarGridRegulador()
            'objAdmin.LlenarInstalacion()
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub

    Public Sub Limpiar()
        txt_Regulador.Text = String.Empty
        ddl_Regulador.SelectedIndex = 0
    End Sub

    Protected Sub gridDocRegulador_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridDocRegulador.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Cat_DocRegulador set Activado=1 WHERE Id_DocRegulador= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                MostrarGridRegulador()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridDocRegulador.DataKeys(row.RowIndex).Value

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
            txtEdit.Visible = True
            Dim lblInstalacion As Label = CType(row.FindControl("lblNombre"), Label)
            lblInstalacion.Visible = False




            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)
            btnCancel.Visible = True

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)
            btnAct.Visible = True

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)
            btnEditar.Visible = False
            'gridInstalacion.Columns(0).Visible = False
            'gridInstalacion.Columns(1).Visible = True


        ElseIf e.CommandName = "Actualizar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridDocRegulador.DataKeys(row.RowIndex).Value

            Dim Actual As Label = CType(row.FindControl("lblNombre"), Label)

            Dim Nuevo As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)




            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Cat_DocRegulador set Nombre= '" + Nuevo.Text + "' Where Id_DocRegulador=" + Id.ToString + ""
            If Actual.Text <> Nuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    Actual.Text = Nuevo.Text
                    Actual.Visible = True
                    Nuevo.Visible = False




                    btnCancel.Visible = False
                    btnAct.Visible = False
                    btnEditar.Visible = True

                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizó el dato correctamente.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al actualizar el dato.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                End If

            End If

        ElseIf e.CommandName = "Cancelar" Then

            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
            txtEdit.Visible = False
            Dim lblInstalacion As Label = CType(row.FindControl("lblNombre"), Label)
            lblInstalacion.Visible = True



            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)
            btnCancel.Visible = False

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)
            btnAct.Visible = False

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)
            btnEditar.Visible = True
            'gridInstalacion.Columns(0).Visible = True
            'gridInstalacion.Columns(1).Visible = False



        End If
    End Sub
End Class