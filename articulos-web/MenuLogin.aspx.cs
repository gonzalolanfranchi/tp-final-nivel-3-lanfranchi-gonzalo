using domain;
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
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    lblTitulo.Text = "Bienvenido " + ((Usuario)Session["user"]).Email;
                }               
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false); 
        }

        protected void btnPaginaNormal_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaNormal.aspx", false);
        }
        protected void btnPaginaAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaAdmin.aspx", false);

        }
    }
}