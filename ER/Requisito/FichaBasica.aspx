<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FichaBasica.aspx.vb" Inherits="ER.FichaBasica" %>

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
            <%--                    <h1 class="bg-light"><asp:Label runat="server" ID="lblTitulo"></asp:Label></h1>--%>
        </section>
        <section class="content">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-6">
                        <%--<img class="img-fluid" runat="server" id="img"  alt="Sin registro" typeof=""/>--%>
                        <%--                                 <div class="embed-responsive embed-responsive-1by1">

                        <iframe id="frame" runat="server" frameborder="0" class="embed-responsive-item"></iframe>

                        <%--                                 <div class="embed-responsive embed-responsive-1by1">
            
                <iframe class="embed-responsive-item" runat="server" id="frame" visible="true" frameBorder="0" style="border:none;display:block" ></iframe>

                                                   
                    </div>--%>
                        <div class="form-group">
                            <div class="embed-responsive embed-responsive-1by1">
                                <iframe id="frame" runat="server" frameborder="0" class="embed-responsive-item"></iframe>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="card border-dark">
                                <div class="card-body">
                                    <label class="text small">
                                        La información presentada en este análisis de mercado fue obtenido con información pública, de acuerdo con la metodología anexa.
En este sentido el análisis socioeconómico no puede ser considerado garantía de mercado, por lo que se libera a "Grupo Walmart"
de cualquier responsabilidad presente o a futura al respecto.</label>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-6 mt-2">
                        <div class="form-group">
                            <asp:ListView runat="server" ID="list" OnItemDataBound="list_ItemDataBound">
                                <ItemTemplate>
                                    <%--    <ul class="list-group">
                                                 <li class="list-group-item font-weight-bold bg-light border border-bottom-0 border-dark">INFORMACIÓN GENERAL</li>

                                <li class="list-group-item border border-bottom-0 border-dark"><label class=" font-weight-bold">Clave Determinante:</label> <%# Eval("Determinante") %></li>
                                <li class="list-group-item bg-light border border-bottom-0 border-dark"><label class=" font-weight-bold">Combo Walmex:</label> <%# Eval("Combo_Walmex") %></li>
                                <li class="list-group-item border border-bottom-0 border-dark"><label class=" font-weight-bold">Tipo:</label> <%# Eval("Tipo") %></li>
                                <li class="list-group-item bg-light border border-bottom-0 border-dark"><label class=" font-weight-bold">Locación:</label> <%# Eval("Locacion") %></li>
                                <li class="list-group-item border border-bottom-0 border-dark"><label class=" font-weight-bold">Uso de suelo:</label> <%# Eval("Uso_suelo") %></li>
                                <li class="list-group-item bg-light border border-bottom-0 border-dark"><label class=" font-weight-bold">Det. Combo:</label> <%# Eval("DetCombo") %></li>
                                <li class="list-group-item border border-bottom-0 border-dark"><label class=" font-weight-bold">Total Edicifio (M2):</label> <%# Eval("Total_edificio") %></li>
                                <li class="list-group-item bg-light border border-dark"><label class=" font-weight-bold">#Cajones estimados:</label> <%# Eval("Cajones") %></li>

                                  </ul>
   
                                    --%>

                                    <div class="card border-dark">

                                        <div class="row text-center mt-2 mr-1 ml-1">
                                            <div class="col-sm-12">

                                                <div class="card border-dark">
                                                    <div class="card-body">
                                                          <img src="../docs/MiniLogo.PNG" class="img-fluid float-left" />

                                                        <h4>
                                                            <asp:Label CssClass="font-weight-bold" runat="server" ID="lblTitulo"></asp:Label></h4>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="card-body">

                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <label class="">Entidad (a): </label>
                                                    <label class=" font-weight-bold"><%# Eval("Entidad_federativa") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Municipio (a): </label>
                                                    <label class=" font-weight-bold"><%# Eval("municipio") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="f">Clave determinante (f): </label>
                                                    <label class=" font-weight-bold"><%# Eval("Determinante") %></label>

                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Formato (f): </label>
                                                    <label class=" font-weight-bold"><%# Eval("Formato") %></label>

                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Tipo: </label>
                                                    <label class=" font-weight-bold"><%# Eval("Tipo") %></label>

                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Dirección: </label>
                                                    <label class=" font-weight-bold"><%# Eval("Locacion") %></label>

                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Coordenadas (g):    </label>
                                                    <label class="ml-5">Latitud:    </label>
                                                    <label class=" font-weight-bold"><%# Eval("coordenada_latitud") %></label>

                                                    <label class="ml-4">Longitud: </label>
                                                    <label class=" font-weight-bold"><%# Eval("coordenada_longitud") %></label>


                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Uso de suelo: </label>
                                                      <label class=" font-weight-bold"><%# Eval("Uso_suelo") %></label>

                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Det combo: </label>
                                                <label class=" font-weight-bold"><%# Eval("DetCombo") %></label>

                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Total edificio (m2): </label>
                                                    <label class=" font-weight-bold"><%# Eval("Total_edificio") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">No. cajones de estacionamiento (f): </label>
                                                    <label class=" font-weight-bold"><%# Eval("Cajones") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Horario: </label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Estacionamiento: </label>
                                                    <label class="">Abierto: </label>
                                                    <asp:CheckBox runat="server" Enabled="false" />
                                                    <label class="">Concesionado: </label>
                                                    <asp:CheckBox runat="server" Enabled="false" />
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">No. de accesos al estacionamiento: </label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Promedio mensual de afluencia vehicular (f.g): </label>
                                                    <label class=" font-weight-bold"><%# Eval("flujo_vehiculo_tienda2") %></label>
                                                    <img src="../docs/MiniER.PNG" class="img-fluid float-right" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </ItemTemplate>

                            </asp:ListView>

                        </div>
                        <div class="form-group">
                            <asp:ListView runat="server" ID="list2">
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
                                                <label class="font-weight-bold">1:2,630</label>
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
                                            <div class="col-sm-1"></div>
                                            <div class=" card col-sm-3 border-dark text-center mt-1" style="margin-bottom: 150px">
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

</script>
</body>
</html>
