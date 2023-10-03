<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CartasDeArticulos.aspx.cs" Inherits="articulos_web.CartasDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous">
    <h1 class="text-center mb-5" style="color: white">Productos
    </h1>
    <div class="container">
        <div class="row row-cols-1 row-cols-md-3 g-4">

            <%
                foreach (domain.Producto prod in ListaProducto)
                {%>

            <div class="col">
                <div class="card h-100">
                    <asp:Image ID="Image1" runat="server" />
                    <img src="<%: prod.ImagenUrl %>" class="card-img-top" alt="..." style="max-height:300px; max-width: 300px;">
                    <div class="card-body">
                        <h5 class="card-title"><%: prod.Nombre %></h5>
                        <p class="card-text"><%: prod.Descripcion %></p>
                        <a href="Producto.aspx?id=<%: prod.Id %>" class="btn btn-primary">Detalle</a>
                    </div>
                </div>
            </div>
            <%  } %>
        </div>
    </div>
</asp:Content>
