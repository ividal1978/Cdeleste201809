using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;
using System.Web.Services;
using DayPilot.Web;


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
                TbFechaAlquiler.Text = DateTime.Now.ToString("dd/MM/yyyy");
                HndId.Value = "-1";
                CargarRecusosCalendario();
                CargarCalendario();
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
            CargarCalendario();
        }
        protected void VerReserva(object sender, GridViewDeleteEventArgs e)
        {
            // buscar info por id
            int IdReserva = Convert.ToInt32(GvReservas.Rows[e.RowIndex].Cells[0].Text);
            HndId.Value = IdReserva.ToString();
            //Obtener la info
            Reservas oRes = new Reservas();
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            oRes = oNegocio.Get_ReservasxId(IdReserva);
            //cargar la info
            TbFechaDesde.Text = oRes.FDesde.ToString("dd/MM/yyyy");
            TbFechaHasta.Text = oRes.FHasta.ToString("dd/MM/yyyy");
            DdlPropiedad.SelectedValue = oRes.IdPropiedad.ToString();
            TbInquilino.Text = oRes.Inquilino_Nombre + ", " + oRes.Inquilino_Apellido + " #"+oRes.IdInquilino.ToString();
            TbMontoTotal.Text = oRes.Monto_Total.ToString();
            TbMontoReserva.Text = oRes.Monto_Reserva.ToString();
            RblPago.SelectedValue = oRes.Pagado.ToString();
            TbFechapago.Text = (oRes.FDePago > Convert.ToDateTime("1900-01-01") ? oRes.FDePago.ToString("dd/MM/yyyy") : "Impago");
            DdlEstados.SelectedValue = oRes.Estado;
            //desplazarme hacia abajo
            BtnNuevo.Focus();
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

        protected void CargarCalendario()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();

            DayPilotCalendario.DataSource = oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            // oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            DayPilotCalendario.StartDate = Convert.ToDateTime(TbFechaAlquiler.Text);
            DayPilotCalendario.DataStartField = "FDesde";
            //DayPilotScheduler1.DataStartField = "start";
            DayPilotCalendario.DataEndField = "Fhasta";
            //DayPilotScheduler1.DataEndField = "end";
            DayPilotCalendario.DataTextField = "Inquilino_Nombre";
            //DayPilotScheduler1.DataTextField = "name";
            DayPilotCalendario.DataResourceField = "IdPropiedad";
            //DayPilotScheduler1.DataIdField = "id";
           
            //DayPilotScheduler1.DataResourceField = "resource";

          DayPilotCalendario.DataBind();
        }

        protected void CargarRecusosCalendario()
        {
            DayPilotCalendario.Resources.Clear();
            Negocio.Negocio oNegocio = new Negocio.Negocio();

            //SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [name] FROM [resource]", ConfigurationManager.ConnectionStrings["DayPilot"].ConnectionString);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            var Recursos = oNegocio.Get_Propiedades_All();

            foreach (var r in Recursos)
            {
                string Propiedad_Nombre = r.Nombre;
                string IDPropiedad = r.IdPropiedades.ToString();

               DayPilotCalendario.Resources.Add(Propiedad_Nombre, IDPropiedad);
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(HndId.Value) > 0)
            {
                //Update de Reserva
            }
            else
            {
                //Nuenva reserva
                //Chequear que la reserva no se superponga si en nueva
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] Sugerencias(string prefixText, int count)
        {
            List<InquilinoCMB> oPersonas = new List<InquilinoCMB>();
            string[] PNombres = null; ;

            Negocio.Negocio oNegocio = new Negocio.Negocio();

            prefixText = prefixText.ToUpper();
            oPersonas = oNegocio.GetInquilinoCMB(prefixText);



            IEnumerable<string> ds = from P in oPersonas
                                     orderby P.Nombre_inquilino
                                     select (P.Nombre_inquilino + " #" + P.IdInquilino);

            PNombres = ds.ToArray<string>();


            return PNombres.ToArray();
        }
    }
}