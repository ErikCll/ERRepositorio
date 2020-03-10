<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Prueba.aspx.vb" Inherits="ER.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <link href="../Bootstrap/css/ionicons.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/bootstrap4.4.1.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/AdminLTE.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
         
            <ul class="dropdown">
                <asp:ListView ID="AdminTopListView" runat="server" OnItemDataBound="AdminTopListView_ItemDataBound" DataKeyNames="Nivel1">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbl" Text=' <%# Eval("Nivel1") %>' Visible="false"></asp:Label>
                                             <li>  <%# Eval("Nivel1") %>

                                                     <ul>
                                                    <asp:ListView ID="Menu2" runat="server"  >
                                                <ItemTemplate>

                                <asp:Label  runat="server" id="lbl2" href="Area.aspx" Text='<%# Eval("Nivel2") %>' Visible="false">
                                                                    </asp:Label>
                                                    <li><%# Eval("Nivel2") %>

                                                            <ul>
                                                                          <asp:ListView ID="Menu3" runat="server">
                                                <ItemTemplate>

                                <li  href="Area.aspx"> <%# Eval("Nivel3") %></li>

<%--                                <div class="dropdown-divider"></div>--%>
                                                </ItemTemplate>
                                            </asp:ListView>
                                                    </ul>
                                                    </li>
                                    
                                                
                                  
                                                </ItemTemplate>
                                            </asp:ListView>
                                           </ul>
                                       
                            </li>
                                           
                                       

                                    </ItemTemplate>
                                    <EmptyItemTemplate><li>Sin datos</li></EmptyItemTemplate>
                                </asp:ListView>

            </ul>
                                
                     <ul class="dropDownMenu">
	
		<li><a href="#">Programming</a>
			<ul>
				<li><a href="#">WordPress</a>
					<ul>
						<li><a href="#">Hacks</a></li>
						<li><a href="#">Plugins</a></li>
						<li><a href="#">Shortcodes</a></li>
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
        </div>
    </form>
        <script src="../Bootstrap/js/jquery-3.4.1.min.js"></script>
    <script src="../Bootstrap/js/popper.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
