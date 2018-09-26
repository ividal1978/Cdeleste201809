using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Noticias_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) => Autenticar();
       
        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {
                lbUsuario.Text = "Usuario: " + (Session["usuario"] != null ? Session["usuario"].ToString() : "");
                lbFechaPagina.Text += " " + DateTime.Now;
             }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }
    }
}