﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contrato;
using Negocio;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarNoticias();
            CargarPortada();
        }
        protected void CargarNoticias()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            List<Noticias> lNoticias = new List<Noticias>();
            foreach (var aux in oNegocio.GetNoticias("NOTI", 4))
            {
                Noticias nNoticia = new Noticias();
                nNoticia.IdNoticia = aux.IdNoticia;
                nNoticia.Fecha = aux.Fecha;
                nNoticia.Noticia = aux.Noticia;
                nNoticia.Tipo = aux.Tipo;
                if (aux.RutaImagen == null || aux.RutaImagen.Length < 2)
                {
                    nNoticia.RutaImagen = "noticiaVacia.png"; 
                 }
                else
                {
                    nNoticia.RutaImagen = aux.RutaImagen;
                }
                lNoticias.Add(nNoticia);
            }


            dlNoticias.DataSource = lNoticias;
            dlNoticias.DataBind();
        }
        protected void CargarPortada()
        {
            Negocio.Negocio oNegocio = new Negocio.Negocio();
            var Query = oNegocio.GetNoticias("PORT", 1).FirstOrDefault();
            if (Query != null)
            {
               lbPortada.Text = Query.Noticia;
            }
            else
            {
                lbPortada.Text = " <p> Seguimos renovado nuestro sitio web para poder seguir brindando mejores servicios a la las familias que que nos eligen año tras año. </p>" +
                                 " <p> Ya que contamos con mas de 35 años en Costa del Este, brindando excelentes vacaciones para Usted y su familia." +
                                 " En un lugar donde pueda descansar y disfrutar del bosque, la playa y el mar durante todo el año. </p>" +
                                 " <p> Un lugar para disfrutar de la frescura del mar y la tranquilidad del bosque.La playa del millón de pinos lo invita a pasar una de las estadías mas placenteras que la naturaleza le puede brindar. </p> ";
            }
            

            
        }
    }
}