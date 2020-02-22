Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Conexion

    Private cadena As String = "server= ; User= ; database= ; password="
    Public conn As SqlConnection
    Private cmb As SqlCommandBuilder
    Public cmd As SqlCommand
    Public ds As DataSet
    Public da As SqlDataAdapter
    Public dt As New DataTable()
    Public dr As SqlDataReader
    Public Id As Integer
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

    Public Function LlenarDropDownList(ByVal sqlQuery As String)
        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
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

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario  WHERE usuario = '" + usuario + "' AND contrasena = '" + password + "' AND Activado IS NULL"
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


    Public Function ObtenerIdUsuario(ByVal sqlQuery As String)


        conn.Open()
        cmd = New SqlCommand(sqlQuery, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        Id = dr(0)


        conn.Close()
        Return Id
    End Function

    Public Function AutenticarUsuario(ByVal usuario As String) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM Usuario WHERE Usuario='" + usuario + "' AND Activado IS NULL"
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
    Public Function RolUsuario(ByVal IdUsuario As String, ByVal URL As String) As Boolean

        '//consulta a la base de datos

        Dim sqlQuery As String = "SELECT COUNT(*) FROM UsuarioActividad UsAct JOIN Usuario Us on UsAct.Id_Usuario=Us.Id_Usuario JOIN Actividad Act on UsAct.Id_Actividad=Act.Id_Actividad WHERE Us.Id_Usuario=" + IdUsuario + " AND Act.URL='" + URL + "' AND Us.Activado IS NULL "
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

    Public Function AutenticarAdministrador(ByVal IdUsuario As Integer) As Boolean

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
End Class
