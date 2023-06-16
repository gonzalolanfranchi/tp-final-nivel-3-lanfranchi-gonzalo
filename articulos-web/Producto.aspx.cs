using domain;
using service;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Producto> ListaProducto { get; set; }
        public List<Marca> ListaMarcas { get; set; }
        public List<Categoria> ListaCategorias { get; set; }

        public string Textareadisoren = "";
        public bool modificar = false;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                //Me guardo la pagina previa
                if (Request.UrlReferrer != null)
                {
                    ViewState["PreviousPage"] = Request.UrlReferrer.ToString();

                }



                // Cargar los Drop Down List
                MarcaService marcaService = new MarcaService();
                ListaMarcas = marcaService.toListWithSP();

                ddlMarca.Items.Add("");

                foreach (Marca marca in ListaMarcas)
                {
                    ddlMarca.Items.Add(marca.Descripcion);
                }
                //LUEGO, MAS ADELANTE, ESTARIA BUENO ALGUN BOTON PARA AGREGAR MARCAS 

                CategoriaService categoriaService = new CategoriaService();
                ListaCategorias = categoriaService.toListWithSP();

                ddlCategoria.Items.Add("");

                foreach (Categoria categoria in ListaCategorias)
                {
                    ddlCategoria.Items.Add(categoria.Descripcion);
                }
            }


            if (Request.QueryString["id"] != null)
            {
                ProductoService service = new ProductoService();
                ListaProducto = service.toListWithSP();


                Producto prod = ListaProducto.FirstOrDefault(p => p.Id == int.Parse(Request.QueryString["id"]));

                lblTitulo.Text = "Detalle del Producto";
                txtId.Text = prod.Id.ToString();
                txtId.Enabled = false;
                txtNombre.Text = prod.Nombre.ToString();
                txtNombre.Enabled= false;
                txtImagenUrl.Text = prod.ImagenUrl.ToString();
                txtImagenUrl.Enabled= false;
                txtPrecio.Text = "$" + prod.Precio.ToString("0.00");
                txtPrecio.Enabled= false;
                txtCodigo.Text = prod.Codigo.ToString();
                txtCodigo.Enabled= false;
                imgArticulo.ImageUrl = prod.ImagenUrl.ToString();
                Textareadisoren = "disabled";
                ddlMarca.SelectedValue = prod.Marca.Descripcion;
                ddlMarca.Enabled= false;
                ddlCategoria.SelectedValue = prod.Categoria.Descripcion;
                ddlCategoria.Enabled= false;
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ProductoService service = new ProductoService();
            ListaProducto = service.toListWithSP();


            Producto prod = ListaProducto.FirstOrDefault(p => p.Id == int.Parse(Request.QueryString["id"]));

            modificar = true;
            lblTitulo.Text = "Modificar Producto";
            txtId.Enabled = true;
            txtNombre.Enabled = true;
            txtImagenUrl.Enabled = true;
            txtPrecio.Enabled = true;
            txtCodigo.Enabled = true;
            Textareadisoren = "";
            ddlMarca.Enabled = true;
            ddlCategoria.Enabled = true;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)
            {
                string previousPage = ViewState["PreviousPage"].ToString();
                Response.Redirect(previousPage);
            }
            else
            {
                // Si no hay una página anterior, redirige al usuario a una página predeterminada.
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
