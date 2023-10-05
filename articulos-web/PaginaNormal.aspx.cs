using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class PaginaNormal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                Session.Add("error", "Debes loguearte para acceder a esa página");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}