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




                If obj.RolUsuario(IdUsuario, URL) Then


                Else
                    Dim script As String = "alert('No cuentas con los accesos para este apartado'); window.location.href= 'AdminInicio.aspx';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

                End If



            Else
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())


            End If
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("DatosEmpleado") = Nothing

        Page.Form.DefaultButton = btnBuscar.UniqueID

        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then

            MostrarGridEmpleado()
            DropDownListInstalacion()
        End If

    End Sub

    Public Sub MostrarGridEmpleado()
        Dim Query = "SELECT Emp.Id_empleado,CASE WHEN us.Activado=1 THEN Null ELSE Us.Acceso END 'Acceso',Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado AND Us.Activado IS NULL WHERE Emp.Activado IS NULL ORDER BY Emp.Id_empleado DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query = "SELECT Emp.Id_empleado,CASE WHEN us.Activado=1 THEN Null ELSE Us.Acceso END 'Acceso',Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado AND Us.Activado IS NULL WHERE Emp.Activado IS NULL AND Emp.Nombre LIKE '%" + txtSearch.Text.Trim() + "%' OR us.Acceso LIKE '%" + txtSearch.Text.Trim() + "%'  ORDER BY Emp.Id_empleado DESC"
        End If

        gridEmpleado.DataSource = obj.Consultar(Query)
        gridEmpleado.DataBind()
    End Sub

    Public Sub DropDownListInstalacion()
        ddl_Instalacion.DataSource = obj.LlenarDropDownList("SELECt Id_instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL")
        ddl_Instalacion.DataBind()
        ddl_Instalacion.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridEmpleado()

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Dim Materno As String = If(String.IsNullOrWhiteSpace(String.Format("NULL")), Nothing, txtMaterno.Text)
        Dim Materno As String = txtMaterno.Text
        'If (Materno = String.Empty) Then
        ' '   Materno = DBNull.Value.ToString()
        'End If
        Dim Nombre As String = txtNombre.Text
        Dim Paterno As String = txtPaterno.Text

        Dim ddlInstalacion = ddl_Instalacion.SelectedValue

        Dim sqlQuery = "INSERT INTO Cat_Empleado(Id_instalacion,Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha) VALUES(" + ddlInstalacion + ",'" + Nombre + "','" + Paterno + "','" + Materno + "',GETDATE())"
        Try
            If obj.Insertar(sqlQuery) Then


                Limpiar()

                MostrarGridEmpleado()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If
        Catch ex As Exception
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
            scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        End Try

    End Sub

    Private Sub Limpiar()
        txtNombre.Text = String.Empty
        ddl_Instalacion.SelectedIndex = 0
        txtPaterno.Text = String.Empty
        txtMaterno.Text = String.Empty

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
            Dim sqlQuery = "BEGIN TRAN UPDATE Cat_Empleado set Activado=1 WHERE Id_empleado= " + Id.ToString()+" UPDATE Usuario set Activado=1 WHERE Id_empleado="+Id.ToString()+" COMMIT TRAN"
            If obj.Eliminar(sqlQuery) Then
                MostrarGridEmpleado()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
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




            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnAgregar As LinkButton = CType(row.FindControl("btnAgregar"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Cat_Empleado set Nombre= '" + NombreNuevo.Text + "', ApellidoPaterno='" + PaternoNuevo.Text + "', ApellidoMaterno='" + MaternoNuevo.Text + "' Where Id_empleado=" + Id.ToString + ""
            If NombreActual.Text <> NombreNuevo.Text Or PaternoActual.Text <> PaternoNuevo.Text Or MaternoActual.Text <> MaternoNuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    NombreActual.Text = NombreNuevo.Text
                    PaternoActual.Text = PaternoNuevo.Text
                    MaternoActual.Text = MaternoNuevo.Text

                    NombreActual.Visible = True
                    NombreNuevo.Visible = False

                    PaternoActual.Visible = True
                    PaternoNuevo.Visible = False

                    MaternoActual.Visible = True
                    MaternoNuevo.Visible = False

                    btnCancel.Visible = False
                    btnAct.Visible = False
                    btnEditar.Visible = True
                    btnAgregar.Visible = True

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
            Dim instalacion = row.Cells(6).Text
            Dim FechaCreacion = row.Cells(7).Text

            Dim objAtr As New AtributosEmpleado
            With objAtr

                .Id_empleado = Id
                .Nombre = lblNombre.Text
                .ApellidoPaterno = lblApellidoPaterno.Text
                .ApellidoMaterno = lblApellidoMaterno.Text
                .Instalacion = instalacion
                .CreacionFecha = FechaCreacion

            End With
            Session("DatosEmpleado") = objAtr
            Response.Redirect("Usuario.aspx")



            'Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(lblNombre.Text)))
            'Dim encodedString2 As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(lblApellidoPaterno.Text)))

            ''Query String: ? strID = XXXX&strName=yyyy&strDate=zzzzz

            'Dim queryString As String = Request.QueryString.ToString()
            ''String.Format("yourpage.aspx?strId={0}&strName={1}&strDate{2}"

            'Response.Redirect(String.Format("Usuario.aspx?lblNombre=encodedString&lblApellidoPaterno=encodedString2"))
        End If
    End Sub
End Class