﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Operacion/Site2.Master" CodeBehind="Requisito.aspx.vb" Inherits="ER.Requisito1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Requisito
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--     <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>--%>
       <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="Update1">

                   <ContentTemplate>
                        <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-lg-12">
                    <div class="row">
                         <div class="box box-info" style="border-top-color: #5b6060" >
                <div class="box-body" id="DivInsertar" runat="server">
                    <div class="row">

                     
                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Regulador:</label>
  <asp:DropDownList class="form-control" ID="ddl_Regulador" runat="server" DataTextField="Nombre" DataValueField="Id_Regulador" AutoPostBack="true" OnSelectedIndexChanged="ddl_Regulador_SelectedIndexChanged" ></asp:DropDownList>
                              

                            </div>
                        </div>
                                                    <div class="col-sm-12 col-md-4">

                                                                <div class="form-group">
                                <label class="font-weight-bold">Documento Regulador:</label>
  <asp:DropDownList class="form-control" ID="ddl_DocRegulador" runat="server" DataTextField="Nombre" DataValueField="Id_DocRegulador" ></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddl_DocRegulador"
                                    ErrorMessage="Documento Regulador requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                            </div>
                                                    </div>
                           <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Nombre:</label>
                                <asp:TextBox class="form-control " ID="txt_Regulador" runat="server" MaxLength="200" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="txt_Regulador"
                                    ErrorMessage="Nombre de requisito requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

            <div class="col-sm-8 col-md-4 col-lg-4">
                <div class="form-group">
                    <label class="font-weight-bold">Sin vigencia:</label>
                    <asp:CheckBox runat="server" ID="checkSin"   />
                </div>
            </div>
                        <div class="col-sm-8 col-md-8 col-lg-8"></div>


            <div class="col-sm-8 col-md-4 col-lg-4">
                <div class="form-group">
                    <label class="font-weight-bold">Con vigencia:</label>
                    <asp:CheckBox runat="server" ID="checkCon" />
                </div>
            </div>
                        <div class="col-sm-8 col-md-8 col-lg-8"></div>


                               <div class="col-sm-8 col-md-3 col-lg-3" id="Div1">
                            <div class="form-group">
                                <label class="font-weight-bold">Vigencia Regulatoria:</label>
                                <asp:DropDownList runat="server" ID="ddl_Regulatoria" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2" id="Div2">
                            <div class="form-group">
                                <label class="font-weight-bold">Cantidad:</label>
                                   <asp:TextBox runat="server" ID="txtRegulatoria" CssClass="form-control" onkeypress="return soloNumeros(event)" MaxLength="2"></asp:TextBox>

                            </div>

                        </div>

                            <div class="col-sm-8 col-md-3 col-lg-3" id="Div3">
                            <div class="form-group">
                                <label class="font-weight-bold">Vigencia Operativa:</label>
                                <asp:DropDownList runat="server" ID="ddl_Operativa" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2" id="Div4">
                            <div class="form-group">
                                <label class="font-weight-bold">Cantidad:</label>
                                                            <asp:TextBox runat="server" ID="txtOperativa" CssClass="form-control" onkeypress="return soloNumeros(event)" MaxLength="2"></asp:TextBox>

                            </div>

                        </div>
                     
                   
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="vert-offset-bottom-2">
                                <br />
                            </div>
                            <div class="form-group Botones">
                                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                <asp:LinkButton id="btn_ClearButton" class="btn btn-default"  onclick="limpiar2" runat="server">Limpiar</asp:LinkButton>
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
    <div class="container col-12 ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
                <asp:GridView ID="gridRequisito"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de requisitos"
                 PageSize="10"
                     OnPageIndexChanging="gridRegulador_PageIndexChanging"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_Requisito" 
                     OnRowCommand="gridRegulador_RowCommand">
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
                          
                                            <asp:BoundField HeaderText="Regulador" DataField="Regulador" />
                                             <asp:BoundField HeaderText="Documento Regulador" DataField="Documento" />

                        
                        <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                <asp:TextBox ID="txtEditNombre" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
                                    Text='<%# Eval("Nombre") %>' Visible="false" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vigencia Regulatoria(meses)">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblVigenciaReg" Text='<%# Eval("VigenciaReg") %>'></asp:Label>
                                <asp:TextBox runat="server" ID="txtEditVigenciaReg" Visible="false" onkeypress="return soloNumeros(event)" MaxLength="2"
                                     BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="60px" Text='<%# Eval("VigenciaReg") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Vigencia Operativa(meses)">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblVigenciaOpe" Text='<%# Eval("VigenciaOpe") %>'></asp:Label>
                                <asp:TextBox runat="server" ID="txtEditVigenciaOpe" Visible="false" onkeypress="return soloNumeros(event)" MaxLength="2"
                                     BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="60px" Text='<%# Eval("VigenciaOpe") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requisito con vigencia">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTieneVigencia" Text='<%# Eval("TieneVigencia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                     
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

                   var div =  $("#<%=DivInsertar.ClientID%>");
                      var divP = $('#Div1');
                   var divS = $('#Div2');
                    var divT = $('#Div3');
                   var divC = $('#Div4');
                   //div.hide();
                       //divP.hide();
                       //divS.hide();
                       //divT.hide();
                       //divC.hide();
                       divP.hide();
                   divS.hide();
                   divT.hide();
                   divC.hide();


                        $('#lnk_Agregar').click(function () {

                            //div.slideToggle(500);
                            div.slideDown();

                        });
                        $('#btnCerrar').click(function () {
                            div.slideUp();
                   }); 

                       var checkSin = $("#<%=checkSin.ClientID%>");
                   
                   var checkCon = $("#<%=checkCon.ClientID%>");
                




                   checkSin.click(function () {
                       checkCon.prop('checked', false);
                        divP.hide();
                   divS.hide();
                   divT.hide();
                   divC.hide();

                   });
                     checkCon.click(function () {
                         if (checkCon.prop('checked')==false) {
                               divP.hide();
                   divS.hide();
                   divT.hide();
                   divC.hide();
                         }
                         else {
                                                          checkSin.prop('checked', false);

                      divP.show();
                             divS.show();
                             divT.show();
                             divC.show();
                         }

                   });
               

                     

        });
                  
           
                


              function limpiar() {
                  document.getElementById("<%= txt_Regulador.ClientID %>").value = "";
                  document.getElementById("<%= txtOperativa.ClientID %>").value = "";
                                                      document.getElementById("<%= txtRegulatoria.ClientID %>").value = "";


                  document.getElementById("<%= ddl_Regulador.ClientID %>").selectedIndex = 0;
                                    document.getElementById("<%= ddl_DocRegulador.ClientID %>").selectedIndex = 0;

                                     document.getElementById("<%= ddl_Operativa.ClientID %>").selectedIndex = 0;

                                     document.getElementById("<%= ddl_Regulatoria.ClientID %>").selectedIndex = 0;

         
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
          function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
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

