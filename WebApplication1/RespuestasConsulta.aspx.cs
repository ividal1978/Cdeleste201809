﻿using System;
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
            try
            {
                if (Request.QueryString["Rta"] != null)
                {
                    string CodigoRespuesta = Request.QueryString["Rta"].ToString();
                    CodigoRespuesta = CodigoRespuesta.Substring(2, CodigoRespuesta.IndexOf("-")-2);
                    Negocio.Negocio oNegocio = new Negocio.Negocio();
                    //Busco la consulta
                    var QConsulta = oNegocio.Get_Cometario(Convert.ToInt32(CodigoRespuesta));
                    LbNombre.Text ="Nombre: "+ QConsulta.Nombre_Persona;
                    var QMotivo = oNegocio.Get_Consulta_Tipo();
                    var Motivo = QMotivo.Where(c => c.Codigo == QConsulta.Tipo).SingleOrDefault(); ;
                    LbMotivo.Text = "Motivo: " + (Motivo !=null?Motivo.Descrip:"Otro");
                    //LbMotivo.Text = QConsulta.Tipo;
                    TbConsulta.Enabled = false;
                    TbRespuesta.Enabled = false;
                    TbConsulta.Text = QConsulta.Comentario;
                    //Busco la respuesta
                    var QRespuesta = oNegocio.Get_Respuesta(Convert.ToInt32(CodigoRespuesta));
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