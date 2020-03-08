Public Class Instalacion
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Private Sub Instalacion_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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

            MostrarGridInstalacion()
            DropDownListRegion()
        End If

    End Sub
    Private HaCambiadoElTexto As Boolean = False

    Public Sub MostrarGridInstalacion()
        Dim Query = "SELECT Id_Instalacion, catIns.Nombre as Instalacion,catReg.Nombre as Region FROM Cat_Instalacion catIns JOIN Cat_Region catReg on catIns.id_region=catReg.id_region WHERE catIns.Activado IS NULL ORDER BY Id_Instalacion DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query = "SELECT Id_Instalacion, catIns.Nombre as Instalacion,catReg.Nombre as Region FROM Cat_Instalacion catIns JOIN Cat_Region catReg on catIns.id_region=catReg.id_region WHERE catIns.Activado IS NULL  AND catIns.Nombre LIKE  '%" + txtSearch.Text.Trim() + "%' ORDER BY Id_Instalacion DESC"
        End If

        gridInstalacion.DataSource = obj.Consultar(Query)

        gridInstalacion.DataBind()
        'And catIns.Nombre Like '%" + txtFiltro.Text + "%'
    End Sub


    Public Sub DropDownListRegion()
        ddl_Region.DataSource = obj.LlenarDropDownList("SELECT id_Region, Nombre FROM Cat_Region WHERE Activado Is NULL")
        'ddl_Region.DataTextField = "Nombre"
        'ddl_Region.DataValueField = "id_Region"
        ddl_Region.DataBind()
        ddl_Region.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub


    'Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
    '    gridInstalacion.PageIndex = e.NewPageIndex
    '    MostrarGridInstalacion()

    'End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click


        Dim txtInstalacionn As String = txtNombreInstalacion.Text
        Dim ddlRegion = ddl_Region.SelectedValue

        Dim sqlQuery = "INSERT INTO Cat_Instalacion (id_region,Nombre,Activado) VALUES(" + ddlRegion + ",'" + txtInstalacionn + "',NULL)"
        Try
            If obj.Insertar(sqlQuery) Then


                Limpiar()

                MostrarGridInstalacion()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If
        Catch ex As Exception
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
            scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        End Try

    End Sub


    'Protected Sub gridInstalacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridInstalacion.SelectedIndexChanged

    '    Dim row As GridViewRow = gridInstalacion.SelectedRow
    '    Dim Id_Instalacion As Integer = Convert.ToInt32(gridInstalacion.DataKeys(row.RowIndex).Values("Id_Instalacion"))


    '    Dim sqlQuery = "UPDATE Cat_Instalacion set Activado=1 WHERE Id_instalacion= " + Id_Instalacion.ToString
    '    If obj.Eliminar(sqlQuery) Then
    '        MostrarGridInstalacion()
    '    End If

    'End Sub

    'Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
    '    Dim isUpdateVisible As Boolean = False
    '    For Each row As GridViewRow In gridInstalacion.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = True
    '            For i As Integer = 1 To row.Cells.Count - 1
    '                Try
    '                    row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
    '                Catch ex As Exception

    '                End Try
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If isChecked AndAlso Not isUpdateVisible Then
    '                    isUpdateVisible = True
    '                End If
    '            Next
    '        End If
    '    Next
    '    btnEditar.Visible = False
    '    btnGuardarEdit.Visible = isUpdateVisible
    '    btnCancelar.Visible = isUpdateVisible
    'End Sub
    'Protected Sub btnGuardarEdit_Click(sender As Object, e As EventArgs) Handles btnGuardarEdit.Click
    '    For Each row As GridViewRow In gridInstalacion.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim NombreActual = row.Cells(1).Controls.OfType(Of Label)().FirstOrDefault.Text
    '            'Dim rowId As GridViewRow = gridInstalacion.Rows
    '            'Dim Id_Instalacion As Integer = Convert.ToInt32(gridInstalacion.DataKeys(rowId.RowIndex).Values("Id_Instalacion"))
    '            'Dim txtedit As String = Request.Form("txtEditInstalacion")
    '            'Dim txtedit = CType(row.Cells(1).FindControl("txtEditInstalacion"), TextBox).Text
    '            Dim Id_Instalacion As Integer = Convert.ToInt32(gridInstalacion.DataKeys(row.RowIndex).Value)
    '            Dim NombreNuevo As String = row.Cells(1).Controls.OfType(Of TextBox)().FirstOrDefault().Text
    '            Dim sqlQuery = "UPDATE Cat_Instalacion set Nombre= '" + NombreNuevo + "' Where Id_instalacion=" + Id_Instalacion.ToString + ""
    '            If NombreNuevo <> NombreActual Then

    '                If obj.Modificar(sqlQuery) Then
    '                    MostrarGridInstalacion()
    '                End If
    '            End If
    '            row.Cells(1).Controls.OfType(Of Label)().FirstOrDefault().Visible = True
    '            row.Cells(1).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = False
    '        End If
    '    Next
    '    btnCancelar.Visible = False
    '    btnGuardarEdit.Visible = False
    '    btnEditar.Visible = True
    'End Sub

    'Protected Sub txtEditInstalacion_TextChanged(sender As Object, e As EventArgs)
    '    'Dim int = TryCast(gridInstalacion.FooterRow.FindControl("txtEditInstalacion"), TextBox).Text
    '    HaCambiadoElTexto = True
    'End Sub

    'Protected Sub txtFiltro_TextChanged(sender As Object, e As EventArgs)
    '    MostrarGridInstalacion()

    'End Sub

    'Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    '    MostrarGridInstalacion()
    '    btnGuardarEdit.Visible = False
    '    btnCancelar.Visible = False
    '    btnEditar.Visible = True

    'End Sub
    Private Sub Limpiar()
        txtNombreInstalacion.Text = String.Empty
        ddl_Region.SelectedIndex = 0
        txtSearch.Text = String.Empty
    End Sub

    Protected Sub gridInstalacion_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        gridInstalacion.PageIndex = e.NewPageIndex

        MostrarGridInstalacion()
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridInstalacion()
    End Sub

    Protected Sub gridInstalacion_RowCommand(sender As Object, e As GridViewCommandEventArgs)


        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridInstalacion.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Cat_Instalacion set Activado=1 WHERE Id_instalacion= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                MostrarGridInstalacion()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridInstalacion.DataKeys(row.RowIndex).Value

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditInstalacion"), TextBox)
            txtEdit.Visible = True
            Dim lblInstalacion As Label = CType(row.FindControl("lblInstalacion"), Label)
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
            Dim Id As Integer = gridInstalacion.DataKeys(row.RowIndex).Value

            Dim Actual As Label = CType(row.FindControl("lblInstalacion"), Label)

            Dim Nuevo As TextBox = CType(row.FindControl("txtEditInstalacion"), TextBox)

            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Cat_Instalacion set Nombre= '" + Nuevo.Text + "' Where Id_instalacion=" + Id.ToString + ""
            If Actual.Text <> Nuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    Actual.Text = Nuevo.Text
                    Actual.Visible = True
                    Nuevo.Visible = False
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

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditInstalacion"), TextBox)
            txtEdit.Visible = False
            Dim lblInstalacion As Label = CType(row.FindControl("lblInstalacion"), Label)
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