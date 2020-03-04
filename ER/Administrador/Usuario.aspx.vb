Public Class Usuario
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim obj As AtributosEmpleado = CType(Session("DatosEmpleado"), AtributosEmpleado)

            If obj IsNot Nothing Then
                lblIdEmpleado.Text = obj.Id_empleado
                lblNombre.Text = obj.Nombre
                lblPaterno.Text = obj.ApellidoPaterno
                lblMaterno.Text = obj.ApellidoMaterno
                lblInstalacion.Text = obj.Instalacion
                lblFecha.Text = obj.CreacionFecha

            End If
            MostrarGridUsuario()
        End If

    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Response.Redirect("Empleado.aspx")
    End Sub

    Public Sub MostrarGridUsuario()
        Dim Query = "SELECT Us.Id_usuario,Us.Acceso,Us.Email,CONVERT(varchar,Us.CreacionFecha,105)'CreacionFecha' FROM Usuario Us  JOIN Cat_Empleado emp on Us.Id_empleado=emp.Id_empleado WHERE Us.Activado IS NULL AND Us.Id_empleado=" + lblIdEmpleado.Text + ""


        gridUsuario.DataSource = obj.Consultar(Query)

        gridUsuario.DataBind()
        If gridUsuario.Rows.Count = 0 Then
            MostrarControles()
        Else
            EsconderControles()
            MostrarGridAccesos()
        End If
    End Sub

    Public Sub MostrarGridAccesos()

        For Each row As GridViewRow In gridUsuario.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim IdUsuario As Integer = Convert.ToInt32(gridUsuario.DataKeys(row.RowIndex).Values("Id_usuario"))
                Dim Query = "SELECT Nav.Id_webform 'Id_webform', Nav.Descripcion 'Descripcion', Nav.URL, CASE WHEN UsAct.id_webform IS NULL THEN 0 else UsAct.Id_webform END 'Id_registro' FROM Cat_Navegacion Nav  LEFT JOIN (SELECT Id_webform FROM Op_Roles WHERE Id_Usuario=" + IdUsuario.ToString() + ") UsAct on Nav.Id_webform=UsAct.Id_webform"
                gridAcceso.DataSource = obj.Consultar(Query)
                gridAcceso.DataBind()
            End If
        Next

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim Acceso As String = txtUsuario.Text
        Dim Email As String = txtEmail.Text
        Dim Password As String = txtPassword.Text

        If (obj.AutenticarUsuario(Acceso)) Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ya existe este usuario con este nombre de acceso.")
            scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        Else
            Dim sqlQuery = "INSERT INTO Usuario(Id_empleado,Acceso,Contrasena,Email,CreacionFecha) VALUES(" + lblIdEmpleado.Text + ",'" + Acceso + "','" + Password + "','" + Email + "',GETDATE())"
            Try
                If obj.Insertar(sqlQuery) Then


                    Limpiar()

                    MostrarGridUsuario()
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Usuario creado exitosamente.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                End If
            Catch ex As Exception
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear usuario.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End Try
        End If



    End Sub

    Private Sub Limpiar()
        txtUsuario.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPassword.Text = String.Empty
        txtPasswordConfirm.Text = String.Empty

    End Sub

    Private Sub EsconderControles()
        txtUsuario.ReadOnly = True
        txtEmail.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPasswordConfirm.ReadOnly = True
        btnGuardar.Visible = False
        btn_ClearButton.Visible = False
        btnSave.Visible = True
    End Sub

    Private Sub MostrarControles()
        txtUsuario.ReadOnly = False
        txtEmail.ReadOnly = False
        txtPassword.ReadOnly = False
        txtPasswordConfirm.ReadOnly = False
        btnGuardar.Visible = True
        btn_ClearButton.Visible = True
        btnSave.Visible = False


    End Sub

    Protected Sub gridUsuario_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridUsuario.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Usuario SET Activado=1 WHERE Id_usuario= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                MostrarGridUsuario()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridUsuario.DataKeys(row.RowIndex).Value

            Dim txtEditAcceso As TextBox = CType(row.FindControl("txtEditAcceso"), TextBox)
            txtEditAcceso.Visible = True
            Dim lblAcceso As Label = CType(row.FindControl("lblAcceso"), Label)
            lblAcceso.Visible = False


            Dim txtEditEmail As TextBox = CType(row.FindControl("txtEditEmail"), TextBox)
            txtEditEmail.Visible = True
            Dim lblEmail As Label = CType(row.FindControl("lblEmail"), Label)
            lblEmail.Visible = False

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
            Dim Id As Integer = gridUsuario.DataKeys(row.RowIndex).Value

            Dim AccesoActual As Label = CType(row.FindControl("lblAcceso"), Label)
            Dim AccesoNuevo As TextBox = CType(row.FindControl("txtEditAcceso"), TextBox)

            Dim EmailActual As Label = CType(row.FindControl("lblEmail"), Label)

            Dim EmailNuevo As TextBox = CType(row.FindControl("txtEditEmail"), TextBox)


            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Usuario set Acceso= '" + AccesoNuevo.Text + "', Email='" + EmailNuevo.Text + "' Where Id_usuario=" + Id.ToString + ""
            If AccesoActual.Text <> AccesoNuevo.Text Or EmailActual.Text <> EmailNuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    AccesoActual.Text = AccesoNuevo.Text
                    EmailActual.Text = EmailNuevo.Text

                    AccesoActual.Visible = True
                    AccesoNuevo.Visible = False
                    EmailActual.Visible = True
                    EmailNuevo.Visible = False

                    btnCancel.Visible = False
                    btnAct.Visible = False
                    btnEditar.Visible = True

                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizó el dato correctamente.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al actualizar el dato.")
                    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                End If

            End If

        ElseIf e.CommandName = "Cancelar" Then

            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer

            Dim txtEditAcceso As TextBox = CType(row.FindControl("txtEditAcceso"), TextBox)
            txtEditAcceso.Visible = False
            Dim lblAcceso As Label = CType(row.FindControl("lblAcceso"), Label)
            lblAcceso.Visible = True


            Dim txtEditEmail As TextBox = CType(row.FindControl("txtEditEmail"), TextBox)
            txtEditEmail.Visible = False
            Dim lblEmail As Label = CType(row.FindControl("lblEmail"), Label)
            lblEmail.Visible = True

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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class