<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="articulos_web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4">
            <div class="text-center mb-5">
                <asp:Label Text="Contactanos" runat="server" CssClass="h1 " />
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" type="email" placeholder="name@example.com" />
                <label for="floatingInput">Email address</label>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox type="text" class="form-control" ID="txtAsunto" placeholder="Asunto" runat="server" />
                <label for="Asunto">Asunto</label>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox textmode="MultiLine" class="form-control" ID="txtMensaje" placeholder="Escribe aqui tu mensaje" runat="server" Rows="10" style="height: 200px;"></asp:TextBox>

                <label for="txtMensaje">Escribe aqui tu mensaje</label>
            </div>

            <div class="mb-3 ">
                <asp:Button Text="Enviar" ID="btnEnviar" runat="server" CssClass="btn btn-primary float-end" OnClick="btnEnviar_Click"/>
            </div>







        </div>
    </div>

</asp:Content>
