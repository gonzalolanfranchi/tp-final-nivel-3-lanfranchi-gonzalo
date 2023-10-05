using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public enum TipoUsuario
    {
        NORMAL = 0,
        ADMIN = 1
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UrlImagenPerfil { get; set; }
        public TipoUsuario Admin { get; set; }


        public Usuario(string user, string pass, bool admin) 
        {
            Email = user;
            Pass = pass;
            Admin = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }

    
}
