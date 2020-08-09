Imports Telerik.Web.UI

Public Class Site2
    Inherits System.Web.UI.MasterPage
    Dim obj As New Conexion()

    Public ReadOnly Property IdInstalacion() As String
        Get
            Return lblIdInstalacion.Text
        End Get

    End Property

    Public ReadOnly Property Instalacion() As String
        Get
            Return lblInstalacion.Text
        End Get

    End Property

    Private Sub OpBitacora_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        If HttpContext.Current.User.Identity.IsAuthenticated Then

            lblUsuario.Text = Page.User.Identity.Name

            Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
            If objUs Is Nothing Then
                FormsAuthentication.SignOut()
                Response.Redirect("Inicio.aspx")

            End If

            LlenarInstalacion()


            If RadComboBox1.Items.Count = 1 Then
                lblInstalacion.Visible = True
                lblInstalacion.Text = objUs.Instalacion
                lblIdInstalacion.Text = objUs.Id_Instalacion
                lblPlaza.Text = objUs.Plaza
                lblLocalizacion.Text = objUs.Localizacion
            ElseIf RadComboBox1.Items.Count = 0 Then
                lblInstalacion.Visible = True
                lblInstalacion.Text = "Sin instalación"
                lblIdInstalacion.Text = -1
            Else

                RadComboBox1.Visible = True
                If Session("IdInstalacion") = Nothing Then
                    lblIdInstalacion.Text = RadComboBox1.SelectedIndex
                Else
                    RadComboBox1.SelectedValue = Session("IdInstalacion")
                    lblIdInstalacion.Text = Session("IdInstalacion")

                    lblLocalizacion.Text = Session("Ubicacion")
                    lblPlaza.Text = Session("Plaza")
                    lblInstalacion.Text = RadComboBox1.SelectedItem.Text

                End If
            End If


            'If obj.EsAdministrador(objUs.Id_usuario) Then
            '    RadComboBox1.Visible = True
            '    If Session("IdInstalacion") = Nothing Then
            '        lblIdInstalacion.Text = RadComboBox1.SelectedIndex
            '    Else
            '        RadComboBox1.SelectedValue = Session("IdInstalacion")
            '        lblIdInstalacion.Text = Session("IdInstalacion")
            '        lblLocalizacion.Text = Session("Ubicacion")
            '        lblPlaza.Text = Session("Plaza")
            '    End If
            'Else

            '    lblInstalacion.Visible = True
            '    lblInstalacion.Text = objUs.Instalacion
            '    lblIdInstalacion.Text = objUs.Id_Instalacion
            '    lblPlaza.Text = objUs.Plaza
            '    lblLocalizacion.Text = objUs.Localizacion

            'End If



            'lblInstalacion.Text = objUs.Instalacion



            'lblIdInstalacion.Text = objUs.Id_Instalacion


        Else
            FormsAuthentication.SignOut()
            Response.Redirect(Request.UrlReferrer.ToString())

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'LlenarInstalacion()

        End If

        ListRegulador()
    End Sub

    Public Sub ListRegulador()

        Dim query As String = "SELECT Id_Regulador,Nombre FROM Cat_Regulador WHERE Activado IS NULL ORDER BY Id_Regulador DESC"
        obj.Llenar(query)
        list.DataSource = obj.ds2
        list.DataBind()
        If list.Items.Count = 0 Then
            List22.Visible = False
        End If

    End Sub

    Public Sub LlenarInstalacion()
        'Dim query As String = "SELECT Id_Instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL"
        'obj.LlenarDropDownList(query)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("AdminInicio.aspx")

        End If

        If obj.EsAdministrador(objUs.Id_usuario) Then
            RadComboBox1.DataSource = obj.LlenarDropDownList("SELECT Id_Instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL")
            RadComboBox1.DataBind()
        Else
            RadComboBox1.DataSource = obj.LlenarDropDownList("SELECT Nav.Id_instalacion, Nav.Nombre  FROM Cat_Instalacion Nav  JOIN (SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=" + objUs.Id_usuario.ToString() + ") UsAct on Nav.Id_instalacion=UsAct.Id_Instalacion  WHERE nav.Activado IS NULL")
            RadComboBox1.DataBind()
        End If




    End Sub


    Protected Sub RadComboBox1_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)
        Dim Id_Instalacion = RadComboBox1.SelectedValue
        lblIdInstalacion.Text = Id_Instalacion
        Session("IdInstalacion") = Id_Instalacion
        Dim query As String = "SELECT ISNULL(CONCAT(Ins.Localizacion,', ',Reg.Nombre),'') Ubicacion,ISNULL(Plaza,'') Plaza FROM Cat_Instalacion Ins JOIN Cat_Region Reg on Ins.Id_region=Reg.Id_region WHERE Ins.Id_instalacion=" + Id_Instalacion.ToString() + ""
        obj.DatosInstalacion(query)

        obj.drInstalacion.Read()
        lblLocalizacion.Text = obj.drInstalacion("Ubicacion").ToString()
        lblPlaza.Text = obj.drInstalacion("Plaza").ToString()
        Session("Ubicacion") = lblLocalizacion.Text
        Session("Plaza") = lblPlaza.Text
        obj.drInstalacion.Close()
        obj.conn.Close()
        Response.Redirect(Request.UrlReferrer.ToString())


        'Response.Redirect(Request.UrlReferrer.ToString())
        'Response.Redirect("AdminInicio.aspx")


    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub

    Protected Sub lblRegulador_Click(sender As Object, e As EventArgs)
        If lblIdInstalacion.Text = -1 Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar Estación de Servicio.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)


        Else
            Dim item As ListViewItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, ListViewItem)
            Dim Id_Regulador As Label = CType(item.FindControl("lblIdRegulador"), Label)
            Dim NombreRequisito As LinkButton = CType(item.FindControl("lblRegulador"), LinkButton)

            'Dim Requisito1 As String = requisito.Text

            Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Id_Regulador.Text)))
            'Dim encodedString2 As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(requisito.Text)))

            Dim encodedString2 = System.Text.Encoding.UTF8.GetBytes(NombreRequisito.Text)
            Dim s = System.Convert.ToBase64String(encodedString2)

            Response.Redirect("Requisitos.aspx?id=" + encodedString + "&reg=" + s)
            'Response.Redirect(String.Format("Usuario.aspx?lblNombre=encodedString&lblApellidoPaterno=encodedString2"))
        End If

    End Sub

    Protected Sub Unnamed_Click1(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("Inicio.aspx")

        End If
        If objUs.Rol = "Administrador" Then
            Response.Redirect("Regulador.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub

    Protected Sub Unnamed_Click2(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("Inicio.aspx")

        End If
        If objUs.Rol = "Administrador" Then
            Response.Redirect("Requisito.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub

    Protected Sub Unnamed_Click4(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("Inicio.aspx")

        End If
        If objUs.Rol = "Administrador" Then
            Response.Redirect("DocRegulador.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub
End Class