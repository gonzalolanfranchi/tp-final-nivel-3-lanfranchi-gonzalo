using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;

namespace articulos_web
{
    public partial class PaginaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["user"] == null)
            {
                Session.Add("error", "Debes loguearte para acceder a esa página");
                Response.Redirect("Error.aspx", false);
            }else if (((Usuario)Session["user"]).Admin != TipoUsuario.ADMIN)
            {
                Session.Add("error", "Debes ser ADMIN para acceder a esa página");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}