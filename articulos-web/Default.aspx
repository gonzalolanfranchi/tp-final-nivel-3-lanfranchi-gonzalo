<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="articulos_web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="row d-flex justify-content-center">
        <div class="col-6 fondoblanco d-flex justify-content-center mt-5 rounded-5">
            <h1 class="mt-2 text-center fw-semibold">Bienvenido a tu Administrador</h1>
        </div>
    </div>

    <div class="row d-flex justify-content-center">
        <div class="col-3 fondoblanco d-flex justify-content-center mt-5 rounded-5">
            <asp:Button Text="=> Ir a los Productos <=" runat="server" class="btn btn-primary btn-lg my-3 fw-bold" OnClick="IrALosProductos_Click"/>
        </div>
    </div>


</asp:Content>
