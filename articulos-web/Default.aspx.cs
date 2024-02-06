﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("CartasDeArticulos.aspx", false);
        }

        protected void IrALosProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaArticulos.aspx", false);
        }
    }
}