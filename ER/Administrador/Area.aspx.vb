Public Class Area
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then

            MostrarGridArea()
            DropDownListInstalacion()
        End If
    End Sub

    Public Sub MostrarGridArea()
        gridArea.DataSource = obj.Consultar("SELECT catArea.Id_area, catArea.Nombre 'Area', catIns.Nombre 'Instalacion', catArea.Codigo FROM Cat_Area catArea JOIN Cat_Instalacion catIns on catArea.Id_instalacion=catIns.Id_instalacion where catArea.Activado IS NULL AND CatIns.Id_Instalacion=" + ddl_Instalacion.SelectedValue + "")
        gridArea.DataBind()

    End Sub

    Public Sub DropDownListInstalacion()
        ddl_Instalacion.DataSource = obj.LlenarDropDownList("SELECt Id_instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL")
        ddl_Instalacion.DataBind()
        ddl_Instalacion.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridArea()

    End Sub
End Class