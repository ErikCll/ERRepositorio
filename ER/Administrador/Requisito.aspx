﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="Requisito.aspx.vb" Inherits="ER.Requisito" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <label class=" font-weight-bold">Requisito:</label>
    <asp:Label runat="server" ID="lblRequisito"></asp:Label>
       <br />
    <div runat="server" id="divHead" >
         <label class="font-weight-bold" >Estado:</label>
    <asp:Label runat="server" ID="lblAprobada"  Visible="false">Aprobada <a class=" ion-record text-green"></a></asp:Label>
        <asp:Label runat="server" ID="lblEnAprobacion"  Visible="false">Pendiente de aprobación <a class=" ion-record text-yellow"></a></asp:Label>
            <asp:Label runat="server" ID="lblRechazada" Visible="false">Rechazada <a class=" ion-record text-red"></a></asp:Label>
                <asp:Label runat="server" ID="lblSinEvidencia" Visible="true">Sin evidencia <a class=" ion-record text-red"></a></asp:Label>
                    <asp:Label runat="server" ID="lblNoAplica" Visible="false">No Aplica <a class=" ion-record text-gray"></a></asp:Label>
    </div>
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>--%>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1">
        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>
             <ul class="nav nav-tabs">
      <li class="nav-item" runat="server" id="itemCaptura">
        <a data-toggle="tab" class="nav-link active" href="#<%= captura.ClientID %>">Evidencia</a>
      </li>
      <li class="nav-item" runat="server" id="itemConsulta">
        <a data-toggle="tab" class="nav-link" href="#<%= consulta.ClientID %>">Aprobación de Evidencia</a>
      </li>
   
    </ul>
            <div class="col-lg-12">
                    <div class="tab-content">
                        <div class="tab-pane active" id="captura" runat="server" >
     <div class="row">  
         <div class="box box-info" style="border-top-color: #5b6060" >
                <div class="box-body" id="DivInsertar" runat="server" >
                    <div class="row">

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Evidencia:</label>
                               
                              <asp:FileUpload runat="server" ID="File1" />
                                <%--<input type="file" name="File3" />
                       
                               <telerik:RadUpload ID="File2" runat="server"></telerik:RadUpload>--%>

                            </div>
                               <asp:RequiredFieldValidator runat="server" ID="reqFile" ControlToValidate="File1"
                                    ErrorMessage="Debe seleccionar un archivo PDF." ForeColor="Red" ValidationGroup="btnGuardar" Enabled="false"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo PDF." ForeColor="Red"
                                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$" ControlToValidate="File1" ValidationGroup="btnGuardar">
                                                    </asp:RegularExpressionValidator>
                                  
                        </div>

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">No aplica requisito:</label>
                                <asp:CheckBox runat="server" ID="chkRequisito" />
                            </div>
                        </div>
                        <div class="col-sm-4 col-md-4 col-lg-4"></div>
                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Observaciones:</label>

                                <textarea runat="server" class="form-control" id="txtDesc" onkeypress="return AllowAlphabet(event)" maxlength="200"></textarea>
                                <asp:RequiredFieldValidator runat="server" ID="reqRegion" ControlToValidate="txtDesc"
                                    ErrorMessage="Observación requerida." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col-sm-12 col-md-2"></div>
                        </div>
               
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="vert-offset-bottom-2">
                                <br />
                            </div>
                            <div class="form-group Botones">
                                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                <a id="btn_ClearButton" class="btn btn-default" role="button" onclick="limpiar()">Limpiar</a>
                                        <a id="btnCerrar" class="btn btn-default " runat="server">Cerrar</a>

                            </div>
                        </div>

                    </div>


                </div>


            </div>
                      <asp:GridView runat="server" DataKeyNames="id_requisito" ID="gridEvidencia" AutoGenerateColumns="false" Visible="false"><Columns>
                          <asp:BoundField  DataField="id_evidencia" HeaderText="ID de evidencia"/>
                          <asp:BoundField DataField="id_requisito" HeaderText="Id requisito"                           
                           />
                          <asp:BoundField DataField="estado" />
                                                                               </Columns></asp:GridView>
          <div class="btn-group">
                <a id="lnk_Agregar" class="btn btn-sm text-blue" runat="server" ><span class=" ion-plus" ></span>Agregar</a>
            </div>
                                 <div class="embed-responsive embed-responsive-1by1">
            
                <iframe class="embed-responsive-item" runat="server" id="frame" visible="false" frameBorder="0" style="border:0"></iframe>
                    </div></div>
                    </div>
             <div class="tab-pane" id="consulta" runat="server" >
              
                      <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
                                                              <asp:Literal ID="litControl2" runat="server"></asp:Literal>

                             <div class="row">
   <div class="box box-info" style="border-top-color: #5b6060" >
                <div class="box-body" >
                    <div class="row">
                         <div class="container ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
                     <asp:GridView ID="gridEvidencia2"
                    runat="server"
                    AutoGenerateColumns="false" 
                    CssClass="table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de evidencias"
                 PageSize="10"
                    DataKeyNames="id_evidencia" 
               OnRowCommand="gridEvidencia2_RowCommand"
                          OnPageIndexChanging="gridEvidencia2_PageIndexChanging"
                         AllowCustomPaging="false"
                          AllowPaging="true"
                     >
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="240px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                     
                              
                                 <asp:LinkButton runat="server" ID="btnAprobar" class="btn btn-primary" BackColor="#5b6060"  Text="Aprobar" CommandName="Aprobar" OnClientClick="javascript:if(!confirm('¿Desea aprobar la evidencia?'))return false">
                                </asp:LinkButton>
                                   <asp:LinkButton runat="server" ID="btnRechazar" class="btn btn-danger"   Text="Rechazar" CommandName="Rechazar" OnClientClick="javascript:if(!confirm('¿Desea rechazar la evidencia?'))return false" >
                                </asp:LinkButton>
                               <asp:LinkButton runat="server" ID="btnEliminar" Visible="false" class="btn btn-danger"   Text="Eliminar" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea eliminar la evidencia?'))return false" >
                                </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>

                       <asp:TemplateField HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" HeaderText="Evidencia">
                           <ItemTemplate>
                               <asp:HyperLink runat="server" CssClass="ion-android-document" ID="link1"></asp:HyperLink>
                           </ItemTemplate>
                       </asp:TemplateField>
                             
                     
                        
                      
                                                <asp:BoundField HeaderText="Creado por" DataField="Acceso" />
                     
                     <asp:BoundField HeaderText="Estado" DataField="Estado" />
                          <asp:BoundField HeaderText="Fecha de creación " DataField="Fecha"/>

                        <asp:TemplateField HeaderText="Observación">
                            <ItemTemplate>
                                <div style="width:400px; overflow: auto;">
                        <%# Eval("observaciones")%>
                    </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                                           <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmail" Text='<%# Eval("Email")%>'></asp:Label>
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


            </div>                 

                 </div>
                                                                               </ContentTemplate></asp:UpdatePanel>
               
             </div>
                        </div>
                    </div>
                  
              
        </ContentTemplate>
               <Triggers>
       <asp:PostBackTrigger ControlID="btnGuardar"  />
   </Triggers>
    </asp:UpdatePanel>
   <div class="col-lg-12">
       <div class="row">
                         <div class="embed-responsive embed-responsive-1by1">
            
                <iframe class="embed-responsive-item" runat="server" id="iframe2" visible="false" frameBorder="0" style="border:0"></iframe>
                    </div>
       </div>
   </div>
  <%--     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
            <div class="col" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">--%>
<%--            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;"></></span>--%>
    <%--            <div class=" spinner-border" style="padding:50px;position:fixed;top:60%;left:60%"></div>
        </div>   
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
      <script type="text/javascript">

                            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); sender.disabled = true; }

               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

  var div = $("#<%=DivInsertar.ClientID%>");
                        div.hide();
                        $("#<%=lnk_Agregar.ClientID%>").click(function () {

                            //div.slideToggle(500);
                            div.slideDown();

                        });
                        $("#<%=btnCerrar.ClientID%>").click(function () {
                            div.slideUp();
                                 }); 
          });
           
            function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                document.getElementById("<%= btnGuardar.ClientID %>").value="Cargando..."


  }
  window.onbeforeunload = DisableButton;
                


                function limpiar() {
                  document.getElementById("<%= txtDesc.ClientID %>").value = "";
                

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

    
          
</script>  
</asp:Content>
