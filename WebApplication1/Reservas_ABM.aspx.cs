using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;
using System.Web.Services;
using DayPilot.Web;
using DayPilot.Web.Ui;

namespace WebApplication1
{
    public partial class Reservas_ABM : System.Web.UI.Page
    {
        private readonly object LbMes;

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
                TbFechaDesde.Text = DateTime.Now.ToString("dd/MM/yyyy");
                TbFechaHasta.Text = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
              
                  
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
           // CargaGrilla();
            CargarCalendario();
        }
        //protected void VerReserva(object sender, GridViewDeleteEventArgs e)
        //{
        //    // buscar info por id
        //    int IdReserva = Convert.ToInt32(GvReservas.Rows[e.RowIndex].Cells[0].Text);
        //     Get_Reserva(IdReserva);
        // }

        //protected void CambioPagina(object sender, GridViewPageEventArgs e)
        //{
        //    GvReservas.PageIndex = e.NewPageIndex;
        //    CargaGrilla();
        //}

        //protected void CargaGrilla()
        //{
        //    Negocio.Negocio oNegocio = new Negocio.Negocio();
        //    GvReservas.DataSource = oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
        //    GvReservas.DataBind();
        //}

        protected void CargarCalendario()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
                       
            DayPilotCalendario.DataSource = oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            // oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            DayPilotCalendario.StartDate = Convert.ToDateTime(TbFechaAlquiler.Text);
            MesGrilla();

