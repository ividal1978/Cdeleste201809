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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login()
        {

            string usuario = "";//usuarioInput.Value.ToString(); //Request.QueryString["usuarioInput"];
            string password = "";//passwordInput.Value.ToString(); //Request.QueryString["passwordInput"];
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            if (usuario.Length > 0)
            {
                var Acceso = oNegocio.GetUsuario(usuario, password);
                if (Acceso != null)
                {
                    Session["usuario"] = Acceso.Usuario;
                    Session["fInicioUsuario"] = DateTime.Now;
                    Response.Redirect("Menu.aspx");

                }
            }
        }
    }
}