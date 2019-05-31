using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reservas_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Autenticar();
                CargaCombos();
            }
        }

        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {
                LbUsuario.Text = "Usuario: " + (Session["usuario"] != null ? Session["usuario"].ToString() : "");
                LbFecha.Text = "Fecha: " + DateTime.Now;
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }

        protected void CargaCombos()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            DdlPropiedadAlquiler.DataSource = oNegocio.Get_Propiedades_CMB();
            DdlPropiedadAlquiler.DataValueField = "Id";
            DdlPropiedadAlquiler.DataTextField = "Descripcion";
            DdlPropiedadAlquiler.DataBind();
            DdlPropiedadAlquiler.Items.Insert(0, new ListItem("Todas", "-1"));
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inquilinos_ABM.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            //Debo chequear el combo propiedades
            GvReservas.DataSource = oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            GvReservas.DataBind();
        }
        protected void VerReserva(object sender, GridViewDeleteEventArgs e)
        { }
    }
}