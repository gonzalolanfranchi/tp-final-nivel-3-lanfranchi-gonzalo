using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using service;
using domain;

namespace articulos_web
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public CultureInfo ci = new CultureInfo("es-AR");
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoService service = new ProductoService();
            Session.Add("productos", service.toListWithSP());
            dgvArticulos.DataSource = Session["productos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectionIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Producto.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["productos"];
            List<Producto> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource= listaFiltrada;
            dgvArticulos.DataBind();
        }
    }
}