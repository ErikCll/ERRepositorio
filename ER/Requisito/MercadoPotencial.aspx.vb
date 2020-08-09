Public Class MercadoPotencial
    Inherits System.Web.UI.Page
    Dim obj As New Conexion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Id_Instalacion As String = Request.QueryString("ins")

        frame.Src = "https://eregional.blob.core.windows.net/mpotencialimg/" & Id_Instalacion.ToString() & ".pdf"

        'img.Src = "https://er2020.blob.core.windows.net/mpotencialimg/" & Id_Instalacion.ToString() & ".jpg"
        'If img.Alt = "Sin registro" Then
        '    img.Src = "https://eregional.blob.core.windows.net/mpotencialimg/" & Id_Instalacion.ToString() & ".JPG"

        'End If
        'If img.Alt = "Sin registro" Then
        '    img.Src = "https://eregional.blob.core.windows.net/mpotencialimg/" & Id_Instalacion.ToString() & ".png"

        'End If
        'If img.Alt = "Sin registro" Then
        '    img.Src = "https://eregional.blob.core.windows.net/mpotencialimg/" & Id_Instalacion.ToString() & ".PNG"


        'End If
        If Not IsPostBack Then
            MostrarListaPoligono()
        End If

    End Sub

    Public Sub MostrarListaPoligono()
        Dim Id_Instalacion As String = Request.QueryString("ins")
        Dim query As String = "SELECT REPLACE(CONVERT(varchar,CAST(CAST (Veh_viviendas AS DECIMAL(20)) as money),1),'.00','') 'Veh_viviendas2', REPLACE(CONVERT(varchar,CAST(CAST (vol_ventas_vehiculos AS DECIMAL(20)) as money),1),'.00','') 'vol_ventas_vehiculos2', REPLACE(CONVERT(varchar,CAST(CAST (vol_consumo_area AS DECIMAL(20)) as money),1),'.00','') 'vol_consumo_area2', REPLACE(CONVERT(varchar,CAST(CAST (num_vehiculos_flotantes AS DECIMAL(20)) as money),1),'.00','') 'num_vehiculos_flotantes2', REPLACE(CONVERT(varchar,CAST(CAST (vol_consumo_flotantes AS DECIMAL(20)) as money),1),'.00','') 'vol_consumo_flotantes2', REPLACE(CONVERT(varchar,CAST(CAST (flujo_vehiculo_tienda AS DECIMAL(20)) as money),1),'.00','') 'flujo_vehiculo_tienda2', REPLACE(CONVERT(varchar,CAST(CAST (vol_consumo_tienda AS DECIMAL(20)) as money),1),'.00','') 'vol_consumo_tienda2',* from Plantilla_mercado_pot WHERE Id_Instalacion=" + Id_Instalacion + ""
        list.DataSource = obj.Llenar(query)
        list.DataBind()

        list2.DataSource = obj.Llenar(query)
        list2.DataBind()

        list3.DataSource = obj.Llenar(query)
        list3.DataBind()

        list4.DataSource = obj.Llenar(query)
        list4.DataBind()
    End Sub

    Protected Sub list3_ItemDataBound(sender As Object, e As ListViewItemEventArgs)
        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim Requisito As String = Request.QueryString("reqn")
            Dim label As Label = CType(e.Item.FindControl("lblTitulo"), Label)
            label.Text = Requisito
        End If
    End Sub
End Class