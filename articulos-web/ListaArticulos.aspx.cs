using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using service;
using domain;
using System.Text.RegularExpressions;

namespace articulos_web
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public CultureInfo ci = new CultureInfo("es-AR");
        public bool FiltroAvanzado { get; set; }
        public string error { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = checkFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                ProductoService service = new ProductoService();
                Session.Add("productos", service.toListWithSP());
                dgvArticulos.DataSource = Session["productos"];
                dgvArticulos.DataBind();
                ddlCriterio.Items.Add("Que Contenga");
                ddlCriterio.Items.Add("Que Empiece Por");
                ddlCriterio.Items.Add("Que Termine Por");
                //ddlCriterio.SelectedItem = "Que Contenga";
            }
            
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
            if (txtFiltro.Text == "")
            {
                dgvArticulos.DataSource = Session["productos"];
                dgvArticulos.DataBind();
                return;
            }

            if (validarFiltro())
            {
                if (!checkFiltroAvanzado.Checked)
                {
                    List<Producto> lista = (List<Producto>)Session["productos"];
                    List<Producto> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    dgvArticulos.DataSource = listaFiltrada;
                    dgvArticulos.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "focusScript", "setFocusOnFilter();", true);
                }
                else
                {
                    ProductoService service = new ProductoService();
                    dgvArticulos.DataSource = service.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltro.Text);
                    dgvArticulos.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "focusScript", "setFocusOnFilter();", true);
                }
            }
        }

        private bool validarFiltro()
        {
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                if (Regex.IsMatch(txtFiltro.Text, @"[a-zA-Z]"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El texto ingresado contiene letras. Por favor, ingrese solo numeros para filtrar por Precio. ');", true);
                    return false;
                }
            }

            return true;
        }

        protected void checkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = checkFiltroAvanzado.Checked;


            //if (checkFiltroAvanzado.Checked)
            //    FiltroAvanzado = true;
            //else
            //    FiltroAvanzado = false;

            
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            switch (ddlCampo.SelectedValue)
            {
                default: //Nombre, Marca o Categoria
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Termina con");
                    ddlCriterio.Items.Add("Comienza con");
                    break;
                case "Precio":
                    ddlCriterio.Items.Add("Menor que");
                    ddlCriterio.Items.Add("Mayor que");
                    ddlCriterio.Items.Add("Igual que");
                    break;
            }
        }

        

    }
}