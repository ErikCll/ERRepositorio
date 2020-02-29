<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Instalacion.aspx.vb" Inherits="ER.Instalacion" %>

<!DOCTYPE html>

<html >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">

    <title>Instalación</title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />

    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
                <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

        <div>
            <section class="content-header">
                <h1>Instalación</h1>
            </section>
            <section class="content">
               <asp:UpdatePanel UpdateMode="Conditional" runat="server">

                   <ContentTemplate>
                        <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-lg-12">
                    <div class="row">
                         <div class="box box-info" style="border-top-color: #5b6060" id="DivInsertar">
                <div class="box-body">
                    <div class="row">

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Nombre:</label>
                                <asp:TextBox class="form-control " ID="txtNombreInstalacion" runat="server" MaxLength="50" onkeypress="return AllowAlphabet(event)">
                   
                                </asp:TextBox>
                             
                                <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="txtNombreInstalacion"
                                    ErrorMessage="Nombre de instalación requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-sm-8 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Region:</label>

                                <asp:DropDownList class="form-control" ID="ddl_Region" runat="server" DataTextField="Nombre" DataValueField="id_region"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="reqRegion" ControlToValidate="ddl_Region"
                                    ErrorMessage="Nombre de región requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-sm-12 col-md-2"></div>
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
                       <div class="row">
        <div class="col-sm-12 col-md-8">
             <div class="btn-group">
                <a id="lnk_Agregar" class="btn btn-sm text-blue" ><span class=" ion-plus" ></span>Agregar</a>
            </div>
        </div>

        <div class="col-sm-12 col-md-4">
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
                <asp:GridView ID="gridInstalacion"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registros"
                 PageSize="10"
                    OnPageIndexChanging="gridInstalacion_PageIndexChanging"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_Instalacion" 
                     OnRowCommand="gridInstalacion_RowCommand">
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
                          
                        <%--                    <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />--%>

                        <asp:TemplateField HeaderText="Instalación">
                            <ItemTemplate>
                                <asp:Label ID="lblInstalacion" runat="server" Text='<%# Eval("Instalacion") %>'></asp:Label>
                                <asp:TextBox ID="txtEditInstalacion" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="300px"
                                    Text='<%# Eval("Instalacion") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Región" DataField="Region" />
                     
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
                   </ContentTemplate>
               </asp:UpdatePanel>
            </section>
        </div>


        <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }


               function limpiar() {
            document.getElementById("<%= txtNombreInstalacion.ClientID %>").value = "";
                   document.getElementById("<%= ddl_Region.ClientID %>").selectedIndex = 0;

            }

 //           function Mostrar() {
 //                var Div = document.getElementById('DivInsertar')

 //               if (Div.style.display=='none') {
 //Div.style.display = 'inline'
 //               }
 //               else
 //                    Div.style.display = 'none'
               
                
//}
            $(document).ready(function () {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
       
      function EndRequestHandler(sender, args) {

                    $('.form-control').datepicker({
                        dateFormat: 'dd-mm-yy',
                        minDate: '+0D',
                        maxDate: '+1Y',
                        changeMonth: true,
                        changeYear: true,
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
                            'Junio', 'Julio', 'Agosto', 'Septiembre',
                            'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr',
                            'May', 'Jun', 'Jul', 'Ago',
                            'Sep', 'Oct', 'Nov', 'Dic']
                    });

      
                       $("#btnIni").on("click", function () {
                        $("#txtFechaIni").datepicker("show");
                    });         
                    $("#txtFechaIni").datepicker({
                        dateFormat: 'dd-mm-yy',
                        minDate: '+0D',
                        maxDate: '+1Y',
                        changeMonth: true,
                        changeYear: true,
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
                            'Junio', 'Julio', 'Agosto', 'Septiembre',
                            'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr',
                            'May', 'Jun', 'Jul', 'Ago',
                            'Sep', 'Oct', 'Nov', 'Dic']
                    });

                    $("#btnFin").on("click", function () {
                        $("#txtFechaFin").datepicker("show");
                    });
                    $("#txtFechaFin").datepicker({
                        dateFormat: 'dd-mm-yy',
                        minDate: '+0D',
                        maxDate: '+1Y',
                        changeMonth: true,
                        changeYear: true,
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
                            'Junio', 'Julio', 'Agosto', 'Septiembre',
                            'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr',
                            'May', 'Jun', 'Jul', 'Ago',
                            'Sep', 'Oct', 'Nov', 'Dic']
                    });


                }
            });
           
          
</script>
    </form>
     <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
