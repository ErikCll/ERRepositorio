<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="Menu.aspx.vb" Inherits="ER.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Menú
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
            <div class=" col-lg-12">

                <div class="row">
                    <div class="box box-info" style="border-top-color: #5b6060">
                        <div class="box-body" id="DivInsertar">
                            <div class="row">

                                <div class="col-sm-8 col-md-4 col-lg-4">
                                    <div class="form-group">
                                        <label class="font-weight-bold">Nivel 1:</label>
                                        <asp:TextBox class="form-control " ID="txtNivel1" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                        </asp:TextBox>

                                        <asp:RequiredFieldValidator runat="server" ID="reqNombre" ControlToValidate="txtNivel1"
                                            ErrorMessage="Nombre requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                    </div>




                                    <div class="form-group">
                                        <label class="font-weight-bold">Nivel 2:</label>
                                        <asp:TextBox class="form-control " ID="txtNivel2" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                        </asp:TextBox>

                                        <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="txtNivel2"
                                            ErrorMessage="Apellido Paterno requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label class="font-weight-bold">Nivel 3:</label>
                                        <asp:TextBox class="form-control " ID="txtNivel3" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                        </asp:TextBox>


                                    </div>
                                </div>
                                <div class="col-sm-8 col-md-4 col-lg-4">
                                    <div class="form-group">
                                        <label class="font-weight-bold">Archivo:</label>


                                        <asp:FileUpload runat="server" ID="File" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="File"
                                            ErrorMessage="Instalación requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                                    </div>

                                </div>


                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <div class="vert-offset-bottom-2">
                                        <br />
                                    </div>
                                    <div class="form-group Botones">
                                        <asp:Button class="btn btn-primary  MargingControles" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                        <a id="btn_ClearButton" class="btn btn-default " role="button" onclick="limpiar()">Limpiar</a>
                                        <a id="btnCerrar" class="btn btn-default " role="button">Cerrar</a>
                                    </div>
                                </div>

                            </div>

                        </div>


                    </div>
                </div>

            </div>


            </div>
                    </div>
</div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
