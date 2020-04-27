Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports System.IO

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim obj As New Conexion()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        MostrarGridEmpleado()
    End Sub



    Public Sub MostrarGridEmpleado()

        Dim Query = "SELECT Emp.Id_empleado,CASE WHEN us.Activado=1 THEN Null ELSE Us.Acceso END 'Acceso',Emp.Nombre,Emp.ApellidoPaterno,Emp.ApellidoMaterno, Inst.Nombre AS 'Instalacion', CONVERT(varchar,Emp.CreacionFecha,105)'CreacionFecha',CASE WHEN us.EsSupervisor IS NULL THEN '' ELSE 'Supervisor' END 'Rol' FROM Cat_Empleado Emp JOIN Cat_Instalacion Inst on Emp.Id_instalacion=Inst.Id_instalacion LEFT JOIN Usuario us on Emp.Id_empleado=us.Id_empleado AND Us.Activado IS NULL WHERE Emp.Activado IS NULL ORDER BY us.EsSupervisor DESC, Emp.Id_empleado DESC"


        gridEmpleado.DataSource = obj.Consultar(Query)
        gridEmpleado.DataBind()


    End Sub

    Protected Sub btnGenrar_Click(sender As Object, e As EventArgs) Handles btnGenrar.Click
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=print.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)


        panelPDF.RenderControl(hw)
        Dim SR As New StringReader(sw.ToString())

        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 10.0F)
        Dim htmlParser As New HTMLWorker(pdfDoc)


        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)

        pdfDoc.Open()
        htmlParser.Parse(SR)
        pdfDoc.Close()

        Response.Write(pdfDoc)
        Response.End()

    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub
End Class