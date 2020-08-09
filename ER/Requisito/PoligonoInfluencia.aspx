<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PoligonoInfluencia.aspx.vb" Inherits="ER.PoligonoInfluencia" %>

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
<%--      <h1 class="bg-light">--%>
<%--                <asp:Label runat="server" ID="lblTitulo"></asp:Label></h1>--%>
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
                                                       <label class="font-weight-bold"> <%# Eval("Determinante") %></label>

                                                    </div>                                         
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                                                            <label>Formato:</label>
                                                <br />
                                                 <label class="font-weight-bold"> <%# Eval("Formato") %></label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                                                            <label>Tienda:</label>
                                                <br />
                                                 <label class="font-weight-bold"> <%# Eval("Tienda") %></label>
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
                            <iframe id="frame" runat="server" frameborder="0" class="embed-responsive-item"></iframe>
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
                                                <label class="font-weight-bold"> <%# Eval("Entidad") %></label>
                                            </div>
                                            <div class="col-sm-12">
                                                <label class="">Municipio: </label>
                                                <label class="font-weight-bold"> <%# Eval("Municipio") %></label>
                                               
                                            </div>
                                            <div class="col-sm-12">
                                                <label class="">AGEBs dentro del área de influencia (a): </label>
                                                <label class="font-weight-bold"> <%# Eval("ageb") %></label>
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
                                        <div class="col-row">
                                       <div class="col-sm-12 text-center">
                                                                                            <label class=" font-weight-bold">Simbología</label>
                                           <br />


                                                                                          <img src="../docs/SimbologiaFicha2.PNG" class="img-fluid" />

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

                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="card-body">
                                            <br /><br />
                                            <div class="row">
                                              
                                                <div class="col-sm-12">
                                                    <label class=" font-weight-bold">Información demográfica</label>
                                                    
                                                </div>
                                                <br /><br />
                                                <div class="col-sm-12">
                                                    <label class="">Población total (a): </label>
                                                    <label class="font-weight-bold"> <%# Eval("Poblacion_AI2") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Población económicamente activa (a): </label>
                                                    <label class="font-weight-bold"> <%# Eval("PEA2") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Población económicamente inactiva (a): </label>
                                                    <label class="font-weight-bold"> <%# Eval("poblacion_inactiva2") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Total de viviendas (a):</label>
                                                    <label class="font-weight-bold"> <%# Eval("Total_viviendas2") %></label>
                                                </div>
                                                <br /><br />
                                                <div class="col-sm-12">
                                                    <label class=" font-weight-bold">Unidades económicas</label>
                                                </div>
                                                <br /><br />
                                                <div class="col-sm-12">
                                                    <label class="">Escuelas (c):</label>
                                                    <label class="font-weight-bold"> <%# Eval("Escuelas") %></label>
                                           
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Hospitales (c):</label>
                                                    <label class="font-weight-bold"> <%# Eval("Hospitales") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Taller mecánico (c): </label>
                                                    <label class="font-weight-bold"> <%# Eval("Talleres_Mecanicos") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Venta de autos y motocicletas (c):</label>
                                                    <label class="font-weight-bold"> <%# Eval("Venta_autos_motos") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Manejo de residuos (c): </label>
                                                    <label class="font-weight-bold"> <%# Eval("Residuos_Peligrosos") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Sitios de transporte público (c): </label>
                                                    <label class="font-weight-bold"> <%# Eval("Sitios_transp_pub") %></label>
                                                </div>
                                                <div class="col-sm-12">
                                                    <label class="">Venta de lubricantes (c):</label>
                                                    <label class="font-weight-bold"> <%# Eval("Venta_lubricantes") %></label>
                                                                                                   <img src="../docs/MiniER.PNG" class="img-fluid float-right" />

                                                </div>
                                             
                                            </div>

                                        </div>
                                    </div>

                            </ItemTemplate>

                        </asp:ListView>

                        </div>
                        <div class="form-group">
                            <asp:ListView runat="server" ID="list4" >
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
                                                <label class="font-weight-bold">1:37,140</label>
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

</script>
</body>
</html>
