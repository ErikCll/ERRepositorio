<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="ER.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>Login</title>
    <link href="Bootstrap/css/ionicons.min.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />
    <link href="Bootstrap/css/AdminLTE.min.css" rel="stylesheet" />
</head>
<body style="background-color: rgba(0, 0, 0, 0.85);">
    <form runat="server">
           <asp:Literal ID="litControl" runat="server"></asp:Literal>
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>
        
                 <div class="container">

            <div class="row">

                <div class="col-md-12 min-vh-100 d-flex flex-column justify-content-center">
                    <div class="row">

                        <div class="col-lg-6 col-md-8 mx-auto">

                            <!-- form card login -->

                            <div class="card rounded shadow shadow-lg ">
                                <div class="card-header">
                                    <h3 class="mb-0">Iniciar sesión</h3>
                                </div>
                                <asp:Login runat="server" CssClass="col-12" ID="Login1">
                                    <LayoutTemplate>
                                        <div class="card-body">
                                            <div class="form-group">

                                                <label>Usuario</label>
                                                <div class="input-group">
                                                    <asp:TextBox runat="server" ID="UserName" MaxLength="15" class="form-control" onkeypress="return AllowAlphabet(event)"></asp:TextBox>

                                                    <span class="input-group-append bg-white border-left-0">
                                                        <span class="input-group-text bg-transparent">
                                                            <i class=" ion-android-person"></i>
                                                        </span>
                                                    </span>
                                                </div>
                                                                    <asp:RequiredFieldValidator ForeColor="red" ID="require" runat="server" ControlToValidate="UserName" ValidationGroup="LoginButton" ErrorMessage="Ingresar acceso" ></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="form-group">
                                                <label>Contraseña</label>
                                                <div class="input-group">
                                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control" onkeypress="return AllowAlphabet(event)" ClientIDMode="Static"></asp:TextBox>

                                                    <span class="input-group-append bg-white">
                                                        <span class="btn border border-left-0" onmousedown="mostrarContrasena()" onmouseup="NomostrarContrasena()"><i class=" icon  ion-eye"></i></span>
                                                    </span>
                                                </div>
                                                                  <asp:RequiredFieldValidator  ForeColor="red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password" ValidationGroup="LoginButton" ErrorMessage="Ingresar contraseña"></asp:RequiredFieldValidator>

                                            </div>

                                            <div>
                                               <%-- <label class="custom-control ">
                                                    <span class="custom-control-description small text-dark">Remember me on this computer</span>
                                                </label>--%>
                                            </div>
                                            <asp:Button runat="server" class="btn btn-primary float-right my-2" ID="LoginButton" Text="Entrar" ValidationGroup="LoginButton" CommandName="Login" />


                                        </div>
                                    </LayoutTemplate>
                                </asp:Login>

                            </div>

                            <!--/card-block-->

                            <!-- /form card login -->

                        </div>


                    </div>
                    <!--/row-->

                </div>
                <!--/col-->
            </div>
            <!--/row-->
        </div>
        
       
        <!--/container-->

    </form>

    <script src="Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="Bootstrap/js/popper.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
                     Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

       $('.card').hover(
                function () {
                    $(this).animate({
                        marginTop: "-=2%",

                    }, 200);
                },
                function () {
                    $(this).animate({
                        marginTop: "0%"
                    }, 200);
                }

            );
        });
                  
     
          function mostrarContrasena(){
      var tipo = document.getElementById("Password");
      if(tipo.type == "password"){
          tipo.type = "text";
      }
     
        }
         function NomostrarContrasena(){
      var tipo = document.getElementById("Password");
      if(tipo.type == "text"){
          tipo.type = "password";
      }
     
        }

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
