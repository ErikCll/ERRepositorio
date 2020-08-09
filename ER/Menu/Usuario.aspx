<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu/Menu.Master" CodeBehind="Usuario.aspx.vb" Inherits="ER.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>


ul,
li {
  margin: 0;
  padding: 0;
  list-style-type: none;
}

/*h1 {
  margin: 0;
  padding: 10px 0;
  font-size: 24px;
  text-align: center;
  background: #eff4f7;
  border-bottom: 1px solid #dde0e7;
  box-shadow: 0 -1px 0 #fff inset;
  border-radius: 5px 5px 0 0;
  text-shadow: 1px 1px 0 #fff;
}*/


/*label {
  color: #555;
}*/



#pswd_info {
  position: absolute;

  /* IE Specific */

  padding: 10px;
  background: #fefefe;
  font-size: .875em;
  border-radius: 5px;
  box-shadow: 0 1px 3px #ccc;
  border: 1px solid #ddd;
}
#pswd_info h4 {
  margin: 0 0 10px 0;
  padding: 0;
  font-weight: normal;
}
#pswd_info::before {
  content: "\25B2";
  position: absolute;
  top: -12px;
  font-size: 14px;
  line-height: 14px;
  color: #ddd;
  text-shadow: none;
  display: block;
}
.invalid {
  line-height: 24px;
  color: #ec3f41;
}
.valid {
  line-height: 24px;
  color: #3a7d34;
}
#pswd_info {
  display: none;
}
    </style>
