﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using service;

namespace articulos_web
{
    public partial class Login : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("MenuLogin.aspx");
            }

            if (Session["error"] != null)
            {
                txtMensaje.Text = Session["error"].ToString();
                Session.Remove("error");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["cc"] != null && Request.QueryString["cc"] == "y")
                {
                    Session["crearcuenta"] = null;
                    toggleCrearCuenta();
                }
                else
                {
                    Session["crearcuenta"] = null;
                }
                establecerBotones();
            }
            

        }

        public bool quiereCrearCuenta()
        {
            if (Session["crearcuenta"] != null && (bool)Session["crearcuenta"])
                return true;
            else 
                return false; 
        }

        public void toggleCrearCuenta()
        {
            if (Session["crearcuenta"] == null)
            {
                Session.Add("crearcuenta", true);
            }
            else
            {
                if((bool)Session["crearcuenta"])
                    Session["crearcuenta"] = false;
                else
                    Session["crearcuenta"] = true;
            }
        }

        public void establecerBotones()
        {
            if (!quiereCrearCuenta())
            {
                btnLogin.Text = "Iniciar Sesion";
                btnCrearCuenta.Text = "Crear Cuenta";
            }
            else
            {
                btnLogin.Text = "Crear Cuenta";
                btnCrearCuenta.Text = "Iniciar Sesion";
            }
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            toggleCrearCuenta();
            establecerBotones();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user;
            UserService service = new UserService();
            try
            {
                user = new Usuario(txtEmail.Text, txtPassword.Text, false);
                if (quiereCrearCuenta())
                {
                    // CREAR CUENTA
                    try
                    {
                        user.Nombre = txtNombre.Text;
                        user.Apellido = txtApellido.Text;
                        user.Id = service.CrearCuenta(user);
                        Session.Add("user", user);


                        EmailService emailService = new EmailService();
                        emailService.armarCorreoNuevaCuenta(user.Email, user.Pass);
                        emailService.enviarEmail();

                        Response.Redirect("MenuLogin.aspx", false);

                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex.ToString());    
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    //LOGUEAR 
                    try
                    {
                        if (service.Loguear(user))
                        {
                            Session.Add("user", user);

                            //CARGAR FAVORITOS A LA SESION
                            FavoritoService favservice = new FavoritoService();
                            Session.Add("favs", favservice.toList(user.Id));


                            Response.Redirect("Default.aspx", false);  
                        }else
                        {
                            txtMensaje.Text = "Email o Contraseña incorrectos.";
                            //Session.Add("error", "Email o Password incorrectos.");
                            //Response.Redirect("Error.aspx", false);
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}