using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;
using Contrato;

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
            var  Combo = oNegocio.Get_Propiedades_CMB();
            DdlPropiedades.DataSource = Combo.Where(x => x.Id.ToString().Contains("C"));
            DdlPropiedades.DataBind();
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            // verifico los datos
            if (VerificarForm() < 1)
            {
                //Guardo la consulta 
                Comentarios oComentario = new Comentarios();
                oComentario.Estado = "Activo";
                oComentario.FechaComentario = DateTime.Now;
                oComentario.Mail_Persona = TbEcorreo.Text;
                oComentario.Nombre_Persona = TbNombre.Text;
                oComentario.Tel_Persona = TbTeléfono.Text;
                oComentario.Tipo = DdlMotivo.SelectedValue;
                oComentario.IdPropiedad = (DdlPropiedades.Visible == true ? DdlPropiedades.SelectedValue.ToString() : "-1");
                oComentario.IdComentario = -1;
                oComentario.Comentario = TbConsulta.Text;

                Negocio.Negocio oNegocio = new Negocio.Negocio();
                oNegocio.Save_Comentario(oComentario);
                //Envio mail sobre nueva consula
                Email Correo = new Email();
                Correo.Para = ConfigurationManager.AppSettings["ListaMail"].ToString();
                //Correo.CopiaOculta= ConfigurationManager.AppSettings["ListaMail"].ToString();
                Correo.Asunto = "Nueva Consulta - " + DdlMotivo.SelectedItem.ToString() + " Fecha "+ DateTime.Now;
                Correo.Mensaje = "<H2> Se ha Recibido una nueva consulta<<H2><Hr> <br>";
                Correo.Mensaje += "<h3> Datos de la consulta : <br /> Nombre: " + oComentario.Nombre_Persona + "<br /> Teléfono :"
                    + (string.IsNullOrEmpty(oComentario.Tel_Persona) == true ? "Sin Teléfono" : oComentario.Tel_Persona) + "<br />"
                    + " Email: " + (string.IsNullOrEmpty(oComentario.Mail_Persona) == true ? "Sin Correo" : oComentario.Tel_Persona) + "<br />"
                    + " Motivo: " + DdlMotivo.SelectedItem.ToString() + "<br >" + (DdlPropiedades.Visible == true ? "Propiedad: " + DdlPropiedades.SelectedItem: "< br/>")
                    + " Consulta: " + oComentario.Comentario + "< br/>";

                //Envio el mail
                oNegocio.Envio_Email(Correo);
                // comunico que la consulta se envio

                //Envio Asivo al cliente por mail?
                LbError.CssClass = "alert-success";
                LbError.Text = "El comentario se ha generado de forma exitosa <br /> Próximamente nos comunicaremos con Ud. <br/> Gracias.";

                Limpiar();
            }

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

        protected void Limpiar()
        {
            TbNombre.Text = "";
            TbTeléfono.Text = "";
            TbEcorreo.Text = "";
            TbConsulta.Text = "";
        }

    }
}