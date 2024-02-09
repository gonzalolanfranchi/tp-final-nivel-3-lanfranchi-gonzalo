<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="articulos_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous">
    <h1 class="text-center mb-5" style="color: white">Productos
    </h1>
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">

        <ContentTemplate>
            <div class="container">
                <div class="row ">
                    <asp:Label Text="Filtrar" runat="server" />
                    <div class="col-6 d-block">
                        <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="false" CssClass="form-control" onkeydown="detectarEnter(event)" />
                    </div>
                    <div class="col-2 d-block">
                        <asp:CheckBox Text="Filtro Avanzado" ID="checkFiltroAvanzado" runat="server" OnCheckedChanged="checkFiltroAvanzado_CheckedChanged" AutoPostBack="true" CssClass="" />
                    </div>
                    <div class="col-2 d-block">
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
                        <div class="">
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
                        <div class="">
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="col-3">
                        <div class="">
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
                <div class="row row-cols-1 row-cols-md-3 g-4 mt-2">

                    <asp:Repeater runat="server" ID="repRepetidor">
                        <ItemTemplate>
                            <div class="col mt-3">
                                <div class="card h-100">
                                    <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt="..." style="object-fit: contain; max-height: 300px">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Descripcion")%></p>
                                        <div class="d-flex justify-content-between mx-3" style="height: 40px;">
                                            <p class="card-text text-success fs-3"><%# string.Format(ci, "{0:C0}", Eval("Precio")) %></p>

                                            <asp:ImageButton OnClick="AlternarFavorito_Click" ID="imgAgregarFavorito" AutoPostBack="true" ImageUrl='<%#urlFav((int)Eval("Id")) %>' runat="server" CommandArgument='<%#Eval("Id")%>' Style="height: 30px; width: 30px;" />


                                            <a href="Detalle.aspx?id=<%#Eval("Id") %>" class=" btn btn-primary ">Ver</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


















                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
