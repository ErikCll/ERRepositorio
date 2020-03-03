<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Usuario.aspx.vb" Inherits="ER.Usuario" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">

    <title>Usuario</title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />

    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" defaultbutton="">
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

        <div>
            <section class="content-header">
                <h1>Usuario</h1>
            </section>
            <section class="content">
                <%--    <asp:UpdatePanel UpdateMode="Conditional" runat="server">

                   <ContentTemplate>--%>
                <asp:Literal ID="litControl" runat="server"></asp:Literal>

                <div class="col-lg-12">
                    <div class="row">
                        <div class="box box-info" style="border-top-color: #5b6060">
                            <div class="box-body" id="DivInsertar">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12 col-lg-12">
                                        <h5>Datos del empleado</h5>
                                    </div>
                                    <div class="col-sm-8 col-md-4 col-lg-4">
                                        <div class="form-group">

                                            <div class="label">Nombre(s):</div>
                                            <asp:Label runat="server" Text="Erik Alejandro" class="font-weight-bold"></asp:Label>

                                        </div>




                                        <div class="form-group">


                                            <div class="label">Apellido Paterno:</div>
                                            <asp:Label runat="server" Text="Castañeda" class="font-weight-bold"></asp:Label>
                                        </div>
                                        <div class="form-group">

                                            <div class="label">Apellido Materno:</div>
                                            <asp:Label runat="server" Text="Llanas" class="font-weight-bold"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-sm-8 col-md-4 col-lg-4">
                                        <div class="form-group">


                                            <div class="label">Instalación:</div>
                                            <asp:Label runat="server" Text="Instalacion de Prueba" class="font-weight-bold"></asp:Label>
                                        </div>
                                        <div class="form-group">


                                            <div class="label">Fecha de creación:</div>
                                            <asp:Label runat="server" Text="01-03-2020" class="font-weight-bold"></asp:Label>

                                        </div>

                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12">
                                        <div class="border-top my-3 "></div>


                                    </div>
                                    <div class="col-sm-12 col-md-12 col-lg-12">
                                        <h5>Crear usuario</h5>
                                    </div>
                                    <div class="col-sm-12 col-md-4 col-lg-4">
                                        <div class="form-group">
                                            <label class="font-weight-bold">Nombre de usuario:</label>
                                            <asp:TextBox class="form-control " ID="txtUsuario" runat="server" MaxLength="50" onkeypress="return AllowAlphabet(event)">
                   
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
                                            <asp:TextBox class="form-control " ID="txtPassword" runat="server" TextMode="Password" MaxLength="50" onkeypress="return AllowAlphabet(event)">
                   
                                            </asp:TextBox>

                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtPassword"
                                                 ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                        <div class="col-sm-12 col-md-4 col-lg-4">
                                            <div class="form-group">
                                            <label class="font-weight-bold">Confirmar contraseña:</label>
                                            <asp:TextBox class="form-control " ID="txtPasswordConfirm" runat="server" TextMode="Password" MaxLength="50" onkeypress="return AllowAlphabet(event)">
                   
                                            </asp:TextBox>

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
                                            <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                            <a id="btn_ClearButton" class="btn btn-default " role="button" onclick="limpiar()">Limpiar</a>
                                            <a id="btnCerrar" class="btn btn-default " role="button">Cerrar</a>
                                        </div>
                                    </div>

                                </div>

                            </div>


                        </div>
                    </div>
                    <%--     <div class="row">
                        <div class="col-sm-4 col-md-1"></div>
                        <div class="col-sm-4 col-md-7">
                            <div class="btn-group">
                                <a id="lnk_Agregar" class="btn btn-sm text-blue"><span class=" ion-plus"></span>Agregar</a>
                            </div>
                        </div>

                        <div class="col-sm-4 col-md-4">
                            <div class="input-group">
                                <div class="input-group btn">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-default btn-sm" />
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <%--<div class="row">
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
                        
                             
                        <asp:TemplateField HeaderStyle-Width="20px">
                            <ItemTemplate>

                                <asp:LinkButton runat="server" ID="btnEliminar" class="btn btn-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false">
                             <span class=' ion-ios-trash'></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                      

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                <asp:TextBox ID="txtEditNombre" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
                                    Text='<%# Eval("Nombre") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Paterno">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("ApellidoPaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoMaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
                                    Text='<%# Eval("ApellidoPaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Materno">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("ApellidoMaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoMaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
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
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" runat="server" visible="false">
                <div class="vert-offset-bottom-2"></div>
                <div class="form-group Botones">

                    <asp:Button class="btn  btn-primary" ID="btnEditar" runat="server" Text="Editar" BackColor="#5b6060" BorderColor="#5b6060" />
                    <asp:Button class="btn  btn-primary" ID="btnGuardarEdit" runat="server" Text="Actualizar" Visible="false" BackColor="#5b6060" BorderColor="#5b6060" />
                    <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" Text="Cancelar" Visible="false" />
                </div>
            </div>
        
    </div>--%>
                </div>
                <%-- </ContentTemplate>
               </asp:UpdatePanel>--%>
            </section>
        </div>


    </form>
    <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var div = $('#DivInsertar');
            //div.hide();
            $('#lnk_Agregar').click(function () {

                //div.slideToggle(500);
                div.slideDown();

            });
            $('#btnCerrar').click(function () {
                div.slideUp();
            });


        });


            //    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            //function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }


<%--               function limpiar() {
            document.getElementById("<%= txtNombreInstalacion.ClientID %>").value = "";
                   document.getElementById("<%= ddl_Region.ClientID %>").selectedIndex = 0;

            }--%>

 //           function Mostrar() {
 //                var Div = document.getElementById('DivInsertar')

 //               if (Div.style.display=='none') {
 //Div.style.display = 'inline'
 //               }
 //               else
 //                    Div.style.display = 'none'


//}


    </script>

</body>
</html>
