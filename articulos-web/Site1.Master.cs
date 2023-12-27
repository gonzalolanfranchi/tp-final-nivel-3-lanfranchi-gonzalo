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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Default || Page is Detalle || Page is Contacto || Page is CartasDeArticulos || Page is Error))
            {
                if (!Security.sesionActiva(Session["user"]))
                {
                    Session.Add("error", "Debes iniciar sesion para acceder a esta pagina");
                    Response.Redirect("Login.aspx", false);
                }
            }

            if (Page is PaginaAdmin || Page is ListaArticulos)
            {
                if (!Security.esAdmin(Session["user"]))
                {
                    Session.Add("error", "Debes ser Administrador para acceder a esta pagina");
                    Response.Redirect("Error.aspx", false);
                }
            }

            if (Security.sesionActiva(Session["user"]))
            {
                if (((Usuario)Session["user"]).UrlImagenPerfil != "")
                    imgPerfil.ImageUrl = "~/Images/Perfil/" + ((Usuario)Session["user"]).UrlImagenPerfil;
            }


        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Add("error", "Sesion cerrada con exito.");
            Response.Redirect("Login.aspx", false);
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?cc=y", false);
        }

        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }


    }
}