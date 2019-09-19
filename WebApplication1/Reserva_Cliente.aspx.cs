using Contrato;
using DayPilot.Web.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reserva_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtengo el id de propiedad
            HdnPropiedad.Value = (Request.QueryString["IdProp"] != null ? Request.QueryString["IdProp"].ToString() : "-1");

            if (!Page.IsPostBack)
            {
                CargaCombos();
                TbFechaAlquiler.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarRecusosCalendario();
                CargarCalendario(); 
            }
            if (int.Parse(HdnPropiedad.Value.ToString()) > 0)
            {
                DdlPropiedadAlquiler.SelectedValue = HdnPropiedad.Value;
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

        protected void CargarRecusosCalendario()
        {
            DayPilotCalendario.Resources.Clear();
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            var Recursos = oNegocio.Get_Propiedades_All();

            if (DdlPropiedadAlquiler.SelectedValue != "-1")
                Recursos = Recursos.Where(x => x.IdPropiedades.Equals(Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue))).ToList();

            foreach (var r in Recursos)
            {
                string Propiedad_Nombre = r.Nombre;
                string IDPropiedad = r.IdPropiedades.ToString();

                DayPilotCalendario.Resources.Add(Propiedad_Nombre, IDPropiedad);
            }

        }

        protected void CargarCalendario()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            var datos = oNegocio.Get_ReservaxFecha(Convert.ToDateTime(TbFechaAlquiler.Text), Convert.ToInt32(DdlPropiedadAlquiler.SelectedValue));
            if (DdlPropiedadAlquiler.SelectedValue!= "-1")
            {
                datos = datos.Where(x => x.IdPropiedad == int.Parse(HdnPropiedad.Value)).ToList();
            }

            DayPilotCalendario.DataSource = datos;
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
        protected void MesGrilla()
        {
            int mes = Convert.ToDateTime(TbFechaAlquiler.Text).Month;
            switch (mes)
            {
                case 1:
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
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarRecusosCalendario();
            // CargaGrilla();
            CargarCalendario();
        }


        protected void DayPilotCalendar1_EventClick(object sender, EventClickEventArgs e)
        {
            //Cargar los datos de la reserva
            //  Get_Reserva(Convert.ToInt32(e.Value));
        }
     
    }
}