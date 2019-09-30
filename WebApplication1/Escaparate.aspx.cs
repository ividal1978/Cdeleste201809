using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;


namespace WebApplication1
{
    public partial class Escaparate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                CargaPropiedad(Id);
                CargaCaracterisitecas(Id);
                CargaImagenes(Id);
                hdnId.Value = (Id>0&&Id<9?Id.ToString():"-1");
            }
            else
            {
                Response.Redirect("Error.aspx?Msg=PNExiste");
            }
        }

        private void CargaPropiedad(int IdPropiedad)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            Propiedades oProp = new Propiedades();
            oProp = oNegocio.Get_Propiedad(IdPropiedad);
            LbPropiedad.Text = oProp.Nombre;
            LbDireccion.Text = "Direccion: " + oProp.Direccion + " (Pax :"+oProp.Plazas+")";
            lbDescripcion.Text =oProp.Intro;
        }

        private void CargaCaracterisitecas(int IdPropiedad)
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            rptDescripcion.DataSource= oNegocio.Get_Propiedades_Confort(IdPropiedad);
            rptDescripcion.DataBind();
        }

        private void CargaImagenes(int IdPropiedad)
        {   //Cargo imagen de Referencia
            ImgReferencia.ImageUrl = "~/Imagenes/Propiedades/"+IdPropiedad.ToString()+"/Intro.JPG";
            //Cargo la galeria de imgenes
            Img1.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/1.JPG";
            Link1.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/1.JPG";
            Img2.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/2.JPG";
            Link2.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/2.JPG";
            Img3.ImageUrl= "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/3.JPG";
            Link3.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/3.JPG";
            Img4.ImageUrl= "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/4.JPG";
            Link4.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/4.JPG";
            Img5.ImageUrl= "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/5.JPG";
            Link5.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/5.JPG";
            Img6.ImageUrl= "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/6.JPG";
            Link6.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/6.JPG";
            Img7.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/7.JPG";
            Link7.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/7.JPG";
            Img8.ImageUrl = "~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/8.JPG";
            Link8.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/8.JPG";
            Img9.ImageUrl="~/Imagenes/Propiedades/" + IdPropiedad.ToString() + "/9.JPG";
            Link9.HRef = "../Imagenes/Propiedades/" + IdPropiedad.ToString() + "/9.JPG";
        }

        protected void btmDisponibilidad_Click(object sender, EventArgs e)
        {
            Server.Transfer($"Reserva_Cliente.aspx?IdProp={hdnId.Value}");
        }

        protected void BtnFaqs_Click(object sender, EventArgs e)
        {
            Server.Transfer("PreguntasFrecuentes.aspx?tipoPreg=PF&IdProp="+ hdnId.Value.ToString() );
        }
    }
}