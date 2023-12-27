using domain;
using service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Producto> ListaProducto { get; set; }
        public List<int> ListaFavoritos { get; set; }
        public List<Producto> ListaFiltrada { get; set; }
        public CultureInfo ci = new CultureInfo("es-AR");
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Session.Add("error", "Debes iniciar sesion para acceder a esta pagina");
                Response.Redirect("Login.aspx", false);
                return;
            }
            
            
            
            
            FiltroAvanzado = checkFiltroAvanzado.Checked;
            ProductoService service = new ProductoService();

            //repetidor
            //repRepetidor.DataSource = ListaFiltrada;
            //repRepetidor.DataBind();



            if (!IsPostBack)
            {
                FavoritoService favService = new FavoritoService();
                ListaFavoritos = favService.toList(((Usuario)Session["user"]).Id);

                ListaProducto = service.toList();

                ListaFiltrada = ListaProducto.Where(p => ListaFavoritos.Contains(p.Id)).ToList();
                //repetidor
                repRepetidor.DataSource = ListaFiltrada;
                repRepetidor.DataBind();
                if (Session["search"] == null)
                {
                    FiltroAvanzado = false;
                    ddlCriterio.Items.Add("Que Contenga");
                    ddlCriterio.Items.Add("Que Empiece Por");
                    ddlCriterio.Items.Add("Que Termine Por");
                }
            }





        }

        

        protected void checkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = checkFiltroAvanzado.Checked;
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltro.Text == "")
            {
                ProductoService service = new ProductoService();
                ListaFiltrada = service.toListFavs(((Usuario)Session["user"]).Id);





                repRepetidor.DataSource = ListaFiltrada;
                repRepetidor.DataBind();
            }
            else
                filtrarTexto(txtFiltro.Text);
        }

        public void filtrarTexto(string filtro)
        {

            if (Session["search"] != null)
            {
                if (checkFiltroAvanzado.Checked)
                {
                    
                    
                    ProductoService service = new ProductoService();
                    ListaFiltrada = service.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltro.Text, ddlImagen.SelectedItem.ToString());
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "focusScript", "setFocusOnFilter();", true);
                    return;
                }
            }


            if (validarFiltro())
            {
                //List<Producto> listaFiltrada = new List<Producto>();
                if (!checkFiltroAvanzado.Checked)
                {
                    ProductoService service = new ProductoService();
                    ListaProducto = service.toList();


                    FavoritoService favService = new FavoritoService();
                    ListaFavoritos = favService.toList(((Usuario)Session["user"]).Id);


                    ListaFiltrada = ListaProducto.Where(p => ListaFavoritos.Contains(p.Id)).ToList();
                    //repetidor
                    repRepetidor.DataSource = ListaFiltrada;

                    ListaFiltrada = ListaFiltrada.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    repRepetidor.DataSource = ListaFiltrada;
                    repRepetidor.DataBind();
                }
                else
                {
                    ProductoService service = new ProductoService();
                    ListaFiltrada = service.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltro.Text, ddlImagen.SelectedItem.ToString());
                    repRepetidor.DataSource = ListaFiltrada;
                    repRepetidor.DataBind();
                }
                //dgvArticulos.DataSource = listaFiltrada;
                //Session.Add("filtro", ListaFiltrada);
                //Session.Add("search", txtFiltro.Text);
                //dgvArticulos.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusScript", "setFocusOnFilter();", true);
            }

        }
        private bool validarFiltro()
        {
            if (checkFiltroAvanzado.Checked)
            {
                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    if (Regex.IsMatch(txtFiltro.Text, @"[a-zA-Z]"))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El texto ingresado contiene letras. Por favor, ingrese solo numeros para filtrar por Precio. ');", true);
                        return false;
                    }
                }
            }
            return true;
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

        public string urlFav(int id)
        {
            if (Session["favs"] == null || !((List<int>)Session["favs"]).Contains(id))
                return ResolveUrl("~/Images/favorito.png");
            else
                return ResolveUrl("~/Images/favoritofull.png");

        }

        public bool isFav(int id)
        {
            if (Session["favs"] == null || !((List<int>)Session["favs"]).Contains(id))
                return false;
            else
                return true;

        }

        protected void AlternarFavorito_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["user"] != null)
            {
                ImageButton imgBtn = (ImageButton)sender;
                int productId = int.Parse(imgBtn.CommandArgument);

                FavoritoService favservice = new FavoritoService();

                if (!isFav(productId))
                {
                    favservice.addFavorite(((Usuario)Session["user"]).Id, productId);
                    Session.Remove("favs");
                    Session.Add("favs", favservice.toList(((Usuario)Session["user"]).Id));
                    //repetidor
                    filtrarTexto(txtFiltro.Text);
                    repRepetidor.DataSource = ListaFiltrada;
                    repRepetidor.DataBind();

                }
                else
                {
                    favservice.removeFavorite(((Usuario)Session["user"]).Id, productId);

                    Session.Remove("favs");
                    Session.Add("favs", favservice.toList(((Usuario)Session["user"]).Id));
                    //repetidor
                    filtrarTexto(txtFiltro.Text);
                    repRepetidor.DataSource = ListaFiltrada;
                    repRepetidor.DataBind();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debes iniciar sesion para agregar productos a favoritos.');", true);
            }
        }


    }
}
