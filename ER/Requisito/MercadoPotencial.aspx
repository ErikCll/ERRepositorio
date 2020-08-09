<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MercadoPotencial.aspx.vb" Inherits="ER.MercadoPotencial" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <section class=" content-header border-top border-dark">


        </section>
               <section class="content">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-6">
                        <div class="form-group">
                            <asp:ListView runat="server" ID="list">
                                <ItemTemplate>
                                       <div class="card border-dark">
                                <div class="card-body">
                                    <div class="col-lg-12">
                                        <div class="row">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                           <label>Clave DET:</label>
                                                        <br />
                                                        <label class=" font-weight-bold"><%# Eval("Determinante") %></label>
                                                    </div>                                         
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                               <label>Formato:</label>
                                                <br />
                                                  <label class=" font-weight-bold"><%# Eval("Formato") %></label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                                                            <label>Tienda:</label>
                                                <br />
                                                  <label class=" font-weight-bold"><%# Eval("Tienda") %></label>
                                            </div>
                                        </div>
                                        </div>
                                    
                                    </div>
                                </div>
                            </div>
                                </ItemTemplate>
                            </asp:ListView>

                         
                        </div>
                        <div class="form-group">
                            <div class="embed-responsive embed-responsive-1by1">
                            <iframe id="frame" runat="server" frameborder="0" class="embed-responsive-item" alt="Sin imagen"></iframe>
                        </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-7 mt-1">
                                                                   <asp:ListView runat="server" ID="list2">
                            <ItemTemplate>
                                <div class="card border-dark">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <label>Entidad: </label>
                                                  <label class=" font-weight-bold"><%# Eval("Ent_Fed") %></label>
                                            </div>
                                            <div class="col-sm-12">
                                                <label class="">Municipio: </label>
                                                <label class=" font-weight-bold"><%# Eval("Municipio") %></label>
                                            </div>
                                            <div class="col-sm-12">
                                                <label class="">AGEBs dentro del área de influencia (a): </label>
                                                <label class=" font-weight-bold"><%# Eval("ageb") %></label>
                                            </div>
                                            <div class="col-sm-12">
                                                <label class="">Número de estaciones de servicio (e): </label>
                                                <label class=" font-weight-bold"><%# Eval("Estaciones") %></label>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>

                        </asp:ListView>

                                </div>
                                <div class="col-sm-5 mt-2">
                                     <div class="card border-dark">
                           
                                    <div class="card-body">
                                        <div class="row">
                                       <div class="col-sm-12 text-center">
                                           <label class="font-weight-bold">Simbología</label>
                                           <br />
                                           <img  src="../docs/SimbologiaFicha3.PNG" class="img-fluid"/>
                                       </div>

                                        </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                        </div>
                     
                        <div class="form-group">
                                   <div class="card border-dark">
                           
                                    <div class="card-body">
                                        <div class="row">
                                       <div class="col-sm-12">
                                           <label class="text small">La información presentada en este análisis de mercado fue obtenido con información pública, de acuerdo con la metodología anexa.
