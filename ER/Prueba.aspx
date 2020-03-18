<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Prueba.aspx.vb" Inherits="ER.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" />
    <style>
   .dropdown-submenu {
  position: relative;
}

.dropdown-submenu a::after {
  transform: rotate(-90deg);
  position: absolute;
  right: 6px;
  top: .8em;
}

.dropdown-submenu .dropdown-menu {
  top: 0;
  left: 100%;
  margin-left: .1rem;
  margin-right: .1rem;
}
.navbar{
    min-height:10px;
}
.navbar  a {
    font-size: 9.2px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="navbar-nav mr-auto">
            <!-- Level one dropdown -->
            <li class="nav-item dropdown">
                <a id="dropdownMenu1" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="nav-link dropdown-toggle">Dropdown</a>
                <ul aria-labelledby="dropdownMenu1" class="dropdown-menu border-0 shadow">
                    <li><a href="#" class="dropdown-item">Some action </a></li>

                    <li class="dropdown-divider"></li>

                    <!-- Level two dropdown-->
                    <li class="dropdown-submenu">
                        <a id="dropdownMenu2" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-item dropdown-toggle">Hover for action</a>
                        <ul aria-labelledby="dropdownMenu2" class="dropdown-menu border-0 shadow">
                            <li>
                                <a tabindex="-1" href="#" class="dropdown-item">level 2</a>
                            </li>

                            <!-- Level three dropdown-->
                            <li class="dropdown-submenu">
                                <a id="dropdownMenu3" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-item dropdown-toggle">level 2</a>
                                <ul aria-labelledby="dropdownMenu3" class="dropdown-menu border-0 shadow">
                                    <li><a href="#" class="dropdown-item">3rd level</a></li>
                                    <li><a href="#" class="dropdown-item">3rd level</a></li>
                                </ul>
                            </li>
                            <!-- End Level three -->

                        </ul>
                    </li>
                    <!-- End Level two -->
                </ul>
            </li>
            <!-- End Level one -->


        </ul>
        <div>

                        <nav class=" navbar navbar-expand-md navbar-dark sticky-top " style="background-color: rgba(0, 0, 0, 0.85); ">
                                            <div class="collapse navbar-collapse" id="navbarSupportedContent">

            <ul class=" navbar-nav mr-auto" aria-labelledby="dropdownMenuLink">

                <asp:ListView ID="AdminTopListView" runat="server" OnItemDataBound="AdminTopListView_ItemDataBound" DataKeyNames="Nivel1">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbl" Text=' <%# Eval("Nivel1") %>' Visible="false"></asp:Label>
                        <li class="nav-item dropdown"><a id="dropdownMenu2" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-item dropdown-toggle"><%# Eval("Nivel1") %></a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <asp:ListView ID="RequisitoNivel1" runat="server">
                                    <ItemTemplate>
                                        <li class="dropdown-item">
                                            <asp:LinkButton CssClass="ion-android-document" runat="server" ID="lblRequisitoNivel1" Text='<%#" " + Eval("Requisito") %>' ForeColor="Blue"></asp:LinkButton>
                                        </li>

                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:ListView ID="Menu2" runat="server">
                                    <ItemTemplate>

                                        <li class="dropdown-submenu">
                                            <asp:Label runat="server" ID="lbl2" href="Area.aspx" Text='<%# Eval("Nivel2") %>' Visible="false">
                                            </asp:Label><a id="dropdownMenu2" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-item dropdown-toggle"><%# Eval("Nivel2") %></a>

                                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                                <asp:ListView ID="RequisitoNivel2" runat="server">
                                                    <ItemTemplate>
                                                        <li class="dropdown-item">
                                                            <asp:LinkButton CssClass="ion-android-document" runat="server" ID="lblRequisitoNivel2" Text='<%#" " + Eval("Requisito") %>' ForeColor="Blue"></asp:LinkButton>
                                                        </li>

                                                    </ItemTemplate>
                                                </asp:ListView>
                                           
                                                <asp:ListView ID="Menu3" runat="server">
                                                    <ItemTemplate>
                                                        <li class="dropdown-submenu">
                                                            <asp:Label runat="server" ID="lbl3" Text='<%# Eval("Nivel3") %>' Visible="false"></asp:Label>
                                                            <a id="dropdownMenu2" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-item dropdown-toggle"><%# Eval("Nivel3") %></a>
                                                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                                                <asp:ListView ID="MenuRequisito" runat="server">
                                                                    <ItemTemplate>
                                                                        <li class="dropdown-item">
                                                                            <asp:LinkButton CssClass="ion-android-document" runat="server" ID="lblRequisito" Text='<%#" " + Eval(" Requisito") %>' ForeColor="Blue"></></asp:LinkButton>
                                                                        </li>

                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </ul>
                                                        </li>

                                                    </ItemTemplate>

                                                </asp:ListView>
                                            </ul>

                                        </li>



                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>


                        </li>



                    </ItemTemplate>
                    <%--<EmptyItemTemplate>
                        <li>Sin datos</li>
                    </EmptyItemTemplate>--%>
                </asp:ListView>


            </ul>
</div>

</nav>

            <ul>

                <li class="nav-item dropdown"><a id="dropdownMenu1" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="nav-link dropdown-toggle" style="color: black">Programming</a>
                    <ul aria-labelledby="dropdownMenu1" class="dropdown-menu border-0 shadow">
                        <li class="dropdown-submenu"><a id="dropdownMenu2" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-item dropdown-toggle">WordPress</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a tabindex="-1" href="#" class="dropdown-item">Hacks</a>
                                <a tabindex="-1" href="#" class="dropdown-item">Plugins</a>
                                <a tabindex="-1" href="#" class="dropdown-item">Shortcodes</a>
                            </ul>
                        </li>

                    </ul>
                </li>

            </ul>
            <%--                <asp:ListView
         ID="AdminTopListView"
         runat="server"
         >
                  
                    <ItemTemplate>
                     
                                                
                             <ul class="navbar-nav mr-auto">
                       <li class="nav-item dropdown"><%#Eval("Nivel1")%></li>

                            <ul>
                                <li><%#Eval("Nivel2")%></li>
                                <ul>
                                    <li><%#Eval("Nivel3")%></li>
                                    <ul>
                                        <li><%#Eval("Nivel4")%></li>
                                        <ul>
                                            <li><%#Eval("Requisito")%></li>
                                        </ul>
                                    </ul>
                                </ul>
                            </ul>
                        </ul>

                       
                    </ItemTemplate>
<EmptyItemTemplate><li>Empty</li></EmptyItemTemplate>          
    </asp:ListView>--%>

            <%--        <ul class="dropdown" aria-labelledby="dropdownMenuLink">

                        <asp:ListView ID="ListView1" runat="server" OnItemDataBound="AdminTopListView_ItemDataBound" DataKeyNames="Nivel1">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbl" Text=' <%# Eval("Nivel1") %>' Visible="false"></asp:Label>
                        <li><%# Eval("Nivel1") %>
                                  <ul>
                                                             <asp:ListView ID="RequisitoNivel1" runat="server">
                                                    <ItemTemplate><li>  <asp:LinkButton CssClass="ion-android-document" runat="server" ID="lblRequisitoNivel1" Text='<%# Eval("Requisito") %>'></asp:LinkButton>
</li>
                                                     
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                        </ul>
                            <ul>
                                <asp:ListView ID="Menu2" runat="server">
                                    <ItemTemplate>

                                        <asp:Label runat="server" ID="lbl2" href="Area.aspx" Text='<%# Eval("Nivel2") %>' Visible="false">
                                        </asp:Label>
                                        <li><%# Eval("Nivel2") %>
                                                <ul>
                                                             <asp:ListView ID="RequisitoNivel2" runat="server">
                                                    <ItemTemplate>
                                                        <li> <asp:LinkButton CssClass="ion-android-document" runat="server" ID="lblRequisitoNivel2" Text='<%# Eval("Requisito") %>'></asp:LinkButton>
</li>
                                                     
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                        </ul>
                                            <ul>
                                                <asp:ListView ID="Menu3" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbl3" Text='<%# Eval("Nivel3") %>' Visible="false"></asp:Label>
                                                        <li ><%# Eval("Nivel3") %></li>
                                                        <ul>
                                                             <asp:ListView ID="MenuRequisito" runat="server">
                                                    <ItemTemplate>
                                                        <li>                                                        <asp:LinkButton CssClass="ion-android-document" runat="server" ID="lblRequisito" Text='<%# Eval("Requisito") %>'></asp:LinkButton>
</li>
                                                     
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                        </ul>
                                                    </ItemTemplate>

                                                </asp:ListView>
                                            </ul>
                                        </li>



                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>

                        </li>



                    </ItemTemplate>
             
                </asp:ListView>
            

            </ul>--%>
        </div>
    </form>
    <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
    $('.dropdown-menu a.dropdown-toggle').on('click', function(e) {
  if (!$(this).next().hasClass('show')) {
    $(this).parents('.dropdown-menu').first().find('.show').removeClass('show');
  }
  var $subMenu = $(this).next('.dropdown-menu');
  $subMenu.toggleClass('show');


  $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function(e) {
    $('.dropdown-submenu .show').removeClass('show');
  });


  return false;
});
    </script>
</body>
</html>
