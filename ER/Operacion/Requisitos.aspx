<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Operacion/Site2.Master" CodeBehind="Requisitos.aspx.vb" Inherits="ER.Requisitos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <label class="font-weight-bold">Regulador: </label> <asp:Label runat="server" ID="lblRegulador"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate
        >
           <div class="col-lg-12">
        <div class="row">
        <div class="col-sm-12 col-md-8">
        </div>
        <div class="col-sm-12 col-md-4">
            <div class="input-group  pull-right">
                <div class="input-group">
                    <input type="text" id="txtFiltro" class="form-control" placeholder="Búsqueda rápida" maxlength="20" style="width: 300px" onkeyup="filtro(this)"/>


                    <%--                    <asp:TextBox onKeyUp="filtro()" runat="server" class="form-control" ID="Filtro"></asp:TextBox>--%>
                    <%-- <telerik:RadTextBox runat="server" id="txtFiltro" ValidateRequestMode="Enabled" class="form-control" DisplayText="Busqueda">
                   <ClientEvents OnKeyPress="AlphabetOnly" />
                    </telerik:RadTextBox>--%>
                    <a id="linkFastSearch" name="linkFastSearch" class="btn btn-default disabled"><span class=" ion-android-search"></span></a>
                </div>
            </div>
        </div>
    </div>
       <br />
       <div class="row">
           <div class="container col-12">
               <div class="table-responsive">
                   <div style="overflow:auto;width:auto">
                       <asp:GridView runat="server"
                           ID="gridTablero" 
                            AutoGenerateColumns="false"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de requisitos."
                    DataKeyNames="id_requisito" 
                          
                           >
                           <Columns>
<%--                               <asp:BoundField  DataField="Nivel1" ItemStyle-Width="320px"/>--%>
                             <asp:BoundField HeaderText="Documento Regulador" DataField="Documento" />

                               <asp:TemplateField HeaderText="Requisito" ItemStyle-HorizontalAlign="Left">
                                   <ItemTemplate>
                              <asp:HyperLink runat="server" ID="Requisitohy" class=" btn-link" Text='<%#Eval("Nombre") %>' ></asp:HyperLink>

                                   </ItemTemplate>
                               </asp:TemplateField>


                               <asp:TemplateField HeaderText="Evidencia" ItemStyle-Width="30px" >
                                   <ItemTemplate>
                                        <asp:Label runat="server" ID="lblIdEvidencia"  Text='<%#Eval("id_Evidencia") %>' Visible="false"></asp:Label>
                                       <asp:HyperLink runat="server" CssClass="ion-android-document" ID="hyRequisito" Visible="false" ></asp:HyperLink>
                                   </ItemTemplate>
                               </asp:TemplateField>

<%--                               <asp:BoundField  DataField="FechaCreacion" HeaderText="Fecha de creación" ItemStyle-Width="100px"/>--%>

                               <asp:TemplateField HeaderText="Fecha de la evidencia" ItemStyle-Width="100px">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lblFechaRequisito" Text='<%#Eval("FechaRequisito") %>' ></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                               
                                <asp:TemplateField HeaderText="Fecha vigencia operativa" ItemStyle-Width="100px">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lblFechaOpe" ></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Fecha vigencia regulatoria" ItemStyle-Width="100px">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lblFechareg" ></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                                   <asp:TemplateField Visible="false">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lblVigenciaReg" Text='<%#Eval("VigenciaReg") %>' ></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                                 <asp:TemplateField Visible="false">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lblVigenciaOpe" Text='<%#Eval("VigenciaOpe") %>' ></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                                   <asp:TemplateField Visible="true" HeaderText="Frecuencia por meses" ItemStyle-Width="50px">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lbll" Text='<%#Eval("VigenciaReg") %>' ></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                                     <asp:TemplateField Visible="false">
                                   <ItemTemplate>
                                       <asp:Label runat="server" ID="lblTieneVigencia" Text='<%#Eval("TieneVigencia") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               

                                     <asp:TemplateField HeaderText="Estatus de la vigencia" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>
                                          

                                        <i class=" ion-record text-green" runat="server" id="Vigente" visible="false"></i>
                                           <i class=" ion-record text-yellow" runat="server" id="Apunto" visible="false"></i>
                                           <i class=" ion-record text-red" runat="server" id="Vencido" visible="false"></i>

                                   </ItemTemplate>
                               </asp:TemplateField>

                               <asp:TemplateField HeaderText="Estado de la evidencia" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>
                                       <asp:Label runat="server" Text='<%# Eval("Estado") %>' ID="lblEstado">
                                          

                                       </asp:Label>
                                        <i class=" ion-record text-green" runat="server" id="IconAprobada" visible="false"></i>
                                           <i class=" ion-record text-yellow" runat="server" id="IconEnAprobacion" visible="false"></i>
                                           <i class=" ion-record text-gray" runat="server" id="IconNoAplica" visible="false"></i>
                                           <i class=" ion-record text-red" runat="server" id="IconRojo" visible="false"></i>
                                           <i class=" ion-record text-gray" runat="server" id="IconNoAplica2" visible="false"></i>

                                   </ItemTemplate>
                               </asp:TemplateField>
                           </Columns>
                       </asp:GridView>
                   </div>
               </div>
           </div>
       </div>

   </div>

    </ContentTemplate>
</asp:UpdatePanel>
 
    <script  type="text/javascript">
  function filtro() {
            var txtKeyword = document.getElementById("txtFiltro");
            var tblGrid = document.getElementById('<%= gridTablero.ClientID %>');
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

</script>
</asp:Content>