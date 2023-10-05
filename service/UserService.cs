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
                    usuario.Admin = (int)(data.Reader["admin"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
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
    }
}
