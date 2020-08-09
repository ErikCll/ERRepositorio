<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Menu/Menu.Master" CodeBehind="Index.aspx.vb" Inherits="ER.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="col-sm-6 col-md-6 col-lg-6">
           Bienvenido <asp:Label runat="server" ID="lblUsuario" CssClass="font-weight-bold"></asp:Label> 

    </div>
    <div class="col-sm-6 col-md-6 col-lg-6">
        
    <asp:Label runat="server">Rol:</asp:Label> 
    <asp:Label runat="server" ID="lblRol" CssClass="font-weight-bold"></asp:Label>
    </div>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .zoom {
 
  transition: transform .2s; /* Animation */

  margin: 0 auto;
}

.zoom:hover {
  transform: scale(1.1); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
}
    </style>
    <div class="col-lg-12">
        <br />
        <div class="row">
            <div class="col-sm-4 col-md-4 col-lg-4" runat="server" id="Panel1">
                <div   class="form-group">

                             <div class="card shadow zoom" style="border-left-color:#125886;border-left:solid steelblue">
  <asp:LinkButton runat="server" ID="linkEtapa1" OnClick="linkEtapa1_Click"  class="card-body  ">
    <h4 class="card-title text-black">Estudio de factibilidad ES</h4>
    <p class="card-text text-black">Estudios económicos, socioeconómicos, regulatorios, técnicos, sociales, cantidad de gasolineras en la zona, etc.</p>
  </asp:LinkButton>
</div>
                </div>
   
            </div>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="form-group">
                                 <div class="card shadow zoom" style="border-left-color:#125886;border-left:solid steelblue">
  <asp:LinkButton runat="server" ID="linkEtapa2" OnClick="linkEtapa2_Click"  class="card-body ">
    <h4 class="card-title text-black">Construcción ES</h4>
    <p class="card-text text-black">Permiso de construcción, de impacto ambiental, de colonos, protección civil, etc. CRE, ASEA, etc.</p>
      <p></p>
  </asp:LinkButton>
</div>

                    </div>
   
            </div>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="form-group">

                                  <div class="card shadow zoom" style="border-left-color:#125886;border-left:solid steelblue">
  <asp:LinkButton runat="server" ID="linkEtapa3"  OnClick="linkEtapa3_Click" class="card-body ">
    <h4 class="card-title text-black">Operación ES</h4>
    <p class="card-text text-black">Verificaciones de CRE, ASEA, PROFECO, calibraciones, calidad de producto, etc.</p>
      <p></p>
  </asp:LinkButton>
</div>
                    </div>
  
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <h4>Tu lista de instalaciones:</h4>
            </div>
            <div class="col-sm-5 col-md-5 col-lg-5">
                                                    <div class="table-responsive">
                                                                            <div style="overflow: auto; height: 400px">
                                                                            <asp:GridView ID="gridInstalacion" runat="server"
                                                            AutoGenerateColumns="false" 
                                                            CssClass=" table table-striped  no-border border"
                                                                              HeaderStyle-CssClass=""
                                                            EmptyDataText="Sin registro de instalaciones"
                                                            DataKeyNames="Id_Instalacion"
                                                                  >
                                                                     
                                                            <Columns>
                                                                
                                                               

                                                                <asp:BoundField HeaderText="Instalación" DataField="Instalacion" HeaderStyle-CssClass="header-center" />
                                                                  <asp:BoundField HeaderText="Localización" DataField="Localizacion" HeaderStyle-CssClass="header-center" />

                                                              
                                                           
                                                            </Columns>



                                                        </asp:GridView>

</div>

                                                        </div>

            </div>

        </div>
    </div>
</asp:Content>
