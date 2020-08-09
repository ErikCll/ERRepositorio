<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="Requisitos.aspx.vb" Inherits="ER.Requisitos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Requisitos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="update1">
        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-12">
                
                <div class="row">
                    <div class="box box-info" style="border-top-color: #5b6060">
                        <div class="box-body" id="DivInsertar" runat="server" visible="false">
                            <div class="row">
                                <div class="col-sm-12 col-md-4 col-lg-4">
                                      <div class="form-group">
                                        <label class="font-weight-bold">Nivel 1:</label>
                                         <asp:LinkButton runat="server" CssClass="btn btn-sm text-blue float-right" OnClick="Abrir1" Visible="false" ID="Open1"><span class=" ion-edit" ></span> Renombrar</asp:LinkButton>
                                        <asp:DropDownList runat="server" CssClass=" form-control" ID="ddl_Nivel1" AutoPostBack="true" DataTextField="Nivel1" DataValueField="Nivel1_no" OnSelectedIndexChanged="ddl_Nivel1_SelectedIndexChanged"></asp:DropDownList>

                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="ddl_Nivel1"
                                            ErrorMessage="Nivel 1 requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                  
                                <div class="col-sm-12 col-md-4 col-lg-4">
                                      <div class="form-group">
                                                       <asp:LinkButton id="Link1" class="btn btn-sm" ForeColor="Gray" onclick="Renombrar1" runat="server" Visible="false" ><span class=" ion-checkmark" ></span> Guardar </asp:LinkButton>

                                        <asp:TextBox runat="server" ID="txt1" CssClass="form-control" onkeypress="return AllowAlphabet(event)" Visible="false" BackColor="#ffffbb"></asp:TextBox>
                                    

                                    </div>
                                </div>
                                        <div class="col-sm-12 col-md-4 col-lg-4"></div>
                                <div class="col-sm-12 col-md-4 col-lg-4">
                                      <div class="form-group">
                                        <label class="font-weight-bold">Nivel 2:</label>
                                            <asp:LinkButton runat="server" CssClass="btn btn-sm text-blue float-right" OnClick="Abrir2" Visible="false" ID="Open2"><span class=" ion-edit" ></span> Renombrar</asp:LinkButton>

                                   <asp:DropDownList runat="server" CssClass=" form-control" ID="ddl_Nivel2" AutoPostBack="true" DataTextField="Nivel2" DataValueField="Nivel2_no" OnSelectedIndexChanged="ddl_Nivel2_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="ddl_Nivel2"
                                            ErrorMessage="Opción Nivel 2 o No Aplica requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                                     
                                    </div>

                                </div>
                                    
                                  <div class="col-sm-12 col-md-4 col-lg-4">

                                        <div class="form-group">
                                                       <asp:LinkButton id="Link2" class="btn btn-sm " ForeColor="Gray" onclick="Renombrar2" runat="server" Visible="false" ><span class=" ion-checkmark" ></span> Guardar</asp:LinkButton>

                                        <asp:TextBox runat="server" ID="txt2" CssClass="form-control" onkeypress="return AllowAlphabet(event)" Visible="false" BackColor="#ffffbb"></asp:TextBox>
                                    

                                    </div>
                                  </div>
                                      <div class="col-sm-12 col-md-4 col-lg-4"></div>

                                <div class="col-sm-12 col-md-4 col-lg-4">

                                      <div class="form-group">
                                        <label class="font-weight-bold">Nivel 3:</label>
                                              <asp:LinkButton runat="server" CssClass="btn btn-sm text-blue float-right" OnClick="Abrir3" Visible="false" ID="Open3"><span class=" ion-edit" ></span> Renombrar</asp:LinkButton>

                                       <asp:DropDownList AutoPostBack="true" runat="server" CssClass=" form-control" ID="ddl_Nivel3"  DataTextField="Nivel3" DataValueField="Nivel3" OnSelectedIndexChanged="ddl_Nivel3_SelectedIndexChanged"></asp:DropDownList>

                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddl_Nivel3"
                                            ErrorMessage="Opción Nivel 3 o No Aplica requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                              <div class="col-sm-12 col-md-4 col-lg-4">
                                          <div class="form-group">
                                                       <asp:LinkButton id="Link3" class="btn btn-sm" ForeColor="Gray" onclick="Renombrar3" runat="server" Visible="false" ><span class=" ion-checkmark" ></span> Guardar</asp:LinkButton>

                                        <asp:TextBox runat="server" ID="txt3" CssClass="form-control" onkeypress="return AllowAlphabet(event)" Visible="false" BackColor="#ffffbb"></asp:TextBox>
                                    

                                    </div>

                              </div>
                                  
                                       <div class="col-sm-12 col-md-4 col-lg-4"></div>                                
                                <div class="col-sm-8 col-md-4 col-lg-4">
                                    <div class="form-group">
                                        <label class="font-weight-bold">Requisito:</label>
                                        <asp:TextBox runat="server" ID="txtRequisito" CssClass="form-control" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtRequisito"
                                            ErrorMessage="Nombre de Requisito requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                                    </div>

                                </div>


                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <div class="vert-offset-bottom-2">
                                        <br />
                                    </div>
                                    <div class="form-group Botones">
                                        <asp:Button class="btn btn-primary  MargingControles" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                        <a id="btn_ClearButton" class="btn btn-default " role="button" onclick="limpiar()">Limpiar</a>
                                       <asp:LinkButton id="btnCerrar" class="btn btn-default " runat="server" OnClick="Cerrar">Cerrar</asp:LinkButton>
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
               <asp:LinkButton id="lnk_Agregar" class="btn btn-sm text-blue" onclick="Abrir" runat="server" ><span class=" ion-plus" ></span>Agregar</asp:LinkButton>
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
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>

                        <div class="row">

                    <div class=" container">
                        <div class="table-responsive">
 <div style="overflow: auto; height: auto">
                <asp:GridView ID="gridMenu" runat="server"
                    AutoGenerateColumns="false"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de requisitos"
                    OnRowCommand="gridMenu_RowCommand"
                    DataKeyNames="Id_Requisito"
                                        AllowCustomPaging="false" 
                     PageSize="20"
                     AllowPaging="true"
                     OnPageIndexChanging="gridMenu_PageIndexChanging"
