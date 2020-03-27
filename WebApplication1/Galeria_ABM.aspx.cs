using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Galeria_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Autenticar();
                CargaImagenes();


            }
        }
        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {
                LbUsuario.Text = "Usuario: " + (Session["usuario"] != null ? Session["usuario"].ToString() : "");
                LbFechaPagina.Text = "Fecha: " + DateTime.Now;
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }

   

        protected void Image_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ImageClick")
            {
                Negocio.Negocio oNegocio = new Negocio.Negocio();


                //e.CommandArgument -->  photoid value
                var id = e.CommandArgument;
                var Imagen = oNegocio.Get_ImagenesGaleria_xId(Convert.ToInt32(id));
                lbId.Text = Imagen.id.ToString();
                tbNombre.Text = Imagen.nombre;
                tbComentario.Text = Imagen.reseña;
                hdnSelectedRuta.Value = Imagen.reseña;
                img.ImageUrl = "~/Imagenes/Galeria/" + Imagen.ruta;


                //Do something
            }
        }
        public void CargaImagenes()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();

            if (string.IsNullOrEmpty(img.ImageUrl))
                img.ImageUrl = "~/Imagenes/Noticias/noimagen.png";
            rptImages.DataSource = oNegocio.Get_ImagenesGaleria_All();
            rptImages.DataBind();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            lbId.Text = "Nuevo";
            tbNombre.Text = "";
            tbComentario.Text = "";
           

        }
    }
}