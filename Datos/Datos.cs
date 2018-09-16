using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Contrato;
using System.Configuration;
using MySql.Data.MySqlClient;
using NLog;

namespace Datos
{
    public partial class Datos
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");

        public string StringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["CdelesteDBConnectionString"].ConnectionString;

        #region Usuarios
        public Usuarios GetUsuario(string Usuario, string Password)
        {
            Usuarios oUsuario = new Usuarios();
            try
            {
                MySqlConnection oConeccion = new MySqlConnection(StringConnection);
                string query = "SELECT Apellido,Nombre, Usuario,Rol ,PASSWORD FROM Usuarios "
                + " WHERE Usuario = '" + Usuario + "' AND PASSWORD = '" + Password + "'";

                oConeccion.Open();

                MySqlCommand myCommand = new MySqlCommand(query, oConeccion);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Usuario");

                if (myDS.Tables["Usuario"].Rows.Count > 0)
                {
                    oUsuario.Apellido = myDS.Tables["Usuario"].Rows[0].ItemArray[0].ToString();
                    oUsuario.Nombre = myDS.Tables["Usuario"].Rows[0].ItemArray[1].ToString();
                    oUsuario.Usuario = myDS.Tables["Usuario"].Rows[0].ItemArray[2].ToString();
                    oUsuario.Rol = myDS.Tables["Usuario"].Rows[0].ItemArray[3].ToString();
                    oUsuario.Password = myDS.Tables["Usuario"].Rows[0].ItemArray[4].ToString();

                }
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get Usuario");
            }
            //buscar en base
            return oUsuario;
        }
        #endregion
    }

}
