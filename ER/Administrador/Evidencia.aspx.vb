Public Class Evidencia
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Nivel1()

        End If
    End Sub

    Public Sub Nivel1()
        ddl_Nivel1.DataSource = obj.LlenarDropDownList("SELECT Nivel1 FROM Cat_Menu GROUP BY Nivel1")

        ddl_Nivel1.DataBind()
        ddl_Nivel1.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

    Protected Sub ddl_Nivel1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Nivel2()

    End Sub

    Public Sub Nivel2()
        ddl_Nivel2.DataSource = obj.LlenarDropDownList("SELECT  CASE WHEN Nivel2 IS NULL THEN '(Requisito)' ELSE Nivel2 END FROM Cat_Menu WHERE Nivel1='" + ddl_Nivel1.SelectedValue + "' GROUP BY Nivel2")

        ddl_Nivel2.DataBind()
        ddl_Nivel2.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

End Class