<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="articulos_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container fondoblanco">
        <%-- TITULO --%>
        <div class="row">
            <div class="col-6 d-flex justify-content-center">
                <asp:Label ID="lblTitulo" runat="server" Text="Agregar Producto" CssClass="fs-1 fw-semibold "></asp:Label>
            </div>
        </div>
        <%-- FIN DEL TITULO --%>

        <div class="row">

            <div class="col-12 col-sm-6">
                <div class="row pb-3 pt-2" style="background-color: red;">

                    <div class="col-3">
                        <label class="d-block form-label fw-semibold" for="txtId">ID:</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false"/>
                    </div>
                    <div class="col-3">
                        <label class="d-block form-label fw-semibold" for="txtCodigo">Codigo:</label>
                        <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                    </div>
                    <div class="col-6">
                        <label class="d-block form-label fw-semibold" for="txtNombre">Nombre:</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>
                </div>

                <div class="row pb-3 pt-2" style="background-color: chocolate;">

                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="txtDescripcion">Descripcion:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4" Columns="50" class="form-control d-flex w-100"></asp:TextBox>
                    </div>
                </div>

                <div class="row pb-3 pt-2" style="background-color: crimson;">
                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="ddlMarca">Marca:</label>
                        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="ddlCategoria">Categoria:</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>

                <div class="row pb-3 pt-2" style="background-color: darkorchid;">
                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="txtImagenUrl">ImagenURL:</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"/>
                    </div>
                </div>

                <div class="row pb-3 pt-3" style="background-color: cornflowerblue;">
                    <div class="col">
                        <asp:Button Text="Volver" runat="server" ID="btnVolver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
                    </div>

                    <div class="col d-flex justify-content-end">
                        <%if (Request.QueryString["id"] != null){%>
                        <div class="me-1">
                            <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="btn btn-success" OnClick="btnModificar_Click" />
                        </div>
                        <div id="divEliminar" class="ms-1">
                            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-danger" />
                        </div>
                        <%} %>

                        <div class="ms-1" <%=(modificar || Request.QueryString["id"] == null) ? "" : "style='display: none'"%>>
                            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" />
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-12 col-sm-6 py-3" style="background-color: khaki;">
                <div class="d-flex justify-content-center">
                    <asp:Image ID="imgArticulo" runat="server" Height="300px" Width="300px" CssClass="img-thumbnail" Style="object-fit: contain"  />
                </div>
                <label class="form-label d-block fs-2 fw-semibold pt-1 text-end mt-2" for="txtPrecio">Precio por unidad</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control fs-1 fw-bold d-flex text-end text-success" />
            </div>

        </div>
    </div>

</asp:Content>
