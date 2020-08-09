Public Class Requisito1
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Private Sub Requisito_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Private Sub Requisito_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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
            DropDownListRegulador()
            TablaRequisito()
            Drops()

        End If
    End Sub


    Public Sub TablaRequisito()
        Dim query As String = "SELECT req.Id_Requisito,reg.Nombre 'Regulador',doc.Nombre'Documento', req.Nombre, req.VigenciaReg,req.VigenciaOpe,CASE WHEN req.TieneVigencia=1 THEN 'Si' ELSE '' END 'TieneVigencia' FROM Cat_Requisito req JOIN Cat_DocRegulador doc on req.Id_DocRegulador=doc.Id_DocRegulador JOIN Cat_Regulador reg on doc.Id_Regulador=reg.Id_Regulador WHERE req.Activado IS NULL AND reg.Activado IS NULL AND doc.Activado IS NULL ORDER BY req.Id_Requisito DESC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            query = "SELECT req.Id_Requisito,reg.Nombre 'Regulador',doc.Nombre'Documento', req.Nombre, req.VigenciaReg,req.VigenciaOpe,CASE WHEN req.TieneVigencia=1 THEN 'Si' ELSE '' END 'TieneVigencia' FROM Cat_Requisito req JOIN Cat_DocRegulador doc on req.Id_DocRegulador=doc.Id_DocRegulador JOIN Cat_Regulador reg on doc.Id_Regulador=reg.Id_Regulador WHERE req.Activado IS NULL AND reg.Activado IS NULL AND doc.Activado IS NULL AND req.Nombre LiKE '%" + txtSearch.Text.Trim() + "%' ORDER BY req.Id_Requisito DESC"
        End If
        gridRequisito.DataSource = obj.Consultar(query)
        gridRequisito.DataBind()
    End Sub

    Public Sub DropDownListRegulador()

        ddl_Regulador.DataSource = obj.LlenarDropDownList("SELECT Id_Regulador,Nombre FROM Cat_Regulador WHERE Activado IS NULL ORDER BY Id_Regulador DESC")
        'ddl_Region.DataTextField = "Nombre"
        'ddl_Region.DataValueField = "id_Region"
        ddl_Regulador.DataBind()
        ddl_Regulador.Items.Insert(0, New ListItem("[Seleccionar]", "0"))



    End Sub

    Public Sub DropDownListDocRegulador()

        ddl_DocRegulador.DataSource = obj.LlenarDropDownList("SELECT Id_DocRegulador,Nombre FROM Cat_DocRegulador WHERE Id_Regulador=" + ddl_Regulador.SelectedValue + " AND Activado IS NULL ORDER BY Id_DocRegulador DESC")
        'ddl_Region.DataTextField = "Nombre"
        'ddl_Region.DataValueField = "id_Region"
        ddl_DocRegulador.DataBind()
        ddl_DocRegulador.Items.Insert(0, New ListItem("[Seleccionar]"))



    End Sub

    Public Sub Drops()
        ddl_Regulatoria.Items.Insert(0, New ListItem("[Seleccionar]"))
        ddl_Regulatoria.Items.Insert(1, New ListItem("Mes"))
        ddl_Regulatoria.Items.Insert(2, New ListItem("Año"))

        ddl_Operativa.Items.Insert(0, New ListItem("[Seleccionar]"))
        ddl_Operativa.Items.Insert(1, New ListItem("Mes"))
        ddl_Operativa.Items.Insert(2, New ListItem("Año"))

    End Sub

    Protected Sub gridRegulador_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridRequisito.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Cat_Requisito set Activado=1 WHERE Id_Requisito= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                TablaRequisito()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridRequisito.DataKeys(row.RowIndex).Value
            Dim TieneVigencia As Label = CType(row.FindControl("lblTieneVigencia"), Label)
            If TieneVigencia.Text = "Si" Then
                Dim txtEdit As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
                txtEdit.Visible = True
                Dim lblInstalacion As Label = CType(row.FindControl("lblNombre"), Label)
                lblInstalacion.Visible = False

                Dim txtEdit2 As TextBox = CType(row.FindControl("txtEditVigenciaReg"), TextBox)
                txtEdit2.Visible = True
                Dim lblInstalacion2 As Label = CType(row.FindControl("lblVigenciaReg"), Label)
                lblInstalacion2.Visible = False

                Dim txtEdit3 As TextBox = CType(row.FindControl("txtEditVigenciaOpe"), TextBox)
                txtEdit3.Visible = True
                Dim lblInstalacion3 As Label = CType(row.FindControl("lblVigenciaOpe"), Label)
                lblInstalacion3.Visible = False



                Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)
                btnCancel.Visible = True

                Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)
                btnAct.Visible = True

                Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)
                btnEditar.Visible = False

            Else
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

            End If




        ElseIf e.CommandName = "Actualizar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridRequisito.DataKeys(row.RowIndex).Value
            Dim TieneVigencia As Label = CType(row.FindControl("lblTieneVigencia"), Label)

            Dim mesesRegularotia As TextBox = CType(row.FindControl("txtEditVigenciaReg"), TextBox)
            Dim meesesOperativa As TextBox = CType(row.FindControl("txtEditVigenciaOpe"), TextBox)

            If TieneVigencia.Text = "Si" Then
                If mesesRegularotia.Text = String.Empty Or meesesOperativa.Text = String.Empty Then

                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Llenar los campos a editar.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                Else

                    If Convert.ToInt32(meesesOperativa.Text) > Convert.ToInt32(mesesRegularotia.Text) Then
                        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "La vigencia Operativa no puede ser mayor a la Vigencia Regulatoria.")
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                    Else
                        If mesesRegularotia.Text = 0 Or meesesOperativa.Text = 0 Then
                            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "La cantidad debe ser mayor a 0.")
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                        Else
                            Dim Actual As Label = CType(row.FindControl("lblNombre"), Label)
                            Dim Nuevo As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)

                            Dim Actual2 As Label = CType(row.FindControl("lblVigenciaReg"), Label)
                            Dim Nuevo2 As TextBox = CType(row.FindControl("txtEditVigenciaReg"), TextBox)

                            Dim Actual3 As Label = CType(row.FindControl("lblVigenciaOpe"), Label)
                            Dim Nuevo3 As TextBox = CType(row.FindControl("txtEditVigenciaOpe"), TextBox)





                            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

                            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

                            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

                            Dim sqlQuery = "UPDATE Cat_Requisito set Nombre= '" + Nuevo.Text + "',VigenciaReg=" + Nuevo2.Text + ",VigenciaOpe=" + Nuevo3.Text + " Where Id_Requisito=" + Id.ToString + ""
                            If Actual.Text <> Nuevo.Text Or Actual2.Text <> Nuevo2.Text Or Actual3.Text <> Nuevo3.Text Then

                                If obj.Modificar(sqlQuery) Then

                                    Actual.Text = Nuevo.Text
                                    Actual2.Text = Nuevo2.Text
                                    Actual3.Text = Nuevo3.Text

                                    Actual.Visible = True
                                    Nuevo.Visible = False

                                    Actual2.Visible = True
                                    Nuevo2.Visible = False

                                    Actual3.Visible = True
                                    Nuevo3.Visible = False




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

                        End If

                    End If

                End If


            Else
                Dim Actual As Label = CType(row.FindControl("lblNombre"), Label)

                Dim Nuevo As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)





                Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

                Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

                Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

                Dim sqlQuery = "UPDATE Cat_Requisito set Nombre= '" + Nuevo.Text + "' Where Id_Requisito=" + Id.ToString + ""
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
            End If


        ElseIf e.CommandName = "Cancelar" Then

            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer

            Dim txtEdit As TextBox = CType(row.FindControl("txtEditNombre"), TextBox)
            txtEdit.Visible = False
            Dim lblInstalacion As Label = CType(row.FindControl("lblNombre"), Label)
            lblInstalacion.Visible = True

            Dim txtEdit2 As TextBox = CType(row.FindControl("txtEditVigenciaReg"), TextBox)
            txtEdit2.Visible = False
            Dim lblInstalacion2 As Label = CType(row.FindControl("lblVigenciaReg"), Label)
            lblInstalacion2.Visible = True

            Dim txtEdit3 As TextBox = CType(row.FindControl("txtEditVigenciaOpe"), TextBox)
            txtEdit3.Visible = False
            Dim lblInstalacion3 As Label = CType(row.FindControl("lblVigenciaOpe"), Label)
            lblInstalacion3.Visible = True



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
        gridRequisito.PageIndex = e.NewPageIndex

        TablaRequisito()
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        TablaRequisito()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If checkSin.Checked = False And checkCon.Checked = False Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar si cuenta o no con vigencia.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        Else
            If checkSin.Checked = True Then
                Dim query As String = "INSERT INTO Cat_Requisito(Nombre,Activado,TieneVigencia,Id_DocRegulador) values('" + txt_Regulador.Text + "',null,null," + ddl_DocRegulador.SelectedValue + ")"
                If obj.Insertar(query) Then
                    Limpiar()
                    TablaRequisito()
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                End If
            ElseIf checkCon.Checked = True Then
                If ddl_Operativa.SelectedIndex = 0 Or ddl_Regulatoria.SelectedIndex = 0 Then
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar tipo de periodo.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                ElseIf txtOperativa.Text = String.Empty Or txtRegulatoria.Text = String.Empty Then

                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Llenar los campos de cantidad.")
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                Else
                    Dim mesesRegularotia As Integer = txtRegulatoria.Text
                    Dim meesesOperativa As Integer = txtOperativa.Text
                    If ddl_Regulatoria.SelectedIndex = 2 Then
                        mesesRegularotia = mesesRegularotia * 12

                    End If
                    If ddl_Operativa.SelectedIndex = 2 Then
                        meesesOperativa = meesesOperativa * 12

                    End If
                    If meesesOperativa > mesesRegularotia Then
                        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "La vigencia Operativa no puede ser mayor a la Vigencia Regulatoria.")
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                    Else
                        If mesesRegularotia = 0 Or meesesOperativa = 0 Then
                            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "La cantidad debe ser mayor a 0.")
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                        Else
                            Dim query As String = "INSERT INTO Cat_Requisito(Nombre,Activado,VigenciaReg,VigenciaOpe,TieneVigencia,Id_DocRegulador) values('" + txt_Regulador.Text + "',null," + mesesRegularotia.ToString() + "," + meesesOperativa.ToString() + ",1," + ddl_DocRegulador.SelectedValue + ")"
                            If obj.Insertar(query) Then
                                Limpiar()
                                TablaRequisito()
                                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                            Else
                                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                            End If
                        End If

                    End If


                End If

            End If
        End If



    End Sub

    Public Sub Limpiar()
        txt_Regulador.Text = String.Empty
        txtRegulatoria.Text = String.Empty
        txtOperativa.Text = String.Empty
        ddl_Regulador.SelectedIndex = 0
        ddl_Regulatoria.SelectedIndex = 0
        ddl_Operativa.SelectedIndex = 0
        checkCon.Checked = False
        checkSin.Checked = False
        ddl_DocRegulador.SelectedIndex = 0



    End Sub

    Protected Sub ddl_Regulador_SelectedIndexChanged(sender As Object, e As EventArgs)

        DropDownListDocRegulador()

    End Sub


    Protected Sub limpiar2(sender As Object, e As EventArgs)
        txt_Regulador.Text = String.Empty
        txtRegulatoria.Text = String.Empty
        txtOperativa.Text = String.Empty
        ddl_Regulador.SelectedIndex = 0
        ddl_Regulatoria.SelectedIndex = 0
        ddl_Operativa.SelectedIndex = 0
        checkCon.Checked = False
        checkSin.Checked = False
        DropDownListDocRegulador()

    End Sub
End Class