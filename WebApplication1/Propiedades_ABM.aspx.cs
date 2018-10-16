using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Propiedades_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Autenticar();
            if (!Page.IsPostBack)
            {
                CargarPropiedades();
              

            }
        }

        /// <summary>
        /// Verifica si tengo usuario logueado sino lo envia al menu para loguearse
        /// </summary>
        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {
                lbUsuario.Text = "Usuario: " + (Session["usuario"] != null ? Session["usuario"].ToString() : "");
                lbFechaPagina.Text = "Fecha: " + DateTime.Now;
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }

        protected void CargarPropiedades()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            gvPropiedades.DataSource = oNegocio.Get_Propiedades_All();
            gvPropiedades.DataBind();
        }
    }
}