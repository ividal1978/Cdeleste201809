using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) => Visualizar();
       

        protected void Login()
        {

            string usuario = tbUsuario.Text;
            string password = tbPassword.Text;
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            if (usuario.Length > 0)
            {
                var Acceso = oNegocio.GetUsuario(usuario, password);
                if (Acceso != null && Acceso.Usuario != null)
                {
                    Session["usuario"] = Acceso.Usuario;
                    Session["fInicioUsuario"] = DateTime.Now;

                   // lbTituloUsuario.Text ="Usuario: "+ Acceso.Usuario;
                   // lbFecha.Text = "Fecha: " + DateTime.Now;
                    LbError.Text = "";
                    Visualizar();

                }
                else
                {
                    LbError.Text = "Error al Autenticarse, Password o Usuario incorrecto";
                }
            }
            else
            {
                LbError.Text = "Debe completar los campos de usuario y password";
            }
        }
        protected void Visualizar()
        {
            
            if (Session["usuario"]!=null)
            {
                panelMenu.Visible = true;
                panelLogin.Visible = false;
                lbTituloUsuario.Text = "Usuario: " + (Session["usuario"] != null? Session["usuario"].ToString():"");
                lbFecha.Text += " " + DateTime.Now;

            }
            else
            {
                panelMenu.Visible = false;
                panelLogin.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        protected void btnNoticias_Click(object sender, EventArgs e) => Response.Redirect("Noticias_ABM.aspx");

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["fInicioUsuario"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void btnPropiedades_Click(object sender, EventArgs e) => Response.Redirect("Propiedades_ABM.aspx");

        protected void btnConsultas_Click(object sender, EventArgs e) => Response.Redirect("Consultas_Admin.aspx");

        protected void btnInquilinos_Click(object sender, EventArgs e) => Response.Redirect("Inquilinos_ABM.aspx");
        
    }
}