<%--             <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>--%>

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
                                                        </div>


                            <div class="col-sm-8 col-md-4 col-lg-4">

  <div class="form-group">
                                                    <label class="font-weight-bold">Nombre de usuario:</label>
                                                    <asp:TextBox class="form-control " ID="txtUsuario" runat="server" MaxLength="20" onkeypress="return AllowAlphabet2(event)">
                   
                                                    </asp:TextBox>

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtUsuario"
                                                        ErrorMessage="Nombre de usuario requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                </div>
                            </div>
                        
                           <div class="col-sm-12 col-md-4 col-lg-4">
                                            
                               <div class="form-group">
                                   <label class="font-weight-bold">Rol:</label>
                                   <asp:DropDownList runat="server" ID="ddl_Rol" CssClass="form-control"></asp:DropDownList>
                                                                   <asp:RequiredFieldValidator runat="server" ID="reqRegion" ControlToValidate="ddl_Rol"
                                    ErrorMessage="Rol requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                               </div>

                                            </div>
                  
                        <div class="col-sm-8 col-md-4 col-lg-4">
     <div class="form-group">
                                <label class="font-weight-bold">Apellido Paterno:</label>
                                <asp:TextBox class="form-control " ID="txtPaterno" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="txtPaterno"
                                    ErrorMessage="Apellido Paterno requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                                  
                       <div class="col-sm-8 col-md-4 col-lg-4">

                              <div class="form-group">
                                <label class="font-weight-bold">Apellido Materno:</label>
                                <asp:TextBox class="form-control " ID="txtMaterno" runat="server" MaxLength="25" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                              
                            </div>
                       </div>
                        <div class="col-sm-8 col-md-4 col-lg-4">
                                          <div class="form-group">
                                                    <label class="font-weight-bold">Email:</label>
                                                    <input class="form-control " ID="txtEmail" runat="server" MaxLength="50" onkeypress="return AllowAlphabet2(event)" type="email" >
                   
                                                    

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator55" ControlToValidate="txtEmail"
                                                        ErrorMessage="Email requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                </div>

                        </div>
                         <div class="col-sm-8 col-md-4 col-lg-4">
                               <div class="form-group">
                                                    <label class="font-weight-bold">Contraseña:</label>
                                                    <asp:TextBox class="form-control " ID="txtPassword" runat="server" TextMode="Password" MaxLength="15" onkeypress="return AllowAlphabet2(event)">
                   
                                                    </asp:TextBox>
                                                         <div id="pswd_info" class="dropdown-menu shadow " style="margin-top:-30px" >
    <h4>La contraseña debería cumplir con los siguientes requerimientos:</h4>
    <ul>
      <li id="letter" class="invalid">Al menos <strong>una letra</strong>
      </li>
      <li id="capital" class="invalid">Al menos <strong>una letra mayúscula</strong>
      </li>
      <li id="number" class="invalid">Al menos <strong>un número</strong>
      </li>
      <li id="length" class="invalid">Mínimo <strong>8 carácteres</strong>
      </li>
    </ul>
  </div>

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtPassword"
                                                        ErrorMessage="Contraseña requerida" ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                </div>
                            
                         </div>
                           
                                                 <div class="col-sm-8 col-md-4 col-lg-4">
                                        


                                                        

                                                     
                                                              <div class="form-group">
                                                    <label class="font-weight-bold">Confirmar contraseña:</label>
                                                    <div class="input-group">
                                                        <asp:TextBox class="form-control " ID="txtPasswordConfirm" runat="server" TextMode="Password" MaxLength="15" onkeypress="return AllowAlphabet2(event)">
                   
                                                        </asp:TextBox>
                                                        <span class="btn input-group-addon" onmousedown="mostrarContrasena()" onmouseup="NomostrarContrasena()" style="cursor: pointer"><i class=" ion-eye"></i></span>

                                                    </div>


                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtPasswordConfirm"
                                                        ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ValidationGroup="btnGuardar" ForeColor="Red" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" ErrorMessage="No coinciden las contraseñas"></asp:CompareValidator>

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
<div class="row ">
    <div class=" container col-12">
        <div class="table-responsive">
            <div style="overflow: auto; height: auto; width:auto">
             <asp:GridView ID="gridEmpleado"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de usuarios"
                 PageSize="10"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_Usuario" 
                  OnPageIndexChanging="gridEmpleado_PageIndexChanging"
                  OnRowCommand="gridEmpleado_RowCommand"
             
                     >
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="350px" ItemStyle-HorizontalAlign="Center">
                         
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
                          
                      
                                                <asp:BoundField HeaderText="Usuario" DataField="Acceso" />

                        <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="123px">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                <asp:TextBox ID="txtEditNombre" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="180px"
                                    Text='<%# Eval("Nombre") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Paterno" ItemStyle-Width="123px">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("ApellidoPaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoPaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="180px"
                                    Text='<%# Eval("ApellidoPaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Materno" ItemStyle-Width="123px" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("ApellidoMaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoMaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="180px"
                                    Text='<%# Eval("ApellidoMaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" ItemStyle-Width="123px">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                <asp:TextBox ID="txtEditEmail" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="180px"
                                    Text='<%# Eval("Email") %>' Visible="false"  onkeypress="return AllowAlphabet2(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:BoundField HeaderText="Fecha de creación " DataField="CreacionFecha" ItemStyle-Width="123px"/>
                     <asp:BoundField DataField="Rol"  HeaderText="Rol" />
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
         var longitud = false,
    minuscula = false,
    numero = false,
    mayuscula = false;
  $("#<%=txtPassword.ClientID%>").keyup(function() {
    var pswd = $(this).val();
    if (pswd.length < 8) {
      $('#length').removeClass('valid').addClass('invalid');
      longitud = false;
    } else {
      $('#length').removeClass('invalid').addClass('valid');
      longitud = true;
    }

    //validate letter
    if (pswd.match(/[A-z]/)) {
      $('#letter').removeClass('invalid').addClass('valid');
      minuscula = true;
    } else {
      $('#letter').removeClass('valid').addClass('invalid');
      minuscula = false;
    }

    //validate capital letter
    if (pswd.match(/[A-Z]/)) {
      $('#capital').removeClass('invalid').addClass('valid');
      mayuscula = true;
    } else {
      $('#capital').removeClass('valid').addClass('invalid');
      mayuscula = false;
    }

    //validate number
    if (pswd.match(/\d/)) {
      $('#number').removeClass('invalid').addClass('valid');
      numero = true;
    } else {
      $('#number').removeClass('valid').addClass('invalid');
      numero = false;
    }
  }).focus(function() {
    $('#pswd_info').show();
  }).blur(function() {
    $('#pswd_info').hide();
                });
            $("#<%=txtPassword.ClientID%>").keyup(function () {
                           if (longitud && minuscula && numero && mayuscula) {
                $("#<%=btnGuardar.ClientID%>").removeAttr('disabled');
     
            } else {
                $("#<%=btnGuardar.ClientID%>").attr('disabled','disabled');
                         }
            })
 

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

              function limpiar() {
                  document.getElementById("<%= txtNombre.ClientID %>").value = "";
                  document.getElementById("<%= txtPaterno.ClientID %>").value = "";
                  document.getElementById("<%= txtMaterno.ClientID %>").value = "";

                                                        document.getElementById("<%= txtUsuario.ClientID %>").value = "";
                                      document.getElementById("<%= txtEmail.ClientID %>").value = "";
                                      document.getElementById("<%= txtPassword.ClientID %>").value = "";
                                      document.getElementById("<%= txtPasswordConfirm.ClientID %>").value = "";



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

                function AllowAlphabet2(e) {
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

