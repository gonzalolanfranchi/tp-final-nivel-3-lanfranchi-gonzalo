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

        protected void Page_Load(object sender, EventArgs e)
        {    
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

            if (Request.QueryString["id"] != null)
            {
                ProductoService service = new ProductoService();
                ListaProducto = service.toListWithSP();


                Producto prod = ListaProducto.FirstOrDefault(p => p.Id == int.Parse(Request.QueryString["id"]));

                lblTitulo.Text = "Modificar Producto";
                txtId.Text = prod.Id.ToString();
                txtNombre.Text = prod.Nombre.ToString();

                
            }
            
        }        
    }
}
