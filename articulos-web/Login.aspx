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
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control d-flex" type="email" placeholder="name@example.com"/>
                <label for="floatingInput">Email address</label>
                <div class="d-flex">
                    <asp:RegularExpressionValidator CssClass="text text-danger d-flex" ErrorMessage="Tiene que tener formato de email." ValidationExpression="^([\w-]+(\.[\w-]+)*)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
                </div>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox type="password" class="form-control" ID="txtPassword" placeholder="Password" runat="server"/>
                <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida." ControlToValidate="txtPassword" runat="server" CssClass="text text-danger"/>
                <label for="floatingPassword">Password</label>
            </div>

            
            <%if (Session["crearcuenta"] != null && (bool)Session["crearcuenta"])
            
                {%>
            <div class="row">
                <div class="col-6">   
                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" ID="txtNombre" placeholder="nombre" CssClass="form-control"/>
                        <label for="txtNombre">Nombre</label>
                    </div>
                </div>
                <div class="col-6">   
                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" ID="txtApellido" placeholder="Apellido" CssClass="form-control"/>
                        <label for="txtApellido">Apellido</label>
                    </div>
                </div>
            </div>
            
            <%--<div class="row">
                <div class="col-2">   
                    <div class="form-floating mb-3">
                        <input type="text" class="form-control" id="txtArea" value="011">
                        <label for="txtArea">Area</label>
                    </div>
                </div>
                <div class="col-4">   
                    <div class="form-floating mb-3">
                        <input type="tel" class="form-control" id="txtTelefono" placeholder="Telefono">
                        <label for="txtTelefono">Telefono</label>
                    </div>
                </div>
                <div class="col-6">   
                    <div class="form-floating mb-3">
                        <input type="date" class="form-control" id="dtpFechaNacimiento" placeholder="nombre">
                        <label for="dtpFechaNacimiento">Fecha de Nacimiento </label>
                    </div>
                </div>
            </div>--%>
            <%}
            %>

            <div class="row">   
                <asp:Label Text="" ID="txtMensaje" runat="server" CssClass="text-danger text-center" />
            </div>

            <div class="d-flex justify-content-center">
                <div class="text-center mt-4 mx-2">
                    <asp:Button Text="" ID="btnCrearCuenta" runat="server" CssClass="btn btn-secondary btn-lg" OnClick="btnCrearCuenta_Click" />
                </div>

                <div class="text-center mt-4 mx-2">
                    <asp:Button Text="" ID="btnLogin" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
