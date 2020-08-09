Public Class Regulador
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Private Sub Regulador_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Private Sub Regulador_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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

        If Not IsPostBack() Then
            TablaRegulador()
        End If
    End Sub

    Public Sub TablaRegulador()
        Dim query As String = "SELECT Id_Regulador,Nombre,Nombre_corto FROM Cat_Regulador WHERE Activado IS NULL ORDER BY Id_Regulador DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            query = "SELECT Id_Regulador,Nombre,Nombre_corto FROM Cat_Regulador WHERE Nombre LIKE '%" + txtSearch.Text.Trim() + "%' AND Activado IS NULL ORDER BY Id_Regulador DESC"
        End If
        gridRegulador.DataSource = obj.Consultar(Query)
        gridRegulador.DataBind()
    End Sub
    Protected Sub gridRegulador_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridRegulador.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Cat_Regulador set Activado=1 WHERE Id_Regulador= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                TablaRegulador()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridRegulador.DataKeys(row.RowIndex).Value

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
            txtEdit.Visible = True
            Dim lblInstalacion As Label = CType(row.FindControl("lblNombre"), Label)
            lblInstalacion.Visible = False

            Dim txtEdit2 As TextBox = CType(row.FindControl("txtEditCorto"), TextBox)
            txtEdit2.Visible = True
            Dim lblInstalacion2 As Label = CType(row.FindControl("lblCorto"), Label)
            lblInstalacion2.Visible = False



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
            Dim Id As Integer = gridRegulador.DataKeys(row.RowIndex).Value

            Dim Actual As Label = CType(row.FindControl("lblNombre"), Label)

            Dim Nuevo As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)

            Dim Actual2 As Label = CType(row.FindControl("lblCorto"), Label)

            Dim Nuevo2 As TextBox = CType(row.FindControl("txtEditCorto"), TextBox)



            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Cat_Regulador set Nombre= '" + Nuevo.Text + "',Nombre_Corto='" + Nuevo2.Text + "' Where Id_Regulador=" + Id.ToString + ""
            If Actual.Text <> Nuevo.Text Or Actual2.Text <> Nuevo2.Text Then
                If obj.Modificar(sqlQuery) Then

                    Actual.Text = Nuevo.Text
                    Actual.Visible = True
                    Nuevo.Visible = False

                    Actual2.Text = Nuevo2.Text
                    Actual2.Visible = True
                    Nuevo2.Visible = False



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

            Dim txtEdit2 As TextBox = CType(row.FindControl("txtEditCorto"), TextBox)
            txtEdit2.Visible = False
            Dim lblInstalacion2 As Label = CType(row.FindControl("lblCorto"), Label)
            lblInstalacion2.Visible = True

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

    Protected Sub gridRegulador_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridRegulador.PageIndex = e.NewPageIndex

        TablaRegulador()
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        TablaRegulador()
    End Sub

    Private Sub Limpiar()
        txt_Regulador.Text = String.Empty
        txt_ReguladorCorto.Text = String.Empty

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim query As String = "INSERT INTO cat_regulador values('" + txt_Regulador.Text + "','" + txt_ReguladorCorto.Text + "',null)"
        If obj.Insertar(query) Then
            Limpiar()
            TablaRegulador()
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub
End Class