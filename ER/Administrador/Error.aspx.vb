Imports System.Net.Mail
Imports System.Net.Security

Public Class _Error
    Inherits System.Web.UI.Page

    Dim correo As New Correo()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Try
                Dim objErr = Session("Error")
                objErr = "<b>Favor de corregir</b><hr><br>" &
            "<br><b>Error in: </b>" & Session("URL").ToString() &
            "<br><b>Error Message: </b>" & objErr.Message.ToString() &
            "<br><b>Stack Trace:</b><br>" & objErr.StackTrace.ToString()

                correo.SecuenciaCorreo(objErr)



            Catch ex As Exception

            End Try



            Session("Error") = Nothing
            Session("URL") = Nothing
        End If



    End Sub

    Protected Sub Referencia_Click(sender As Object, e As EventArgs)
        Response.Redirect("AdminInicio.aspx")
    End Sub
End Class