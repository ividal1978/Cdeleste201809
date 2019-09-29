using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PreguntasFrecuentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtengo los datos de IdPropiedad y Tipo
            int idPropiedad = Convert.ToInt32(Request.QueryString["IdProp"].ToString() ?? "-1");
            string tipoPregunta = Request.QueryString["tipoProp"].ToString() ?? "FP";


            // CD Consulta Disponibilidad - ID Propiedad Asociada
            // CP Consulta por Propiedad - ID
            // CR Como Reservar - Sin ID
            // CO Otras Consultas - Sin ID
            // PF Preguntas Frecuentes - Puede incluir o no Id Propiedad
            // PP Pregunta Privada - Pueda incluir o no Id Pero no debe mostrarse en esta  pagina ya que es privada

            CargarRepeater(idPropiedad, tipoPregunta);
         
        }

        protected void CargarRepeater(int idPropiedad, string tipoPregunta)
        {
            //TODO: Llamar al metodo de carga
            if (tipoPregunta != "PP")
            {
                Negocio.Negocio oNegocio = new Negocio.Negocio();
                var Rep = oNegocio.Get_PreguntasFrecuentes(tipoPregunta, idPropiedad);
                rptAccordion.DataSource = Rep;
                rptAccordion.DataBind();
            }
            else
                LbError.Text = "Este tipo de Consulta no puede ser mostrada en esta pantalla <br /> Si esta agurdando una respuesta esta llagará por e-mail y su respectivo link " +
                    "Gracias <br /> Atentamente <br /> www.Cdeleste.com.ar";
        }
    }
}