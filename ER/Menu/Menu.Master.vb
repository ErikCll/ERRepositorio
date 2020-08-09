Public Class Menu
    Inherits System.Web.UI.MasterPage
    Dim obj As New Conexion()
    Private Sub Menu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        If HttpContext.Current.User.Identity.IsAuthenticated Then

            lblUsuario.Text = Page.User.Identity.Name

            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect("Index.aspx")

            End If




            'lblInstalacion.Text = objUs.Instalacion



            'lblIdInstalacion.Text = objUs.Id_Instalacion


        Else
            FormsAuthentication.SignOut()
            Response.Redirect(Request.UrlReferrer.ToString())

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub

    Protected Sub Instalacion_Click(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("Index.aspx")

        End If
        If objUs.Rol = "Administrador" Then
            Response.Redirect("Instalacion.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub



    Protected Sub Unnamed_Click2(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("Index.aspx")

        End If
        If objUs.Rol = "Administrador" Then
            Response.Redirect("Usuario.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub
End Class