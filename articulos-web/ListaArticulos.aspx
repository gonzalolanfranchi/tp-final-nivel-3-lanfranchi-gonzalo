<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="articulos_web.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scr.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row d-flex justify-content-center">
        <div class="col-md-12 col-lg-10  fondoblanco mt-5 rounded-5">

            <h1 class="text-center my-3">Tu lista de Articulos</h1>
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>


                    

                    <div class="row">
                        <asp:Label Text="Filtrar" runat="server" />
                        <div class="col-6 d-block">
                            <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="false"  CssClass="form-control" onkeydown="detectarEnter(event)"/>
                        </div>
                        <div class="col-2 d-block">
                            <asp:CheckBox Text="Filtro Avanzado" ID="checkFiltroAvanzado" runat="server" OnCheckedChanged="checkFiltroAvanzado_CheckedChanged" AutoPostBack="true" CssClass="" />
                        </div>
                        <div class="col-2 d-block" >
                            <div class="">
                                <asp:Button Text="Filtrar" runat="server" ID="btnFiltrar" OnClick="filtro_TextChanged" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>

                    <%if (FiltroAvanzado)
                        {
                        
                    %>
                    <div class="row">
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label Text="Campo" runat="server" />
                                <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Nombre" />
                                    <asp:ListItem Text="Marca" />
                                    <asp:ListItem Text="Categoria" />
                                    <asp:ListItem Text="Precio" />

                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label Text="Criterio" runat="server" />
                                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label Text="Estado" runat="server" />
                                <asp:DropDownList runat="server" ID="ddlImagen" CssClass="form-control">
                                    <asp:ListItem Text="Todos" />
                                    <asp:ListItem Text="Imagen Completa" />
                                    <asp:ListItem Text="Imagen Incompleta" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%}
                    %>


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


    <script type="text/javascript">
        function setFocusOnFilter() {
            var filterBox = document.getElementById('<%= txtFiltro.ClientID %>');
            if (filterBox) {
                filterBox.focus();
                // Mueve el cursor al final del contenido del cuadro de texto
                if (filterBox.value) {
                    filterBox.selectionStart = filterBox.selectionEnd = filterBox.value.length;
                }
            }
        }
        function detectarEnter(e) {
            // Verificar si la tecla presionada es Enter
            if (e.keyCode === 13) {
                // Llamar al evento click del botón
                document.getElementById('<%= btnFiltrar.ClientID %>').click();
                // Evitar que se realice la acción predeterminada del Enter en el TextBox
                e.preventDefault();
            }
        }
    </script>


</asp:Content>
