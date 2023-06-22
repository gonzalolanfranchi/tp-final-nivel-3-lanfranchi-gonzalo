using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using service;

namespace articulos_web
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoService service = new ProductoService();
            dgvArticulos.DataSource = service.toListWithSP();
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectionIndexChanged(object sender, EventArgs e)
        {
            //var algo = dgvArticulos.SelectedRow.Cells[0].Text;
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Producto.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
    }
}