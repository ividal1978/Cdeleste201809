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
    }
}