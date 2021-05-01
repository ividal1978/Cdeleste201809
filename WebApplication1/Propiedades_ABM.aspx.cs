using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Contrato;
using NLog;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Propiedades_ABM : System.Web.UI.Page
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");
        protected void Page_Load(object sender, EventArgs e)
        {
            Autenticar();
            if (!Page.IsPostBack)
            {
                CargarPropiedades();
                DivConfort.Visible = false;
                DivImagenes.Visible = false;

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

        protected void CargarPropiedades()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            gvPropiedades.DataSource = oNegocio.Get_Propiedades_All();
            gvPropiedades.DataBind();
        }

        protected void gvPropiedades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();

            int Id = Convert.ToInt32(gvPropiedades.Rows[e.NewEditIndex].Cells[0].Text);
            var oProp = oNegocio.Get_Propiedad(Id);
            lbId.Text = Id.ToString();
            TbPax.Text = oProp.Plazas.ToString();
            TbPropiedad.Text = oProp.Nombre;
            TbDireccion.Text = oProp.Direccion;
            TbIntro.Text = oProp.Intro;
            CargaConfort(Id);
            LbIdConfort.Text = "-1";
            CargaImagenes(oProp.IdPropiedades);
        }

    

        protected void CargaConfort(int IdPropiedad)
        {
            DivConfort.Visible = true;
            DivImagenes.Visible = true;
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            GvConfort.DataSource = oNegocio.Get_Propiedades_Confort(IdPropiedad);
            GvConfort.DataBind();
        }

        protected void BtnNuevoConfort_Click(object sender, EventArgs e)
        {
            LbIdConfort.Text = "-1";
            TbDescripcionConfort.Text = "";
        }

        protected void GvConfort_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();

            int Id = Convert.ToInt32(GvConfort.Rows[e.NewEditIndex].Cells[0].Text);
            var oConf = oNegocio.Get_Propiedades_ConfortxID(Id);
            LbIdConfort.Text = Id.ToString();
            TbDescripcionConfort.Text = oConf.Descripcion;


        }

        protected void BntGuardarConfort_Click(object sender, EventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            Prop_Confort oConfort = new Prop_Confort();
            oConfort.IdPropiedad = Convert.ToInt32(lbId.Text);
            oConfort.IdConfort = Convert.ToInt32(LbIdConfort.Text);
            oConfort.Descripcion = TbDescripcionConfort.Text;
            oNegocio.Save_Propiedades_Confort(oConfort);
            CargaConfort(Convert.ToInt32(lbId.Text));
        }

        protected void GvConfort_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            Prop_Confort oConfort = new Prop_Confort();
            oConfort.IdPropiedad = Convert.ToInt32(lbId.Text);
            oConfort.IdConfort = Convert.ToInt32(GvConfort.Rows[e.RowIndex].Cells[0].Text);
            oNegocio.Del_Propiedades_Confort(oConfort);
            CargaConfort(Convert.ToInt32(lbId.Text));
            //Enviar a Borrar
        }

        protected void BtnImg1_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(1);
        }

        protected void BtnImg2_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(2);
        }

        protected void BtnImg3_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(3);
        }

        protected void BtnImg4_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(4);
        }

        protected void BtnImg5_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(5);
        }

        protected void BtnImg6_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(6);
        }

        protected void BtnImg7_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(7);
        }

        protected void BtnImg8_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(8);
        }

        protected void BtnImg9_Click(object sender, ImageClickEventArgs e)
        {
            GuardarImagen(9);
        }
        private void CargaImagenes(int IdPropiedad)
        {   //Cargo la galeria de imgenes
            BtnImg1.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/1.JPG";
            BtnImg2.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/2.JPG";
            BtnImg3.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/3.JPG";
            BtnImg4.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/4.JPG";
            BtnImg5.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/5.JPG";
            BtnImg6.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/6.JPG";
            BtnImg7.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/7.JPG";
            BtnImg8.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/8.JPG";
            BtnImg9.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/9.JPG";

        }

        private void GuardarImagen(int IdImagen)
        {
            if (FUpload.HasFile)
            {
                string Archivo = FUpload.FileName.ToString();
                //verifico el formato jpg o png 
                if (Archivo.ToUpper().Contains(".JPG"))
                {
                    string extencion = ".JPG";
                    //verifico la dimension de la imagen
                    System.Drawing.Image viImagen = System.Drawing.Image.FromStream(FUpload.PostedFile.InputStream);
                    if (viImagen.PhysicalDimension.Width <= 1280 && viImagen.PhysicalDimension.Height <= 960)
                    { // guardo la imagen en imagenes/noticias
                        try
                        {     // subo el nombre del archivo al objeto
                            string nombrArchivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            FUpload.SaveAs(Server.MapPath("~\\Imagenes\\Propiedades\\" +lbId.Text+"\\" +IdImagen.ToString() + extencion));
                            LbError.Text = "";
                            CargaImagenes(Convert.ToInt32(lbId.Text));
                            Response.Cache.SetNoStore();
                            FUpload.Focus();
                        }
                        catch (Exception ex)
                        {
                            _logger1.Error(ex, " Carga Imangen Propiedad");
                        }
                    }
                    else
                    {
                        LbError.Text = "La imagen debe ser menor a 1280px x 960px ";
                        LbError.Focus();
                    }
                }
                else
                {
                    LbError.Text = "Solo imagenes de extensio .jpg";
                    LbError.Focus();
                }
            }
            else
            {
                LbError.Text = " No se ha seleccionado una imágen.";
                LbError.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            Propiedades oPropiedad = new Propiedades();
            try
            {
                oPropiedad.IdPropiedades = Convert.ToInt32(lbId.Text);
                oPropiedad.Plazas = Convert.ToInt32(TbPax.Text);
                oPropiedad.Intro = TbIntro.Text;
                oPropiedad.Nombre = TbPropiedad.Text;
                oPropiedad.Direccion = TbDireccion.Text;
                if (oPropiedad.IdPropiedades > 0)
                {
                    oNegocio.Save_Propiedad(oPropiedad);
                    LbError.Text = "Se acualizo el contenido de forma exitosa";
                }
                else
                {
                    LbError.Text = "No es posible agregar una nueva Propiedad.";
                }
               
            }
            catch (Exception ex)
            {
                LbError.Text = "Se produjo un error al guardar. ";
                LbError.Focus();
            }
           
        }
    }
}