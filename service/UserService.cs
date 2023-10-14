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
                    usuario.Nombre = (string)data.Reader["nombre"];
                    usuario.Apellido = (string)data.Reader["apellido"];
                    usuario.UrlImagenPerfil = (string)data.Reader["urlImagenPerfil"];
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
    }
}
