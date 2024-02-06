using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using domain;
using service;

namespace service
{
    public class UserService
    {
        public bool Loguear(Usuario usuario)
        {
			DataAccess data = new DataAccess();
			try
			{
				data.setQuery("Select Id, nombre, apellido, urlImagenPerfil, admin FROM USERS Where email = @email AND pass = @pass");
				data.setParameter("@email", usuario.Email);
                data.setParameter("@pass", usuario.Pass);
                data.executeRead();
                while (data.Reader.Read())
                {
                    usuario.Id = (int)data.Reader["Id"];
                    usuario.Admin = (bool)(data.Reader["admin"]) == true ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    if(data.Reader["nombre"] != DBNull.Value)
                        usuario.Nombre = (string)data.Reader["nombre"];
                    if (data.Reader["apellido"] != DBNull.Value)
                        usuario.Apellido = (string)data.Reader["apellido"];
                    if (data.Reader["urlImagenPerfil"] != DBNull.Value)
                        usuario.UrlImagenPerfil = (string)data.Reader["urlImagenPerfil"];
                    else
                        usuario.UrlImagenPerfil = "data:image/png;base64,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";
                    return true;
                }
                return false;
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

        public int CrearCuenta(Usuario usuario)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("INSERT INTO USERS (email, pass, nombre, apellido, urlImagenPerfil, admin) OUTPUT inserted.Id VALUES (@email, @pass, ISNULL(@nombre, ''), ISNULL(@apellido, ''), '', 0)");
                data.setParameter("@email", usuario.Email);
                data.setParameter("@pass", usuario.Pass);
                data.setParameter("@nombre", usuario.Nombre);
                data.setParameter("@apellido", usuario.Apellido);
                return data.executeActionScalar();
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

        public void modificarUsuario(Usuario user)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("UPDATE USERS set email = @email, pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil Where Id = @Id");
                data.setParameter("@email", user.Email);
                data.setParameter("@pass", user.Pass);
                data.setParameter("@nombre", user.Nombre);
                data.setParameter("@apellido", user.Apellido);
                data.setParameter("@urlImagenPerfil", user.UrlImagenPerfil);
                data.setParameter("@Id", user.Id);
                data.executeAction();
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

        public bool comprobarSiExiste(string email)
        {
            DataAccess data = new DataAccess();
            data.setQuery("Select * From USERS where email = @email");
            data.setParameter("@email", email);
            data.executeRead();

            if(data.Reader.Read())
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
