<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="articulos_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container fondoblanco">
        <%-- TITULO --%>
        <div class="row">
            <asp:Label ID="lblTitulo" runat="server" Text="Agregar Producto" CssClass="fs-1 fw-semibold"></asp:Label>
        </div>
        <%-- FIN DEL TITULO --%>

        <div class="row">

            <div class="col">
                <div class="row pb-3 pt-2" style="background-color: red;">

                    <div class="col">
                        <label class="d-block form-label fw-semibold" for="txtId">ID:</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <div class="col">
                        <label class="d-block form-label fw-semibold" for="txtNombre">Nombre:</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>
                </div>

                <div class="row pb-3 pt-2" style="background-color: chocolate;">

                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="txtDescripcion">Descripcion:</label>

                        <%-- Esto se hace para tener un textarea ajustable no asp pero que la rellene con codigo aca mismo --%>
                        <%
                            domain.Producto prod = new domain.Producto();

                            if (Request.QueryString["id"] != null)
                            {
                                prod = ListaProducto.FirstOrDefault(p => p.Id == int.Parse(Request.QueryString["id"]));
                            }
                        %>

                        <textarea id="txtDescripcion" class="form-control d-flex" rows="3"><%: prod.Descripcion %></textarea>
                    </div>
                </div>

                <div class="row pb-3 pt-2" style="background-color: crimson;">
                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="ddlMarca">Marca:</label>
                        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" ></asp:DropDownList>
                    </div>
                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="ddlCategoria">Categoria:</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>

                <div class="row pb-3 pt-2" style="background-color: darkorchid;">

                    <div class="col">
                        <label class="form-label d-block fw-semibold" for="txtImagenUrl">ImagenURL:</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" />
                    </div>


                </div>

            </div>
            <div class="col py-3" style="background-color: khaki;">
                <asp:Image ImageUrl="https://fondosmil.com/fondo/29403.jpg" runat="server" Width="100%" class="" />
                <label class="form-label d-block fw-semibold pt-1 text-end" for="txtPrecio">PRECIO DEL PRODUCTO</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
        </div>


    </div>




</asp:Content>