En este sentido el análisis socioeconómico no puede ser considerado garantía de mercado, por lo que se libera a "Grupo Walmart"
de cualquier responsabilidad presente o a futura al respecto.</label>
                                       </div>

                                        </div>
                                    </div>
                                </div>
                        </div>

                    
                         

                    </div>
                    <div class="col-sm-12 col-md-12 col-lg-6 mt-1">
                        <div class="form-group">
                                    <asp:ListView runat="server" ID="list3" OnItemDataBound="list3_ItemDataBound">
                            <ItemTemplate>
                              
                                    <div class="card border-dark">
                                        <div class="row text-center mt-2 mr-1 ml-1">
                                            <div class="col-sm-12">
                                                <div class="card border-dark">
                                                    <div class="card-body">
                                                                                                               <img src="../docs/MiniLogo.PNG" class="img-fluid float-left" />
                                                        <h4>
                                                            <asp:Label CssClass="font-weight-bold" runat="server" ID="lblTitulo"></asp:Label></h4>
                                                        <h4><label class="font-weight-bold">(Estimaciones mensuales)</label></h4>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="card-body">
                                            <div class="row">
                                              
                                                <div class="col-sm-12">
                                                    <label class=" font-weight-bold">Estimación de volumen de venta en litros de gasolinas en área de influencia (g):</label>
                                                     <label class=" font-weight-bold"><%# Eval("vol_ventas_vehiculos2") %></label>
                                                </div>
                                                <br />
                                                <br />
                                              
                                                <div class="col-sm-12 mt-1">
                                                    <label class="font-weight-bold">Estimación de volumen de venta en litros de gasolinas de vehículos locales en área de influencia:</label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Vehículos locales (a):</label>
                                                    <label class=" font-weight-bold"><%# Eval("Veh_viviendas2") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Volumen de consumo (g): </label>
                                                    <label class=" font-weight-bold"><%# Eval("vol_consumo_area2") %></label>
                                                </div>
                                                <br />
                                                <br />
                                                
                                                <div class="col-sm-12">
                                                    <label class="font-weight-bold">Estimación de volumen de venta en litros de gasolinas de vehículos flotantes en área de influencia</label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Vehículos flotantes (c):</label>
                                                      <label class=" font-weight-bold"><%# Eval("num_vehiculos_flotantes2") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Volumen de consumo (g)</label>
                                             <label class=" font-weight-bold"><%# Eval("vol_consumo_flotantes2") %></label>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="col-sm-12">
                                                    <label class="font-weight-bold">Hostimación de volumen de venta en litros de gasolinas de vehículos que transitan en la tienda</label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Promedio mensual de vehículos (f): </label>
                                                    <label class=" font-weight-bold"><%# Eval("flujo_vehiculo_tienda2") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Volumen de consumo (g):</label>
                                                    <label class=" font-weight-bold"><%# Eval("vol_consumo_tienda2") %></label>
                                                                                                        <img src="../docs/MiniER.PNG" class="img-fluid float-right" />

                                                </div>
                                            
                                           
                                             
                                            </div>

                                        </div>
                                    </div>

                            </ItemTemplate>

                        </asp:ListView>

                        </div>
                        <div class="form-group">
                            <asp:ListView runat="server" ID="list4">
                                <ItemTemplate>
                                     <div class="card border-dark">
                                <div class="card-body">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="card col-sm-8 border-dark mt-1">
                                                <label>Metadatos:</label>
                                                <label class=" text small ">
                                          Sistema de coordenadas Geográfica: GCS_WGS_1984
                                                </label>
                                                <label class=" text small">
                                                    Datum: D_WGS_1984
                                                </label>

                                                <label class=" text small">
                                                    Sistema de referencia de coordenadas: WGS 84 EPSG:4326

                                                </label>
                                            </div>
                                            <div class="col-sm-1"></div>
                                            <div class=" card col-sm-3 border-dark text-center mt-1">
                                                <label>Escala numérica:</label>
                                                <label class=" font-weight-bold">1:37,080</label>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="card col-sm-8 border-dark">
                                                <label>Fuentes de información:</label>
                                                <label class=" text small ">
                                                    (a) Inventario Nacional de Viviendas (INVI), 2016, INEGI
                                               
                                                </label>
                                                <label class=" text small">
                                                    (b) Encuesta Nacional de Ingreso Gasto en Hogares (ENIGH), 2018, INEGI
                                               
                                                </label>

                                                <label class=" text small">
                                                    (c) Directorio Estadístico Nacional de Unidades Económicas (DENUE), 2019, INEGI

                                                </label>
                                                <label class=" text small">
                                                    (d) Encuesta Origen Destino en Hogares (EODH), 2017, INEGI

                                                </label>
                                                <label class=" text small">
                                                   (e) Listado de estaciones de servicio con georreferencia, 2019, CRE

                                                </label>
                                                <label class=" text small">
                                                   (f) Información Wal Mart

                                                </label>
                                                <label class=" text small">
                                                    (g) Elaboración propia


                                                </label>
                                            </div>
                                            <div class="col-sm-1 "></div>
                                            <div class=" card col-sm-3 border-dark text-center mt-1" style="margin-bottom:150px">
                                                <label>Ficha técnica:</label>
                                                <label class=" font-weight-bold"><%# Eval("Determinante") %></label>
                                                <label class=" font-weight-bold"><%# Eval("Formato") %></label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                </ItemTemplate>
                            </asp:ListView>
                                                       


                        </div>
                
                    </div>
                       


                   
                  
                </div>




            </div>

        </section>

    </form>
    <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {

    $(("<%= frame.ClientID %>")).not(":has([src])").each(function () {

    var ifrm = this;

    ifrm = (ifrm.contentWindow) ? ifrm.contentWindow : (ifrm.contentDocument.document) ? ifrm.contentDocument.document : ifrm.contentDocument;

    ifrm.document.open();
    ifrm.document.write($(this).attr("alt"));
    ifrm.document.close();

    });

});
</script>
</body>
</html>
