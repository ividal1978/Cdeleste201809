using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Contrato;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Datos
{
    public partial class Datos
    {
        public string StringConnection = "Server=localhost;Database=cdeleste_DB;User ID=cdeleste_rpt ;Password=costa10";
        public Usuarios GetUsuario(string Usuario, string Password)
        {
            Usuarios oUsuario = new Usuarios();
            //        System.Configuration.ConfigurationManager.
            //ConnectionStrings["connectionStringName"].ConnectionString;

            string StringConnection = System.Configuration.ConfigurationManager.ConnectionString["CdelesteDBConnectionString"].ConnectionString;

            //buscar en base
            return oUsuario;
        }
    }

}
