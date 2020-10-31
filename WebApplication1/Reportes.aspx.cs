using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Autenticar();


            }
        }
        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {

                LbFecha.Text = $"Fecha:{ DateTime.Now} ";
                LbUsuario.Text = $"Usuario:{(Session["usuario"] != null ? Session["usuario"].ToString() : "")}";
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }
    }
}