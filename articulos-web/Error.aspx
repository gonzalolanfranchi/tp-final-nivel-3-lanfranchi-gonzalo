<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="articulos_web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fondoblanco" style="height: 2000px; width:2000px;">
        <h1>Hubo un problema</h1>
        <asp:Label Text="text" ID="lblMensaje" runat="server" />

    </div>
</asp:Content>
