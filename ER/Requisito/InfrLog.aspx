<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InfrLog.aspx.vb" Inherits="ER.InfrLog" %>

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
                                            <div class="col-sm-12 col-md-6 col-lg-6">
                                                <label class=" font-weight-bold">Entidad (a): </label>
                                               <br />
                                               <label ><%# Eval("Ent_Fed") %></label>

                                            </div>
                                            <div class="col-sm-12 col-md-6 col-lg-6">
                                                <label class="font-weight-bold">Tienda (f): </label>
                                                <br />
                                                <label><%# Eval("Nombre") %></label>
                                            </div>
                                        <div class="col-sm-12 col-md-6 col-lg-6">
                                                <label class=" font-weight-bold">Municipio (a): </label>
                                            <br />
                                               <label ><%# Eval("Municipio") %></label>

                                            </div>
                                               <div class="col-sm-12 col-md-6 col-lg-6">
                                                <label class=" font-weight-bold">Clave DET (f): </label>
                                                   <br />
                                               <label ><%# Eval("Determinante") %></label>

                                            </div>
                                               <div class="col-sm-12 col-md-6 col-lg-6">
                                                <label class=" font-weight-bold">Formato (f): </label>
                                                   <br />
                                               <label ><%# Eval("Formato") %></label>

                                            </div>
                                               <div class="col-sm-12 col-md-6 col-lg-6">
                                                <label class=" font-weight-bold">Combo (f): </label>
                                                   <br />
                                               <label ><%# Eval("Formato") %></label>

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
                                           <img  src="../docs/SimbologiaFicha4.PNG" class="img-fluid"/>
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
En este sentido el análisis socioeconómico no puede ser considerado garantía de mercado.</label>
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
                                                        <h4><label class="font-weight-bold"></label></h4>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="card-body">
                                            <div class="row">
                                       
                                                <div class="col-sm-12 mt-5">
                                                    <label class=" font-weight-bold">Terminal de almacenamiento (opción 1) (h): </label>
                                                    <br />
                                                     <label class=""><%# Eval("Opcion_1") %></label>
                                                </div>
                                               
                                              
                                                <div class="col-sm-12 mt-3">
                                                    <label class="font-weight-bold">Recorrido lineal (km)(g):</label>
                                                    <label class=""><%# Eval("Distancia_Lineal_1") %></label>
                                                </div>
                                                <div class="col-sm-12 mt-3">
                                                    <label class=" font-weight-bold">Recorrido en vialidades (km)(g):</label>
                                                    <label class=""><%# Eval("Distancia_vial_1") %></label>
                                                </div>
                                                <div class="col-sm-12 mt-3">
                                                    <label class=" font-weight-bold">Terminal de almacenamiento (opción 2) (h):</label>
                                                    <br />
                                                    <label class=""><%# Eval("Opcion_2") %></label>
                                                </div>
                                            
                                                
                                                <div class="col-sm-12 mt-3">
                                                    <label class="font-weight-bold">Recorrido lineal (km)(g):</label>
                                                    <label class=""><%# Eval("Distancia_Lineal_2") %></label>
                                                </div>
                                                <div class="col-sm-12 mt-3">
                                                    <label class=" font-weight-bold">Recorrido en vialidades (km)(g):</label>
                                                    <label class=""><%# Eval("Distancia_vial_2") %></label>
                                                </div>
                                                <div class="col-sm-12 mt-3">
                                                    <label class="">Opción 1 se refiere a la terminal de almacenamiento más cercana, y la opción 2 se refiere a la segunda más cercana.</label>
                                                  <img src="../docs/MiniER.PNG" class="img-fluid float-right" />

                                                </div>
                                             
                                             
                                           
                                             
                                            </div>

                                        </div>
                                    </div>

                            </ItemTemplate>

                        </asp:ListView>

                        </div>
                        <div class="form-group">
                            <asp:ListView runat="server" ID="list4" Visible="false">
                                <ItemTemplate>
                                     <div class="card border-dark">
                                <div class="card-body">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="card col-sm-12 border-dark mt-1">
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
                                          <%--  <div class="col-sm-1"></div>
                                            <div class=" card col-sm-3 border-dark text-center mt-1">
                                                <label>Escala numérica:</label>
                                                <label class=" font-weight-bold">1:61,810</label>
                                            </div>--%>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="card col-sm-12 border-dark">
                                                <label>Fuentes de información:</label>
                                                <label class=" text small ">
(a) Inventario Nacional de Viviendas (INVI), 2016, INEGI
                                               
                                                </label>
                                                <label class=" text small">
(f) Información Wal Mart
                                               
                                                </label>

                                                <label class=" text small">
(g) Estimaciones propias

                                                </label>
                                                <label class=" text small">
(h) Subsecretaría de Hidrocarburos, Secretaría de Energía (SENER), 2018.

                                                </label>
                                                <label class=" text small">
(i) Service Layer Credits: Source: Esri, Digital Globe, GeoEye,

                                                </label>
                                                <label class=" text small">
Earthstar Geographics, CNES/Airbus DS, USDA, USGS, AeroGRID,
ING, and the GIS User Community.
                                                </label>
                                            
                                            </div>
                                         <%--   <div class="col-sm-1 "></div>
                                            <div class=" card col-sm-3 border-dark text-center mt-1" style="margin-bottom:150px">
                                                <label>Ficha técnica:</label>
                                                <label class=" font-weight-bold"><%# Eval("Formato") %></label>
                                            </div>--%>
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
