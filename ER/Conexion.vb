Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Conexion

    'Private cadena As String = "server=NPLSMXL7471M3X,1433\SQLEXPRESS ; User=sa ; database=ER ; password=Sopenco21"
    'Private cadena As String = " Server=tcp:jcol.database.windows.net,1433;Initial Catalog=orygon;Persist Security Info=False;User ID=jcol;Password=Sopenco21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

    Private cadena As String = "Server=tcp:eregional.database.windows.net,1433;Initial Catalog=eregional;Persist Security Info=False;User ID=er;Password=Datos2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

    Public conn As SqlConnection
    Private cmb As SqlCommandBuilder
    Public cmd As SqlCommand
    Public ds As DataSet
    Public ds2 As DataSet
    Public ds3 As DataSet


    Public da As SqlDataAdapter
    Public dt As New DataTable()
    Public dr As SqlDataReader
    Public drCorreo As SqlDataReader
    Public drInstalacion As SqlDataReader


    Public Id As Integer
    Public AccesoNAme As String
    Public InstalacionName As String
    Public InstalacionId As Integer

    Public Email As String
    Public IdEvidencia As Integer
    Public LocalizacionName As String
    Public PlazaName As String
    Public Rol As String


    Private Sub Conectar()
        conn = New SqlConnection(cadena)

    End Sub
    Public Sub New()
        Conectar()
    End Sub


#Region "Funcion de hacer consultas"
    Public Function Consultar(ByVal sqlQuery As String)
        Try
            conn.Open()
            cmd = New SqlCommand(sqlQuery, conn)
            da = New SqlDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
        Catch ex As Exception
        Finally
            conn.Close()
        End Try
        Return dt
    End Function
#End Region
#Region "Funcion de llenar DropDownList"

    Public Function Llenar(ByVal sqlQuery As String)
        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        da = New SqlDataAdapter(cmd)
        ds2 = New DataSet()
        ds2.Clear()
        da.Fill(ds2)
        conn.Close()
        Return ds2
    End Function
    Public Function LlenarDropDownList(ByVal sqlQuery As String)
        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        ds.Clear()
        da.Fill(ds)
        conn.Close()
        Return ds
    End Function

#End Region

#Region "Funcion Insertar"
    Public Function Insertar(ByVal sqlQuery As String) As Boolean

        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        Dim i As Integer = cmd.ExecuteNonQuery()
        conn.Close()
        If i > 0 Then
            Return True
        Else
            Return False

        End If


    End Function



#End Region

    Public Function InsertarInstalaciones(ByVal IdUusario As String, ByVal IdInstalacion As String) As Boolean

        conn.Open()
        Using cmd = New SqlCommand("INSERT INTO Op_UsIns (Id_Usuario,Id_Instalacion) VALUES(@Id_Usuario,@Id_Instalacion)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Id_Usuario", IdUusario)
            cmd.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion)
            cmd.ExecuteNonQuery()


        End Using
        conn.Close()




    End Function

    Public Function EliminarInstalaciones(ByVal IdUusario As String, ByVal IdInstalacion As String) As Boolean

        conn.Open()
        Using cmd = New SqlCommand("DELETE FROM Op_UsIns WHERE Id_Usuario=@Id_Usuario AND Id_Instalacion=@Id_Instalacion", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Id_Usuario", IdUusario)
            cmd.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion)
            cmd.ExecuteNonQuery()


        End Using
        conn.Close()



    End Function



#Region "Funcion Eliminar"
    Public Function Eliminar(ByVal sqlQuery As String) As Boolean

        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        Dim i As Integer = cmd.ExecuteNonQuery()
        conn.Close()
        If i > 0 Then
            Return True
        Else
            Return False

        End If


    End Function
#End Region

