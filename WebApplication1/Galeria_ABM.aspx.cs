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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            // si tengo id debo hacer upload.
            if (lbId.Text == "Nuevo")
            {
                if (VerificarImagen() == 0)
                {
                    // Guardo Archivo
                    // Guardo Base de datos
                }
            }
            else
            {
                //   Debo hacer un upload del  archivo
                if (VerificarImagen() == 0)
                {
                    // Modifico Archivo
                    // Modifico Base de datos
                }
            }
        }

        protected int VerificarImagen()
        {
            int counter = 0;
            string[] Formatos = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
            if (fUpload.HasFile)
            {
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

        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = "~/Imagenes/Galeria/";//"c:\\temp\\uploads\\";

            // Get the name of the file to upload.
            string fileName = fUpload.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
               //-- UploadStatusLabel.Text = "A file with the same name already exists." +
               //--     "<br />Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that the file was saved successfully.
                LbError.Text = "Your file was uploaded successfully.";
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            fUpload.SaveAs(savePath);

        }
    }

}