>
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
                        
                        <asp:BoundField DataField="Nivel1" />
                                                <asp:BoundField DataField="Nivel2" />
                        <asp:BoundField DataField="Nivel3" />

                               <asp:TemplateField HeaderText="Requisito"  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblRequisito" runat="server" Text='<%# Eval("Requisito") %>'></asp:Label>
                                <asp:TextBox ID="txtRequisito" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="200px"
                                    Text='<%# Eval("Requisito") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                    </Columns>
                                   <PagerStyle HorizontalAlign = "Center" CssClass="" />

                </asp:GridView>
            </div>




            </div>


            </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script type="text/javascript">
                            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

  //var div = $('#DivInsertar');
  //                      div.hide();
  //                      $('#lnk_Agregar').click(function Abrir() {

  //                          //div.slideToggle(500);
  //                          div.slideDown();

  //                      });
  //                      $('#btnCerrar').click(function () {
  //                          div.slideUp();
  //                 }); 


                  
        });
                  
            function filtro() {
            var txtKeyword = document.getElementById("txtFiltro");
            var tblGrid = document.getElementById('<%= gridMenu.ClientID %>');
            var rows = tblGrid.rows;
            var i = 0, row, cell;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                for (var j = 0; j < row.cells.length; j++) {
                    cell = row.cells[j];
                    if (cell.innerHTML.toUpperCase().indexOf(txtKeyword.value.toUpperCase()) >= 0) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    row.style['display'] = 'none';

                }
                else {
                    row.style.display = '';
                }
            }

            return false;

        }

         
              function limpiar() {
                  document.getElementById("<%= txtRequisito.ClientID %>").value = "";
              

       

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
