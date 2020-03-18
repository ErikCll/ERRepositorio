Public Class Admin
    Inherits System.Web.UI.MasterPage
    Dim obj As New Conexion()


    Private Sub OpBitacora_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init



        If HttpContext.Current.User.Identity.IsAuthenticated Then

            lblUsuario.Text = Page.User.Identity.Name





        Else
            FormsAuthentication.SignOut()
            Response.Redirect(Request.UrlReferrer.ToString())

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            Dim query As String = "select Nivel1 from cat_menu group by Nivel1"
            obj.LlenarDropDownList(query)
            AdminTopListView.DataSource = obj.ds
            AdminTopListView.DataBind()
        End If



    End Sub
    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        FormsAuthentication.SignOut()
        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub

    Protected Sub AdminTopListView_ItemDataBound(sender As Object, e As ListViewItemEventArgs)

        Dim itm As ListViewDataItem = CType(e.Item, ListViewDataItem)
        'Dim name As String = AdminTopListView.DataKeys(itm.DataItemIndex)("Nivel1")
        Dim name As Label = CType(e.Item.FindControl("lbl"), Label)

        Dim childMenu As ListView = TryCast(e.Item.FindControl("Menu2"), ListView)
        Dim RequisitoNivel1 As ListView = TryCast(e.Item.FindControl("RequisitoNivel1"), ListView)


        Dim recommendedProducts1 As ListView = TryCast(e.Item.FindControl("Menu3"), ListView)

        Dim query4 As String = "SELECT Requisito FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND Nivel2 IS NULL AND Nivel3 IS NULL"
        obj.LlenarDropDownList(query4)

        RequisitoNivel1.DataSource = obj.ds
        RequisitoNivel1.DataBind()
        For Each item In childMenu.Items
            Dim recommendedProducts2 = TryCast(item.FindControl("Menu3"), ListView)


        Next




        Dim query As String = "SELECT Nivel2 FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND NIVEL2 IS NOT NULL GROUP BY Nivel2"

        obj.LlenarDropDownList(query)
        childMenu.DataSource = obj.ds

        childMenu.DataBind()

        For Each item In childMenu.Items
            Dim name2 As Label = CType(item.FindControl("lbl2"), Label)
            Dim recommendedProducts3 As ListView = TryCast(item.FindControl("Menu3"), ListView)
            Dim query2 As String = "SELECT Nivel3 FROM Cat_menu WHERE Nivel2 = '" + name2.Text + "' AND NIVEL3 IS NOT NULL GROUP BY Nivel3"
            obj.LlenarDropDownList(query2)
            recommendedProducts3.DataSource = obj.ds
            recommendedProducts3.DataBind()

            Dim RequisitoNivel2 As ListView = TryCast(item.FindControl("RequisitoNivel2"), ListView)
            Dim query5 As String = "SELECT Requisito FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND Nivel2='" + name2.Text + "' AND NIVEL3 iS NULL"
            obj.LlenarDropDownList(query5)
            RequisitoNivel2.DataSource = obj.ds
            RequisitoNivel2.DataBind()




            For Each item3 In recommendedProducts3.Items
                Dim name3 As Label = CType(item3.FindControl("lbl3"), Label)

                Dim Requisito2 = TryCast(item3.FindControl("MenuRequisito"), ListView)
                Dim query3 As String = "SELECT Requisito FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND Nivel2='" + name2.Text + "' AND Nivel3='" + name3.Text + "'"
                obj.LlenarDropDownList(query3)
                Requisito2.DataSource = obj.ds
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
End Class