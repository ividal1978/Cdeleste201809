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
            CargaCombo();
        }
        protected void CargaCombo()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            DdlTipoConsulta.DataTextField = "Descrip";
            DdlTipoConsulta.DataValueField = "Codigo";
            DdlTipoConsulta.DataSource = oNegocio.Get_Consulta_Tipo();
            DdlTipoConsulta.DataBind();
        }
    }
}