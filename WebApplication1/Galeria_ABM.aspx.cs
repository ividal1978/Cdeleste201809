using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;
using NLog;
using System.IO;

namespace WebApplication1
{
    public partial class Galeria_ABM : System.Web.UI.Page
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Autenticar();
                CargaImagenes();
                lbId.Text = "Nuevo";

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
                hdnSelectedRuta.Value = Imagen.ruta;
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

            Limpiar();
        }
        protected void Limpiar()
        {
            lbId.Text = "Nuevo";
            tbNombre.Text = "";
            tbComentario.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            // si tengo id debo hacer upload.
            if (lbId.Text == "Nuevo")
            {
                if (VerificarImagen() == 0)
                {
                    // Guardo Archivo
                    img.DescriptionUrl = SaveFile(fUpload.PostedFile);
                    LbError.CssClass = "alert-info";
                    LbError.Text = "La imagen se Guardo correctamente.";
                    Limpiar();
                    Server.TransferRequest(Request.Url.AbsolutePath, false);
                }
            }
            else
            {
                //   Debo hacer un upload del  archivo
                if (VerificarImagen() == 0)
                {
                    img.DescriptionUrl = SaveFile(fUpload.PostedFile, hdnSelectedRuta.Value);
                    LbError.CssClass = "alert-info";
                    LbError.Text = "La imagen se actualizo correctamente.";
                    //   ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                    // Modifico Archivo
                    // Modifico Base de datos
                    Server.TransferRequest(Request.Url.AbsolutePath, false);
                }
                else
                {
                    LbError.CssClass = " alert-info";
                    LbError.Text = "Se ha actualizaron los datos correctamente.";
                    ImagesGaleria oImagen = new ImagesGaleria();
                    oImagen.id = (lbId.Text == "Nuevo" ? -1 : Convert.ToInt32(lbId.Text));
                    oImagen.ruta =hdnSelectedRuta.Value;
                    oImagen.reseña = tbComentario.Text;
                    oImagen.nombre = tbNombre.Text;

                    Negocio.Negocio oNegocio = new Negocio.Negocio();
                    oNegocio.Save_Imagen(oImagen);
                    Server.TransferRequest(Request.Url.AbsolutePath, false);
                }
            }

        }

        protected int VerificarImagen()
        {
            int counter = 0;
            string[] Formatos = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
            if (fUpload.HasFile)
            {
                LbError.CssClass = "alert-danger";
                var ext = fUpload.FileName.Substring(fUpload.FileName.LastIndexOf("."));
                //Verificar el formato de la imagen.
                if (Formatos.Contains(ext.ToLower()))
                {      //Verificar el peso de la imagen. 500k Max.
                    if (fUpload.PostedFile.ContentLength <= 512000)
                    {
                        //verifico la dimension de la imagen
                        System.Drawing.Image viImagen = System.Drawing.Image.FromStream(fUpload.PostedFile.InputStream);
                        if (viImagen.PhysicalDimension.Width <= 1280 && viImagen.PhysicalDimension.Height <= 960)
                        {
                            counter = 0;
                        }
                        else
                        {
                            LbError.Text = $"La imagen tiene {viImagen.PhysicalDimension.Width }  x {viImagen.PhysicalDimension.Height} se recomienda no mas" +
                                $" de 1280 x 960";
                            counter++;
                        }
                    }
                    else
                    {
                        LbError.Text = "La imagen pesa mas de 500kb, reduzca su peso en www.tinyjpg.com";
                        counter++;
                    }

                }
                else
                {
                    LbError.Text = "Verifique el que el formato del archivo sea .jpg, .jpeg, .gif, .png";
                    counter++;
                }
            }
            else
            {
                LbError.Text = "Seleccione un archivo de imagen .jpg , .gif ,.png";
                counter++;
            }
            return counter;
        }

        protected string SaveFile(HttpPostedFile file, string ruta = "")
        {
            // Specify the path to save the uploaded file to.
            string savePath = "~\\Imagenes\\Galeria\\";//"c:\\temp\\uploads\\";
           // Server.MapPath("~\\Imagenes\\Propiedades\\" + lbId.Text + "\\" + IdImagen.ToString() + extencion)
            // Get the name of the file to upload.
            string fileName = fUpload.FileName;
            string auxFilename = fUpload.FileName.Substring(0, fUpload.FileName.LastIndexOf("."));
            string ext = fUpload.FileName.Substring(fUpload.FileName.LastIndexOf("."));
            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            string aux =  (string.IsNullOrEmpty(ruta)?DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("-", ""):ruta.Substring(0, ruta.LastIndexOf(".")));

            // Append the name of the file to upload to the path.
            savePath += aux + ext;

            fUpload.SaveAs(Server.MapPath(savePath));
            LbError.CssClass = " alert-info";
            LbError.Text = "Se ha Guardado correctamente.";
            ImagesGaleria oImagen = new ImagesGaleria();
            oImagen.id = (lbId.Text == "Nuevo" ? -1 : Convert.ToInt32(lbId.Text));
            oImagen.ruta = aux + ext;
            oImagen.reseña = tbComentario.Text;
            oImagen.nombre = tbNombre.Text;

            Negocio.Negocio oNegocio = new Negocio.Negocio();
            oNegocio.Save_Imagen(oImagen);

            return savePath;
        }

        protected void btnSobreEscribir_Click(object sender, EventArgs e)
        {
            img.DescriptionUrl = SaveFile(fUpload.PostedFile);
            LbError.CssClass = "alert-info";
            LbError.Text = "La imagen se actualizo correctamente.";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbId.Text != "Nuevo" && !string.IsNullOrEmpty(lbId.Text))
            {
                string strPhysicalFolder = Server.MapPath("~/Imagenes/Galeria/");

                Negocio.Negocio oNegocio = new Negocio.Negocio();
             
                string strFileFullPath = strPhysicalFolder +hdnSelectedRuta.Value;
                try
                {
                    oNegocio.Del_Galeria(Convert.ToInt32(lbId.Text));


                    if (File.Exists(strFileFullPath))
                    {
                        File.Delete(strFileFullPath);
                    }
                    LbError.CssClass = "alert-info";
                    LbError.Text = "La imagen se Elimino correctamente.";
                    Server.TransferRequest(Request.Url.AbsolutePath, false);
                }
                catch (Exception ex)
                {
                    _logger1.Error(ex, " Datos - Galeria - Delete :: " + ex.StackTrace.ToString());
                    LbError.CssClass = "alert-danger";
                    LbError.Text = "Ha ocurrido un error.";
                }
            }
            else
            {
                LbError.CssClass = "alert-danger";
                LbError.Text = "Seleccione una imagen.";
            }

        }
    }

}