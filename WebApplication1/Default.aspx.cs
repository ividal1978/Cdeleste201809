using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;
using Negocio;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarNoticias();
        }
        protected void CargarNoticias()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            dlNoticias.DataSource = oNegocio.GetNoticias("NOTI", 4);
            dlNoticias.DataBind();
        }
    }
}