#Region "Funcion Modificar"

    Public Function Modificar(ByVal sqlQuery As String) As Boolean
        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        Dim i As Integer = cmd.ExecuteNonQuery()
        conn.Close()
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region


    Public Function Autenticar(ByVal usuario As String, ByVal password As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario  WHERE Acceso =@Nombre AND contrasena =@Password COLLATE Latin1_General_CS_AS AND Activado IS NULL"
        '//conn.Open();
        '//SqlCommand cmd = New SqlCommand(sqlQuery, conn)
        '//cmd.Parameters.Add(New SqlParameter("Nombre", usuario))
        '//cmd.Parameters.Add(New SqlParameter("Password", password))
        '//consulta a la base de datos

        'Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario  WHERE Acceso = '" + usuario + "' AND contrasena = '" + password + "' AND Activado IS NULL"
        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)
        cmd.Parameters.Add(New SqlParameter("Nombre", usuario))
        cmd.Parameters.Add(New SqlParameter("Password", password))
        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function


    Public Function ObtenerIdUsuario(ByVal sqlQuery As String)


        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        Id = dr(0)
        AccesoName = dr(1)
        InstalacionName = dr(2)
        InstalacionId = dr(3)
        Email = dr(4)
        LocalizacionName = dr(5)
        PlazaName = dr(6)
        Rol = dr(7)



        conn.Close()
        Return Id
    End Function

    Public Function DatosInstalacion(ByVal sqlQuery As String)
        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        drInstalacion = cmd.ExecuteReader

        Return drInstalacion
    End Function

    Public Function CorreosAdministradores(ByVal sqlQuery As String)
        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        drCorreo = cmd.ExecuteReader

        Return drCorreo
    End Function



    Public Function ObtenerIdEvidencia(ByVal query As String)
        conn.Open()

        cmd = New SqlCommand(query, conn)
        IdEvidencia = cmd.ExecuteScalar
        conn.Close()
        Return IdEvidencia

    End Function



    Public Function AutenticarUsuario(ByVal usuario As String) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Acceso='" + usuario + "' AND Activado IS NULL"
        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function


    Public Function AutenticaEmail(ByVal correo As String) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Email='" + correo + "' AND Activado IS NULL"
        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function

    Public Function AutenticarCorreo(ByVal sqlquery As String) As Boolean

        '//consulta a la base de datos

        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlquery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function
    Public Function RolUsuario(ByVal IdUsuario As String, ByVal URL As String) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = " Select COUNT(*)From Op_Roles UsAct Join Usuario Us on UsAct.Id_usuario=Us.Id_Usuario Join Cat_Navegacion Act on UsAct.Id_webform= Act.Id_webform Where Us.Id_Usuario = " + IdUsuario + " And Act.URL ='" + URL + "' AND Us.Activado IS NULL"



        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)


        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function

    Public Function EsAdministrador(ByVal IdUsuario As Integer) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Id_usuario=" + IdUsuario.ToString + " AND EsAdministrador=1 AND Activado IS NULL"
        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function

    Public Function EsSupervisorAdministrador(ByVal IdUsuario As Integer) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Id_usuario=" + IdUsuario.ToString + " AND (EsAdministrador=1 OR EsSupervisor=1) AND Activado IS NULL"
        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function

    Public Function CambioPassword(ByVal IdUsuario As Integer, ByVal Password As String) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Id_usuario=" + IdUsuario.ToString + " AND Contrasena='" + Password + "'"
        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function



    Public Function EsCliente(ByVal IdUsuario As String) As Boolean

        '//consulta a la base de datos
        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Id_usuario=" + IdUsuario.ToString + " AND EsCliente=1"

        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function

    Public Function EsConsultor(ByVal IdUsuario As String) As Boolean

        '//consulta a la base de datos
        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Id_usuario=" + IdUsuario.ToString + " AND EsConsultor=1"

        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function


    Public Function EsOperador(ByVal IdUsuario As String) As Boolean

        '//consulta a la base de datos
        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Id_usuario=" + IdUsuario.ToString + " AND EsOperador=1"

        '//cadena conexion
        conn.Open()

        cmd = New SqlCommand(sqlQuery, conn)

        Dim i As Integer = cmd.ExecuteScalar()
        conn.Close()
        If i > 0 Then
            Return True
        Else Return False
        End If

    End Function
End Class
