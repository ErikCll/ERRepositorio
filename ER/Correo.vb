﻿Imports System.Net.Mail
Imports System.Net.Security

Public Class Correo
    Inherits System.Web.UI.Page

    Public hotmail As String = "erik-ale1@hotmail.com"
    Public Password As String = "Eriklenovo123"


    Public Function SecuenciaCorreo(ByVal ObjetoError As String)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential(hotmail, Password)
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.live.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress(hotmail)
        e_mail.To.Add(hotmail)
        e_mail.Subject = "Error Administrador"
        e_mail.IsBodyHtml = True
        e_mail.Body = ObjetoError
        'ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
        Smtp_Server.Send(e_mail)

        Server.ClearError()
        Return True
    End Function
End Class
