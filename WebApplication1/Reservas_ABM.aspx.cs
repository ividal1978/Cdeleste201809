using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;

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

            DdlPropiedad.DataSource = oNegocio.Get_Propiedades_CMB();
            DdlPropiedad.DataValueField = "Id";
            DdlPropiedad.DataTextField = "Descripcion";
            DdlPropiedad.DataBind();

        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inquilinos_ABM.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }
        protected void VerReserva(object sender, GridViewDeleteEventArgs e)
        {
            // buscar info por id
            int IdReserva = Convert.ToInt32(GvReservas.Rows[e.RowIndex].Cells[0].Text);
            //Obtener la info
            Reservas oRes = new Reservas();
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            oRes = oNegocio.Get_ReservasxId(IdReserva);
            //cargar la info
            TbFechaDesde.Text = oRes.FDesde.ToString("dd/MM/yyyy");
            TbFechaHasta.Text = oRes.FHasta.ToString("dd/MM/yyyy");
            DdlPropiedad.SelectedValue = oRes.IdPropiedad.ToString();
            TbInquilino.Text = oRes.Inquilino_Nombre + ", " + oRes.Inquilino_Apellido;
            TbMontoTotal.Text = oRes.Monto_Total.ToString();
            TbMontoReserva.Text = oRes.Monto_Reserva.ToString();
            RblPago.SelectedValue = oRes.Pagado.ToString();
            TbFechapago.Text = (oRes.FDePago > Convert.ToDateTime("1900-01-01") ? oRes.FDePago.ToString("dd/MM/yyyy") : "Impago");
            DdlEstados.SelectedValue = oRes.Estado;
            //desplazarme hacia abajo
            //posicionarme en el primer control de abajo
            
        }

        protected void CambioPagina(object sender, GridViewPageEventArgs e)
        {

            GvReservas.PageIndex = e.NewPageIndex;
            CargaGrilla();
        }

        protected void CargaGrilla()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            GvReservas.DataSource = oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            GvReservas.DataBind();
        }
    }
}