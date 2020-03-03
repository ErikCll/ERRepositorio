<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Empleado.aspx.vb" Inherits="ER.Empleado" %>

<!DOCTYPE html>

<html >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">

    <title>Empleado</title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />

    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
                <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

        <div>
            <section class="content-header">
                <h1>Empleado</h1>
            </section>
            <section class="content">
           <%--    <asp:UpdatePanel UpdateMode="Conditional" runat="server">

                   <ContentTemplate>--%>
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
                     >
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                                <div class="btn-group">
                <asp:LinkButton runat="server" id="btnAgrear" class="btn btn-sm text-blue" CommandName="Agregar" ><span class=" ion-plus" ></span>Usuario</asp:LinkButton>
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
        
    </div>
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
                        div.hide();
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
