Public Class Requisitos
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()



    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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


                If obj.EsAdministrador(IdUsuario) Then


                Else

                    Dim script As String = "alert('No cuentas con el acceso para este apartado'); window.location.href= 'AdminInicio.aspx';"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)


                End If








            Else
                FormsAuthentication.SignOut()
                Response.Redirect(Request.UrlReferrer.ToString())


            End If
        End If


    End Sub

    Private Sub Requisitos_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("Error.aspx")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.DefaultButton = btnBuscar.UniqueID

        If Not IsPostBack Then
            MostrarGridRequisito()
            DropNivel1()

        End If
    End Sub

    Public Sub DropNivel1()

        ddl_Nivel1.DataSource = obj.LlenarDropDownList("SELECT Nivel1,Nivel1_no FROM Cat_Menu_V3 GROUP BY Nivel1,Nivel1_no ORDER BY Nivel1_no ASC")

        ddl_Nivel1.DataBind()
        ddl_Nivel1.Items.Insert(0, New ListItem("[Seleccionar]"))


    End Sub


    Public Sub DropNivel2()

        ddl_Nivel2.DataSource = obj.LlenarDropDownList("SELECT Nivel2,Nivel2_no FROM Cat_Menu_V3 WHERE Nivel1='" + ddl_Nivel1.SelectedItem.Text + "' AND Nivel2 IS NOT NULL GROUP BY Nivel2,Nivel2_no ORDER BY Nivel2_no ASC")

        ddl_Nivel2.DataBind()
        ddl_Nivel2.Items.Insert(0, New ListItem("[Seleccionar]"))
        ddl_Nivel2.Items.Insert(1, New ListItem("[No Aplica]"))
        If ddl_Nivel2.SelectedIndex = 0 Or ddl_Nivel2.SelectedIndex = 1 Then
            Open2.Visible = False
            Link2.Visible = False
            txt2.Visible = False

        Else
            Open2.Visible = True
        End If

    End Sub


    Public Sub DropNivel3()

        ddl_Nivel3.DataSource = obj.LlenarDropDownList("SELECT Nivel3 FROM Cat_Menu_V3 WHERE Nivel2='" + ddl_Nivel2.SelectedItem.Text + "' AND Nivel3 IS NOT NULL GROUP BY Nivel3,Nivel3_no ORDER BY Nivel3_no ASC")

        ddl_Nivel3.DataBind()
        ddl_Nivel3.Items.Insert(0, New ListItem("[Seleccionar]"))
        ddl_Nivel3.Items.Insert(1, New ListItem("[No Aplica]"))
        If ddl_Nivel3.SelectedIndex = 0 Or ddl_Nivel3.SelectedIndex = 1 Then
            Open3.Visible = False
            Link3.Visible = False
            txt3.Visible = False

        Else
            Open3.Visible = True

        End If
    End Sub

    Public Sub MostrarGridRequisito()
        Dim query As String = "SELECT Id_Requisito,Nivel1,Nivel2,Nivel3,Requisito FROM Cat_Menu_V3 WHERE Activado IS NULL ORDER BY Nivel1_no,Nivel2_no ASC"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            query = "SELECT Id_Requisito,Nivel1,Nivel2,Nivel3,Requisito FROM Cat_Menu_V3 WHERE (Activado IS NULL )AND (Nivel1 LIKE '%" + txtSearch.Text.Trim() + "%' OR Nivel2 LIKE '%" + txtSearch.Text.Trim() + "%' OR Nivel3 LIKE '%" + txtSearch.Text.Trim() + "%' OR Requisito LIKE '%" + txtSearch.Text.Trim() + "%') ORDER BY Nivel1_no,Nivel2_no ASC"
        End If
        gridMenu.DataSource = obj.Consultar(query)
        gridMenu.DataBind()
    End Sub


    Protected Sub gridMenu_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Eliminar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridMenu.DataKeys(row.RowIndex).Value
            Dim sqlQuery = "UPDATE Cat_Menu_V3 set Activado=1 WHERE Id_Requisito= " + Id.ToString()
            If obj.Eliminar(sqlQuery) Then
                MostrarGridRequisito()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.")
                ScriptManager.RegisterClientScriptBlock(Literal2, Literal2.GetType(), "script", txtJS, False)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al eliminar el dato.")
                ScriptManager.RegisterClientScriptBlock(Literal2, Literal2.GetType(), "script", txtJS, False)
            End If

        ElseIf e.CommandName = "Editar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridMenu.DataKeys(row.RowIndex).Value

            Dim txtRequisito As TextBox = CType(row.FindControl("txtRequisito"), TextBox)
            txtRequisito.Visible = True
            Dim lblRequisito As Label = CType(row.FindControl("lblRequisito"), Label)
            lblRequisito.Visible = False



            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)
            btnCancel.Visible = True

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)
            btnAct.Visible = True

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)
            btnEditar.Visible = False


        ElseIf e.CommandName = "Actualizar" Then
            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer
            Dim Id As Integer = gridMenu.DataKeys(row.RowIndex).Value

            Dim Actual As Label = CType(row.FindControl("lblRequisito"), Label)

            Dim Nuevo As TextBox = CType(row.FindControl("txtRequisito"), TextBox)




            Dim btnCancel As LinkButton = CType(row.FindControl("btnCancel"), LinkButton)

            Dim btnAct As LinkButton = CType(row.FindControl("btnAct"), LinkButton)

            Dim btnEditar As LinkButton = CType(row.FindControl("btnEditar"), LinkButton)

            Dim sqlQuery = "UPDATE Cat_Menu_V3 set Requisito= '" + Nuevo.Text + "' Where Id_Requisito=" + Id.ToString + ""
            If Actual.Text <> Nuevo.Text Then
                If obj.Modificar(sqlQuery) Then

                    Actual.Text = Nuevo.Text
                    Actual.Visible = True
                    Nuevo.Visible = False

                    btnCancel.Visible = False
                    btnAct.Visible = False
                    btnEditar.Visible = True

                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizó el dato correctamente.")
                    ScriptManager.RegisterClientScriptBlock(Literal2, Literal2.GetType(), "script", txtJS, False)

                Else
                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al actualizar el dato.")
                    ScriptManager.RegisterClientScriptBlock(Literal2, Literal2.GetType(), "script", txtJS, False)
                End If

            End If

        ElseIf e.CommandName = "Cancelar" Then

            Dim ctl = e.CommandSource
            Dim row As GridViewRow = ctl.NamingContainer

            Dim txtRequisito As TextBox = CType(row.FindControl("txtRequisito"), TextBox)
            txtRequisito.Visible = False
            Dim lblRequisito As Label = CType(row.FindControl("lblRequisito"), Label)
            lblRequisito.Visible = True


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

    Protected Sub ddl_Nivel1_SelectedIndexChanged(sender As Object, e As EventArgs)

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "Abrir()", True)
        If ddl_Nivel1.SelectedIndex = 0 Then
            Open1.Visible = False
            Link1.Visible = False
            txt1.Visible = False
        Else
            Open1.Visible = True
            txt1.Text = ddl_Nivel1.SelectedItem.Text
        End If
        DropNivel2()
        DropNivel3()
        Link2.Visible = False
        txt2.Visible = False
        Link3.Visible = False
        txt3.Visible = False
    End Sub

    Protected Sub ddl_Nivel2_SelectedIndexChanged(sender As Object, e As EventArgs)

        If ddl_Nivel2.SelectedIndex = 0 Or ddl_Nivel2.SelectedIndex = 1 Then
            Open2.Visible = False
            Link2.Visible = False
            txt2.Visible = False
        Else
            Open2.Visible = True
            txt2.Text = ddl_Nivel2.SelectedItem.Text
        End If
        DropNivel3()
        Link3.Visible = False
        txt3.Visible = False
    End Sub

    Protected Sub ddl_Nivel3_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddl_Nivel3.SelectedIndex = 0 Or ddl_Nivel3.SelectedIndex = 1 Then
            Open3.Visible = False
            Link3.Visible = False
            txt3.Visible = False
        Else
            Open3.Visible = True
            txt3.Text = ddl_Nivel3.SelectedItem.Text
        End If
    End Sub


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ddl_Nivel2.SelectedIndex = 1 Then
            Dim query As String = "INSERT INTO Cat_Menu_V3(Nivel1_no,Nivel1,Requisito) VALUES(" + ddl_Nivel1.SelectedValue + ",'" + ddl_Nivel1.SelectedItem.Text + "','" + txtRequisito.Text + "')"
            If obj.Insertar(query) Then
                MostrarGridRequisito()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se creó correctamente el Requisito " + ddl_Nivel1.SelectedItem.Text + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                Limpiar()

                DropNivel1()
                DropNivel2()
                DropNivel3()
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al crear el Requisito.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If

        ElseIf ddl_Nivel3.SelectedIndex = 1 Then

            Dim query As String = "INSERT INTO Cat_Menu_V3(Nivel1_no,Nivel1,Nivel2_no,Nivel2,Requisito) VALUES(" + ddl_Nivel1.SelectedValue + ",'" + ddl_Nivel1.SelectedItem.Text + "'," + ddl_Nivel2.SelectedValue + ",'" + ddl_Nivel2.SelectedItem.Text + "','" + txtRequisito.Text + "')"
            If obj.Insertar(query) Then
                MostrarGridRequisito()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se creó correctamente el Requisito para " + ddl_Nivel2.SelectedItem.Text + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                Limpiar()

                DropNivel1()
                DropNivel2()
                DropNivel3()
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al crear el Requisito.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If

        Else
            Dim query As String = "INSERT INTO Cat_Menu_V3(Nivel1_no,Nivel1,Nivel2_no,Nivel2,Nivel3,Requisito) VALUES(" + ddl_Nivel1.SelectedValue + ",'" + ddl_Nivel1.SelectedItem.Text + "'," + ddl_Nivel2.SelectedValue + ",'" + ddl_Nivel2.SelectedItem.Text + "','" + ddl_Nivel3.SelectedValue + "','" + txtRequisito.Text + "')"

            If obj.Insertar(query) Then
                MostrarGridRequisito()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se creó correctamente el Requisito para " + ddl_Nivel3.SelectedValue + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                Limpiar()

                DropNivel1()
                DropNivel2()
                DropNivel3()
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al crear el Requisito.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If


        End If

    End Sub

    Public Sub Limpiar()

        txtRequisito.Text = String.Empty

    End Sub

    Protected Sub gridMenu_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridMenu.PageIndex = e.NewPageIndex

        MostrarGridRequisito()
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridRequisito()
    End Sub

    Protected Sub Abrir(sender As Object, e As EventArgs)
        DivInsertar.Visible = True
    End Sub

    Protected Sub Cerrar(sender As Object, e As EventArgs)
        DivInsertar.Visible = False
    End Sub

    Protected Sub Renombrar1(sender As Object, e As EventArgs)
        If ddl_Nivel1.SelectedItem.Text <> txt1.Text Then
            Dim query As String = "UPDATE Cat_Menu_V3 SET Nivel1='" + txt1.Text + "' WHERE Nivel1='" + ddl_Nivel1.SelectedItem.Text + "'"
            If obj.Modificar(query) Then
                Link1.Visible = False
                txt1.Visible = False

                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se renombró correctamente la opción " + ddl_Nivel1.SelectedItem.Text + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                DropNivel1()
                DropNivel2()
                DropNivel3()

                MostrarGridRequisito()
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al renombrar.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If
        Else

        End If
    End Sub


    Protected Sub Renombrar2(sender As Object, e As EventArgs)
        If ddl_Nivel2.SelectedItem.Text <> txt2.Text Then
            Dim query As String = "UPDATE Cat_Menu_V3 SET Nivel2='" + txt2.Text + "' WHERE Nivel2='" + ddl_Nivel2.SelectedItem.Text + "'"
            If obj.Modificar(query) Then
                Link2.Visible = False
                txt2.Visible = False

                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se renombró correctamente la opción " + ddl_Nivel2.SelectedItem.Text + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                DropNivel2()
                DropNivel3()
                MostrarGridRequisito()
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al renombrar.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If
        Else

        End If
    End Sub

    Protected Sub Renombrar3(sender As Object, e As EventArgs)
        If ddl_Nivel3.SelectedValue <> txt3.Text Then
            Dim query As String = "UPDATE Cat_Menu_V3 SET Nivel3='" + txt3.Text + "' WHERE Nivel3='" + ddl_Nivel3.SelectedValue + "'"
            If obj.Modificar(query) Then
                Link3.Visible = False
                txt3.Visible = False

                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se renombró correctamente la opción " + ddl_Nivel3.SelectedValue + ".")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
                DropNivel3()
                MostrarGridRequisito()
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al renombrar.")
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If
        Else

        End If
    End Sub


    Protected Sub Abrir1(sender As Object, e As EventArgs)
        Link1.Visible = True
        txt1.Visible = True
    End Sub

    Protected Sub Abrir2(sender As Object, e As EventArgs)
        Link2.Visible = True
        txt2.Visible = True
    End Sub

    Protected Sub Abrir3(sender As Object, e As EventArgs)
        Link3.Visible = True
        txt3.Visible = True
    End Sub


End Class

