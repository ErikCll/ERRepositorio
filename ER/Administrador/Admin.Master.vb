Public Class Admin
    Inherits System.Web.UI.MasterPage
    Dim obj As New Conexion()


    Private Sub OpBitacora_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then


            If HttpContext.Current.User.Identity.IsAuthenticated Then

                lblUsuario.Text = Page.User.Identity.Name






            End If
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        'Dim Query As String = "SELECT Id_Usuario,Acceso FROM Usuario WHERE Id_usuario=" + objUs.Id_usuario.ToString() + ""

        '    If objUs IsNot Nothing Then
        '        If (obj.ObtenerIdUsuario(Query)) Then

        '        End If

        '        lblUsuario.Text = obj.AccesoNAme



        '    End If

    End Sub
    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub
End Class