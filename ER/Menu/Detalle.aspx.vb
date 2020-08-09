Public Class Usuario
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Private Sub Usuario_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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

    Private Sub Detalle_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim obj As AtributosEmpleado = CType(Session("DatosEmpleado"), AtributosEmpleado)

            If obj IsNot Nothing Then
                lblIdEmpleado.Text = obj.Id_empleado
                lblNombre.Text = obj.Nombre
                lblPaterno.Text = obj.ApellidoPaterno
                lblMaterno.Text = obj.ApellidoMaterno
                lblInstalacion.Text = obj.Usuario
                lblFecha.Text = obj.CreacionFecha
                lblEmail.Text = obj.Email
            Else
                Response.Redirect("Usuario.aspx")
            End If
            'Dim decodedString As String = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString("lblNombre")))
            ''Dim decodedString As String = Request.QueryString("lblNombre")
            'lblNombre.Text = decodedString
            MostrarGridInstalacion()

            'MostrarGridAccesos()
        End If

    End Sub

    Public Sub MostrarGridInstalacion()
        Dim Query = "SELECT Nav.Id_instalacion, Nav.Nombre 'Instalacion',Nav.Localizacion, CASE WHEN UsAct.Id_Instalacion IS NULL THEN 0 else UsAct.Id_Instalacion END 'Id_registro'  FROM Cat_Instalacion Nav LEFT JOIN (SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=" + lblIdEmpleado.Text + ") UsAct on Nav.Id_instalacion=UsAct.Id_Instalacion  WHERE nav.Activado IS NULL ORDER BY Id_registro DESC, nav.Id_instalacion ASC"
        gridInstalacion.DataSource = obj.Consultar(Query)
        gridInstalacion.DataBind()
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Session("DatosEmpleado") = Nothing

        Response.Redirect("Usuario.aspx")
    End Sub



    'Public Sub MostrarGridAccesos()

    '    'For Each row As GridViewRow In gridUsuario.Rows
    '    '    If row.RowType = DataControlRowType.DataRow Then
    '    '        Dim IdUsuario As Integer = Convert.ToInt32(gridUsuario.DataKeys(row.RowIndex).Values("Id_usuario"))
    '    '        Dim Query = "SELECT Nav.Id_webform 'Id_webform', Nav.Descripcion 'Descripcion', Nav.URL, CASE WHEN UsAct.id_webform IS NULL THEN 0 else UsAct.Id_webform END 'Id_registro' FROM Cat_Navegacion Nav  LEFT JOIN (SELECT Id_webform FROM Op_Roles WHERE Id_Usuario=" + lblIdEmpleado.Text + ") UsAct on Nav.Id_webform=UsAct.Id_webform ORDER BY Id_registro DESC"
    '    '        gridAcceso.DataSource = obj.Consultar(Query)
    '    '        gridAcceso.DataBind()
    '    '    End If
    '    'Next
    '    Dim Query = "SELECT Nav.Id_webform 'Id_webform', Nav.Descripcion 'Descripcion', Nav.URL, CASE WHEN UsAct.id_webform IS NULL THEN 0 else UsAct.Id_webform END 'Id_registro' FROM Cat_Navegacion Nav  LEFT JOIN (SELECT Id_webform FROM Op_Roles WHERE Id_Usuario=" + lblIdEmpleado.Text + ") UsAct on Nav.Id_webform=UsAct.Id_webform ORDER BY Id_registro DESC"
    '    gridAcceso.DataSource = obj.Consultar(Query)
    '    gridAcceso.DataBind()
    'End Sub








    'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    '    For Each row As GridViewRow In gridAcceso.Rows
    '            If row.RowType = DataControlRowType.DataRow Then
    '                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '                Dim Id_Actividad = row.Cells(2).Controls.OfType(Of Label)().FirstOrDefault.Text
    '                Dim Id_Registro = row.Cells(3).Controls.OfType(Of Label)().FirstOrDefault.Text



    '                If isChecked = True And Id_Actividad <> Id_Registro Then
    '                Dim sqlInsert As String = "INSERT INTO Op_Roles (Id_Usuario,Id_webform) VALUES(" + lblIdEmpleado.Text + "," + Id_Actividad + ") "
    '                If obj.Insertar(sqlInsert) Then
    '                    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizaron los datos para el usuario " + lblInstalacion.Text + " ")
    '                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
    '                    MostrarGridAccesos()

    '                End If

    '                End If

    '                If Id_Registro <> 0 Then
    '                    If isChecked = False Then
    '                    Dim sqlDelete As String = "DELETE FROM Op_Roles WHERE Id_Usuario= " + lblIdEmpleado.Text + "AND Id_webform= " + Id_Actividad + ""
    '                    If obj.Eliminar(sqlDelete) Then
    '                        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizaron los datos para el usuario " + lblInstalacion.Text + " ")
    '                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
    '                        MostrarGridAccesos()




    '                    End If
    '                    End If

    '                End If

    '            End If

    '        Next

    '    'PanelAccesos.Visible = True


    'End Sub

    Protected Sub btnActualizarIns_Click(sender As Object, e As EventArgs) Handles btnActualizarIns.Click

        For Each row As GridViewRow In gridInstalacion.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                Dim Id_Actividad = row.Cells(3).Controls.OfType(Of Label)().FirstOrDefault.Text
                Dim Id_Registro = row.Cells(4).Controls.OfType(Of Label)().FirstOrDefault.Text



                If isChecked = True And Id_Actividad <> Id_Registro Then
                    Dim sqlInsert As String = "INSERT INTO Op_UsIns (Id_Usuario,Id_Instalacion) VALUES(" + lblIdEmpleado.Text + "," + Id_Actividad + ") "
                    obj.InsertarInstalaciones(lblIdEmpleado.Text, Id_Actividad)
                    Dim script As String = "alert('Se actualizaron las instalaciones.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                        'Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizaron los datos para el usuario " + lblInstalacion.Text + " ")
                        'ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

                    End If

                If Id_Registro <> 0 Then
                    If isChecked = False Then
                        Dim sqlDelete As String = "DELETE FROM Op_UsIns WHERE Id_Usuario= " + lblIdEmpleado.Text + "AND Id_Instalacion= " + Id_Actividad + ""
                        obj.EliminarInstalaciones(lblIdEmpleado.Text, Id_Actividad)
                        Dim script As String = "alert('Se actualizaron las instalaciones.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';"
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
                            'Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se actualizaron los datos para el usuario " + lblInstalacion.Text + " ")
                            'ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)




                        End If

                End If

            End If


        Next
        MostrarGridInstalacion()

    End Sub

    Protected Sub gridInstalacion_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("checkall"), CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + CType(e.Row.FindControl("checkall"), CheckBox).ClientID + "')")
        End If


    End Sub
End Class