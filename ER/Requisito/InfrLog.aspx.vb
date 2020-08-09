Public Class InfrLog
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Id_Instalacion As String = Request.QueryString("ins")


        frame.Src = "https://eregional.blob.core.windows.net/inflogisticaimg/" & Id_Instalacion.ToString() & ".pdf"


        If Not IsPostBack Then
            MostrarDatos()
        End If
    End Sub

    Public Sub MostrarDatos()
        Dim Id_Instalacion As String = Request.QueryString("ins")

        Dim query As String = "select * from plantilla_infr_log where id_Instalacion=" + Id_Instalacion.ToString() + ""
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