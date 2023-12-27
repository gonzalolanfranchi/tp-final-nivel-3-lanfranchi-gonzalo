using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace service
{
    public class FavoritoService
    {
        public List<int> toList(Usuario user)
        {
            List<int> list = new List<int>();
            DataAccess datos = new DataAccess();
            try
            {
                datos.setQuery("Select IdArticulo From FAVORITOS WHERE IdUser = " + user.Id);
                datos.executeRead();
                while (datos.Reader.Read())
                {
                    list.Add((int)datos.Reader["IdArticulo"]);
                }
                return list;
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

        public void addFavorite(int idUser, int idProd)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("INSERT INTO FAVORITOS values ('" + idUser + "', '" + idProd + "')");
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

        public void removeFavorite(int idUser, int idProd)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("DELETE FROM FAVORITOS WHERE IdUser = '" + idUser + "' AND IdArticulo = '" + idProd + "'");
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
