using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Web.Services;
using Negocio;
using Contrato;

namespace WebApplication1
{
    public partial class Galeria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeterData();
        }

        public void RepeterData()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();

            rptImages.DataSource = oNegocio.Get_ImagenesGaleria_All();
            rptImages.DataBind();

        }
    }
}