using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Autenticar();


            }
        }
        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {

                LbFecha.Text = $"Fecha:{ DateTime.Now} ";
                LbUsuario.Text = $"Usuario:{(Session["usuario"] != null ? Session["usuario"].ToString() : "")}";
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }

        protected void btnAlquileres_Click(object sender, EventArgs e)
        {
            // Varaibles Para Alquileres
            // Fecha desde Fecha / Fecha Hasta / Popiedad / Inquilino
        }

        protected void btnInquilinos_Click(object sender, EventArgs e)
        {
            // Fecha desde / Fecha Hasta /Propiedad / Nombre / Validacion / Cantidad de Reservas
        }

        protected void btnConsultas_Click(object sender, EventArgs e)
        {
            // Fecha desde  / Fecha Hasta / Tipo de consulta / Propiedad
        }
    }
}