<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="Usuario.aspx.vb" Inherits="ER.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

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


                                                    <div class="label">Instalación:</div>
                                                    <asp:Label runat="server" ID="lblInstalacion" class="font-weight-bold"></asp:Label>
                                                </div>
                                                <div class="form-group">


                                                    <div class="label">Fecha de creación:</div>
                                                    <asp:Label runat="server" ID="lblFecha" class="font-weight-bold"></asp:Label>

                                                </div>

                                            </div>
                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="border-top my-3 "></div>


                                            </div>
                                            <div class="col-sm-12 col-md-12 col-lg-12"">
                                                <div class="input-group">
                                                    <h5>Crear usuario</h5>
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
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Nombre de usuario:</label>
                                                    <asp:TextBox class="form-control " ID="txtUsuario" runat="server" MaxLength="15" onkeypress="return AllowAlphabet(event)">
                   
                                                    </asp:TextBox>

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtUsuario"
                                                        ErrorMessage="Nombre de usuario requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                </div>



                                            </div>
                                            <div class="col-sm-12 col-md-4 col-lg-4">
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Email:</label>
                                                    <asp:TextBox class="form-control " ID="txtEmail" runat="server" MaxLength="50" onkeypress="return AllowAlphabet(event)">
                   
                                                    </asp:TextBox>

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtEmail"
                                                        ErrorMessage="Email requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-4 col-lg-4"></div>
                                            <div class="col-sm-12 col-md-4 col-lg-4">
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Contraseña:</label>
                                                    <asp:TextBox class="form-control " ID="txtPassword" runat="server" TextMode="Password" MaxLength="15" onkeypress="return AllowAlphabet(event)">
                   
                                                    </asp:TextBox>

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtPassword"
                                                        ErrorMessage="Contraseña requerida" ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-4 col-lg-4">
                                                <div class="form-group">
                                                    <label class="font-weight-bold">Confirmar contraseña:</label>
                                                    <div class="input-group">
                                                        <asp:TextBox class="form-control " ID="txtPasswordConfirm" runat="server" TextMode="Password" MaxLength="15" onkeypress="return AllowAlphabet(event)">
                   
                                                        </asp:TextBox>
                                                        <span class="btn input-group-addon" onmousedown="mostrarContrasena()" onmouseup="NomostrarContrasena()" style="cursor: pointer"><i class=" ion-eye"></i></span>

                                                    </div>


                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtPasswordConfirm"
                                                        ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ValidationGroup="btnGuardar" ForeColor="Red" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" ErrorMessage="No coinciden las contraseñas"></asp:CompareValidator>

                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-4 col-lg-4"></div>

                                            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                                <div class="vert-offset-bottom-2">
                                                    <br />
                                                </div>
                                                <div class="form-group ">
                                                    <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                                    <a id="btn_ClearButton" class="btn btn-default " role="button" onclick="limpiar()" runat="server">Limpiar</a>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-7 col-lg-7">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gridUsuario" runat="server"
                                                        AutoGenerateColumns="false" AllowPaging="true"
                                                        CssClass=" table table-striped table-sm text-md-center"
                                                        HeaderStyle-CssClass=" thead-dark text-sm-center"
                                                        EmptyDataText="Sin registro"
                                                        DataKeyNames="Id_usuario"
                                                        OnRowCommand="gridUsuario_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>



                                                                    <asp:LinkButton runat="server" ID="btnEditar" class="btn btn-primary" BackColor="#5b6060" Text="Editar" CommandName="Editar">
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton runat="server" ID="btnAct" class="btn btn-primary" BackColor="#5b6060" Text="Actualizar" CommandName="Actualizar" Visible="false">
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-default" Text="Cancelar" CommandName="Cancelar" Visible="false">
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


                                                            <asp:TemplateField HeaderText="Acceso">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAcceso" runat="server" Text='<%# Eval("Acceso") %>'></asp:Label>
                                                                    <asp:TextBox ID="txtEditAcceso" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="150px"
                                                                        Text='<%# Eval("Acceso") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Email">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                                    <asp:TextBox ID="txtEditEmail" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="150px"
                                                                        Text='<%# Eval("Email") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:BoundField HeaderText="Fecha de creación " DataField="CreacionFecha" />

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-2 col-lg-2"></div>

                                                </div>
                                         
                                            </div>

                                           

                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="border-top my-3 "></div>


                                            </div>
                                            <div class="col-sm-12 col-md-12 col-lg-12">
                                                <div class="input-group">
                                                    <h5>Accesos al sistema</h5>
                                                    <div class="btn-group">
                                                        <a id="AddAccesos" class="btn btn-sm text-blue"><span class=" ion-android-add-circle"></span></a>
                                                    </div>
                                                    <div class="btn-group">
                                                        <a id="RemoveAccesos" class="btn btn-sm text-blue"><span class=" ion-android-remove-circle"></span></a>
                                                    </div>


                                                </div>
                                            </div>
                                           
                                            <div class="col-12" >
                                                <br />
                                                <div class="row" id="PanelAccesos">
                                                       <div class="col-sm-12 col-md-4 col-lg-4">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gridAcceso" runat="server"
                                                            AutoGenerateColumns="false" AllowPaging="true"
                                                            CssClass=" table table-striped table-sm text-md-center"
                                                            HeaderStyle-CssClass="text-sm-center"
                                                            EmptyDataText="Sin registro"
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
                                             
                                            </div>
                                        </div>

                                    </div>


                                </div>
                            </div>
                          
                               <div class="col">
                                                              <asp:Button runat="server" ID="btnCerrar" class="btn btn-default text-bold float-right my-2" Text="Regresar"></asp:Button>


                            </div>
                        </div>
                       
                    </ContentTemplate>
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






        function limpiar() {
            document.getElementById("<%= txtUsuario.ClientID %>").value = "";
                  document.getElementById("<%= txtEmail.ClientID %>").value = "";
                  document.getElementById("<%= txtPassword.ClientID %>").value = "";

                  document.getElementById("<%= txtPasswordConfirm.ClientID %>").value = "";


        }
        function mostrarContrasena() {
            var tipo = document.getElementById("<%=txtPasswordConfirm.ClientID%>");
            if (tipo.type == "password") {
                tipo.type = "text";
            }

        }
        function NomostrarContrasena() {
            var tipo = document.getElementById("<%=txtPasswordConfirm.ClientID%>");
            if (tipo.type == "text") {
                tipo.type = "password";
            }

        }
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

