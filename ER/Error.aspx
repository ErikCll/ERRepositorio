<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Error.aspx.vb" Inherits="ER._Error" %>

<!DOCTYPE html>
<html>
<head>

    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
  
 
    <title>Administrador</title>

    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" />
    <style type="text/css">
        .header-center {
            text-align: center;
        }
    </style>
</head>
<body>



    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>


        <header>
        </header>


        <!-- Right side column. Contains the navbar and content of the page -->
        <div>
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Error</h1>
            </section>
            <br />
            <section class="content">


                                           <div class="col-lg-12">
                                           <div class="row">

                                               <div class="error-page">
<%--        <h2 class="headline text-red">500</h2>--%>

        <div class="error-content">
          <h3><i class=" ion-android-warning text-red "></i> Error al momento de la ejecución.</h3>

          <p>
            Se notificó a los administradores sobre el error.
            Para regresar a inicio, presione <asp:LinkButton OnClick="Referencia_Click" runat="server" id="Referencia">aqui.</asp:LinkButton>
          </p>

         
        </div>
      </div>
                                           </div>
                         
                        </div>
            

            </section>


        </div>
        <!-- /.content -->
        <!-- /.content-wrapper -->






    <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
        
        <script type="text/javascript">

           {
if(history.forward(1))
location.replace(history.forward(1))
}
        </script>
      
    </form>

</body>

</html>