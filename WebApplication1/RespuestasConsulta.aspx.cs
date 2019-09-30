using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
namespace WebApplication1
{
    public partial class Respuestas : System.Web.UI.Page
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");
        protected void Page_Load(object sender, EventArgs e)
        {
            var Rta = Request.QueryString["Rta"].ToString();


            try
            {
                  if (!String.IsNullOrEmpty(Rta))
                {
                    string CodigoRespuesta = Request.QueryString["Rta"].ToString();
                    CodigoRespuesta = CodigoRespuesta.Substring(2, (CodigoRespuesta.Length-2)-3);
                    Negocio.Negocio oNegocio = new Negocio.Negocio();
                    //Busco la consulta
                    //Obterngo el tipo 
                    var TConsulta = CodigoRespuesta.Substring(0, 2);
                    var NroConsulta = CodigoRespuesta.Substring(2, CodigoRespuesta.Length-2);
                    //TODO: Verdificar por Tipos / Id 
                    // Para Tipos FP - CP hacer una busqueda generica de tipo list ordenados por fechas
                    // Para el resto hacer un busqueda puntual de la consulta en si misma
                    var QConsulta = oNegocio.Get_Cometario(Convert.ToInt32(NroConsulta));
                    LbNombre.Text ="Nombre: "+ QConsulta.Nombre_Persona;
                    var QMotivo = oNegocio.Get_Consulta_Tipo();
                    var Motivo = QMotivo.Where(c => c.Codigo == QConsulta.Tipo).SingleOrDefault(); ;
                    LbMotivo.Text = "Motivo: " + (Motivo !=null?Motivo.Descrip:"Otro");
                    //LbMotivo.Text = QConsulta.Tipo;
                    TbConsulta.Enabled = false;
                    TbRespuesta.Enabled = false;
                    TbConsulta.Text = QConsulta.Comentario;
                    //Busco la respuesta
                    var QRespuesta = oNegocio.Get_Respuesta(Convert.ToInt32(NroConsulta));
                    if (QRespuesta.Respuesta != null)
                    {
                        if (QRespuesta.Estado == "Respondida")
                            TbRespuesta.Text = "<br />" +QRespuesta.Respuesta;
                        else
                            TbRespuesta.Text = "<font color='saddlebrown'>Su consulta no ha sido respondida, <br /> " +
                            "en la brevedad nos estaremos comunicando via mail / Teléfono </font> <br />" +
                            "<h3><font color='Green'><i class='fas fa-tree' style='color: forestgreen; '></i> www.CdelEste.com.ar</font> </h3> <br />";
                    }
                    else
                    {
                            TbRespuesta.Text = "<font color='saddlebrown'>Su consulta no ha sido respondida, <br /> " +
                            "en la brevedad nos estaremos comunicando via mail / Teléfono </font><br />" +
                            "<h3><font color='Green'><i class='fas fa-tree' style='color: forestgreen; '></i> www.CdelEste.com.ar</font> </h3> <br />";
                    }
                }
                else
                {
                    TbRespuesta.Text = "<br /><font color='saddlebrown'> <H2> Código de Respuesta Invalido </H2></font> <br />" +
                        " <h3><font color='Green'><i class='fas fa-tree' style='color: forestgreen; '></i> www.CdelEste.com.ar</font> </h3> ";

                }
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Frontend - RespuestaConsulta - RespuestaConsulta");

                Response.Redirect("Error.aspx", false);
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx",false);
        }
    }
}