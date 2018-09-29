using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;

namespace WebApplication1
{
    public partial class Noticias_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Autenticar();
            //Cargar Noticias
            if (!Page.IsPostBack)
            {
                CargarNoticias();
                img.ImageUrl = "\\Imagenes\\Noticias\\noimagen.png";

            }

        }

        /// <summary>
        /// Verifica si tengo usuario logueado sino lo envia al menu para loguearse
        /// </summary>
        protected void Autenticar()
        {

            if (Session["usuario"] != null)
            {
                lbUsuario.Text = "Usuario: " + (Session["usuario"] != null ? Session["usuario"].ToString() : "");
                lbFechaPagina.Text = "Fecha: " + DateTime.Now;
             }
            else
            {
                Response.Redirect("Menu.aspx");
            }
        }

        /// <summary>
        /// Carga todas las noticias en la tabla
        /// </summary>
        protected void CargarNoticias()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            dgNoticias.DataSource = oNegocio.GetNoticias_All(ddlTipoNoticia.SelectedValue.ToString());
            dgNoticias.DataBind();

        }

        protected void ddlTipoNoticia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNoticias();
        }

        protected void Carga1Noticia(object sender, DataGridCommandEventArgs e)
        {
            Negocio.Negocio oNeogicio = new Negocio.Negocio();
            int Id = Convert.ToInt32(dgNoticias.Items[e.Item.ItemIndex].Cells[0].Text);
            var Query = oNeogicio.GetNoticias_One(Id);
            if (Query.IdNoticia > 0)
            {
                lbId.Text ="Id: "+ Query.IdNoticia.ToString();
                lbFecha.Text ="Fecha :"+ Query.Fecha.ToString();
                tbNoticia.Text = Query.Noticia;
                img.ImageUrl = (Query.RutaImagen.Length > 0 ? "\\Imagenes\\Noticias\\" + Query.RutaImagen : "\\Imagenes\\Noticias\\noimagen.png");
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lbId.Text = "NUEVO";
            lbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbNoticia.Text = "";
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Noticias oNoticias = new Noticias();
            oNoticias.IdNoticia = (lbId.Text == "NUEVO" ? -1 : Convert.ToInt32(lbId.Text.Substring(lbId.Text.IndexOf(":") + 1)));
            oNoticias.Fecha = (oNoticias.IdNoticia > 0 ? DateTime.Now : Convert.ToDateTime(lbFecha.Text.Substring(lbFecha.Text.IndexOf(":") + 1)));
            oNoticias.Noticia = tbNoticia.Text;
            oNoticias.Tipo = ddlTipoNoticia.SelectedValue.ToString();
            if (fupdate.HasFile)
            {
                //verifico la dimension de la imagen

                //verifico el formato jpg o png

                // guardo la imagen en imagenes/noticias

                // subo el nombre del archivo al objeto
            }
            //envio a guardar

           //limpio los contorles del formulario
        }
    }
}