Public Class Actividad
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then
            MostrarGridActividad()
            DropDownListArea()
            DropDownListTipo()
            DropDownListDifusion()
        End If
    End Sub

    Public Sub MostrarGridActividad()
        gridActividad.DataSource = obj.Consultar("SELECT CatAct.Id_actividades,CatArea.Nombre 'Area', CatAct.Codigo 'Codigo', CatAct.Nombre 'Actividad', CatAct.Tipo 'Tipo' FROM Cat_Actividades CatAct JOIN Cat_Area CatArea on CatAct.Id_Area=CatArea.Id_area WHERE CatAct.Activado IS NULL AND CatArea.Id_area=" + ddl_Area.SelectedValue + "")
        gridActividad.DataBind()

    End Sub

    Public Sub DropDownListArea()
        ddl_Area.DataSource = obj.LlenarDropDownList("SELECT Id_area,Nombre FROM Cat_Area WHERE Activado IS NULL")
        ddl_Area.DataBind()
        ddl_Area.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub
    Public Sub DropDownListTipo()
        ddl_Tipo.DataSource = obj.LlenarDropDownList("SELECT Nombre FROM Tipo WHERE GrupoTipo=2")
        ddl_Tipo.DataBind()
        ddl_Tipo.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub
    Public Sub DropDownListDifusion()
        ddl_Difusion.DataSource = obj.LlenarDropDownList("SELECT Nombre FROM Tipo WHERE GrupoTipo=3")
        ddl_Difusion.DataBind()
        ddl_Difusion.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub
    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridActividad()

    End Sub
End Class