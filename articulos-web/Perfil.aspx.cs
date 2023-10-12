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
        public bool cambiarContraseña = false;
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
                    imgPerfilUrl.Text = user.UrlImagenPerfil;

                    if (!(user.UrlImagenPerfil == null || user.UrlImagenPerfil == ""))
                    {
                        imgPerfilMuestra.ImageUrl = user.UrlImagenPerfil;
                    }
                    else
                    {
                        imgPerfilMuestra.ImageUrl = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";
                    }
                }

                if (cambiarContraseña)
                {
                    //que me seleccione para escribir la casilla txtPassword2
                }
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            cambiarContraseña = true;
        }
    }
}