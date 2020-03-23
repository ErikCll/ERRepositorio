Public Class Login
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.DefaultButton = CType(Login1.FindControl("LoginButton"), Button).UniqueID

        Session.RemoveAll()

    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        'obj.conn.Open()
        'Dim sqlString As String = "SELECT Id_Usuario FROM Usuario WHERE Usuario='" + Login1.UserName + "'"
        'obj.cmd = New SqlCommand(sqlString, obj.conn)
        'obj.dr = obj.cmd.ExecuteReader
        'If obj.dr.Read Then
        '    Dim id = obj.dr(0)



        If obj.Autenticar(Login1.UserName, Login1.Password) Then
            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
            Dim sqlString As String = "SELECT Id_Usuario,Acceso,ISNULL(Ins.Nombre,'') Nombre FROM Usuario us LEFT JOIN Cat_Empleado Emp on us.Id_empleado=emp.Id_empleado LEFT JOIN Cat_Instalacion Ins on Emp.Id_instalacion=Ins.Id_instalacion WHERE Acceso='" + Login1.UserName + "' AND us.ACTIVADO IS NULL"
            obj.ObtenerIdUsuario(sqlString)
            Dim IdUsuario = obj.Id
            Dim Acceso = obj.AccesoNAme
            Dim Instalacion = obj.InstalacionName
            Dim objUs As New AtributosUsuario
            With objUs

                .Id_usuario = IdUsuario

                .Acceso = Acceso

                .Instalacion = Instalacion


            End With
            Session("DatosUsuario") = objUs
        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Usuario o contraseña son incorrectos.")
            scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub
End Class