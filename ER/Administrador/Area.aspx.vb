Public Class Area
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then

            MostrarGridArea()
            DropDownListInstalacion()
        End If
    End Sub

    Public Sub MostrarGridArea()
        Dim Query = "SELECT catArea.Id_area, catArea.Nombre 'Area', catIns.Nombre 'Instalacion', catArea.Codigo FROM Cat_Area catArea JOIN Cat_Instalacion catIns on catArea.Id_instalacion=catIns.Id_instalacion where catArea.Activado IS NULL ORDER BY CatArea.Id_area DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query = "SELECT catArea.Id_area, catArea.Nombre 'Area', catIns.Nombre 'Instalacion', catArea.Codigo FROM Cat_Area catArea JOIN Cat_Instalacion catIns on catArea.Id_instalacion=catIns.Id_instalacion where catArea.Activado IS NULL AND catArea.Nombre LIKE  '%" + txtSearch.Text.Trim() + "%' ORDER BY CatArea.Id_area DESC"
        End If
        gridArea.DataSource = obj.Consultar(Query)

        gridArea.DataBind()

    End Sub

    Public Sub DropDownListInstalacion()
        ddl_Instalacion.DataSource = obj.LlenarDropDownList("SELECt Id_instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL")
        ddl_Instalacion.DataBind()
        ddl_Instalacion.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridArea()

    End Sub

    Protected Sub gridArea_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridArea.PageIndex = e.NewPageIndex

        MostrarGridArea()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim NombreArea = txtArea.Text
        Dim Instalacion = ddl_Instalacion.SelectedValue
        Dim Codigo = txt_NombreCodigo.Text
        Dim sqlQuery = "INSERT INTO Cat_Area(Id_instalacion,Nombre,Codigo) VALUES(" + Instalacion + ",'" + NombreArea + "','" + Codigo + "')"
        Try
            If (obj.Insertar(sqlQuery)) Then

                Limpiar()
                MostrarGridArea()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        Catch ex As Exception
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
            scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End Try

    End Sub
    Private Sub Limpiar()
        txtArea.Text = String.Empty
        ddl_Instalacion.SelectedIndex = 0
        txt_NombreCodigo.Text = String.Empty
    End Sub

    Protected Sub gridArea_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridArea.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Cat_Area set Activado=1 WHERE Id_Area= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                MostrarGridArea()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridArea.DataKeys(row.RowIndex).Value

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditArea"), TextBox)
            txtEdit.Visible = True
            Dim lblArea As Label = CType(row.FindControl("lblArea"), Label)
            lblArea.Visible = False


            Dim txtEditCodigo As TextBox = CType(row.FindControl("txtEditCodigo"), TextBox)
            txtEditCodigo.Visible = True
            Dim lblCodigo As Label = CType(row.FindControl("lblCodigo"), Label)
            lblCodigo.Visible = False

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
            Dim Id As Integer = gridArea.DataKeys(row.RowIndex).Value

            Dim AreaActual As Label = CType(row.FindControl("lblArea"), Label)
            Dim AreaNuevo As TextBox = CType(row.FindControl("txtEditArea"), TextBox)

            Dim CodigoActual As Label = CType(row.FindControl("lblCodigo"), Label)

            Dim CodigoNuevo As TextBox = CType(row.FindControl("txtEditCodigo"), TextBox)


            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Cat_Area set Nombre= '" + AreaNuevo.Text + "', Codigo='" + CodigoNuevo.Text + "' Where Id_area=" + Id.ToString + ""
            If AreaActual.Text <> AreaNuevo.Text Or CodigoActual.Text <> CodigoNuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    AreaActual.Text = AreaNuevo.Text
                    CodigoActual.Text = CodigoNuevo.Text

                    AreaActual.Visible = True
                    AreaNuevo.Visible = False
                    CodigoActual.Visible = True
                    CodigoNuevo.Visible = False

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
            'gridInstalacion.Columns(0).Visible = True
            'gridInstalacion.Columns(1).Visible = False



        End If
    End Sub
End Class