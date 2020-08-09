Public Class FichaBasica
    Inherits System.Web.UI.Page

    Dim obj As New Conexion()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Id_Instalacion As String = Request.QueryString("ins")


        frame.Src = "https://eregional.blob.core.windows.net/fichaimg/" & Id_Instalacion.ToString() & ".pdf"

        ''img.Src = "https://er2020.blob.core.windows.net/fichaimg/" & Id_Instalacion.ToString() & ".jpg"
        'If img.Alt = "Sin registro" Then
        '    img.Src = "https://eregional.blob.core.windows.net/fichaimg/" & Id_Instalacion.ToString() & ".JPG"

        'End If
        'If img.Alt = "Sin registro" Then
        '    img.Src = "https://eregional.blob.core.windows.net/fichaimg/" & Id_Instalacion.ToString() & ".png"

        'End If
        'If img.Alt = "Sin registro" Then
        '    img.Src = "https://eregional.blob.core.windows.net/fichaimg/" & Id_Instalacion.ToString() & ".PNG"


        'End If

        If Not IsPostBack Then

            MostrarListaFicha()
        End If
    End Sub

    Public Sub MostrarListaFicha()
        Dim Id_Instalacion As String = Request.QueryString("ins")
        Dim query As String = "SELECT REPLACE(CONVERT(varchar,CAST(CAST (flujo_vehiculo_tienda AS DECIMAL(20)) as money),1),'.00','') 'flujo_vehiculo_tienda2',* FROM Plantilla_Inf_basica WHERE Id_Instalacion=" + Id_Instalacion + ""
        list.DataSource = obj.Llenar(query)
        list.DataBind()
        list2.DataSource = obj.Llenar(query)
        list2.DataBind()
    End Sub

    Protected Sub list_ItemDataBound(sender As Object, e As ListViewItemEventArgs)

        If e.Item.ItemType = ListViewItemType.DataItem Then
            Dim Requisito As String = Request.QueryString("reqn")
            Dim label As Label = CType(e.Item.FindControl("lblTitulo"), Label)
            label.Text = Requisito
        End If



    End Sub
End Class