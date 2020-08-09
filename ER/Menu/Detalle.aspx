<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu/Menu.Master" CodeBehind="Detalle.aspx.vb" Inherits="ER.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--         <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>--%>
  
          <asp:UpdatePanel UpdateMode="Conditional" runat="server">

                    <ContentTemplate>
                        <asp:Literal ID="litControl" runat="server"></asp:Literal>
                               <div class="col-lg-12">
                            <div class="row">
                                <div class="box box-info" style="border-top-color: #5b6060">
                                    <div class="box-body" id="DivInsertar">
                                        <div class="row">
                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                        <h5>Datos del empleado</h5>

                                                                                            <asp:Label runat="server" ID="lblIdEmpleado" Visible="false"></asp:Label>

                                            </div>
                                            <div class="col-sm-8 col-md-4 col-lg-4">
                                                <div class="form-group">

                                                    <div class="label">Nombre(s):</div>
                                                    <asp:Label runat="server" ID="lblNombre" class="font-weight-bold"></asp:Label>

                                                </div>




                                                <div class="form-group">


                                                    <div class="label">Apellido Paterno:</div>
                                                    <asp:Label runat="server" ID="lblPaterno" class="font-weight-bold"></asp:Label>
                                                </div>
                                                <div class="form-group">

                                                    <div class="label">Apellido Materno:</div>
                                                    <asp:Label runat="server" ID="lblMaterno" class="font-weight-bold"></asp:Label>

                                                </div>
                                            </div>
                                            <div class="col-sm-8 col-md-4 col-lg-4">
                                                <div class="form-group">


                                                    <div class="label">Usuario:</div>
                                                    <asp:Label runat="server" ID="lblInstalacion" class="font-weight-bold"></asp:Label>
                                                </div>
                                                 <div class="form-group">


                                                    <div class="label">Email:</div>
                                                    <asp:Label runat="server" ID="lblEmail" class="font-weight-bold"></asp:Label>
                                                </div>
                                                <div class="form-group">


                                                    <div class="label">Fecha de creación:</div>
                                                    <asp:Label runat="server" ID="lblFecha" class="font-weight-bold"></asp:Label>

                                                </div>

                                            </div>
                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="border-top my-3 "></div>


                                            </div>
                                         <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="input-group">
                                                    <h5>Agregar instalaciones</h5>
                                                    <div class="btn-group" role="group">
                                                        <a id="AddUsuario" class="btn btn-sm text-blue"><span class="ion-android-add-circle"></span></a>
                                                          <a id="RemoveUsuario" class="btn btn-sm text-blue"><span class=" ion-android-remove-circle"></span></a>
                                                    </div>
                                                   
                                                </div>
                                            </div>
                                            <div class=" col-12">
                                                <br />
                                                <div class="row" id="Panel2">
                                       
                                            <div class="col-sm-12 col-md-4 col-lg-4">
                                                    <div class="input-group">
                    <input type="text" id="txtFiltro" class="form-control" placeholder="Búsqueda rápida" maxlength="20" style="width: 300px" onkeyup="filtro(this)"/>


                    <%--                    <asp:TextBox onKeyUp="filtro()" runat="server" class="form-control" ID="Filtro"></asp:TextBox>--%>
                    <%-- <telerik:RadTextBox runat="server" id="txtFiltro" ValidateRequestMode="Enabled" class="form-control" DisplayText="Busqueda">
                   <ClientEvents OnKeyPress="AlphabetOnly" />
                    </telerik:RadTextBox>--%>
                    <a id="linkFastSearch" name="linkFastSearch" class="btn btn-default disabled"><span class=" ion-android-search"></span></a>
                </div>
                                                <br />
                                           <asp:Button  class="btn btn-primary" ID="btnActualizarIns" runat="server" Text="Actualizar" BackColor="#5b6060" BorderColor="#5b6060" />
                                                <br />
                                                <br />
                                                
                                                    <div class="table-responsive">
                                                                            <div style="overflow: auto; height: 400px">
                                                                            <asp:GridView ID="gridInstalacion" runat="server"
                                                            AutoGenerateColumns="false" 
                                                            CssClass=" table table-striped table-sm text-md-center"
                                                            HeaderStyle-CssClass="text-sm-center"
                                                            EmptyDataText="Sin registro de instalaciones"
                                                            DataKeyNames="Id_Instalacion"
                                                                                 OnRowDataBound="gridInstalacion_RowDataBound">
                                                                     
                                                            <Columns>
                                                                
                                                                <asp:TemplateField HeaderStyle-Width="15px" HeaderText="Agregar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="header-center">
                                                                    <HeaderTemplate>
                                                                       <asp:CheckBox runat="server" ID="checkall" CssClass="chkHeader"/>

                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="chckAct" Checked='<%#Eval("Id_registro") %>' />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Instalación" DataField="Instalacion" HeaderStyle-CssClass="header-center" />
                                                                  <asp:BoundField HeaderText="Localización" DataField="Localizacion" HeaderStyle-CssClass="header-center" />

                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwebForm" runat="server" Text='<%#Eval("Id_Instalacion") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id_registro")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>



                                                        </asp:GridView>

