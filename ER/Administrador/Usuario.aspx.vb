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
        Dim Query = "SELECT Us.Id_usuario,Us.Acceso,Us.Email,CONVERT(varchar,Us.CreacionFecha,105)'CreacionFecha' FROM Usuario Us  JOIN Cat_Empleado emp on Us.Id_empleado=emp.Id_empleado WHERE emp.Id_empleado=" + lblIdEmpleado.Text + ""


        gridUsuario.DataSource = obj.Consultar(Query)

        gridUsuario.DataBind()
        If gridUsuario.Rows.Count = 0 Then
            btnGuardar.Visible = True
        Else
            btnGuardar.Visible = False
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim Acceso As String = txtUsuario.Text
        Dim Email As String = txtEmail.Text
        Dim Password As String = txtPassword.Text



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
    End Sub

    Private Sub Limpiar()
        txtUsuario.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPassword.Text = String.Empty
        txtPasswordConfirm.Text = String.Empty

    End Sub
End Class