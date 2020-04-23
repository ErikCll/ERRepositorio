Imports System.Net.Mail
Imports System.Net.Security

Public Class Correo
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()
    Public hotmail As String = "orygonconsultores@gmail.com"
    Public Password As String = "Orygonconsultores2020"


    Public Function SecuenciaCorreo(ByVal ObjetoError As String)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential(hotmail, Password)
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(hotmail)
        e_mail.To.Add("erik-ale1@hotmail.com")
        e_mail.To.Add("jc_ortega12@hotmail.com")
        e_mail.To.Add("lucio_gzz@hotmail.com")

        e_mail.Subject = "Error en Proyecto ER"
        e_mail.IsBodyHtml = True
        e_mail.Body = ObjetoError
        'ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
        Smtp_Server.Send(e_mail)

        Server.ClearError()
        Return True
    End Function

    Public Function EnviarCorreoAdministrador(ByVal mensaje As String, ByVal query As String)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential(hotmail, Password)
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(hotmail)

        obj.CorreosAdministradores(query)
        While (obj.drCorreo.Read())
            Dim bdd As MailAddress = New MailAddress(obj.drCorreo("Email").ToString())
            e_mail.To.Add(bdd)
        End While



        'e_mail.To.Add("erik.castaneda@autozone.com")
        'e_mail.To.Add(hotmail)
        e_mail.Subject = "Evidencia cargada"
        e_mail.IsBodyHtml = True

        e_mail.Body = mensaje
        e_mail.BodyEncoding = System.Text.Encoding.UTF8
        'ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
        Smtp_Server.Send(e_mail)

        Server.ClearError()
        Return True
    End Function

    Public Function EnviarCorreoUsuario(ByVal mensaje As String, ByVal email As String)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential(hotmail, Password)
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(hotmail)
        e_mail.To.Add(email)
        'e_mail.To.Add(hotmail)
        e_mail.Subject = "Información de Evidencia"
        e_mail.IsBodyHtml = True
        e_mail.Body = mensaje
        'ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
        Smtp_Server.Send(e_mail)

        Server.ClearError()
        Return True
    End Function

    Public Function CorreoContrasena(ByVal mensaje As String, ByVal email As String)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential(hotmail, Password)
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(hotmail)
        e_mail.To.Add(email)
        'e_mail.To.Add(hotmail)
        e_mail.Subject = "Recuperación de contraseña"
        e_mail.IsBodyHtml = True
        e_mail.Body = mensaje
        'ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
        Smtp_Server.Send(e_mail)

        Server.ClearError()
        Return True
    End Function
End Class
