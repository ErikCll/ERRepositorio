Public Class Index
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()
    Dim IdUsuario As String
    Dim RolUsuario As String

    Private Sub Index_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim URL As String = (New System.IO.FileInfo(Page.Request.Url.AbsolutePath)).Name
        Session("URL") = URL
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Session("Error") = objErr
        Response.Redirect("~/Administrador/Error.aspx")



    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)

        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect(Request.UrlReferrer.ToString())
        End If
        IdUsuario = objUs.Id_usuario
        RolUsuario = objUs.Rol
        If obj.EsOperador(objUs.Id_usuario) Then
            Panel1.Visible = False
        End If
        lblUsuario.Text = Page.User.Identity.Name
        lblRol.Text = objUs.Rol.ToString()


    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MostrarGridInstalacion()
        End If
    End Sub

    Public Sub MostrarGridInstalacion()

        Dim Query = "  SELECT Nav.Id_instalacion, Nav.Nombre 'Instalacion',Nav.Localizacion FROM Cat_Instalacion Nav JOIN (SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=" + IdUsuario.ToString + ") UsAct on Nav.Id_instalacion=UsAct.Id_Instalacion  WHERE nav.Activado IS NULL "
        If RolUsuario = "Administrador" Then
            Query = "  SELECT Id_instalacion, Nombre 'Instalacion',Localizacion FROM Cat_Instalacion WHERE Activado IS NULL "
        End If
        gridInstalacion.DataSource = obj.Consultar(Query)
        gridInstalacion.DataBind()
    End Sub

    Protected Sub linkEtapa1_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Administrador/AdminInicio.aspx")
    End Sub

    Protected Sub linkEtapa2_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Construccion/Inicio.aspx")

    End Sub

    Protected Sub linkEtapa3_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Operacion/Inicio.aspx")

    End Sub
End Class