Imports System.Net.Mail
Imports System.Net.Security

Public Class _Error
    Inherits System.Web.UI.Page

    'Dim correo As New Correo()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Try
                Dim objErr = Session("Error")
                objErr = "<b>Favor de corregir</b><hr><br>" &
            "<br><b>Error in: </b>" & Request.Url.ToString() &
            "<br><b>Error Message: </b>" & objErr.Message.ToString() &
            "<br><b>Stack Trace:</b><br>" & objErr.StackTrace.ToString()

                'correo.SecuenciaCorreo(objErr)

            Catch ex As Exception

            End Try


            'If Session("URL") = "Actividad.aspx" Then
            '    Referencia.HRef = Session("Programa")
            'ElseIf Session("URL") = "Area.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            'ElseIf Session("URL") = "Op_RSPA_Resultado.aspx" Then
            '    Referencia.HRef = Session("URL")


            'Referencia.HRef = Session("URL")
            Session("URL") = Nothing
            '    End If
        End If



    End Sub

    Protected Sub Referencia_Click(sender As Object, e As EventArgs)
        Response.Redirect("Administrador/AdminInicio.aspx")
    End Sub
End Class