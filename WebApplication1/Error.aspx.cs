using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Msg"] != null)
            {
                string Msg = Request.QueryString["Msg"].ToString();
                switch (Msg)
                {
                    case "PNExiste":
                        lbRazones.Text = "Hemos detectado un Error.La pagina seleccionada no existe<br /> Lo invitamos a seguir navegando por nuestro sitio< br /> www.Cdeleste.com.ar";
                        break;

                    default:
                        lbRazones.Text = "Hemos detectado un Error.A la brevedad sera informado y solucionado por nuestro equipo de desarrollo<br /> Disculpe las molestias ocasionadas. < br /> www.Cdeleste.com.ar";
                        break;
                }
            }
        }
    }
}