using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class MenuLogin : System.Web.UI.Page
    {
        public bool usuarioLogueado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["isLogged"] == null)
                    Session.Add("isLogged", false);

                if ((bool)Session["isLogged"])
                {
                    if((bool)Session["crearcuenta"])
                        lblTitulo.Text = "Registro exitoso, Bienvenido " + "USUARIO";
                    else
                        lblTitulo.Text = "Bienvenido " + "USUARIO";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false); 
        }
    }
}