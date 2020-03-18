Public Class Contrasena
    Inherits System.Web.UI.Page

    Dim obj As New Conexion()

    Private Sub Contrasena_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("../Error.aspx")



    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)

        Dim IdUsuario = objUs.Id_usuario
        Dim ContrasenaActual As String = txtActual.Text
            Dim ContrasenaNueva As String = txtNueva.Text
            Dim ContrasenaConfirmar As String = txtConfirmar.Text



        If obj.CambioPassword(IdUsuario, ContrasenaActual) Then
            'Response.Write("<script>alert(""La venta se realizo correctamente, en breve un  \r representarte se contactara con usted para verificar su tarjeta"");window.location.href = """";</script>")

            If obj.Modificar("UPDATE Usuario SET Contrasena='" + ContrasenaConfirmar + "' WHERE Id_Usuario=" + IdUsuario.ToString() + "") Then


                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Se cambió la contraseña correctamente.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, True)


                'Dim script As String = "alert('msj'); window.location.href= 'AdminInicio.aspx';"

                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)
            Else
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al cambiar la contraseña.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "La contraseña actual es incorrecta.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
            End If



    End Sub

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("AdminInicio.aspx")
    End Sub
End Class