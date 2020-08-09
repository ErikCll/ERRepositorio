<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu/Menu.Master" CodeBehind="Contrasena.aspx.vb" Inherits="ER.Contrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Cambiar contraseña
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--            <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>--%>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-sm-12 col-md-12 col-lg-12">
                    <div class="row">
                        <div class="col-sm-4 col-md-8">
                            <div class="form-inline">
                                <div class="form-group ">
                                    <label>Contraseña actual:</label>
                                    <asp:TextBox runat="server" ID="txtActual" CssClass="form-control form-control-sm ml-1" TextMode="Password" MaxLength="10" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="txtActual" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-12"></div>
                    </div>
                    <div class="row my-4">
                        <div class="col-sm-4 col-md-8">
                            <div class="form-inline">
                                <div class="form-group">
                                    <label>Nueva contrseña:</label>
                                                                        <asp:TextBox runat="server" ID="txtNueva" class="form-control form-control-sm ml-1" TextMode="Password" MaxLength="10" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ControlToValidate="txtNueva" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4 col-md-8">
                            <div class="form-inline">
                                <div class="form-group">
                                    <label>Confirmar contrseña:</label>
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtConfirmar" class="form-control form-control-sm ml-1" TextMode="Password" MaxLength="10" onkeypress="return AllowAlphabet(event)"></asp:TextBox>

                                       <span class="input-group-append bg-white">
                                                        <span class=" btn btn-sm border border-left-0" onmousedown="mostrarContrasena()" onmouseup="NomostrarContrasena()"><i class=" icon  ion-eye"></i></span>
                                                    </span>
                                    </div>
                                 
                                </div>
                            </div>
                            <div class="col-md-2"></div>
                             <asp:CompareValidator  ForeColor="Red" ValidationGroup="btnGuardar" runat="server" ControlToCompare="txtNueva" ControlToValidate="txtConfirmar" ErrorMessage="No coinciden las contraseñas"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">

                                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar cambios" BackColor="#5b6060" BorderColor="#5b6060" ValidationGroup="btnGuardar" />
<%--                                <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" Text="Regresar"  />--%>
     <asp:Button class="btn btn-default" ID="btnRegresar" runat="server" Text="Regresar"></asp:Button>  
<%--                                     <a class="btn btn-default" href="#" onClick="history.back();">Regresar</a>  --%>

                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
     <script type="text/javascript">

           Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }



          function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                ((keyEntry >= 97) && (keyEntry <= 122)) ||
                (keyEntry == 46) || (keyEntry == 46) || keyEntry == 45 || (keyEntry == 46) || keyEntry == 45
                || (keyEntry == 241) || keyEntry == 209
                || (keyEntry == 225) || keyEntry == 233
                || (keyEntry == 237) || keyEntry == 243
                || (keyEntry == 243) || keyEntry == 250
                || (keyEntry == 193) || keyEntry == 201
                || (keyEntry == 205) || keyEntry == 211
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }
  function mostrarContrasena(){
      var tipo = document.getElementById("<%=txtConfirmar.ClientID%>");

      if(tipo.type == "password"){
          tipo.type = "text";
      }
     
        }
         function NomostrarContrasena(){
          var tipo = document.getElementById("<%=txtConfirmar.ClientID%>");

      if(tipo.type == "text"){
          tipo.type = "password";
      }
     
            }

    
        </script>
</asp:Content>
