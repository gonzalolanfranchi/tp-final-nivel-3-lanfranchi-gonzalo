using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using service;

namespace articulos_web
{
    public partial class Login : System.Web.UI.Page
    {
        public bool usuarioLogueado { get; set; }
        public bool crearCuenta { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("MenuLogin.aspx");
            }
            
            if (!IsPostBack)
            {
                if (Request.QueryString["crearcuenta"] == null)
                    Session.Add("crearcuenta", false);
                else
                    Session.Add("crearcuenta", true);
                if (Session["isLogged"] == null)
                {
                    Session.Add("isLogged", false);
                }
                else
                {
                    Session["isLogged"] = false;
                }
            }


        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            if ((bool)Session["crearcuenta"])
            {
                Session["crearcuenta"] = false;
                btnLogin.Text = "Iniciar Sesion";
                btnCrearCuenta.Text = "Crear Cuenta";

            }
            else
            {
                Session["crearcuenta"] = true;
                btnLogin.Text = "Crear Cuenta";
                btnCrearCuenta.Text = "Iniciar Sesion";

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user;
            UserService service = new UserService();
            try
            {
                user = new Usuario(txtEmail.Text, txtPassword.Text, false);
                if (service.Loguear(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("MenuLogin.aspx", false);
                }else
                {
                    Session.Add("error", "Email o Password incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }




            //if ((bool)Session["crearcuenta"])
            //{
            //    //CREAR CUENTA
            //    Session["isLogged"] = true;
            //    Response.Redirect("MenuLogin.aspx");

            //}
            //else
            //{
            //    //INICIAR SESION
            //    Session["isLogged"] = true;
            //    Response.Redirect("MenuLogin.aspx");

            //}
        }
    }
}