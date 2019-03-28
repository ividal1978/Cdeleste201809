using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Consultas_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DdlPropiedades.Visible = false;    
            }
            
        }

        protected void DdlMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlMotivo.SelectedValue == "CP")
            {
                DdlPropiedades.Visible = true;
                CargarCMBPropiedades();
            }
        }

        protected void CargarCMBPropiedades()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            DdlPropiedades.DataTextField = "Descripcion";
            DdlPropiedades.DataValueField = "Id";
            DdlPropiedades.DataSource = oNegocio.Get_Propiedades_CMB();
            DdlPropiedades.DataBind();
        }
    }
}