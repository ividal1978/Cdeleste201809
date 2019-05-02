using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;

namespace WebApplication1
{
    public partial class Inquilinos_ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Autenticar();
            }
            else
            {
                if (TbNombreCmb.Text.Contains("#"))
                {
                    int inicio = TbNombreCmb.Text.IndexOf("#") +1;
                    int Fin = TbNombreCmb.Text.Length;
                    int ID = Convert.ToInt32(TbNombreCmb.Text.Substring(inicio, Fin - inicio));
                    Carga_Datos(ID);
                }
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

        protected void Carga_Datos(int Id)
        {

        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] Sugerencias(string prefixText, int count)
        {
            List<InquilinoCMB> oPersonas = new List<InquilinoCMB>();
            string[] PNombres = null; ;

            Negocio.Negocio oNegocio = new Negocio.Negocio();
            
            prefixText = prefixText.ToUpper();
            oPersonas = oNegocio.GetInquilinoCMB(prefixText);



            IEnumerable<string> ds = from P in oPersonas
                                     orderby P.Nombre_inquilino
                                     select (P.Nombre_inquilino + " #"+P.IdInquilino);

            PNombres = ds.ToArray<string>();
                    
             
            return PNombres.ToArray();
        }
    }
}