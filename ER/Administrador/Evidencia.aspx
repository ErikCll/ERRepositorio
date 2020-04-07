<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Administrador/Admin.Master" CodeBehind="Evidencia.aspx.vb" Inherits="ER.Evidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Evidencias
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate>
                                <asp:Literal ID="litControl" runat="server"></asp:Literal>
         <div class="col-lg-12">
                    <div class="row">
                         <div class="box box-info" style="border-top-color: #5b6060" >
                <div class="box-body" id="DivInsertar">
                    <div class="row">

                        <div class="col-sm-8 col-md-4 col-lg-4">
                               <div class="form-group">
                                <label class="font-weight-bold">Nivel 1:</label>
                             <asp:DropDownList class="form-control" ID="ddl_Nivel1" runat="server" DataTextField="Nivel1" DataValueField="Nivel1" OnSelectedIndexChanged="ddl_Nivel1_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>

                       
                            </div>
                      
                            </div>
   
                 <div class="col-sm-8 col-md-4 col-lg-4">
                               <div class="form-group">
                                <label class="font-weight-bold">Nivel 2:</label>
                             <asp:DropDownList class="form-control" ID="ddl_Nivel2" runat="server" DataTextField="Nivel2" DataValueField="Nivel2" ></asp:DropDownList>

                       
                            </div>
                      
                            </div>
     <div class="col-sm-8 col-md-4 col-lg-4">
                               <div class="form-group">
                                <label class="font-weight-bold">Nivel 3:</label>
                             <asp:DropDownList class="form-control" ID="ddl_Nivel3" runat="server" ></asp:DropDownList>

                       
                            </div>
                      
                            </div>
   
               <div class="col-sm-8 col-md-4 col-lg-4">
                               <div class="form-group">
                                <label class="font-weight-bold">Requisito:</label>
                             <asp:DropDownList class="form-control" ID="ddl_Requisito" runat="server" ></asp:DropDownList>

                       
                            </div>
                      
                            </div>
   

                    </div>
                 
                </div>


            </div>
                    </div>
                       <div class="row">
                           <div class="col-sm-4 col-md-1"></div>
        <div class="col-sm-4 col-md-7">
             <div class="btn-group">
            </div>
        </div>

        <div class="col-sm-4 col-md-4">
            <div class="input-group">
                <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  CssClass="btn btn-default btn-sm" />
                </div>
            </div>
        </div>
    </div>
<%--<div class="row">
    <div class="container ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
             <asp:GridView ID="gridEmpleado"
                    runat="server"
                    AutoGenerateColumns="false" AllowPaging="true"
                    CssClass=" table table-striped table-sm text-md-center"
                     HeaderStyle-CssClass=" thead-dark text-sm-center"
                    EmptyDataText="Sin registros"
                 PageSize="10"
                    AllowCustomPaging="false" 
                    DataKeyNames="Id_empleado" 
                  OnPageIndexChanging="gridEmpleado_PageIndexChanging"
                  OnRowCommand="gridEmpleado_RowCommand"
                     >
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="220px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                                <div class="btn-group">
                <asp:LinkButton runat="server" id="btnAgregar" class="btn btn-sm text-blue" CommandName="Agregar" ><span class=" ion-plus" ></span>Usuario</asp:LinkButton>
            </div>
                              
                                 <asp:LinkButton runat="server" ID="btnEditar" class="btn btn-primary" BackColor="#5b6060"  Text="Editar" CommandName="Editar">
                                </asp:LinkButton>
                                   <asp:LinkButton runat="server" ID="btnAct" class="btn btn-primary" BackColor="#5b6060"  Text="Actualizar" CommandName="Actualizar" Visible="false" >
                                </asp:LinkButton>
                               <asp:LinkButton runat="server" ID="btnCancel" class="btn btn-default"  Text="Cancelar" CommandName="Cancelar" Visible="false" >
                                </asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                             
                        <asp:TemplateField HeaderStyle-Width="20px">
                            <ItemTemplate>

                                <asp:LinkButton runat="server" ID="btnEliminar" class="btn btn-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false">
                             <span class=' ion-ios-trash'></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                      
                                                <asp:BoundField HeaderText="Usuario" DataField="Acceso" />

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                <asp:TextBox ID="txtEditNombre" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="120px"
                                    Text='<%# Eval("Nombre") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Paterno">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoPaterno" runat="server" Text='<%# Eval("ApellidoPaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoPaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="100px"
                                    Text='<%# Eval("ApellidoPaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido Materno">
                            <ItemTemplate>
                                <asp:Label ID="lblApellidoMaterno" runat="server" Text='<%# Eval("ApellidoMaterno") %>'></asp:Label>
                                <asp:TextBox ID="txtEditApellidoMaterno" runat="server" BackColor="#ffffbb" BorderColor="#ffffbb" class="form-control" Width="100px"
                                    Text='<%# Eval("ApellidoMaterno") %>' Visible="false"  onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                          <asp:BoundField HeaderText="Fecha de creación " DataField="CreacionFecha" />
                     
                    </Columns>
               <PagerStyle HorizontalAlign = "Center" CssClass="" />
                </asp:GridView>
            </div>




       
        </div>
         
    </div>

        
    </div>--%>
                </div>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
