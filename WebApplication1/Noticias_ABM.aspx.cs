using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Noticias_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Autenticar();
            //Cargar Noticias
            if (!Page.IsPostBack)
            {
                CargarNoticias();

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

        /// <summary>
        /// Carga todas las noticias en la tabla
        /// </summary>
        protected void CargarNoticias()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            dgNoticias.DataSource = oNegocio.GetNoticias_All(ddlTipoNoticia.SelectedValue.ToString());
            dgNoticias.DataBind();

        }

        protected void ddlTipoNoticia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNoticias();
        }
    }
}