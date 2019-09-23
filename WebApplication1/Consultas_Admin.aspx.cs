using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Contrato;
using System.Text;
using System.Configuration;

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

            if (DdlEstado.SelectedValue == "Anulado")
            {
                BtnAnular.Visible = false;
                BtnResponder.Visible = true;
            }
            else
            {
                BtnAnular.Visible = true;
                BtnResponder.Visible = true;
            }
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
            HdnIdComentario.Value = IdConsulta.ToString();
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
                TbRespuesta.Text = (QRespuesta.Respuesta!= null? QRespuesta.Respuesta.ToString():"");
            }
        }

        protected void BtnAnular_Click(object sender, EventArgs e)
        {
            Comentarios oComentario = new Comentarios();
            oComentario.IdComentario = Convert.ToInt32(HdnIdComentario.Value.ToString());
            oComentario.Tipo = DdlTipoConsulta.SelectedValue.ToString();
            oComentario.Estado = "Anulado";
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            oNegocio.Save_Comentario(oComentario);
            Limpiar();
            LbMensaje.Text = "Se ha Guardado Correctamente.";

        }

        protected void Limpiar()
        {
            LbNombreConsulta.Text = LbTelefonoConsulta.Text = LbMailConsulta.Text = LbFechaConsulta.Text = "";
            LbPropiedadConsulta.Text = LbFechaRespuesta.Text = TbConsulta.Text = TbRespuesta.Text = "";
        }

        protected void BtnResponder_Click(object sender, EventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            Contrato.Respuestas oRespuesta = new Contrato.Respuestas();
            
            oRespuesta.IdRespuesta = Convert.ToInt32(HdnIdComentario.Value.ToString());
            oRespuesta.Tipo = "R";
            oRespuesta.Estado = "Respondida";
            oRespuesta.Respuesta = TbRespuesta.Text;
            oRespuesta.Fecha = DateTime.Now;

            oNegocio.Save_Respuesta(oRespuesta);

            Comentarios oComentario = new Comentarios();
            oComentario.IdComentario = Convert.ToInt32(HdnIdComentario.Value.ToString());
            switch (RblCambiaPRegunta.SelectedValue)
            {
                case "XX":
                    oComentario.Tipo = DdlTipoConsulta.SelectedValue.ToString();
                    break;
                case "PP"://Pregunta Privada
                    oComentario.Tipo = "PP";
                    break;
                case "PF"://Pregunta Frecuente
                    oComentario.Tipo = "PF";
                    break;
                default:
                    oComentario.Tipo = DdlTipoConsulta.SelectedValue.ToString();
                    break;
            }
           
            oComentario.Estado = "Respondida";

            oNegocio.Save_Comentario(oComentario);
            //Random XXTTID-NN
            string CodigoConsulta = GeneradorRandom(oComentario.Tipo+ HdnIdComentario.Value.ToString());
            if (ChkEnviarmail.Checked == true)
            {
                //Debo enviar el mail
                Email Correo = new Email();
                Correo.Para = LbMailConsulta.Text;
                Correo.CopiaOculta = ConfigurationManager.AppSettings["ListaMail"].ToString();
               
                //Correo.CopiaOculta= ConfigurationManager.AppSettings["ListaMail"].ToString();
                Correo.Asunto = "Respuesta Consulta- " + CodigoConsulta + " Fecha " + DateTime.Now;
                Correo.Mensaje = "<H2> Estimado/a "+ oComentario.Nombre_Persona + ":<H2><Hr> <br>";
                Correo.Mensaje += "<h4> Desde www.CdelEste.com.ar hemos recibido su consulta, la misma ya ha sido respondida.< br />" +
                    "Puede consultar la misma en el siguiente link http:\\www.cdeleste.com.ar\\RespuestasConsulta.aspx? Rta =" + CodigoConsulta
                    + "<br /> <br /> <h4> "
                    + " Ante cualquier consulta comuniquese via web o telefónicamente <br /> <br />"
                    + " Atentamente <br/>"
                    + "<h3><font color='Green'><i class='fas fa-tree' style='color: forestgreen; '></i> www.CdelEste.com.ar</font> </h3> < br/> " +
                    "<h3><hr><B>NOTA: </B></h3> <h4> Este mail se ha generado de forma automática."+
                    " No responda o envié mail a esta dirección de correo ya que no recibirá respuesta alguna."+
                    " Desde ya muchas Gracias..<br />This email was generated automatically. Do not respond or send mail to this email address, you will not receive any response. Thank you in advance.</h4>";

                //Envio el mail
                oNegocio.Envio_Email(Correo);
                // comunico que la consulta se envio

            }
            Limpiar();
            LbMensaje.Text = "Se Ha guardado correctamente, para su consulta ver: <br /> http:\\www.cdeleste.com.ar\\RespuestasConsulta.aspx? Rta =" + CodigoConsulta +" "+ (ChkEnviarmail.Checked == true ? " y se ha enviado en el mail." : ".");
        }

        protected string GeneradorRandom(string ID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, true));
            builder.Append(ID +"-");
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        // Generate a random string with a given size  
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}