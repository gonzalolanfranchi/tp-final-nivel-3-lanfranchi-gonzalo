﻿using domain;
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
        //public List<Producto> ListaProducto { get; set; }
        //public List<Marca> ListaMarcas { get; set; }
        //public List<Categoria> ListaCategorias { get; set; }
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

                try
                {
                    // Cargar los Drop Down List
                    MarcaService marcaService = new MarcaService();
                    List<Marca> listaMarcas = marcaService.toListWithSP();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaService categoriaService = new CategoriaService();
                    List<Categoria> listaCategorias = categoriaService.toListWithSP();

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
            }

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                ProductoService service = new ProductoService();
                //List<Producto> listaProductos = service.toList(id);
                //Producto prod = listaProductos[0];
                Producto prod = (service.toList(id))[0];

                lblTitulo.Text = "Detalle del Producto";
                txtId.Text = prod.Id.ToString();
                txtNombre.Text = prod.Nombre;
                txtNombre.Enabled= false;
                txtImagenUrl.Text = prod.ImagenUrl.ToString();
                txtImagenUrl.Enabled= false;
                txtPrecio.Text = "$" + prod.Precio.ToString("0.00");
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //ProductoService service = new ProductoService();
            //ListaProducto = service.toListWithSP();

            //Producto prod = ListaProducto.FirstOrDefault(p => p.Id == int.Parse(Request.QueryString["id"]));

            modificar = true;
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Producto prod = new Producto();
                ProductoService service = new ProductoService();
                prod.Codigo = txtCodigo.Text;
                prod.Nombre = txtNombre.Text;
                prod.Descripcion = txtDescripcion.Text;
                prod.ImagenUrl = txtImagenUrl.Text;
                prod.Marca = new Marca();
                prod.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                prod.Categoria = new Categoria();
                prod.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                prod.Precio = int.Parse(txtPrecio.Text); // esto esta fallando cuando modifico porque lo cargo con $


                if (Request.QueryString["id"] != null)
                    service.modificarConSP(prod);
                else
                    service.addWithSP(prod);

                Response.Redirect("ListaArticulos.aspx", false);
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
    }
}
