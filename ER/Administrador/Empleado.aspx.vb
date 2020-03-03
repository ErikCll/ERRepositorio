Public Class Empleado
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then

            MostrarGridEmpleado()
            DropDownListInstalacion()
        End If

    End Sub

    Public Sub MostrarGridEmpleado()
        Dim Query = "SELECT Emp.Id_empleado,us.Acceso,Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado WHERE Emp.Activado IS NULL ORDER BY Emp.Id_empleado DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query = "SELECT Emp.Id_empleado,us.Acceso,Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado WHERE Emp.Activado IS NULL AND Emp.Nombre LIKE '%" + txtSearch.Text.Trim() + "%' OR us.Acceso LIKE '%" + txtSearch.Text.Trim() + "%'  ORDER BY Emp.Id_empleado DESC"
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
            'Dim ctl = e.CommandSource
            'Dim row As GridViewRow = ctl.NamingContainer
            'Dim Id As Integer = gridEmpleado.DataKeys(row.RowIndex).Value
            'Dim sqlQuery = "UPDATE Cat_Area set Activado=1 WHERE Id_Area= " + Id.ToString()
            'If obj.Eliminar(sqlQuery) Then
            '    MostrarGridEmpleado()
            '    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
            '    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            'Else
            '    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
            '    scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            'End If

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
            'Dim ctl = e.CommandSource
            'Dim row As GridViewRow = ctl.NamingContainer
            'Dim Id As Integer = gridEmpleado.DataKeys(row.RowIndex).Value

            'Dim AreaActual As Label = CType(row.FindControl("lblArea"), Label)
            'Dim AreaNuevo As TextBox = CType(row.FindControl("txtEditArea"), TextBox)

            'Dim CodigoActual As Label = CType(row.FindControl("lblCodigo"), Label)

            'Dim CodigoNuevo As TextBox = CType(row.FindControl("txtEditCodigo"), TextBox)


            'Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            'Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            'Dim btnAgregar As LinkButton = CType(row.FindControl("btnAgregar"), LinkButton)

            'Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            'Dim sqlQuery = "UPDATE Cat_Area set Nombre= '" + AreaNuevo.Text + "', Codigo='" + CodigoNuevo.Text + "' Where Id_instalacion=" + Id.ToString + ""
            'If AreaActual.Text <> AreaNuevo.Text Or CodigoActual.Text <> CodigoNuevo.Text Then
            '    If obj.Modificar(sqlQuery) Then

            '        AreaActual.Text = AreaNuevo.Text
            '        CodigoActual.Text = CodigoNuevo.Text

            '        AreaActual.Visible = True
            '        AreaNuevo.Visible = False
            '        CodigoActual.Visible = True
            '        CodigoNuevo.Visible = False

            '        btnCancel.Visible = False
            '        btnAct.Visible = False
            '        btnEditar.Visible = True
            '        btnAgregar.Visible = True

            '        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizó el dato correctamente.")
            '        scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            '    Else
            '        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al actualizar el dato.")
            '        scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            '    End If

            'End If

        ElseIf e.CommandName = "Cancelar" Then

            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditArea"), TextBox)
            txtEdit.Visible = False
            Dim lblArea As Label = CType(row.FindControl("lblArea"), Label)
            lblArea.Visible = True


            Dim txtEditCodigo As TextBox = CType(row.FindControl("txtEditCodigo"), TextBox)
            txtEditCodigo.Visible = False
            Dim lblCodigo As Label = CType(row.FindControl("lblCodigo"), Label)
            lblCodigo.Visible = True

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
        End If
    End Sub
End Class