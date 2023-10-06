using domain;
using service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    txtEmail.Text = ((Usuario)Session["user"]).Email;
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            HtmlString mensaje = new HtmlString(txtMensaje.Text);
            emailService.armarCorreo(txtEmail.Text, txtAsunto.Text, mensaje);
            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
                //Response.Redirect("Error.aspx", false);
            }
        }
    }
}