            DayPilotCalendario.DataStartField = "FDesde";
            //DayPilotScheduler1.DataStartField = "start";
            DayPilotCalendario.DataEndField = "Fhasta";
            //DayPilotScheduler1.DataEndField = "end";
            DayPilotCalendario.DataTextField = "Inquilino_Nombre";
            //DayPilotScheduler1.DataTextField = "name";
            DayPilotCalendario.DataResourceField = "IdPropiedad";
            //DayPilotScheduler1.DataIdField = "id";
                        //DayPilotScheduler1.DataResourceField = "resource";
            DayPilotCalendario.DurationBarColor = System.Drawing.Color.SaddleBrown;
            

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
            if (Page.IsValid)
            {
                if (ValidacionesLogicas())
                {
                    //Cargo los datos
                    Reservas oRes = new Reservas();

                    oRes.Estado = DdlEstados.SelectedValue;
                    if (!string.IsNullOrEmpty(TbFechapago.Text) && TbFechapago.Text!= "Impago")
                        oRes.FDePago = Convert.ToDateTime(TbFechapago.Text);
                    oRes.FDesde = Convert.ToDateTime(TbFechaDesde.Text);
                    oRes.FHasta = Convert.ToDateTime(TbFechaHasta.Text);
                    oRes.IdPropiedad = Convert.ToInt32(DdlPropiedad.SelectedValue.ToString());
                    oRes.IdInquilino = Convert.ToInt32(TbInquilino.Text.Substring(TbInquilino.Text.IndexOf("#") + 1));
                    oRes.Pagado = RblPago.SelectedValue.ToString();
                    oRes.Inquilino_Nombre = TbInquilino.Text.Substring(0, TbInquilino.Text.IndexOf(","));
                    oRes.Inquilino_Apellido = TbInquilino.Text.Substring(TbInquilino.Text.IndexOf(",") + 1, TbInquilino.Text.IndexOf("#") + 1 - TbInquilino.Text.IndexOf(",") - 1);
                    oRes.Monto_Total = Convert.ToDecimal(TbMontoTotal.Text);
                    oRes.Monto_Reserva = Convert.ToDecimal(TbMontoReserva.Text);
                    // Obtener el id De Usuario 
                    Negocio.Negocio oNegocio = new Negocio.Negocio();
                    Usuarios oUsuario = new Usuarios();
                    oUsuario = oNegocio.GetUsuraioXNombre(Session["usuario"].ToString());
                    oRes.IdUsuario = oUsuario.IdUsuario;

                    if (Convert.ToInt32(HndId.Value) > 0)
                    {
                        //Update de Reserva
                        oRes.IdReserva = Convert.ToInt32(HndId.Value);
                        //Limpiar la el valor del hdn value
                        HndId.Value = "";
                    }
                    else
                    {
                        //Nuenva reserva
                        oRes.IdReserva = -1;

                    }


                    oNegocio.Save_Reserva(oRes);

                    LbError.Text = "Se ha Guardado Correctamente";
                }
            }
        }

        protected void MesGrilla()
        {
            int mes = Convert.ToDateTime(TbFechaAlquiler.Text).Month;
            switch (mes)
            { 
                case  1:
                    TbMes.Text = "Enero";
                    DayPilotCalendario.Days = 31;
                    break;
                case 2:
                    TbMes.Text = "Febrero";
                    DayPilotCalendario.Days = 29;
                    break;
                case 3:
                    TbMes.Text = "Marzo";
                    DayPilotCalendario.Days = 31;
                    break;
                case 4:
                    TbMes.Text = "Abril";
                    DayPilotCalendario.Days = 30;
                    break;
                case 5:
                    TbMes.Text = "Mayo";
                    DayPilotCalendario.Days = 31;
                    break;
                case 6:
                    TbMes.Text = "Junio";
                    DayPilotCalendario.Days = 30;
                    break;
                case 7:
                    TbMes.Text = "Julio";
                    DayPilotCalendario.Days = 31;
                    break;
                case 8:
                    TbMes.Text = "Agosto";
                    DayPilotCalendario.Days = 31;
                    break;
                case 9:
                    TbMes.Text = "Septiembre";
                    DayPilotCalendario.Days = 30;
                    break;
                case 10:
                    TbMes.Text = "Octubre";
                    DayPilotCalendario.Days = 31;
                    break;
                case 11:
                    TbMes.Text = "Noviembre";
                    DayPilotCalendario.Days = 30;
                    break;
                case 12:
                    TbMes.Text = "Diciembre";
                    DayPilotCalendario.Days = 31;
                    break;
            }
        }

        private void Get_Reserva(int IdReserva)
        {
            HndId.Value = IdReserva.ToString();
            Reservas oRes = new Reservas();
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            oRes = oNegocio.Get_ReservasxId(IdReserva);

            if (oRes != null)
            { //cargar la info
                TbFechaDesde.Text = oRes.FDesde.ToString("dd/MM/yyyy");
                TbFechaHasta.Text = oRes.FHasta.ToString("dd/MM/yyyy");
                DdlPropiedad.SelectedValue = oRes.IdPropiedad.ToString();
                TbInquilino.Text = oRes.Inquilino_Nombre + ", " + oRes.Inquilino_Apellido + " #" + oRes.IdInquilino.ToString();
                TbMontoTotal.Text = oRes.Monto_Total.ToString();
                TbMontoReserva.Text = oRes.Monto_Reserva.ToString();
                RblPago.SelectedValue = oRes.Pagado.ToString();
                TbFechapago.Text = (oRes.FDePago > Convert.ToDateTime("1900-01-01") ? oRes.FDePago.ToString("dd/MM/yyyy") : "Impago");
                DdlEstados.SelectedValue = oRes.Estado;
            }
            else
            {
                LbError.Text = "Renserva no encontrada";
            }
            //desplazarme hacia abajo
            BtnNuevo.Focus();
            //posicionarme en el primer control de abajo
        }

        protected void DayPilotCalendar1_EventClick(object sender, EventClickEventArgs e)
        {
             //Cargar los datos de la reserva
             Get_Reserva(Convert.ToInt32(e.Value));
        }
    
        protected bool ValidacionesLogicas()
        {
            int Errores = 0;
            LbError.Text = "";
            Errores += ValidaFechasDesdeHasta();
            
            //Debe selecionar una propiedad
            if (DdlPropiedad.SelectedValue == "-1")
            {
                LbError.Text += "<br /> Debe seleccionar una propiedad disponible";
                Errores++;        
               
            }
            //verifica que tenga inquilino
            if (!TbInquilino.Text.Contains("#"))
            {
                LbError.Text = "<br /> Debe seleccionar un Inquilino Cargado o cargue uno nuevo";
                Errores++;
            }

            //verifica que tenga pago
            if (string.IsNullOrEmpty(RblPago.SelectedValue))
            {
                LbError.Text += "<br /> Determine el estado de Pago";
                Errores++;
            }

            if (Errores <1)
            { //Verificar que la reserva este disponible
                Negocio.Negocio oNegocio = new Negocio.Negocio();
                Reservas oRes = new Reservas();
                oRes.FDesde = Convert.ToDateTime(TbFechaDesde.Text);
                oRes.FHasta = Convert.ToDateTime(TbFechaHasta.Text);
                oRes.IdPropiedad = Convert.ToInt32(DdlPropiedad.SelectedValue.ToString());
                oRes.IdReserva = Convert.ToInt32(HndId.Value);
                if (oNegocio.Exist_Reserva(oRes))
                {
                    Errores++;
                    LbError.Text += "<br /> Existe una reserva previa para la fecha y propiedad seleccionada";
                }
            }

                return !(Errores > 0);
        }

        protected int ValidaFechasDesdeHasta()
        {
            int Errores = 0;
             try
            {
                Convert.ToDateTime(TbFechaDesde.Text);
                Convert.ToDateTime(TbFechaHasta.Text);

                if (!(Convert.ToInt32(HndId.Value) > 0))
                {
                    //verificar si es nuevo o actualizacion
                    if (Convert.ToDateTime(TbFechaDesde.Text) < DateTime.Now && Convert.ToDateTime(TbFechaHasta.Text) > DateTime.Now)
                    {
                        LbError.Text += "<br /> Las fecha de nuevas reserva deben ser a futuro";
                        Errores++;
                    }
                }
                //Validaciondes de Fechas
                //1 La fecha hasta debe ser menor a la fecha hasta
                if (Convert.ToDateTime(TbFechaDesde.Text) >= Convert.ToDateTime(TbFechaHasta.Text))
                {
                    LbError.Text += "<br /> La fecha desde debe ser menor a la fecha Hasta";
                    Errores++;
                }
            }
            catch
            {
                LbError.Text += "<br />Error en Fecha desde o Fecha Hasta formato dd/MM/yyyy";
                Errores = 1;
            }
            return Errores;
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