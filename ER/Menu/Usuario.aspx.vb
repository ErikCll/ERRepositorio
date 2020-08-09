Public Class Empleado
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Private Sub Empleado_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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
                    Dim script As String = "alert('Solo el administrador puede acceder.'); window.location.href= 'Index.aspx';"

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

    Private Sub Usuario_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("DatosEmpleado") = Nothing

        Page.Form.DefaultButton = btnBuscar.UniqueID

        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then
            DropRol()
            MostrarGridEmpleado()
            'DropDownListInstalacion()
        End If

    End Sub

    Public Sub DropRol()
        ddl_Rol.Items.Insert(0, New ListItem("[Seleccionar]"))
        ddl_Rol.Items.Insert(1, New ListItem("Cliente"))
        ddl_Rol.Items.Insert(2, New ListItem("Consultor"))
        ddl_Rol.Items.Insert(3, New ListItem("Constructor/Operador"))


    End Sub

    Public Sub MostrarGridEmpleado()
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("Index.aspx")

        End If
        Dim Query = "SELECT Id_usuario,Acceso,Nombre,ApellidoPaterno,ApellidoMaterno,Email,CONVERT(varchar,CreacionFecha,105)'CreacionFecha', CASE WHEN EsCliente=1 THEN 'Cliente' WHEN EsConsultor=1 THEN 'Consultor' WHEN EsOperador=1 THEN 'Constructor/Operador' ELSE '' END 'Rol' FROM Usuario WHERE Activado IS NULL AND EsAdministrador IS null ORDER BY Id_Usuario DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query = "SELECT Id_usuario,Acceso,Nombre,ApellidoPaterno,ApellidoMaterno,Email,CONVERT(varchar,CreacionFecha,105)'CreacionFecha', CASE WHEN EsCliente=1 THEN 'Cliente' WHEN EsConsultor=1 THEN 'Consultor' WHEN EsOperador=1 THEN 'Constructor/Operador' ELSE '' END 'Rol' FROM Usuario WHERE Activado IS NULL AND EsAdministrador IS null AND Acceso LIKE '%" + txtSearch.Text.Trim() + "%' OR Nombre LIKE '%" + txtSearch.Text.Trim() + "%' ORDER BY Id_Usuario DESC"
        End If

            gridEmpleado.DataSource = obj.Consultar(Query)
            gridEmpleado.DataBind()
        'Dim Query = "SELECT Emp.Id_empleado,CASE WHEN us.Activado=1 THEN Null ELSE Us.Acceso END 'Acceso',Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha',CASE WHEN us.EsSupervisor IS NULL THEN '' ELSE 'Supervisor' END 'Rol' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado AND Us.Activado IS NULL WHERE Emp.Activado IS NULL AND Inst.Id_Instalacion=" + CType(Me.Master, Admin).IdInstalacion.ToString() + " ORDER BY us.EsSupervisor DESC, Emp.Id_empleado DESC"
        'If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
        '        Query = "SELECT Emp.Id_empleado,CASE WHEN us.Activado=1 THEN Null ELSE Us.Acceso END 'Acceso',Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha',CASE WHEN us.EsSupervisor IS NULL THEN '' ELSE 'Supervisor' END 'Rol' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado AND Us.Activado IS NULL WHERE (Emp.Activado IS NULL AND Inst.Id_Instalacion=" + CType(Me.Master, Admin).IdInstalacion.ToString() + ") AND ( Emp.Nombre LIKE '%" + txtSearch.Text.Trim() + "%' OR us.Acceso LIKE '%" + txtSearch.Text.Trim() + "%')  ORDER BY us.EsSupervisor DESC, Emp.Id_empleado DESC"
        '    End If

        '    gridEmpleado.DataSource = obj.Consultar(Query)
        '    gridEmpleado.DataBind()
        'End If



    End Sub

    'Public Sub DropDownListInstalacion()
    '    Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
    '    If objUs Is Nothing Then
    '        FormsAuthentication.SignOut()
    '        Response.Redirect("Index.aspx")

    '    End If
    '    If obj.EsAdministrador(objUs.Id_usuario) Then
    '        ddl_Instalacion.DataSource = obj.LlenarDropDownList("SELECt Id_instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL")
    '        ddl_Instalacion.DataBind()
    '        ddl_Instalacion.Items.Insert(0, New ListItem("[Seleccionar]"))
    '    Else
    '        ddl_Instalacion.DataSource = obj.LlenarDropDownList("SELECt Id_instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL AND Id_instalacion=" + CType(Me.Master, Admin).IdInstalacion.ToString() + "")
    '        ddl_Instalacion.DataBind()
    '        ddl_Instalacion.Items.Insert(0, New ListItem("[Seleccionar]"))
    '    End If

    'End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridEmpleado()

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (obj.AutenticaEmail(txtEmail.Value)) Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ya existe un usuario con el correo " + txtEmail.Value.ToString() + ".")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        Else
            If (obj.AutenticarUsuario(txtUsuario.Text)) Then
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ya existe un usuario con el nombre " + txtUsuario.Text.ToString() + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            Else

                If ddl_Rol.SelectedIndex = 1 Then
                    Dim Materno As String = txtMaterno.Text
                    'If (Materno = String.Empty) Then
                    ' '   Materno = DBNull.Value.ToString()
                    'End If
                    Dim Nombre As String = txtNombre.Text
                    Dim Paterno As String = txtPaterno.Text

                    'Dim ddlInstalacion = ddl_Instalacion.SelectedValue

                    Dim sqlQuery = "INSERT INTO Usuario(Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha,Acceso,Contrasena,Email,EsCliente) VALUES('" + Nombre + "','" + Paterno + "','" + Materno + "',DATEADD(HH, -5, GETDATE()),'" + txtUsuario.Text + "','" + txtPassword.Text + "','" + txtEmail.Value + "',1)"
                    If obj.Insertar(sqlQuery) Then



                        MostrarGridEmpleado()
                        If gridEmpleado.Rows.Count = 0 Then

                        Else
                            Dim instalacion = gridEmpleado.Rows(0).Cells(6).Text
                            Dim FechaCreacion = gridEmpleado.Rows(0).Cells(7).Text
                            Dim IdUsuario As String = gridEmpleado.DataKeys(0).Values("Id_Usuario")
                            Dim objAtr As New AtributosEmpleado
                            With objAtr

                                .Id_empleado = IdUsuario
                                .Email = txtEmail.Value
                                .Usuario = txtUsuario.Text
                                .Nombre = txtNombre.Text
                                .ApellidoPaterno = txtPaterno.Text
                                .ApellidoMaterno = txtMaterno.Text
                                .Instalacion = instalacion
                                .CreacionFecha = FechaCreacion

                            End With
                            Session("DatosEmpleado") = objAtr
                            Dim script As String = "alert('Registro creado exitosamente.'); window.location.href= 'Detalle.aspx';"

                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                        End If

                        'Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                        'ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    Else
                        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    End If

                ElseIf ddl_Rol.SelectedIndex = 2 Then
                    Dim Materno As String = txtMaterno.Text
                    'If (Materno = String.Empty) Then
                    ' '   Materno = DBNull.Value.ToString()
                    'End If
                    Dim Nombre As String = txtNombre.Text
                    Dim Paterno As String = txtPaterno.Text

                    'Dim ddlInstalacion = ddl_Instalacion.SelectedValue

                    Dim sqlQuery = "INSERT INTO Usuario(Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha,Acceso,Contrasena,Email,EsConsultor) VALUES('" + Nombre + "','" + Paterno + "','" + Materno + "',DATEADD(HH, -5, GETDATE()),'" + txtUsuario.Text + "','" + txtPassword.Text + "','" + txtEmail.Value + "',1)"
                    If obj.Insertar(sqlQuery) Then




                        MostrarGridEmpleado()
                        If gridEmpleado.Rows.Count = 0 Then

                        Else
                            Dim instalacion = gridEmpleado.Rows(0).Cells(6).Text
                            Dim FechaCreacion = gridEmpleado.Rows(0).Cells(7).Text
                            Dim IdUsuario As String = gridEmpleado.DataKeys(0).Values("Id_Usuario")
                            Dim objAtr As New AtributosEmpleado
                            With objAtr

                                .Id_empleado = IdUsuario
                                .Email = txtEmail.Value
                                .Usuario = txtUsuario.Text
                                .Nombre = txtNombre.Text
                                .ApellidoPaterno = txtPaterno.Text
                                .ApellidoMaterno = txtMaterno.Text
                                .Instalacion = instalacion
                                .CreacionFecha = FechaCreacion

                            End With
                            Session("DatosEmpleado") = objAtr
                            Dim script As String = "alert('Registro creado exitosamente.'); window.location.href= 'Detalle.aspx';"

                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                        End If
                    Else
                        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    End If

                ElseIf ddl_Rol.SelectedIndex = 3 Then
                    Dim Materno As String = txtMaterno.Text
                    'If (Materno = String.Empty) Then
                    ' '   Materno = DBNull.Value.ToString()
                    'End If
                    Dim Nombre As String = txtNombre.Text
                    Dim Paterno As String = txtPaterno.Text

                    'Dim ddlInstalacion = ddl_Instalacion.SelectedValue

                    Dim sqlQuery = "INSERT INTO Usuario(Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha,Acceso,Contrasena,Email,EsOperador) VALUES('" + Nombre + "','" + Paterno + "','" + Materno + "',DATEADD(HH, -5, GETDATE()),'" + txtUsuario.Text + "','" + txtPassword.Text + "','" + txtEmail.Value + "',1)"
                    If obj.Insertar(sqlQuery) Then



                        MostrarGridEmpleado()
                        If gridEmpleado.Rows.Count = 0 Then

                        Else
                            Dim instalacion = gridEmpleado.Rows(0).Cells(6).Text
                            Dim FechaCreacion = gridEmpleado.Rows(0).Cells(7).Text
                            Dim IdUsuario As String = gridEmpleado.DataKeys(0).Values("Id_Usuario")
                            Dim objAtr As New AtributosEmpleado
                            With objAtr

                                .Id_empleado = IdUsuario
                                .Email = txtEmail.Value
                                .Usuario = txtUsuario.Text
                                .Nombre = txtNombre.Text
                                .ApellidoPaterno = txtPaterno.Text
                                .ApellidoMaterno = txtMaterno.Text
                                .Instalacion = instalacion
                                .CreacionFecha = FechaCreacion

                            End With
                            Session("DatosEmpleado") = objAtr
                            Dim script As String = "alert('Registro creado exitosamente.'); window.location.href= 'Detalle.aspx';"

                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                        End If
                    Else
                        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    End If


                End If


            End If
        End If







    End Sub

    Private Sub Limpiar()
        txtNombre.Text = String.Empty
        'ddl_Instalacion.SelectedIndex = 0
        txtPaterno.Text = String.Empty
        txtMaterno.Text = String.Empty
        txtUsuario.Text = String.Empty
        txtEmail.Value = String.Empty
        txtPassword.Text = String.Empty
        txtPasswordConfirm.Text = String.Empty

    End Sub

    Protected Sub gridEmpleado_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridEmpleado.PageIndex = e.NewPageIndex

        MostrarGridEmpleado()
    End Sub

    Protected Sub gridEmpleado_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridEmpleado.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Usuario set Activado=1 WHERE Id_Usuario= " + Id.ToString() + ""
            If obj.Eliminar(sqlQuery) Then
                MostrarGridEmpleado()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridEmpleado.DataKeys(row.RowIndex).Value

            Dim txtEditNombre As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
            txtEditNombre.Visible = True
            Dim lblNombre As Label = CType(row.FindControl("lblNombre"), Label)
            lblNombre.Visible = False


            Dim txtEditApellidoPaterno As TextBox = CType(row.FindControl("txtEditApellidoPaterno"), TextBox)
            txtEditApellidoPaterno.Visible = True
            Dim lblApellidoPaterno As Label = CType(row.FindControl("lblApellidoPaterno"), Label)
            lblApellidoPaterno.Visible = False


            Dim txtEditApellidoMaterno As TextBox = CType(row.FindControl("txtEditApellidoMaterno"), TextBox)
            txtEditApellidoMaterno.Visible = True
            Dim lblApellidoMaterno As Label = CType(row.FindControl("lblApellidoMaterno"), Label)
            lblApellidoMaterno.Visible = False

            Dim txtEmail As TextBox = CType(row.FindControl("txtEditEmail"), TextBox)
            txtEmail.Visible = True
            Dim lblEmail As Label = CType(row.FindControl("lblEmail"), Label)
            lblEmail.Visible = False


            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)
            btnCancel.Visible = True

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)
            btnAct.Visible = True

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)
            btnEditar.Visible = False


            Dim btnAgregar As LinkButton = CType(row.FindControl("btnAgregar"), LinkButton)
            btnAgregar.Visible = False
            'gridInstalacion.Columns(0).Visible = False
            'gridInstalacion.Columns(1).Visible = True


        ElseIf e.CommandName = "Actualizar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridEmpleado.DataKeys(row.RowIndex).Value

            Dim NombreActual As Label = CType(row.FindControl("lblNombre"), Label)
            Dim NombreNuevo As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)

            Dim PaternoActual As Label = CType(row.FindControl("lblApellidoPaterno"), Label)
            Dim PaternoNuevo As TextBox = CType(row.FindControl("txtEditApellidoPaterno"), TextBox)

            Dim MaternoActual As Label = CType(row.FindControl("lblApellidoMaterno"), Label)
            Dim MaternoNuevo As TextBox = CType(row.FindControl("txtEditApellidoMaterno"), TextBox)

            Dim CorreoActual As Label = CType(row.FindControl("lblEmail"), Label)
            Dim CorreoNuevo As TextBox = CType(row.FindControl("txtEditEmail"), TextBox)


            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnAgregar As LinkButton = CType(row.FindControl("btnAgregar"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Usuario set Nombre= '" + NombreNuevo.Text + "', ApellidoPaterno='" + PaternoNuevo.Text + "', ApellidoMaterno='" + MaternoNuevo.Text + "',Email='" + CorreoNuevo.Text + "' Where Id_Usuario=" + Id.ToString + ""
            If NombreActual.Text <> NombreNuevo.Text Or PaternoActual.Text <> PaternoNuevo.Text Or MaternoActual.Text <> MaternoNuevo.Text Or CorreoActual.Text <> CorreoNuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    NombreActual.Text = NombreNuevo.Text
                    PaternoActual.Text = PaternoNuevo.Text
                    MaternoActual.Text = MaternoNuevo.Text
                    CorreoActual.Text = CorreoNuevo.Text

                    NombreActual.Visible = True
                    NombreNuevo.Visible = False

                    PaternoActual.Visible = True
                    PaternoNuevo.Visible = False

                    MaternoActual.Visible = True
                    MaternoNuevo.Visible = False

                    CorreoActual.Visible = True
                    CorreoNuevo.Visible = False

                    btnCancel.Visible = False
                    btnAct.Visible = False
                    btnEditar.Visible = True
                    btnAgregar.Visible = True

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

            Dim txtEditNombre As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
            txtEditNombre.Visible = False
            Dim lblNombre As Label = CType(row.FindControl("lblNombre"), Label)
            lblNombre.Visible = True


            Dim txtEditApellidoPaterno As TextBox = CType(row.FindControl("txtEditApellidoPaterno"), TextBox)
            txtEditApellidoPaterno.Visible = False
            Dim lblApellidoPaterno As Label = CType(row.FindControl("lblApellidoPaterno"), Label)
            lblApellidoPaterno.Visible = True


            Dim txtEditApellidoMaterno As TextBox = CType(row.FindControl("txtEditApellidoMaterno"), TextBox)
            txtEditApellidoMaterno.Visible = False
            Dim ApellidoMaterno As Label = CType(row.FindControl("lblApellidoMaterno"), Label)
            ApellidoMaterno.Visible = True

            Dim txtEmail As TextBox = CType(row.FindControl("txtEditEmail"), TextBox)
            txtEmail.Visible = False
            Dim lblEmail As Label = CType(row.FindControl("lblEmail"), Label)
            lblEmail.Visible = True



            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)
            btnCancel.Visible = False

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)
            btnAct.Visible = False

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)
            btnEditar.Visible = True

            Dim btnAgregar As LinkButton = CType(row.FindControl("btnAgregar"), LinkButton)
            btnAgregar.Visible = True

            'gridInstalacion.Columns(0).Visible = True
            'gridInstalacion.Columns(1).Visible = False

        ElseIf e.CommandName = "Agregar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridEmpleado.DataKeys(row.RowIndex).Value
            'Dim row2 As GridViewRow = CType((TryCast(e.CommandSource, LinkButton)).Parent.Parent, GridViewRow)

            Dim lblNombre As Label = CType(row.FindControl("lblNombre"), Label)

            Dim lblApellidoPaterno As Label = CType(row.FindControl("lblApellidoPaterno"), Label)

            Dim lblApellidoMaterno As Label = CType(row.FindControl("lblApellidoMaterno"), Label)
            Dim Email As Label = CType(row.FindControl("lblEmail"), Label)
            Dim Usuario = row.Cells(2).Text

            Dim instalacion = row.Cells(6).Text
            Dim FechaCreacion = row.Cells(7).Text

            Dim objAtr As New AtributosEmpleado
            With objAtr

                .Id_empleado = Id
                .Email = Email.Text
                .Usuario = Usuario
                .Nombre = lblNombre.Text
                .ApellidoPaterno = lblApellidoPaterno.Text
                .ApellidoMaterno = lblApellidoMaterno.Text
                .Instalacion = instalacion
                .CreacionFecha = FechaCreacion

            End With
            Session("DatosEmpleado") = objAtr
            Response.Redirect("Detalle.aspx")



            'Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(lblNombre.Text)))
            'Dim encodedString2 As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(lblApellidoPaterno.Text)))

            ''Query String: ? strID = XXXX&strName=yyyy&strDate=zzzzz

            'Dim queryString As String = Request.QueryString.ToString()
            ''String.Format("yourpage.aspx?strId={0}&strName={1}&strDate{2}"

            'Response.Redirect(String.Format("Usuario.aspx?lblNombre=encodedString&lblApellidoPaterno=encodedString2"))
        End If
    End Sub
End Class