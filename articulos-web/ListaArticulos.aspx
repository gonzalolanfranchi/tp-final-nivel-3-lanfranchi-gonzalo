<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="articulos_web.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row d-flex justify-content-center">
        <div class="col-md-12 col-lg-10  fondoblanco mt-5 rounded-5">
            <h1 class="text-center my-3">Tu lista de Articulos</h1>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label Text="Filtrar" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
                    <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" class="table table-striped mt-3"
                        AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectionIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                        AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                            <asp:TemplateField HeaderText="Precio">
                                <ItemTemplate>
                                    <%# String.Format("{0:C2}", Eval("Precio")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Acciones" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="row d-flex justify-content-center mt-3">
        <div class="col-10">
            <a href="Producto.aspx" class="btn btn-primary">Crear Producto</a>

        </div>


    </div>
</asp:Content>
