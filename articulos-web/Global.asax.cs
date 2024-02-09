using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace articulos_web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string defaultPort = "5024"; // Puedes obtener este valor de cualquier lugar, como una base de datos o un archivo de configuración
            string baseUrl = $"http://localhost:{defaultPort}/";
            // Aquí puedes realizar cualquier configuración adicional de la aplicación
            // Por ejemplo, configurar el puerto base para las rutas de la aplicación
            RouteTable.Routes.MapPageRoute("Default", "", "~/Default.aspx");
        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Session.Add("error", exc);
            Server.Transfer("Error.aspx");
        }
    }
}