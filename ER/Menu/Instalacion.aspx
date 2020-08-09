<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu/Menu.Master" CodeBehind="Instalacion.aspx.vb" Inherits="ER.Instalacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   Instalación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--     <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>--%>
       <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="Update1">

                   <ContentTemplate>
                        <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-lg-12">
                    <div class="row">
                         <div class="box box-info" style="border-top-color: #5b6060" >
                <div class="box-body" id="DivInsertar">
                    <div class="row">

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Estación de Servicio:</label>
                                <asp:TextBox class="form-control " ID="txtNombreInstalacion" runat="server" MaxLength="30" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="txtNombreInstalacion"
                                    ErrorMessage="Nombre de instalación requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Region:</label>

                                <asp:DropDownList class="form-control" ID="ddl_Region" runat="server" DataTextField="Nombre" DataValueField="id_region" ></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="reqRegion" ControlToValidate="ddl_Region"
                                    ErrorMessage="Nombre de región requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                                                    <div class="col-sm-12 col-md-4"></div>

               <div class="col-sm-8 col-md-4 col-md-lg-4">
                   <div class="form-group">
                       <label class="font-weight-bold">Ubicación:</label>
                       <asp:TextBox runat="server" ID="txtUbicacion" CssClass="form-control" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtUbicacion"
                                    ErrorMessage="Nombre de ubicación requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                   </div>
               </div>
                         <div class="col-sm-8 col-md-4 col-md-lg-4">
                   <div class="form-group">
                       <label class="font-weight-bold">Plaza Comercial:</label>
                       <asp:TextBox runat="server" ID="txtPlaza" CssClass="form-control" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPlaza"
                                    ErrorMessage="Nombre de plaza requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                   </div>
               </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="vert-offset-bottom-2">
                                <br />
                            </div>
                            <div class="form-group Botones">
                                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                <a id="btn_ClearButton" class="btn btn-default" role="button" onclick="limpiar()">Limpiar</a>
                                                                <a id="btnCerrar" class="btn btn-default" role="button">Cerrar</a>


                            </div>
                        </div>

                    </div>


                </div>


            </div>
                    </div>
                       <div class="row">
                           <div class="col-sm-4 col-md-1"></div>
        <div class="col-sm-4 col-md-7">
             <div class="btn-group">
                <a id="lnk_Agregar" class="btn btn-sm text-blue" ><span class=" ion-plus" ></span>Agregar</a>
            </div>
        </div>

        <div class="col-sm-4 col-md-4">
            <div class="input-group">
                <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="Search"   CssClass="btn btn-default btn-sm" />
                </div>
            </div>
        </div>
    </div>
<div class="row">
    <div class="container ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
                <asp:GridView ID="gridInstalacion"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de instalaciones"
                 PageSize="10"
                    OnPageIndexChanging="gridInstalacion_PageIndexChanging"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_Instalacion" 
                     OnRowCommand="gridInstalacion_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                                
                                
                                 <asp:LinkButton runat="server" ID="btnEditar" class="btn btn-primary" BackColor="#5b6060"  Text="Editar" CommandName="Editar">
                                </asp:LinkButton>
                                   <asp:LinkButton runat="server" ID="btnAct" class="btn btn-primary" BackColor="#5b6060"  Text="Actualizar" CommandName="Actualizar" Visible="false" >
                                </asp:LinkButton>
                               <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-default"  Text="Cancelar" CommandName="Cancelar" Visible="false" >
                                </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                                <%--<asp:TemplateField HeaderStyle-Width="200px">
                            <ItemTemplate>
                             
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderStyle-Width="20px">
                            <ItemTemplate>

                                <asp:LinkButton runat="server" ID="btnEliminar" class="btn btn-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false">
                             <span class=' ion-ios-trash'></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                        <%--                    <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />--%>
                        
                        <asp:TemplateField HeaderText="Estación de Servicio">
                            <ItemTemplate>
                                <asp:Label ID="lblInstalacion" runat="server" Text='<%# Eval("Instalacion") %>'></asp:Label>
                                <asp:TextBox ID="txtEditInstalacion" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
                                    Text='<%# Eval("Instalacion") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="Ubicación">
                            <ItemTemplate>
                                <asp:Label ID="lblLocalizacion" runat="server" Text='<%# Eval("Localizacion") %>'></asp:Label>
                                <asp:TextBox ID="txtEditLocalizacion" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="200px"
                                    Text='<%# Eval("Localizacion") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="Plaza Comercial">
                            <ItemTemplate>
                                <asp:Label ID="lblPlaza" runat="server" Text='<%# Eval("Plaza") %>'></asp:Label>
                                <asp:TextBox ID="txtEditPlaza" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="200px"
                                    Text='<%# Eval("Plaza") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Región" DataField="Region" />
                     
                    </Columns>
               <PagerStyle HorizontalAlign = "Center" CssClass="" />
                </asp:GridView>
            </div>
   
        </div>
         
    </div>
       
        
    </div>
                </div>
                   </ContentTemplate>
               </asp:UpdatePanel>
      <script type="text/javascript">
                            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

  var div = $('#DivInsertar');
                        div.hide();
                        $('#lnk_Agregar').click(function () {

                            //div.slideToggle(500);
                            div.slideDown();

                        });
                        $('#btnCerrar').click(function () {
                            div.slideUp();
                                 }); 
        });
                  
           
                


              function limpiar() {
                  document.getElementById("<%= txtNombreInstalacion.ClientID %>").value = "";
                              document.getElementById("<%= txtUbicacion.ClientID %>").value = "";
            document.getElementById("<%= txtPlaza.ClientID %>").value = "";

                   document.getElementById("<%= ddl_Region.ClientID %>").selectedIndex = 0;

            }
             function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
                 if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                     ((keyEntry >= 97) && (keyEntry <= 122)) ||
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45
                     || (keyEntry == 241) || keyEntry == 209
                     || (keyEntry == 225) || keyEntry == 233
                     || (keyEntry == 237) || keyEntry == 243
                     || (keyEntry == 243) || keyEntry == 250
                     || (keyEntry == 193) || keyEntry == 201
                     || (keyEntry == 205) || keyEntry == 211
                     || (keyEntry == 218) ||(keyEntry >=48 && keyEntry<=57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64) 
                return true;
            else {
                return false;
            }
        }

        function AlphabetOnly(sender, eventArgs) {
               
            var c = eventArgs.get_keyCode();
            if ((c < 65) || (c > 90 && c < 97) || (c > 122)) {
                eventArgs.set_cancel(true);
                sender._invalid = true;
                sender.updateCssClass();
            }
        }
 //           function Mostrar() {
 //                var Div = document.getElementById('DivInsertar')

 //               if (Div.style.display=='none') {
 //Div.style.display = 'inline'
 //               }
 //               else
 //                    Div.style.display = 'none'
               
                
//}
    
          
</script>   
  
</asp:Content>

