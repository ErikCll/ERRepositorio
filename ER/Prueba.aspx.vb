Public Class Prueba
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim query As String = "select Nivel1 from cat_menu group by Nivel1"
        obj.LlenarDropDownList(query)
        AdminTopListView.DataSource = obj.ds
        AdminTopListView.DataBind()



    End Sub

    Protected Sub AdminTopListView_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
        Dim itm As ListViewDataItem = CType(e.Item, ListViewDataItem)
        'Dim name As String = AdminTopListView.DataKeys(itm.DataItemIndex)("Nivel1")
        Dim name As Label = CType(e.Item.FindControl("lbl"), Label)

        Dim childMenu As ListView = TryCast(e.Item.FindControl("Menu2"), ListView)
        Dim recommendedProducts1 As ListView = TryCast(e.Item.FindControl("Menu3"), ListView)
        'Dim name2 As String = childMenu.DataKeys(itm.DataItemIndex)("Nivel2")

        For Each item In childMenu.Items
            Dim recommendedProducts2 = TryCast(item.FindControl("Menu3"), ListView)


        Next

        Dim query As String = "SELECT Nivel2 FROM Cat_menu WHERE Nivel1 = '" + name.Text + "' AND NIVEL2 IS NOT NULL GROUP BY Nivel2"

        obj.LlenarDropDownList(query)

        childMenu.DataSource = obj.ds
        childMenu.DataBind()

        For Each item2 In childMenu.Items
            Dim name2 As Label = CType(item2.FindControl("lbl2"), Label)

            Dim recommendedProducts3 = TryCast(item2.FindControl("Menu3"), ListView)
            Dim query2 As String = "SELECT Nivel3 FROM Cat_menu WHERE Nivel2 = '" + name2.Text + "' AND NIVEL3 IS NOT NULL GROUP BY Nivel3"
            obj.LlenarDropDownList2(query2)
            recommendedProducts3.DataSource = obj.ds2
            recommendedProducts3.DataBind()
        Next

        'If e.Item.ItemType = ListViewItemType.DataItem Then
        '    Dim itm As ListViewDataItem = CType(e.Item, ListViewDataItem)

        '    Dim name As String = AdminTopListView.DataKeys(itm.DataItemIndex)("Nivel1")

        '    Dim childMenu As ListView = TryCast(e.Item.FindControl("Menu2"), ListView)
        '    Dim childMenu2 As ListView = TryCast(e.Item.FindControl("Menu3"), ListView)


        '    Dim query As String = "SELECT Nivel2 FROM Cat_menu WHERE Nivel1 = '" + name + "' AND NIVEL2 IS NOT NULL GROUP BY Nivel2"
        '    obj.LlenarDropDownList(query)
        '    childMenu.DataSource = obj.ds
        '    childMenu.DataBind()



        'End If
    End Sub

    'Protected Sub Menu2_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
    '    If e.Item.ItemType = ListViewItemType.DataItem Then
    '        Dim itm As ListViewDataItem = CType(e.Item, ListViewDataItem)

    '        Dim name As String = AdminTopListView.DataKeys(itm.DataItemIndex)("Nivel1")

    '        Dim childMenu2 As ListView = TryCast(e.Item.FindControl("Menu3"), ListView)




    '        Dim query2 As String = "SELECT Nivel3 FROM Cat_menu WHERE Nivel1 = 'MODELO DE CUMPLIMIENTO REGULATORIO Y OPERATIVO' AND NIVEL3 IS NOT NULL GROUP BY Nivel3"
    '        obj.LlenarDropDownList2(query2)
    '        childMenu2.DataSource = obj.ds2
    '        childMenu2.DataBind()


    '    End If
    'End Sub
End Class