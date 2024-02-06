using domain;
using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Security.sesionActiva((Usuario)Session["user"]))
                {
                    Usuario user = (Usuario)Session["user"];
                    txtEmail.Text = user.Email;
                    txtPassword.Text = user.Pass;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    if (user.UrlImagenPerfil != "")
                    {
                        imgPerfilMuestra.ImageUrl = "~/Images/Perfil/" + user.UrlImagenPerfil;
                    }
                }
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Session.Add("cambiarContraseña", true);
            Page.SetFocus(txtPassword2);
        }

        protected void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword2.Text != txtPassword.Text)
            {
                if(!(lblErrores.Text.Contains("Las contraseñas no coinciden")))
                    lblErrores.Text += "Las contraseñas no coinciden";
                Page.SetFocus(txtPassword);
            }
            else
            {
                lblErrores.Text = lblErrores.Text.Replace("Las contraseñas no coinciden", "");
                Page.SetFocus(txtNombre);
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    Usuario user = (Usuario)Session["user"];
                    EmailService email = new EmailService();
                    UserService userService = new UserService();
                    string ruta = Server.MapPath("./Images/Perfil/");
                    if (txtPerfilUrl.PostedFile.FileName != "") 
                    {
                        txtPerfilUrl.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                        user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";
                    }
                    user.Nombre = txtNombre.Text;
                    user.Apellido = txtApellido.Text;
                    string emailViejo = user.Email;
                    user.Email = txtEmail.Text;
                    if (Session["cambiarContraseña"] != null && (bool)Session["cambiarContraseña"])
                        user.Pass = txtPassword2.Text;
                    userService.modificarUsuario(user);
                    email.armarCorreoModificarCuenta(emailViejo, user.Email);
                    email.enviarEmail();
                    lblErrores.Text = "Modificado Exitosamente!";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        private bool validarDatos()
        {
            if (Session["cambiarContraseña"] != null && (bool)Session["cambiarContraseña"])
            {
                if (txtPassword.Text != txtPassword2.Text)
                {
                    if(!(lblErrores.Text.Contains("Las contraseñas no coinciden")))
                        lblErrores.Text += "Las contraseñas no coinciden";
                    return false;
                }
            }
            return true;
        }
    }
}