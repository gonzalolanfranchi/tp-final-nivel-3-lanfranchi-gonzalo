<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="articulos_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col-8">
            <div class="row">
                <h1 class="text-white mb-3">Mi Perfil</h1>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" type="email" placeholder="name@example.com" />
                        <label for="floatingInput">Email address</label>
                    </div>
                    <div class="form-floating mb-3">
                        <asp:TextBox type="password" class="form-control" ID="txtPassword" placeholder="Contraseña" runat="server" OnTextChanged="txtPassword_TextChanged" AutoPostBack="true" />
                        <label for="txtPassword">Contraseña</label>
                    </div>
                    <%if (Session["cambiarContraseña"] != null && (bool)Session["cambiarContraseña"] == true)
                        {%>
                    <div class="form-floating mb-3">
                        <asp:TextBox type="password" class="form-control" ID="txtPassword2" placeholder="Confirmar Contraseña" runat="server" OnTextChanged="txtPassword2_TextChanged" AutoPostBack="true"/>
                        <label for="txtPassword2">Confirmar Contraseña</label>
                    </div>

                    <%} %>
                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" ID="txtNombre" placeholder="nombre" CssClass="form-control" />
                        <label for="txtNombre">Nombre</label>
                    </div>
                    <div class="form-floating mb-3">
                        <asp:TextBox runat="server" ID="txtApellido" placeholder="Apellido" CssClass="form-control" />
                        <label for="txtApellido">Apellido</label>
                    </div>
                    <div class="form-floating mb-3">
                        <input type="file" name="txtPerfilUrl" runat="server" id="txtPerfilUrl" class="form-control" />
                        <%--<asp:TextBox runat="server" ID="imgPerfilUrl" CssClass="form-control" type="file"/>--%>
                        <label for="imgPerfilUrl">Imagen de Perfil</label>
                    </div>

                    <div class="row">
                        <asp:Label Text="" runat="server" ID="lblErrores" CssClass="text-danger mb-3"/>
                    </div>
                    
                    <asp:Button Text="Guardar Cambios" runat="server" CssClass="btn btn-lg btn-success" ID="btnGuardarCambios" OnClick="btnGuardarCambios_Click" />

                </div>
                <div class="col-6">
                    <asp:Image runat="server" ID="imgPerfilMuestra" CssClass="img-fluid rounded-4" ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
