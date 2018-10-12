using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;


namespace WebApplication1
{
    public partial class Escaparate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                CargaPropiedad(Id);
                CargaCaracterisitecas(Id);
            }
            else
            {
                Response.Redirect("Error.aspx?Msg=PNExiste");
            }
        }

        private void CargaPropiedad(int IdPropiedad)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            Propiedades oProp = new Propiedades();
            oProp = oNegocio.Get_Propiedad(IdPropiedad);
            LbPropiedad.Text = oProp.Nombre;
            LbDireccion.Text = "Direccion: " + oProp.Direccion + " (Pax :"+oProp.Plazas+")";
            lbDescripcion.Text =oProp.Intro;
        }

        private void CargaCaracterisitecas(int IdPropiedad)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            rptDescripcion.DataSource= oNegocio.Get_Propiedades_Confort(IdPropiedad);
            rptDescripcion.DataBind();
        }
    }
}