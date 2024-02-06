using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using domain;
using static System.Net.Mime.MediaTypeNames;

namespace service
{
    public class ProductoService
    {
        public List<Producto> toList(string id = "")
        {
            List<Producto> list = new List<Producto>();
            DataAccess data = new DataAccess();
            try
            {
                string query = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, C.Descripcion Categoria, M.Descripcion Marca From ARTICULOS A, CATEGORIAS C, MARCAS M Where IdCategoria = C.Id AND IdMarca = M.Id ";
                if (id != "")
                    query += "and A.Id = " + id;
                    
                data.setQuery(query);
                data.executeRead();
                while (data.Reader.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Codigo = (string)data.Reader["Codigo"];
                    aux.Nombre = (string)data.Reader["Nombre"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];
                    aux.ImagenUrl = (string)data.Reader["ImagenUrl"];
                    if (!string.IsNullOrEmpty(aux.ImagenUrl) && Uri.TryCreate(aux.ImagenUrl, UriKind.Absolute, out Uri uriResult) &&
                        (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    {
                        if (!ImageIsValid(uriResult))
                        {
                            aux.ImagenUrl = "https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg";
                        }
                    }
                    else
                    {
                        aux.ImagenUrl = "https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg";
                    }
                    aux.Precio = (decimal)data.Reader["Precio"];

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public bool existeCodigo(string codigo)
        {
            try
            {
                DataAccess data = new DataAccess();
                
                data.setQuery("Select * FROM ARTICULOS Where Codigo = '" + codigo + "'");
                data.executeRead();
                if (data.Reader.Read())
                    return true;
                else 
                    return false;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Producto> toListFavs(int userid) 
        {
            List<Producto> list = new List<Producto>();
            List<int> favlist = new List<int>();

            list = toList();

            FavoritoService favoritoService = new FavoritoService();

            favlist = favoritoService.toList(userid);

            list = list.Where(p => favlist.Contains(p.Id)).ToList();

            return list;
        }





        public List<Producto> toListWithSP()
        {
            List<Producto> list = new List<Producto>();
            DataAccess data = new DataAccess();
            try
            {
                data.setStoreProcedure("storedListar");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Codigo = (string)data.Reader["Codigo"];
                    aux.Nombre = (string)data.Reader["Nombre"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];
                    aux.ImagenUrl = (string)data.Reader["ImagenUrl"];
                    if (!string.IsNullOrEmpty(aux.ImagenUrl) && Uri.TryCreate(aux.ImagenUrl, UriKind.Absolute, out Uri uriResult) &&
                        (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    {
                        if (!ImageIsValid(uriResult))
                        {
                            aux.ImagenUrl = "https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg";
                        }
                    }
                    else
                    {
                        aux.ImagenUrl = "https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg";
                    }
                    aux.Precio = (decimal)data.Reader["Precio"];
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void eliminar(int id)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setQuery("delete From ARTICULOS where id = @id");
                datos.setParameter("id", id);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

        public int agregar(Producto nuevo)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) OUTPUT inserted.Id VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");
                datos.setParameter("@codigo", nuevo.Codigo);
                datos.setParameter("@nombre", nuevo.Nombre);
                datos.setParameter("@descripcion", nuevo.Descripcion);
                datos.setParameter("@idMarca", nuevo.Marca.Id);
                datos.setParameter("@idCategoria", nuevo.Categoria.Id);
                datos.setParameter("@imagenUrl", nuevo.ImagenUrl);
                datos.setParameter("@precio", nuevo.Precio);
                return datos.executeActionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

        public void addWithSP(Producto nuevo)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setStoreProcedure("storedAltaProducto");
                datos.setParameter("@codigo", nuevo.Codigo);
                datos.setParameter("@nombre", nuevo.Nombre);
                datos.setParameter("@descripcion", nuevo.Descripcion);
                datos.setParameter("@IdMarca", nuevo.Marca.Id);
                datos.setParameter("@IdCategoria", nuevo.Categoria.Id);
                datos.setParameter("@ImagenUrl", nuevo.ImagenUrl);
                datos.setParameter("@Precio", nuevo.Precio);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

        public void modificar(Producto prod)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setQuery("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where Id = @id");
                datos.setParameter("@codigo", prod.Codigo);
                datos.setParameter("@nombre", prod.Nombre);
                datos.setParameter("@descripcion", prod.Descripcion);
                datos.setParameter("@idMarca", prod.Marca.Id);
                datos.setParameter("@idCategoria", prod.Categoria.Id);
                datos.setParameter("@imagenUrl", prod.ImagenUrl);
                datos.setParameter("@precio", prod.Precio);
                datos.setParameter("@id", prod.Id);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

        public void modificarConSP(Producto prod)
        {
            DataAccess datos = new DataAccess();
            try
            {

                datos.setStoreProcedure("storedModificarArticulo");
                datos.setParameter("@codigo", prod.Codigo);
                datos.setParameter("@nombre", prod.Nombre);
                datos.setParameter("@descripcion", prod.Descripcion);
                datos.setParameter("@idMarca", prod.Marca.Id);
                datos.setParameter("@idCategoria", prod.Categoria.Id);
                datos.setParameter("@imagenUrl", prod.ImagenUrl);
                datos.setParameter("@precio", prod.Precio);
                datos.setParameter("@id", prod.Id);
                datos.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

        public List<Producto> filtrar(string campo, string criterio, string filtro, string tieneImagen)
        {
            List<Producto> list = new List<Producto>();
            DataAccess data = new DataAccess();

            try
            {
                string query = "Select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, C.Descripcion Categoria, M.Descripcion Marca From ARTICULOS A, CATEGORIAS C, MARCAS M Where IdCategoria = C.Id AND IdMarca = M.Id AND ";
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Menor que":
                                query += "Precio < " + filtro;
                                break;
                            case "Mayor que":
                                query += "Precio > " + filtro;
                                break;
                            default: //Igual que
                                query += "Precio = " + filtro;
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            default: // Que Contenga
                                query += "M.Descripcion like '%" + filtro + "%'";
                                break;
                            case "Que Termine Por":
                                query += "M.Descripcion like '%" + filtro + "'";
                                break;
                            case "Que Empiece Por":
                                query += "M.Descripcion like '" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            default: // Que Contenga
                                query += "C.Descripcion like '%" + filtro + "%'";
                                break;
                            case "Que Termine Por":
                                query += "C.Descripcion like '%" + filtro + "'";
                                break;
                            case "Que Empiece Por":
                                query += "C.Descripcion like '" + filtro + "%'";
                                break;
                        }
                        break;
                    default: //Nombre
                        switch (criterio)
                        {
                            default: // Que Contenga
                                query += "Nombre like '%" + filtro + "%'";
                                break;
                            case "Que Termine Por":
                                query += "Nombre like '%" + filtro + "'";
                                break;
                            case "Que Empiece Por":
                                query += "Nombre like '" + filtro + "%'";
                                break;
                        }
                        break;
                }
                switch (tieneImagen)
                {
                    case "Imagen Completa":
                        query += " AND (ImagenURL != '' OR ImagenURL IS NOT NULL)";
                        break;
                    case "Imagen Incompleta":
                        query += " AND (ImagenURL = '' OR ImagenURL IS NULL)";
                        break;
                    default:
                        break;
                }
                data.setQuery(query);
                data.executeRead();
                while (data.Reader.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Codigo = (string)data.Reader["Codigo"];
                    aux.Nombre = (string)data.Reader["Nombre"];
                    aux.Descripcion = (string)data.Reader["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Reader["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Reader["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Reader["Categoria"];
                    aux.ImagenUrl = (string)data.Reader["ImagenUrl"];
                    aux.Precio = (decimal)data.Reader["Precio"];
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }


        // Función para verificar si la imagen existe
        private bool ImageIsValid(Uri uri)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Configurar el agente de usuario
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0");

                    using (HttpResponseMessage response = httpClient.GetAsync(uri).Result)
                    {
                        response.EnsureSuccessStatusCode();

                        if (response.Content.Headers.ContentType != null && response.Content.Headers.ContentType.MediaType.StartsWith("image"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

    }
}
