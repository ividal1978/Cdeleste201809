using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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
            else
                DdlPropiedades.Visible = false;

        }

        protected void CargarCMBPropiedades()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            DdlPropiedades.DataTextField = "Descripcion";
            DdlPropiedades.DataValueField = "Id";
            DdlPropiedades.DataSource = oNegocio.Get_Propiedades_CMB();
            DdlPropiedades.DataBind();
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            // verifico los datos
            
            //Guardo la consulta 
            //Envio mail sobre nueva consula
            // comunico que la consulta se envio
        }
        protected int VerificarForm()
        {
            int Rta = 0;
            string Msg = "";
            if (string.IsNullOrEmpty(TbNombre.Text))
            {
                Rta++;
                Msg += "* Debe competar en el campo nombre <br />";
            }
            if (string.IsNullOrEmpty(TbEcorreo.Text))
            {
                Rta++;
                Msg += "* Debe competar en el campo e-mail <br />";
            }
            else
            {
                string expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (!Regex.IsMatch(TbEcorreo.Text, expresion))
                {
                    Rta++;
                    Msg += "El e-mail no tiene un formato valido <br />";
                }
            }
            //Verifico telefono ?
           
            // Controlar si tiene propiedad asociada
            //Controlar consulta
            if (string.IsNullOrEmpty(TbConsulta.Text))
            {
                Rta++;
                Msg = "La consulta no tiene mensaje <br />";
            }
            else
            {
                if (TbConsulta.Text.Length > 300)
                {
                    Rta++;
                    Msg += "La consulta debe tener menos de 300 caracteres <br />";
                }
            }
            if (Rta > 0)
                LbError.Text = Msg;
            else
                LbError.Text = "";
            return Rta;

        }

    }
}