</div>

                                                        </div>

                                                </div>
                                     
                                                        <div class="col-sm-12 col-md-8 col-lg-8"></div>
                                                <div class="col-sm-12 col-md-12 col-lg-12">
                                                    <div class="form-group">


                                                    </div>

                                                </div>
                                         
                                         
                                            </div>

                                           

                                        </div>
                                            
                                        <%--    <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="border-top my-3 "></div>


                                            </div>--%>
                                         <%--   <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="input-group">
                                                    <h5>Accesos al sistema</h5>
                                                    <div class="btn-group">
                                                        <a id="AddAccesos" class="btn btn-sm text-blue"><span class=" ion-android-add-circle"></span></a>
                                                    </div>
                                                    <div class="btn-group">
                                                        <a id="RemoveAccesos" class="btn btn-sm text-blue"><span class=" ion-android-remove-circle"></span></a>
                                                    </div>


                                                </div>
                                            </div>--%>
                                           
                                          <%--  <div class="col-12" >
                                                <br />
                                                <div class="row" id="PanelAccesos">
                                                       <div class="col-sm-12 col-md-4 col-lg-4">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gridAcceso" runat="server"
                                                            AutoGenerateColumns="false" AllowPaging="true"
                                                            CssClass=" table table-striped table-sm text-md-center"
                                                            HeaderStyle-CssClass="text-sm-center"
                                                            EmptyDataText="Sin registro de usuario"
                                                            DataKeyNames="Id_registro"
                                                            PageSize="10">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-Width="15px" HeaderText="Agregar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="header-center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="chckAct" Checked='<%#Eval("Id_registro") %>' />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" HeaderStyle-CssClass="header-center" />
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblwebForm" runat="server" Text='<%#Eval("Id_webform") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id_registro")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>



                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="col-sm-12 col-md-8 col-lg-8"></div>
                                                <div class="col-sm-12 col-md-12 col-lg-12">
                                                    <div class="form-group">
                                                                                                            <asp:Button  class="btn btn-primary" ID="btnSave" runat="server" Text="Actualizar" BackColor="#5b6060" BorderColor="#5b6060" />


                                                    </div>

                                                </div>
                                                </div>
                                             
                                            </div>--%>
                                    </div>


                                </div>
                            </div>
                          
                               <div class="col">
                                                              <asp:Button runat="server" ID="btnCerrar" class="btn btn-default text-bold float-right my-2" Text="Regresar"></asp:Button>


                            </div>
                        </div>
                       </div>

                     
                    </ContentTemplate>
              <Triggers>
                         <asp:PostBackTrigger ControlID="btnActualizarIns" />

              </Triggers>
                </asp:UpdatePanel>
        <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {

             
     
            var div2 = $('#Panel2');
             var div = $('#PanelAccesos');
            div.hide();
            div2.show();

                  $('#AddUsuario').click(function () {

                     //div.slideToggle(500);
                     div2.slideDown();

                 });
                 $('#RemoveUsuario').click(function () {
                     div2.slideUp();
                          }); 

                 $('#AddAccesos').click(function () {

                     //div.slideToggle(500);
                     div.slideDown();
                    

                 });
                 $('#RemoveAccesos').click(function () {
                     div.slideUp();

                          }); 
    <%--      $('#<%=btnSave.ClientID%>').click(function (e) {

         
                     div2.show();
              div.show();

                 });--%>
                
        });



   
            function DisableButton() {
                document.getElementById("<%= btnActualizarIns.ClientID %>").disabled = true;
                                document.getElementById("<%= btnActualizarIns.ClientID %>").value="Cargando..."


            }
            
          

            window.onbeforeunload = DisableButton;


        
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

            function filtro() {
            var txtKeyword = document.getElementById("txtFiltro");
            var tblGrid = document.getElementById('<%= gridInstalacion.ClientID %>');
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
 //           function Mostrar() {
 //                var Div = document.getElementById('DivInsertar')

 //               if (Div.style.display=='none') {
 //Div.style.display = 'inline'
 //               }
 //               else
 //                    Div.style.display = 'none'


//}
              function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%= gridInstalacion.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            
            if (grid.rows.length > 0)
            {
                //loop starts from 1. rows[0] points to the header.
                for (i=1; i<grid.rows.length; i++)
                {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];
                    
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox")
                        {
                        //assign the status of the Select All checkbox to the cell 
                        //checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
         
    </script>

</asp:Content>

