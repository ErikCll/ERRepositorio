Public Class RecuperarContrasena
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()


    Private Sub Recuperar_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error

        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al recuperar la contraseña.")
        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        FormsAuthentication.SignOut()
        Response.Redirect("Administrador/AdminInicio.aspx")
    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim correo As New Correo()
        Dim query As String = "SELECT COUNT(*) FROM Usuario WHERE Email='" + txtCorreo.Value + "' AND Activado IS NULL"
        If obj.AutenticarCorreo(query) Then
            Dim query2 As String = "SELECT TOP 1 Contrasena FROM Usuario WHERE Email='" + txtCorreo.Value + "' AND Activado IS NULL"
            obj.CorreosAdministradores(query2)
            obj.drCorreo.Read()

            Dim mensaje As String = "<!doctype html> <html>" &
                "<body>Tu contraseña es: <b>" + obj.drCorreo("Contrasena").ToString() + "</b>, se solicitó el día <b>" + DateTime.Now.ToLongDateString() + ".</b><hr>"
            correo.CorreoContrasena(mensaje, txtCorreo.Value)
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se envió tu contraseña al correo " + txtCorreo.Value + ".")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            txtCorreo.Value = String.Empty
        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "El correo que se ha ingresado no está registrado en el sistema.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub
End Class