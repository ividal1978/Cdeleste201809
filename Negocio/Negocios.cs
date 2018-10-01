using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contrato;
using Datos;

namespace Negocio
{

    public partial class Negocio
    {
        // Instancia de la capa de datos
        public Datos.Datos oData = new Datos.Datos();

        public Usuarios GetUsuario(string Usuario, string Password) => oData.GetUsuario(Usuario, Password);

        #region Noticias
        public List<Noticias> GetNoticias(string Tipo, int Cantidad) => oData.GetNoticias(Tipo, Cantidad);


        public List<Noticias> GetNoticias_All(string Tipo) => oData.GetNoticias_All(Tipo);

        public Noticias GetNoticias_One(int IdNoticia)
        {
            return oData.GetNoticias_One(IdNoticia);

        }
        /// <summary>
        /// Guarda o modifica un registro de noticia
        /// </summary>
        /// <param name="oNoticia"></param>
        public void SaveNoticia(Noticias oNoticia)
        {
            if (oNoticia.IdNoticia > 0)
            {
                //Noticia Update
                oData.UpdateNoticia(oNoticia);
            }
            else
            {
                //Noticias Save
                oData.InsertNoticia(oNoticia);
            }
        }
        #endregion

    }
}
