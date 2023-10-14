using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using domain;
using service;

namespace service
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("gonzalanfranchi@gmail.com", "mgqm txri fean lyjl"); //mgqm txri fean lyjl
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
           
        }

        public void armarCorreo(string emailDestino, string asunto, HtmlString mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("gonzalanfranchi@gmail.com", "Gonzalo Lanfranchi");
            email.CC.Add("gonzalanfranchi@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = cuerpo;
            email.Body = "<h1>Informe de contacto</h1><br>Gracias por dejarnos tu mensaje: <br><br>" + mensaje + "<br><br>Te responderemos a la brevedad.";
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public void armarCorreoNuevaCuenta(string emailDestino, string contraseña)
        {
            email = new MailMessage();
            email.From = new MailAddress("gonzalanfranchi@gmail.com", "Gonzalo Lanfranchi");
            email.To.Add(emailDestino);
            email.Subject = "Registro exitoso";
            email.IsBodyHtml = true;
            email.Body = "<h2>Tu usuario fue creado con éxito!<br></h2><p>Muchas gracias por registrarte en nuestra web.<br></p><p>A partir de ahora, vas a poder iniciar sesion con tus credenciales:</p><p>Email: " + emailDestino + "</p><p>Contraseña: " + contraseña + "</p><p>Nos vemos en la web!</p>";
        }

        public void armarCorreoModificarCuenta(string emailDestino, string emailNuevo)
        {
            email = new MailMessage();
            email.From = new MailAddress("gonzalanfranchi@gmail.com", "Gonzalo Lanfranchi");
            email.To.Add(emailDestino);
            email.CC.Add(emailNuevo);
            email.Subject = "Modificacion exitosa!";
            email.IsBodyHtml = true;
            email.Body = "<h2>Tu usuario fue modificado con éxito</h2><p>Modificaste tus datos mediante nuestra web.<br></p><p>Si no fuiste vos, ponete en contacto con el soporte inmediatamente.<br></p><p>Saludos!</p>";
        }
    }
}
