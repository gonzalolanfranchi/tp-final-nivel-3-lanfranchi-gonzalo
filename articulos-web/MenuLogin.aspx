<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="articulos_web.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (!((bool)Session["isLogged"]))
        {%>
    <div class="row" style="height: 300px">
    </div>

    <% } %>

    <div class="row my-5">
        <div class="col-4">
        </div>
        <div class="col-4 text-center">
            <asp:Label Text="Debes Loguearte." ID="lblTitulo" runat="server" CssClass="h1 text-white" />
            <%if (!((bool)Session["isLogged"]))
                {%>
            <asp:Button Text="Iniciar Sesion o Crear una Cuenta" runat="server" ID="btnLogin" CssClass="btn btn-primary btn-lg mt-3" OnClick="btnLogin_Click" />
            <% } %>
        </div>
    </div>

    <%if ((bool)Session["isLogged"])
        {%>
    <div class="row my-5 text-center">
        <div class="col">
            <asp:Button Text="Usuario Normal" runat="server" CssClass="btn btn-primary"  />
            <asp:Button Text="Tenes que ser Admin   " runat="server" CssClass="btn btn-primary"  />
        </div>
    </div>
    
        <%} %>
















</asp:Content>
