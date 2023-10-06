<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="articulos_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4 text-center">
            <asp:Label Text="Iniciar Sesion" runat="server" ID="lblTitulo" CssClass="h1 text-center text-white" />
        </div>

    </div>

    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4 text-center mb-5">
            <asp:LinkButton
                OnClick="btnCrearCuenta_Click"
                Text="o Crear Cuenta..."
                runat="server"
                ID="lbtnCrearCuenta"
                CssClass="text-center link-success h6" />
        </div>

    </div>

    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4">
            <div class="form-floating mb-3">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" type="email" placeholder="name@example.com"/>
                <label for="floatingInput">Email address</label>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox type="password" class="form-control" ID="txtPassword" placeholder="Password" runat="server"/>
                <label for="floatingPassword">Password</label>
            </div>

            
            <%if ((bool)Session["crearcuenta"])
            
                {%>
            <div class="row">
                <div class="form-floating mb-3 col-6">
                    <input type="password" class="form-control" id="dtp" placeholder="Password">
                    <label for="floatingPassword">Password</label>
                </div>
                <div class="form-floating mb-3 col-6">
                    <input type="password" class="form-control" id="floatingPasswordss" placeholder="Password">
                    <label for="floatingPassword">Password</label>
                </div>

            </div>
            <div class="form-floating mb-3">
                <input type="email" class="form-control" id="floatingInputt" placeholder="name@example.com">
                <label for="floatingInput">Email address</label>
            </div>
            <div class="form-floating">
                <input type="password" class="form-control" id="floatingPasswordt" placeholder="Password">
                <label for="floatingPassword">Password</label>
            </div>
            <%}
            %>

            <div class="d-flex justify-content-center">
                <div class="text-center mt-4 mx-2">
                    <asp:Button Text="Crear Cuenta" ID="btnCrearCuenta" runat="server" CssClass="btn btn-secondary btn-lg" OnClick="btnCrearCuenta_Click" />
                </div>

                <div class="text-center mt-4 mx-2">
                    <asp:Button Text="Iniciar Sesion" ID="btnLogin" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
