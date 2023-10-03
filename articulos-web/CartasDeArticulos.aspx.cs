    using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;

namespace articulos_web
{
    public partial class CartasDeArticulos : System.Web.UI.Page
    {
        public List<Producto> ListaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoService service = new ProductoService();
            ListaProducto = service.toListWithSP();

        }
    }
}