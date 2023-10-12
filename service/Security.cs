using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using domain;

namespace service
{
    public static class Security
    {
        public static bool sesionActiva(object user)
        {
            Usuario userr = user != null ? (Usuario)user : null;
            if (userr != null && userr.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object user)
        {
            Usuario userr = user != null ? (Usuario)user : null;
            if (userr != null && userr.Admin == TipoUsuario.ADMIN)
                return true;
            else
                return false; 
        }
    }
}
