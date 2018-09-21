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

            public Usuarios GetUsuario(string Usuario, string Password)
            {
                return oData.GetUsuario(Usuario, Password);
            }


            #region Noticias
            public List<Noticias> GetNoticias(string Tipo, int Cantidad)
            {
                return oData.GetNoticias(Tipo, Cantidad);
            }
            #endregion
        }
  
}
