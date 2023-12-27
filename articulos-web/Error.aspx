<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="articulos_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fondoblanco" style="height: 2000px; width: 2000px;">
        <div style="height: 50px;"></div>
        <div class="row text-center">
            <div class="col-2">
            </div>
            <div class="col-8">
                <asp:Label ID="lblTitulo" Text="Pagina de Errores" runat="server" CssClass="h1"/>
                <div class="row">
                    <asp:Label Text="No hay ningun problema." ID="lblMensaje" runat="server" CssClass="mt-2" />

                </div>
                <div class="row">
                    <div class="col-2   ">

                    </div>
                    <div class="col-8 mt-2">
                        <%if (lblMensaje.Text == "Debes loguearte para acceder a esa página")
                        {
                                
                                %>
                    <asp:Button Text="Iniciar Sesion" runat="server" CssClass="btn btn-primary" ID="btnIniciarSesion" OnClick="btnIniciarSesion_Click" />
                    <%} %>
                    </div>
                    
                </div>

            </div>
        </div>

    </div>
</asp:Content>
