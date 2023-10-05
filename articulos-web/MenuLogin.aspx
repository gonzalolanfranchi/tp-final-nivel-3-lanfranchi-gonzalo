<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="articulos_web.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row my-5">
        <div class="col-4">
        </div>
        <div class="col-4 text-center">
            <asp:Label Text="Debes Loguearte." ID="lblTitulo" runat="server" CssClass="h1 text-white" />
        </div>
    </div>

    <div class="row my-5 text-center">
        <div class="col">
            <asp:Button Text="Usuario Normal" runat="server" CssClass="btn btn-primary" ID="btnPaginaNormal" OnClick="btnPaginaNormal_Click" />
    <%if (Session["user"] != null && ((domain.Usuario)Session["user"]).Admin == domain.TipoUsuario.ADMIN)
        {%>
            <asp:Button Text="Tenes que ser Admin" runat="server" CssClass="btn btn-primary" ID="btnPaginaAdmin" OnClick="btnPaginaAdmin_Click" />
        </div>
    </div>
    
        <%} %>
















</asp:Content>
