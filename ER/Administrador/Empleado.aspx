<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="Empleado.aspx.vb" Inherits="ER.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   Empleado
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

    <asp:UpdatePanel UpdateMode="Conditional" runat="server">

                   <ContentTemplate>
                        <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-lg-12">
                    <div class="row">
                         <div class="box box-info" style="border-top-color: #5b6060" >
                <div class="box-body" id="DivInsertar">
                    <div class="row">

                        <div class="col-sm-8 col-md-4 col-lg-4">
                               <div class="form-group">
                                <label class="font-weight-bold">Nombre(s):</label>
                                <asp:TextBox class="form-control " ID="txtNombre" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="reqNombre" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        
                         
                  

                            <div class="form-group">
                                <label class="font-weight-bold">Apellido Paterno:</label>
                                <asp:TextBox class="form-control " ID="txtPaterno" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="txtPaterno"
                                    ErrorMessage="Apellido Paterno requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="font-weight-bold">Apellido Materno:</label>
                                <asp:TextBox class="form-control " ID="txtMaterno" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                              
                            </div>
                            </div>
                                                 <div class="col-sm-8 col-md-4 col-lg-4">
<div class="form-group">
                                <label class="font-weight-bold">Instalación:</label>

                                <asp:DropDownList class="form-control" ID="ddl_Instalacion" runat="server" DataTextField="Nombre" DataValueField="Id_instalacion"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddl_Instalacion"
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
<asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="Search" CssClass="btn btn-default btn-sm" />
                </div>
            </div>
        </div>
    </div>
<div class="row">
    <div class="container ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
             <asp:GridView ID="gridEmpleado"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registros"
                 PageSize="10"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_empleado" 
                  OnPageIndexChanging="gridEmpleado_PageIndexChanging"
                  OnRowCommand="gridEmpleado_RowCommand"
                     >
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="220px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                                <div class="btn-group">
                <asp:LinkButton runat="server" id="btnAgregar" class="btn btn-sm text-blue" CommandName="Agregar" ><span class=" ion-plus" ></span>Usuario</asp:LinkButton>
            </div>
                              
                                 <asp:LinkButton runat="server" ID="btnEditar" class="btn btn-primary" BackColor="#5b6060"  Text="Editar" CommandName="Editar">
                                </asp:LinkButton>
                                   <asp:LinkButton runat="server" ID="btnAct" class="btn btn-primary" BackColor="#5b6060"  Text="Actualizar" CommandName="Actualizar" Visible="false" >
                                </asp:LinkButton>
                               <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-default"  Text="Cancelar" CommandName="Cancelar" Visible="false" >
                                </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                             
                        <asp:TemplateField HeaderStyle-Width="20px">
                            <ItemTemplate>

                                <asp:LinkButton runat="server" ID="btnEliminar" class="btn btn-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false">
                             <span class=' ion-ios-trash'></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                      
                                                <asp:BoundField HeaderText="Acceso" DataField="Acceso" />

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                <asp:TextBox ID="txtEditNombre" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="120px"
                                    Text='<%# Eval("Nombre") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Paterno">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("ApellidoPaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoPaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="100px"
                                    Text='<%# Eval("ApellidoPaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Materno">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("ApellidoMaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoMaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="100px"
                                    Text='<%# Eval("ApellidoMaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                          <asp:BoundField HeaderText="Fecha de creación " DataField="CreacionFecha" />
                     
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
                  document.getElementById("<%= txtNombre.ClientID %>").value = "";
                  document.getElementById("<%= txtPaterno.ClientID %>").value = "";
                                      document.getElementById("<%= txtMaterno.ClientID %>").value = "";

                   document.getElementById("<%= ddl_Instalacion.ClientID %>").selectedIndex = 0;

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

