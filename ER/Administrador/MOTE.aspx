<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="MOTE.aspx.vb" Inherits="ER.MOTE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Modelo de Ordenamiento Territorial Energético
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="row">
                          <div class="embed-responsive embed-responsive-1by1">
            
                <iframe class="embed-responsive-item" runat="server" id="frame" frameBorder="0" style="border:0" src="https://energia-regional.maps.arcgis.com/apps/webappviewer/index.html?id=959492d1e1784cb790b0edf7827c3b1a"></iframe>
                    </div>
        </div>
    </div>
</asp:Content>
