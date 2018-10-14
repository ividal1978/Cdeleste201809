using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;
using NLog;

namespace WebApplication1
{

    public partial class Noticias_ABM : System.Web.UI.Page
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");
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
                if (Query.Tipo == "NOTI")
                {
                    img.Visible = true;
                    fupdate.Visible = true;
                    img.ImageUrl = (Query.RutaImagen.Length > 0 ? "\\Imagenes\\Noticias\\" + Query.RutaImagen : "\\Imagenes\\Noticias\\noimagen.png");
                }
                else
                {
                    fupdate.Visible = true;
                    img.Visible = false;
                }
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
                string Archivo = fupdate.FileName.ToString();
                //verifico el formato jpg o png 
                if (Archivo.ToUpper().Contains(".JPG") || Archivo.ToUpper().Contains(".PNG"))
                {
                    string extencion = (Archivo.ToUpper().Contains(".JPG") ? ".JPG" : ".PNG");
                   //verifico la dimension de la imagen
                   System.Drawing.Image viImagen = System.Drawing.Image.FromStream(fupdate.PostedFile.InputStream);
                    if (viImagen.PhysicalDimension.Width <= 200 && viImagen.PhysicalDimension.Height <= 200)
                    { // guardo la imagen en imagenes/noticias
                        try
                        {     // subo el nombre del archivo al objeto
                            string nombrArchivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            fupdate.SaveAs(Server.MapPath("~\\Imagenes\\Noticias\\" + nombrArchivo + extencion));
                            oNoticias.RutaImagen = nombrArchivo + extencion;
                        }
                        catch (Exception ex)
                        {
                            _logger1.Error(ex, " Carga Imangen Noticia");
                        }
                    }
                    else
                    {
                        lbError.Text = "La imagen debe ser menor a 200px x 200px ";
                    }
                }
                else
                {
                    lbError.Text = "Solo imagenes de extensio .jpg o .png";
                }     
            }
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            oNegocio.SaveNoticia(oNoticias);
            //limpio los contorles del formulario
            tbNoticia.Text = "";
            //Cargo la grilla nuevamente
            CargarNoticias();
        }
        
        
        protected void dgNoticias_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgNoticias.CurrentPageIndex = e.NewPageIndex;
            CargarNoticias();
        }

        protected void dgNoticias_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            int Id = Convert.ToInt32(dgNoticias.Items[e.Item.ItemIndex].Cells[0].Text);
            oNegocio.DeleteNoticia(Id);
            CargarNoticias();
        }
    }
}