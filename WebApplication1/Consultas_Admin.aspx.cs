using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Contrato;

namespace WebApplication1
{
    public partial class Consultas_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificar Ingreso
            Autenticar();
            if (!Page.IsPostBack)
            {
                CargaCombo();
                CargaGrilla();
            }
        }
        protected void CargaCombo()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            DdlTipoConsulta.DataTextField = "Descrip";
            DdlTipoConsulta.DataValueField = "Codigo";
            DdlTipoConsulta.DataSource = oNegocio.Get_Consulta_Tipo();
            DdlTipoConsulta.DataBind();
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
        protected void CargaGrilla()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
        
          

            GvConsultas.DataSource = oNegocio.Get_ComentariosxTipo(DdlTipoConsulta.SelectedValue.ToString(), DdlEstado.SelectedValue.ToString());
            GvConsultas.DataBind();
            //llamar al metodo de negocio con los paramentros de 
        }

        protected void DdlTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        protected void DdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        protected void CambioPagina(object sender, GridViewPageEventArgs e)
        {
            
            GvConsultas.PageIndex = e.NewPageIndex;
            CargaGrilla();
        }
        protected void VerConsulta(object sender, GridViewDeleteEventArgs e)
        {
            int IdConsulta = Convert.ToInt32(GvConsultas.Rows[e.RowIndex].Cells[0].Text);
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            var QConsulta = oNegocio.Get_Cometario(IdConsulta);
            LbNombreConsulta.Text = QConsulta.Nombre_Persona;
            LbFechaConsulta.Text = QConsulta.FechaComentario.ToString();
            LbTelefonoConsulta.Text = QConsulta.Tel_Persona;
            LbMailConsulta.Text = QConsulta.Mail_Persona;
            TbConsulta.Text = QConsulta.Comentario;
            //obtengo el nombre de la propiedad si existe
            if (Convert.ToInt32(QConsulta.IdPropiedad) < 1)
                LbPropiedadConsulta.Text = "Consulta General";
            else
            {
                var Propiedad = oNegocio.Get_Propiedad(Convert.ToInt32(QConsulta.IdPropiedad));
                LbPropiedadConsulta.Text = Propiedad.Nombre;
            }
            var QRespuesta = oNegocio.Get_Respuesta(IdConsulta);
            if (QRespuesta != null)
            {
                LbFechaRespuesta.Text = QRespuesta.Fecha.ToShortDateString();
                TbRespuesta.Text = QRespuesta.Respuesta.ToString();
            }
        }
    }
}