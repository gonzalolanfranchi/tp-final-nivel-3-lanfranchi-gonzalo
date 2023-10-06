using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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



    }
}
