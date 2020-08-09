Imports Telerik.Web.UI
Public Class Admin

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
                Response.Redirect("AdminInicio.aspx")

            End If
            If objUs.Rol = "Constructor/Operador" Then

                Dim script As String = "alert('No cuentas con el rol para acceder.'); window.location.href= '../Menu/Index.aspx';"

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", script, True)

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





            Dim query As String = "SELECT Nivel1 FROM Cat_Menu_V3 WHERE Activado IS NULL GROUP BY Nivel1,Nivel1_no ORDER BY Nivel1_no ASC"
            obj.Llenar(query)
            AdminTopListView.DataSource = obj.ds2
            AdminTopListView.DataBind()
            'LlenarInstalacion()

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



    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub

    Protected Sub Instalacion_Click(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("AdminInicio.aspx")

        End If
        If obj.EsAdministrador(objUs.Id_usuario) Then
            Response.Redirect("Instalacion.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub

    Protected Sub Requisitos_Click(sender As Object, e As EventArgs)
        Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        If objUs Is Nothing Then
            FormsAuthentication.SignOut()
            Response.Redirect("AdminInicio.aspx")

        End If
        If objUs.Rol = "Administrador" Then
            Response.Redirect("Requisitos.aspx")

        Else
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede acceder.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        End If
    End Sub

    Protected Sub Construccion_Click(sender As Object, e As EventArgs)



        Response.Redirect("~/Construccion/Inicio.aspx")
    End Sub


    Protected Sub Operacion_Click(sender As Object, e As EventArgs)



        Response.Redirect("~/Operacion/Inicio.aspx")
    End Sub
    Protected Sub Tablero_Click(sender As Object, e As EventArgs)


        'If lblIdInstalacion.Text = -1 Then
        '    Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar Estación de Servicio.")
        '    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        'Else
        '    Dim objUs As AtributosUsuario = CType(Session("DatosUsuario"), AtributosUsuario)
        '    If objUs Is Nothing Then
        '        FormsAuthentication.SignOut()
        '        Response.Redirect("AdminInicio.aspx")

        '    End If

        '    If obj.EsAdministrador(objUs.Id_usuario) Then
        '        Response.Redirect("Tablero.aspx")

        '    Else
        '        Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Solo el administrador puede ingresar a este apartado.")
        '        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        '    End If
        'End If



        If lblIdInstalacion.Text = -1 Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar Estación de Servicio.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)
        Else
            Response.Redirect("Tablero.aspx")

        End If
    End Sub
    Protected Sub AdminTopListView_ItemDataBound(sender As Object, e As ListViewItemEventArgs)

        Dim itm As ListViewDataItem = CType(e.Item, ListViewDataItem)
        'Dim name As String = AdminTopListView.DataKeys(itm.DataItemIndex)("Nivel1")
        Dim name As Label = CType(e.Item.FindControl("lbl"), Label)

        Dim childMenu As ListView = TryCast(e.Item.FindControl("Menu2"), ListView)
        Dim RequisitoNivel1 As ListView = TryCast(e.Item.FindControl("RequisitoNivel1"), ListView)
        Dim RequisitoNivel12 As ListView = TryCast(e.Item.FindControl("RequisitoNivel12"), ListView)


        Dim recommendedProducts1 As ListView = TryCast(e.Item.FindControl("Menu3"), ListView)

        Dim query4 As String = "SELECT id_requisito, Requisito FROM Cat_Menu_V3 WHERE Nivel1 = '" + name.Text + "' AND Nivel2 IS NULL AND Nivel3 IS NULL AND Activado IS NULL"
        obj.Llenar(query4)

        If name.Text = "Governance" Then
            RequisitoNivel12.Visible = True
            RequisitoNivel12.DataSource = obj.ds2
            RequisitoNivel12.DataBind()
        Else
            RequisitoNivel1.DataSource = obj.ds2
            RequisitoNivel1.DataBind()
        End If

        For Each item In childMenu.Items
            Dim recommendedProducts2 = TryCast(item.FindControl("Menu3"), ListView)


        Next




        Dim query As String = "SELECT Nivel2 FROM Cat_Menu_V3 WHERE Nivel1 = '" + name.Text + "' AND NIVEL2 IS NOT NULL AND Activado IS NULL GROUP BY Nivel2,Nivel2_no ORDER BY Nivel2_no ASC"

        obj.Llenar(query)
        childMenu.DataSource = obj.ds2

        childMenu.DataBind()

        For Each item In childMenu.Items
            Dim name2 As Label = CType(item.FindControl("lbl2"), Label)
            Dim recommendedProducts3 As ListView = TryCast(item.FindControl("Menu3"), ListView)
            Dim query2 As String = "SELECT Nivel3 FROM Cat_Menu_V3 WHERE Nivel2 = '" + name2.Text + "' AND NIVEL3 IS NOT NULL AND Activado IS NULL GROUP BY Nivel3"
            obj.Llenar(query2)
            recommendedProducts3.DataSource = obj.ds2
            recommendedProducts3.DataBind()

            Dim RequisitoNivel2 As ListView = TryCast(item.FindControl("RequisitoNivel2"), ListView)
            Dim query5 As String = "SELECT id_requisito,Requisito FROM Cat_Menu_V3 WHERE Nivel1 = '" + name.Text + "' AND Nivel2='" + name2.Text + "' AND NIVEL3 iS NULL AND Activado IS NULL"
            obj.Llenar(query5)
            RequisitoNivel2.DataSource = obj.ds2
            RequisitoNivel2.DataBind()




            For Each item3 In recommendedProducts3.Items
                Dim name3 As Label = CType(item3.FindControl("lbl3"), Label)

                Dim Requisito2 = TryCast(item3.FindControl("MenuRequisito"), ListView)
                Dim query3 As String = "SELECT id_requisito,Requisito FROM Cat_Menu_V3 WHERE Nivel1 = '" + name.Text + "' AND Nivel2='" + name2.Text + "' AND Nivel3='" + name3.Text + "' AND Activado IS NULL"
                obj.Llenar(query3)
                Requisito2.DataSource = obj.ds2
                Requisito2.DataBind()
            Next

        Next





        'Dim itm As ListViewDataItem = CType(e.Item, ListViewDataItem)
        ''Dim name As String = AdminTopListView.DataKeys(itm.DataItemIndex)("Nivel1")
        'Dim name As Label = CType(e.Item.FindControl("lbl"), Label)

        'Dim childMenu As ListView = TryCast(e.Item.FindControl("Menu2"), ListView)
        'Dim RequisitoNivel1 As ListView = TryCast(e.Item.FindControl("RequisitoNivel1"), ListView)


        'Dim recommendedProducts1 As ListView = TryCast(e.Item.FindControl("Menu3"), ListView)

        'Dim query4 As String = "SELECT Requisito FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND Nivel2 IS NULL AND Nivel3 IS NULL"
        'obj.LlenarDropDownList(query4)

        'RequisitoNivel1.DataSource = obj.ds
        'RequisitoNivel1.DataBind()
        'For Each item In childMenu.Items
        '    Dim recommendedProducts2 = TryCast(item.FindControl("Menu3"), ListView)


        'Next




        'Dim query As String = "SELECT Nivel2 FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND NIVEL2 IS NOT NULL GROUP BY Nivel2"

        'obj.LlenarDropDownList(query)
        'childMenu.DataSource = obj.ds

        'childMenu.DataBind()

        'For Each item In childMenu.Items
        '    Dim name2 As Label = CType(item.FindControl("lbl2"), Label)
        '    Dim recommendedProducts3 As ListView = TryCast(item.FindControl("Menu3"), ListView)
        '    Dim query2 As String = "SELECT Nivel3 FROM Cat_menu WHERE Nivel2 = '" + name2.Text + "' AND NIVEL3 IS NOT NULL GROUP BY Nivel3"
        '    obj.LlenarDropDownList2(query2)
        '    recommendedProducts3.DataSource = obj.ds2
        '    recommendedProducts3.DataBind()

        '    Dim RequisitoNivel2 As ListView = TryCast(item.FindControl("RequisitoNivel2"), ListView)
        '    Dim query5 As String = "SELECT Requisito FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND Nivel2='" + name2.Text + "' AND NIVEL3 iS NULL"
        '    obj.LlenarDropDownList2(query5)
        '    RequisitoNivel2.DataSource = obj.ds2
        '    RequisitoNivel2.DataBind()




        '    For Each item3 In recommendedProducts3.Items
        '        Dim name3 As Label = CType(item3.FindControl("lbl3"), Label)

        '        Dim Requisito2 = TryCast(item3.FindControl("MenuRequisito"), ListView)
        '        Dim query3 As String = "SELECT Requisito FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND Nivel2='" + name2.Text + "' AND Nivel3='" + name3.Text + "'"
        '        obj.LlenarDropDownList3(query3)
        '        Requisito2.DataSource = obj.ds3
        '        Requisito2.DataBind()
        '    Next

        'Next







    End Sub

    Protected Sub Requisito1_Click(sender As Object, e As EventArgs)
        If lblIdInstalacion.Text = -1 Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar Estación de Servicio.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)


        Else
            Dim item As ListViewItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, ListViewItem)
            Dim requisitoid As Label = CType(item.FindControl("id_requisito1"), Label)
            Dim requisito As LinkButton = CType(item.FindControl("lblRequisitoNivel1"), LinkButton)

            'Dim Requisito1 As String = requisito.Text

            Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(requisitoid.Text)))
            'Dim encodedString2 As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(requisito.Text)))

            Dim encodedString2 = System.Text.Encoding.UTF8.GetBytes(requisito.Text)
            Dim s = System.Convert.ToBase64String(encodedString2)

            Response.Redirect("Requisito.aspx?id=" + encodedString + "&req=" + s)
            'Response.Redirect(String.Format("Usuario.aspx?lblNombre=encodedString&lblApellidoPaterno=encodedString2"))
        End If



    End Sub

    Protected Sub Requisito2_Click(sender As Object, e As EventArgs)
        If lblIdInstalacion.Text = -1 Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar Estación de Servicio.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        Else

            Dim item As ListViewItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, ListViewItem)
            Dim requisitoid As Label = CType(item.FindControl("id_requisito2"), Label)
            Dim requisito As LinkButton = CType(item.FindControl("lblRequisitoNivel2"), LinkButton)
            Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(requisitoid.Text)))
            'Dim encodedString2 As String = (Convert.ToBase64String(Encoding.ASCII.GetBytes(requisito.Text)))
            Dim encodedString2 = System.Text.Encoding.UTF8.GetBytes(requisito.Text)
            Dim s = System.Convert.ToBase64String(encodedString2)


            Response.Redirect("Requisito.aspx?id=" + encodedString + "&req=" + s)
        End If


    End Sub

    Protected Sub Requisito3_Click(sender As Object, e As EventArgs)
        If lblIdInstalacion.Text = -1 Then
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Seleccionar Estación de Servicio.")
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        Else
            Dim item As ListViewItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, ListViewItem)
            Dim requisitoid As Label = CType(item.FindControl("id_requisito3"), Label)
            Dim requisito As LinkButton = CType(item.FindControl("lblRequisito"), LinkButton)

            'Dim id As Integer = CInt(lstVDataBind.DataKeys(item.DataItemIndex).Values("Id_Producto"))

            Dim encodedString As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(requisitoid.Text)))
            'Dim encodedString2 As String = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(requisito.Text)))

            Dim encodedString2 = System.Text.Encoding.UTF8.GetBytes(requisito.Text)
            Dim s = System.Convert.ToBase64String(encodedString2)
            Response.Redirect("Requisito.aspx?id=" + encodedString + "&req=" + s)
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
        'Response.Redirect("AdminInicio.aspx")


    End Sub

    'Protected Sub RadComboBox1_ItemDataBound(sender As Object, e As RadComboBoxItemEventArgs)
    '    e.Item.Text = String.Concat(e.Item.Text.ToLower().Split(" "c)(0), "@telerik.com")
    'End Sub
End Class