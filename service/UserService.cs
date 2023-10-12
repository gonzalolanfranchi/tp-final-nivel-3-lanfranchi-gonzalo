using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				data.setQuery("Select Id, admin FROM USERS Where email = @email AND pass = @pass");
				data.setParameter("@email", usuario.Email);
                data.setParameter("@pass", usuario.Pass);
                data.executeRead();
                while (data.Reader.Read())
                {
                    usuario.Id = (int)data.Reader["Id"];
                    usuario.Admin = (bool)(data.Reader["admin"]) == true ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
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



    }
}
