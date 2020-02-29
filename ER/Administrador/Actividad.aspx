<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Actividad.aspx.vb" Inherits="ER.Actividad" %>

<!DOCTYPE html>
<%--prueba carlos--%>
<html >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">

    <title>Actividad</title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />

    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
                <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

        <div>
            <section class="content-header">
                <h1>Actividad</h1>
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
                        <div class="col-sm-12 col-md-5">
                            <div class="form-group">
                                <label class="font-weight-bold">Nombre:</label>
                                <asp:TextBox runat="server" ID="txt_NombreAct" class="form-control" MaxLength="50" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqAct" ControlToValidate="txt_NombreAct"
                                    ErrorMessage="Nombre de actividad requerido." ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Área:</label>
                                <asp:DropDownList runat="server" ID="ddl_Area" class="form-control" DataTextField="Nombre" DataValueField="id_area" AutoPostBack="true"></asp:DropDownList>                                
                                <asp:RequiredFieldValidator runat="server" ID="reqArea" ControlToValidate="ddl_Area"
                                     ErrorMessage="Nombre de área requerido." InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3">
                               <div class="form-group">
                                <label class="font-weight-bold">Código:</label>
                                <asp:TextBox runat="server" ID="txt_NombreCodigo" class="form-control" MaxLength="20" onkeypress="return AllowAlphabetNumber(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqCodigo" ControlToValidate="txt_NombreCodigo"
                                    ErrorMessage="Código requerido." ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-4">
                              <label class="font-weight-bold">Tipo:</label>
                            <asp:DropDownList runat="server" ID="ddl_Tipo" class="form-control" DataTextField="Nombre" DataValueField="Nombre" ></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="reqTipo" ControlToValidate="ddl_Tipo"
                                ErrorMessage="Tipo requerido." ValidationGroup="btnGuardar" InitialValue="[Seleccionar]"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-12 col-md-4">
                       <label class="font-weight-bold">Difusión:</label>
                            <asp:DropDownList runat="server" ID="ddl_Difusion" CssClass="form-control" DataTextField="Nombre" DataValueField="Nombre"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="reqq" ControlToValidate="ddl_Difusion"
                                 ErrorMessage="Difusión requerido." ValidationGroup="btnGuardar" InitialValue="[Seleccionar]"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-12 col-md-4"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="vert-offset-bottom-2">
                                <br />
                            </div>
                            <div class="form-group Botones">
                                <asp:Button runat="server" ID="Button1" class="btn btn-primary MarginControles" Text="Guardar" ValidationGroup="btnGuardar" BackColor="#5b6060" BorderColor="#5b6060"/>
                                <a class="btn btn-default MarginControles" role="button" onclick="limpiar()">Limpiar</a>
                            </div>
                        </div>
                    </div>
                       
                
                      
                    

                    </div>


                </div>


            </div>
                    </div>
                       <div class="row barchear">
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
                <asp:GridView ID="gridActividad"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registros"
                 PageSize="10"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_actividades" 
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
                         <asp:BoundField HeaderText="Área" DataField="Area"/>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Codigo") %>' ></asp:Label>
                                <asp:TextBox runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="100px"
                                    Text='<%#Eval("Codigo")%>' Visible="false" onkeypress="return AllowAlphabetNumber(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actividades">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Actividad")%>'></asp:Label>
                                <asp:TextBox runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="320px"
                                    Text='<%#Eval("Actividad")%>' Visible="false" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                     
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
