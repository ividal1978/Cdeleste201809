using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                lbId.Text = "Id: " + Query.IdNoticia.ToString();
                lbFecha.Text = "Fecha :" + Query.Fecha.ToString();
                tbNoticia.Content = Query.Noticia;
                if (Query.Tipo == "NOTI")
                {
                    img.Visible = true;
                    fupdate.Visible = true;
                    img.ImageUrl = (Query.RutaImagen.Length > 0 ? "\\Imagenes\\Noticias\\" + Query.RutaImagen : "\\Imagenes\\Noticias\\noimagen.png");
                    hdnImageSelected.Value = img.ImageUrl;
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
            tbNoticia.Content = "";
            hdnImageSelected.Value = "";

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Noticias oNoticias = new Noticias();
            lbId.Text = (string.IsNullOrEmpty(lbId.Text) == true ? "NUEVO" : lbId.Text);
            oNoticias.IdNoticia = -1;
            if (lbId.Text != "NUEVO")
            {
                oNoticias.IdNoticia = Convert.ToInt32(lbId.Text.Substring(lbId.Text.IndexOf(":") + 1));
                oNoticias.Fecha = Convert.ToDateTime(lbFecha.Text.Substring(lbFecha.Text.IndexOf(":") + 1));
            }
            else
            {
                oNoticias.Fecha = DateTime.Now;
            }
           
            oNoticias.Noticia = tbNoticia.Content;
            oNoticias.Tipo = ddlTipoNoticia.SelectedValue.ToString();
            if (tbNoticia.Content.Length < 800)
            {
                if (VerificarImagen() == 0)
                {
                    string Archivo = fupdate.FileName.ToString();
                    //verifico el formato jpg o png 
                    string extencion = Archivo.Substring(Archivo.LastIndexOf("."));
                    //verifico la dimension de la imagen
                    try
                    {     // subo el nombre del archivo al objeto 
                        Negocio.Negocio oNegocio = new Negocio.Negocio();
                        string nombrArchivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        fupdate.SaveAs(Server.MapPath("~\\Imagenes\\Noticias\\" + nombrArchivo + extencion));
                        oNoticias.RutaImagen = nombrArchivo + extencion;
                        oNegocio.SaveNoticia(oNoticias);
                    }
                    catch (Exception ex)
                    {
                        _logger1.Error(ex, " Carga Imangen Noticia ");
                    }
                }
                //limpio los contorles del formulario
                Limpiar();
                //Cargo la grilla nuevamente
                CargarNoticias();
            }
            else
            {
                lbError.CssClass = "text-danger text-center";
                lbError.Text = " El contenido HTML tiene mas de 800 caracteres.";
            }
        }


        protected void dgNoticias_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            CargarNoticias();
            dgNoticias.CurrentPageIndex = e.NewPageIndex;

        }

        protected void dgNoticias_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            int Id = Convert.ToInt32(dgNoticias.Items[e.Item.ItemIndex].Cells[0].Text);
            oNegocio.DeleteNoticia(Id);
            Limpiar();
            CargarNoticias();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            int Id = Convert.ToInt32(lbId.Text.Substring(lbId.Text.IndexOf(":") + 1));
            //Si existe imagen asociada
            if (!string.IsNullOrEmpty(hdnImageSelected.Value))
            {
                //Elimino imagen asociada.
                string strPhysicalFolder = Server.MapPath(hdnImageSelected.Value);
                if (File.Exists(strPhysicalFolder))
                {
                    File.Delete(strPhysicalFolder);
                }
            }
            //Elimino registro en la base de datos.
            oNegocio.DeleteNoticia(Id);
            CargarNoticias();
        }
        protected void Limpiar()
        {
            lbId.Text = "Nuevo";
            tbNoticia.Content = "";
            lbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            hdnImageSelected.Value = "";
        }

        protected int VerificarImagen()
        {
            int counter = 0;
            string[] Formatos = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
            if (fupdate.HasFile)
            {
                lbError.CssClass = "alert-danger";
                var ext = fupdate.FileName.Substring(fupdate.FileName.LastIndexOf("."));
                //Verificar el formato de la imagen.
                int ancho = 0;
                int alto = 0;
                int peso = 0;

                switch (ddlTipoNoticia.SelectedValue)
                {
                    case "NOTI":
                        ancho = 150;
                        alto = 150;
                        peso = 102400;
                        break;
                    case "PORT":
                        ancho = 500;
                        alto = 500;
                        peso = 409600;
                        break;
                    case "LUGA":
                        ancho = 800;
                        alto = 600;
                        peso = 512000;
                        break;
                    case "EMER":
                        ancho = 150;
                        alto = 150;
                        peso = 102400;
                        break;
                    default:
                        ancho = 1280;
                        alto = 960;
                        peso = 512000;
                        break;
                }


                if (Formatos.Contains(ext.ToLower()))
                {      //Verificar el peso de la imagen. 500k Max.
                    if (fupdate.PostedFile.ContentLength <= peso)
                    {
                        //verifico la dimension de la imagen
                        System.Drawing.Image viImagen = System.Drawing.Image.FromStream(fupdate.PostedFile.InputStream);
                        if (viImagen.PhysicalDimension.Width <= ancho && viImagen.PhysicalDimension.Height <= alto)
                        {
                            counter = 0;
                        }
                        else
                        {
                            lbError.Text = $"La imagen tiene {viImagen.PhysicalDimension.Width }  x {viImagen.PhysicalDimension.Height} se recomienda no mas" +
                                $" de {ancho}px x {alto}px";
                            counter++;
                        }
                    }
                    else
                    {
                        lbError.Text = $"La imagen pesa mas de {peso / 1024}kb, reduzca / optimice su peso en www.tinyjpg.com o sitios similares.";
                        counter++;
                    }

                }
                else
                {
                    lbError.Text = "Verifique el que el formato del archivo sea .jpg, .jpeg, .gif, .png";
                    counter++;
                }
            }
            else
            {
                lbError.Text = "Seleccione un archivo de imagen .jpg , .gif ,.png ,.jpeg";
                counter++;
            }
            return counter;
        }
    }
}