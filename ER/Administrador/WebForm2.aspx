<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="WebForm2.aspx.vb" Inherits="ER.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>


ul,
li {
  margin: 0;
  padding: 0;
  list-style-type: none;
}

h1 {
  margin: 0;
  padding: 10px 0;
  font-size: 24px;
  text-align: center;
  background: #eff4f7;
  border-bottom: 1px solid #dde0e7;
  box-shadow: 0 -1px 0 #fff inset;
  border-radius: 5px 5px 0 0;
  /* otherwise we get some uncut corners with container div */
  text-shadow: 1px 1px 0 #fff;
}


label {
  color: #555;
}



#pswd_info {
  position: absolute;
 
  /* IE Specific */
  right: 55px;
  width: 250px;
  padding: 15px;
  background: #fefefe;
  font-size: .875em;
  border-radius: 5px;
  box-shadow: 0 1px 3px #ccc;
  border: 1px solid #ddd;
}
#pswd_info h4 {
  margin: 0 0 10px 0;
  padding: 0;
  font-weight: normal;
}
#pswd_info::before {
  content: "\25B2";
  position: absolute;
  top: -12px;
  font-size: 14px;
  line-height: 14px;
  color: #ddd;
  text-shadow: none;
  display: block;
}
.invalid {
  line-height: 24px;
  color: #ec3f41;
}
.valid {
  line-height: 24px;
  color: #3a7d34;
}
#pswd_info {
  display: none;
}
    </style>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
        <div class="col-lg-12">
            <div class="row">
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="form-group">

                              <input id="pswd" type="password" runat="server" />

                       <div id="pswd_info" >
    <h4>La contraseña debería cumplir con los siguientes requerimientos:</h4>
    <ul>
      <li id="letter" class="invalid">Al menos <strong>una letra</strong>
      </li>
      <li id="capital" class="invalid">Al menos <strong>una letra mayúscula</strong>
      </li>
      <li id="number" class="invalid">Al menos <strong>un número</strong>
      </li>
      <li id="length" class="invalid">Mínimo <strong>8 carácteres</strong>
      </li>
    </ul>
  </div>
                    </div>
                            
                </div>
            </div>
        </div>
  

      

         
                                                             </ContentTemplate></asp:UpdatePanel>

    <br />
<asp:Panel runat="server" ID="panelPDF">
     <asp:GridView ID="gridEmpleado"
                    runat="server"
                    AutoGenerateColumns="false"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registro de empleados"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_empleado" 
                
                     >
                    <Columns>
                
                   
                          
                      
                                                <asp:BoundField HeaderText="Usuario" DataField="Acceso" />

                        <asp:BoundField  DataField="Nombre"/>
                      <asp:BoundField DataField="ApellidoPaterno" />
                       <asp:BoundField DataField="ApellidoMaterno" />
                        <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                          <asp:BoundField HeaderText="Fecha de creación " DataField="CreacionFecha" />
                     <asp:BoundField DataField="Rol" />
                    </Columns>
               <PagerStyle HorizontalAlign = "Center" CssClass="" />
                </asp:GridView>
</asp:Panel>
    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnGenrar" Text="Generar" />

         <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
              var longitud = false,
    minuscula = false,
    numero = false,
    mayuscula = false;
  $('input[type=password]').keyup(function() {
    var pswd = $(this).val();
    if (pswd.length < 8) {
      $('#length').removeClass('valid').addClass('invalid');
      longitud = false;
    } else {
      $('#length').removeClass('invalid').addClass('valid');
      longitud = true;
    }

    //validate letter
    if (pswd.match(/[A-z]/)) {
      $('#letter').removeClass('invalid').addClass('valid');
      minuscula = true;
    } else {
      $('#letter').removeClass('valid').addClass('invalid');
      minuscula = false;
    }

    //validate capital letter
    if (pswd.match(/[A-Z]/)) {
      $('#capital').removeClass('invalid').addClass('valid');
      mayuscula = true;
    } else {
      $('#capital').removeClass('valid').addClass('invalid');
      mayuscula = false;
    }

    //validate number
    if (pswd.match(/\d/)) {
      $('#number').removeClass('invalid').addClass('valid');
      numero = true;
    } else {
      $('#number').removeClass('valid').addClass('invalid');
      numero = false;
    }
  }).focus(function() {
    $('#pswd_info').show();
  }).blur(function() {
    $('#pswd_info').hide();
                });

     
   
                
        });







       
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                ((keyEntry >= 97) && (keyEntry <= 122)) ||
                (keyEntry == 46) || (keyEntry == 46) || keyEntry == 45 || (keyEntry == 46) || keyEntry == 45
                || (keyEntry == 241) || keyEntry == 209
                || (keyEntry == 225) || keyEntry == 233
                || (keyEntry == 237) || keyEntry == 243
                || (keyEntry == 243) || keyEntry == 250
                || (keyEntry == 193) || keyEntry == 201
                || (keyEntry == 205) || keyEntry == 211
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }


 //           function Mostrar() {
 //                var Div = document.getElementById('DivInsertar')

 //               if (Div.style.display=='none') {
 //Div.style.display = 'inline'
 //               }
 //               else
 //                    Div.style.display = 'none'


//}

    </script>

</asp:Content>
