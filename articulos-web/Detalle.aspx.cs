using domain;
using service;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Detalle : System.Web.UI.Page
    {
        //public List<Producto> ListaProducto { get; set; }
        //public List<Marca> ListaMarcas { get; set; }
        //public List<Categoria> ListaCategorias { get; set; }

        
        
        public CultureInfo ci = new CultureInfo("es-AR");

        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == "" || Request.QueryString["id"] == null)
                {
                    if (Session["user"] == null || ((Usuario)Session["user"]).Admin != TipoUsuario.ADMIN)
                    {
                        Response.Redirect("CartasDeArticulos.aspx", false);
                        return;
                    }
                    Session.Add("modificar", true);
                }
                //Me guardo la pagina previa
                if (Request.UrlReferrer != null)
                {
                    ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
                    string urlddvgo = Request.UrlReferrer.ToString();
                    Session.Add("ddvgo", urlddvgo);
                }
                try
                {
                    // Cargar los Drop Down List
                    MarcaService marcaService = new MarcaService();
                    List<Marca> listaMarcas = marcaService.toList();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaService categoriaService = new CategoriaService();
                    List<Categoria> listaCategorias = categoriaService.toList();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    throw;
                    //redireccion a otra pantalla
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    ProductoService service = new ProductoService();
                    //List<Producto> listaProductos = service.toList(id);
                    //Producto prod = listaProductos[0];
                    Producto prod = (service.toList(id))[0];
                    Session["modificar"] = false;
                    lblTitulo.Text = "Detalle del Producto";
                    txtId.Text = prod.Id.ToString();
                    txtNombre.Text = prod.Nombre;
                    txtNombre.Enabled= false;
                    txtImagenUrl.Text = prod.ImagenUrl.ToString();
                    txtImagenUrl.Enabled= false;
                    txtPrecio.Text = prod.Precio.ToString("C2", ci);
                    txtPrecio.Enabled= false;
                    txtCodigo.Text = prod.Codigo.ToString();
                    txtCodigo.Enabled= false;
                    imgArticulo.ImageUrl = prod.ImagenUrl.ToString();
                    txtDescripcion.Text = prod.Descripcion;
                    txtDescripcion.ReadOnly = true;
                    ddlMarca.SelectedValue = prod.Marca.Id.ToString();
                    ddlMarca.Enabled= false;
                    ddlCategoria.SelectedValue = prod.Categoria.Id.ToString();
                    ddlCategoria.Enabled= false;
                }  
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Session["modificar"] = true;
            lblTitulo.Text = "Modificar Producto";
            txtNombre.Enabled = true;
            txtImagenUrl.Enabled = true;
            txtPrecio.Enabled = true;
            txtCodigo.Enabled = true;
            ddlMarca.Enabled = true;
            ddlCategoria.Enabled = true;
            txtDescripcion.ReadOnly = false;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            txtDescripcion.Enabled = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["ddvgo"] != null)
            {
                //string previousPage = ViewState["PreviousPage"].ToString();
                Response.Redirect((string)Session["ddvgo"]);
            }
            else
            {
                if (Session["user"] != null && ((domain.Usuario)Session["user"]).Admin == domain.TipoUsuario.ADMIN)
                    Response.Redirect("ListaArticulos.aspx");
                else
                    Response.Redirect("CartasDeArticulos.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto prod = new Producto();
                ProductoService service = new ProductoService();
                if (txtCodigo.Text == "")
                    prod.Codigo = "";
                else
                    prod.Codigo = txtCodigo.Text;

                prod.Nombre = txtNombre.Text;

                if (txtDescripcion.Text == "")
                    prod.Descripcion = "";
                else
                    prod.Descripcion = txtDescripcion.Text;
                if (txtImagenUrl.Text == "")
                    prod.ImagenUrl = "";
                else
                    prod.ImagenUrl = txtImagenUrl.Text;

                prod.Marca = new Marca();
                prod.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                prod.Categoria = new Categoria();
                prod.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                string precio = txtPrecio.Text;
                prod.Precio = decimal.Parse(formatPrice(precio));
                if (Request.QueryString["id"] != null)
                {
                    prod.Id = int.Parse(Request.QueryString["id"]);
                    service.modificar(prod);
                    Response.Redirect("Detalle.aspx?id=" + prod.Id);
                }
                else
                {
                    if (service.existeCodigo(prod.Codigo))
                    {
                        MostrarAlertaDesdeServer("Ya existe un producto con ese codigo.");
                        return;
                    }
                    int id = service.agregar(prod);
                    Response.Redirect("Detalle.aspx?id=" + id, false);
                }
                //Response.Redirect("ListaArticulos.aspx" + "?search=" + (Session["search"] != null ? Session["search"].ToString() : ""), false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //pagina de error
            }    
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        public string formatPrice(string precio)
        {
            if (precio.Contains(".") && precio.Contains(","))
                precio = precio.Replace(".", "").Replace("$", "").Trim();
            else
                precio = precio.Replace(".", ",").Replace("$", "").Trim();
            return precio;
        }

        private void MostrarAlertaDesdeServer(string mensaje)
        {
            // Usa el ScriptManager para registrar el script en el lado del servidor.
            string script = $"alert('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerAlertScript", script, true);
        }
    }
}
