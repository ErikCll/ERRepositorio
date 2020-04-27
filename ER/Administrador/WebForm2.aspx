<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="WebForm2.aspx.vb" Inherits="ER.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel runat="server" ID="panelPDF">
     <asp:GridView ID="gridEmpleado"
                    runat="server"
                    AutoGenerateColumns="false"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de empleados"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_empleado" 
                
                     >
                    <Columns>
                
                   
                          
                      
                                                <asp:BoundField HeaderText="Usuario" DataField="Acceso" />

                        <asp:BoundField  DataField="Nombre"/>
                      <asp:BoundField DataField="ApellidoPaterno" />
                       <asp:BoundField DataField="ApellidoMaterno" />
                        <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                          <asp:BoundField HeaderText="Fecha de creación " DataField="CreacionFecha" />
                     <asp:BoundField DataField="Rol" />
                    </Columns>
               <PagerStyle HorizontalAlign = "Center" CssClass="" />
                </asp:GridView>
</asp:Panel>
    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnGenrar" Text="Generar" />
</asp:Content>
