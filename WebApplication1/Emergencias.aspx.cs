using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;

namespace WebApplication1
{
    public partial class Emergencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarLugares();
        }
        protected void CargarLugares()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            var nLugar = oNegocio.GetNoticias("EMER", 50);
            List<Lugar> lLugares = new List<Lugar>();

            foreach (var oitem in nLugar)
            {
                Lugar oLugar = new Lugar();
                oLugar.IdNoticia = oitem.IdNoticia;
                oLugar.Titulo = oitem.Noticia.Substring(0,oitem.Noticia.IndexOf(":"));
                oLugar.Noticia = oitem.Noticia.Substring(oitem.Noticia.IndexOf(":")+1);
                oLugar.Fecha = oitem.Fecha;
                oLugar.RutaImagen = oitem.RutaImagen;
                oLugar.Tipo = oitem.Tipo;
                lLugares.Add(oLugar);
            }
            RptEmergencias.DataSource = lLugares;
            RptEmergencias.DataBind();
        }
    }
}