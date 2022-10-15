using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var contactoMail =  ConfigurationManager.AppSettings["ContactoMail"];
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ContactoTel"]))
            {
                lbContactoTel.Text = "Teléfono: " + ConfigurationManager.AppSettings["ContactoTel"];
            }
        }
    }
}