<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Area.aspx.vb" Inherits="ER.Area" %>

<!DOCTYPE html>

<html >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">

    <title>Área</title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />

    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
                <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

        <div>
            <section class="content-header">
                <h1>Área</h1>
            </section>
            <section class="content">
               <asp:UpdatePanel UpdateMode="Conditional" runat="server">

                   <ContentTemplate>
                        <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-lg-12">
                    <div class="row">
                         <div class="box box-info" style="border-top-color: #5b6060">
                <div class="box-body">
                    <div class="row">

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Nombre:</label>
                                <asp:TextBox class="form-control " ID="txtArea" runat="server" MaxLength="50" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtArea"
                                    ErrorMessage="Nombre de área requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Instalación:</label>

                               <asp:DropDownList runat="server" class="form-control" ID="ddl_Instalacion" DataTextField="Nombre" DataValueField="id_instalacion" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddl_Instalacion"
                                    ErrorMessage="Nombre de instalación requerido." InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                            </div>

                            </div>
                            <div class="col-sm-12 col-md-2"></div>
                         <div class="col-sm-12 col-md-3">
                              <div class="form-group ">
                                <label class="font-weight-bold">Código:</label>
                                <asp:TextBox runat="server" ID="txt_NombreCodigo" class="form-control" MaxLength="20" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqCodigo" ControlToValidate="txt_NombreCodigo"
                                     ErrorMessage="Código requerido." ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        </div>
                
                      
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="vert-offset-bottom-2">
                                <br />
                            </div>
                            <div class="form-group Botones">
                                <asp:Button class="btn btn-primary  MargingControles" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060" />
                                <a id="btn_ClearButton" class="btn btn-default MargingControles" role="button" onclick="limpiar()">Limpiar</a>

                            </div>
                        </div>

                    </div>


                </div>


            </div>
                    </div>
                       <div class="row barchearch">
        <div class="col-sm-12 col-md-9">
        </div>

        <div class="col-sm-12 col-md-3">
            <div class="input-group ClaseInputBusquedaRapida pull-right">
                <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="Search" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
<div class="row">
    <div class="container ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
                <asp:GridView ID="gridArea"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registros"
                 PageSize="10"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_area" 
                 >
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="200px">
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
                          <asp:TemplateField HeaderText="Área">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblArea" Text='<%#Eval("Area") %>'></asp:Label>
                                <asp:TextBox runat="server" ID="txtEditArea" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
                                     Text='<%#Eval("Area") %>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <asp:BoundField HeaderText="Instalación" DataField="Instalacion"/>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <asp:Label runat="server" id="lblCodigo" Text='<%#Eval("Codigo") %>'></asp:Label>
                                <asp:TextBox runat="server" ID="txtEditCodigo" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control"
                                    Text='<%#Eval("Codigo") %>' Visible="false" Width="100px" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                    </Columns>
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
                   </ContentTemplate>
               </asp:UpdatePanel>
            </section>
        </div>


        <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
                function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
$(document).ready(function(){
});
        </script>
    </form>
     <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
