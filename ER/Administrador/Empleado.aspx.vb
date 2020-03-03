Public Class Empleado
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then

            MostrarGridEmpleado()
            DropDownListInstalacion()
        End If

    End Sub

    Public Sub MostrarGridEmpleado()
        Dim Query = "SELECT Id_empleado,Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion WHERE Emp.Activado IS NULL"
        If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
            Query += " AND Emp.Nombre LIKE  '%" + txtSearch.Text.Trim() + "%'  ORDER BY Emp.Id_empleado DESC"
        End If

        gridEmpleado.DataSource = obj.Consultar(Query)

        gridEmpleado.DataBind()
    End Sub

    Public Sub DropDownListInstalacion()
        ddl_Instalacion.DataSource = obj.LlenarDropDownList("SELECt Id_instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL")
        ddl_Instalacion.DataBind()
        ddl_Instalacion.Items.Insert(0, New ListItem("[Seleccionar]"))
    End Sub

    Protected Sub Search(sender As Object, e As EventArgs)
        MostrarGridEmpleado()

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Dim Materno As String = If(String.IsNullOrWhiteSpace(String.Format("NULL")), Nothing, txtMaterno.Text)
        Dim Materno As String = txtMaterno.Text
        'If (Materno = String.Empty) Then
        '    Materno = DBNull.Value.ToString()
        'End If
        Dim Nombre As String = txtNombre.Text
        Dim Paterno As String = txtPaterno.Text

        Dim ddlInstalacion = ddl_Instalacion.SelectedValue

        Dim sqlQuery = "INSERT INTO Cat_Empleado(Id_instalacion,Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha) VALUES(" + ddlInstalacion + ",'" + Nombre + "','" + Paterno + "','" + Materno + "',GETDATE())"
        Try
            If obj.Insertar(sqlQuery) Then


                'Limpiar()

                MostrarGridEmpleado()
                Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Registro creado exitosamente.")
                scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

            End If
        Catch ex As Exception
            Dim txtJS As String = String.Format("<script>alert('{0}');</script>", "Error al crear registro.")
            scrScript.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, False)

        End Try
    End Sub
End Class