<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RecuperarContrasena.aspx.vb" Inherits="ER.RecuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <meta http-equiv="X-UA-Compatible" content="IE=edge"/>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>Recuperar contraseña</title>
    <link href="Bootstrap/css/ionicons.min.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />
    <link href="Bootstrap/css/AdminLTE.min.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
           <asp:Literal ID="litControl" runat="server"></asp:Literal>

                <section class=" content-header">
                    <h1>Recuperar contraseña</h1>
                </section>
       

        <section class="content">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-5 col-md-5 col-lg-5">
                                            <h5 class="font-weight-bold">¿Olvidaste tu contraseña?</h5>
                     
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5 col-md-5 col-lg-5">
                      <p class="text-justify">Ingresa la cuenta de correo con la que fuiste registrado, se enviará a tu correo su contraseña. Si no recuerda su cuenta de correo, contacte al administrador.</p>
                        <input runat="server" type="email" placeholder="Correo electrónico" class="form-control" style="width:350px" id="txtCorreo" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12 col-md-4 col-lg-4">
<%--                                                <asp:Button runat="server" ID="btnRegresar" Text="Regresar" CssClass="btn btn-default"  />--%>
                                                                                     <a class="btn btn-default" href="#" onclick="history.back();">Regresar</a>  

                        <asp:Button runat="server" id="btnEnviar" Text="Enviar" CssClass="btn btn-primary ml-1" ValidationGroup="btnEnviar"/>


                    </div>
              
                </div>
                      <div class="row">
                        <div class="col-sm-12 col-md-4 col-lg-4">
                          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" ValidationGroup="btnEnviar" ErrorMessage="Ingresar correo." ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            </div>
        </section>
              

            </ContentTemplate>
        </asp:UpdatePanel>

                
        
       

    </form>

    <script src="Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="Bootstrap/js/popper.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
                     Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

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

    </script>
</body>
</html>
