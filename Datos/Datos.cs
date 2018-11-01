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

        // public string StringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["CdelesteDBConnectionString"].ConnectionString;
        public string StringConnection = "Server=localhost;Database=cdeleste_DB;User ID = cdeleste_rpt; Password=costa10;";
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

        #region Noticias
        public List<Noticias> GetNoticias(string Tipo, int Cantidad)
        {
            List<Noticias> oLista = new List<Noticias>( );
            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;//"Server=localhost;Database=cdeleste_DB;User ID=cdeleste_rpt ;Password=costa10;";//Pooling=false";
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT Fecha, Noticia, IDNoticia, Tipo, RutaImagen " +
                "FROM Noticias  WHERE Tipo = '"+Tipo+"' ORDER BY Fecha DESC  LIMIT 0 , "+Cantidad.ToString()+"";

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Noticias");

                foreach (DataRow oFila in myDS.Tables["Noticias"].Rows)
                {
                    Noticias oNoticia = new Noticias();
                    oNoticia.IdNoticia = Convert.ToInt32(oFila[2].ToString());
                    oNoticia.Fecha = Convert.ToDateTime(oFila[0].ToString());
                    oNoticia.Noticia = oFila[1].ToString();
                    oNoticia.Tipo = oFila[3].ToString();
                    oNoticia.RutaImagen = oFila[4].ToString();

                    oLista.Add(oNoticia);
                }
                myCommand.Dispose();
                conn.Close();
            }
            catch(Exception ex)
            {
                _logger1.Error(ex, "Datos - GetNoticias");
            }
            return oLista;
        }

        public List<Noticias> GetNoticias_All(string Tipo)
        {
            List<Noticias> oLista = new List<Noticias>();
            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;//"Server=localhost;Database=cdeleste_DB;User ID=cdeleste_rpt ;Password=costa10;";//Pooling=false";
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT Fecha, Noticia, IDNoticia, Tipo, RutaImagen " +
                "FROM Noticias  WHERE Tipo = '" + Tipo + "' ORDER BY Fecha DESC ";

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Noticias");

                foreach (DataRow oFila in myDS.Tables["Noticias"].Rows)
                {
                    Noticias oNoticia = new Noticias();
                    oNoticia.IdNoticia = Convert.ToInt32(oFila[2].ToString());
                    oNoticia.Fecha = Convert.ToDateTime(oFila[0].ToString());
                    oNoticia.Noticia = oFila[1].ToString();
                    oNoticia.Tipo = oFila[3].ToString();
                    oNoticia.RutaImagen = oFila[4].ToString();

                    oLista.Add(oNoticia);
                }
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - GetNoticias_All");
            }
            return oLista;
        }

        /// <summary>
        /// Devuelve solo una noticia por id
        /// </summary>
        /// <param name="IdNoticia"></param>
        /// <returns></returns>
        public Noticias GetNoticias_One(int IdNoticia)
        {
            List<Noticias> oLista = new List<Noticias>();
            Noticias oNoticia = new Noticias();
            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT Fecha, Noticia, IDNoticia, Tipo, RutaImagen " +
                "FROM Noticias  WHERE IDNoticia = " + IdNoticia.ToString() ;

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Noticias");
             
                foreach (DataRow oFila in myDS.Tables["Noticias"].Rows)
                {
                  
                    oNoticia.IdNoticia = Convert.ToInt32(oFila[2].ToString());
                    oNoticia.Fecha = Convert.ToDateTime(oFila[0].ToString());
                    oNoticia.Noticia = oFila[1].ToString();
                    oNoticia.Tipo = oFila[3].ToString();
                    oNoticia.RutaImagen = oFila[4].ToString();

                }
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - GetNoticia_One");
            }
            return oNoticia; ;
        }

        public void InsertNoticia(Noticias oNoticia)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "INSERT INTO Noticias (Fecha, Noticia, Tipo, RutaImagen) VALUES " +
                "(now(),'"+oNoticia.Noticia.Trim()+"','"+oNoticia.Tipo+"','"+oNoticia.RutaImagen+"')";

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Noticias - InsertNoticia");
            }
        }

        public void UpdateNoticia(Noticias oNoticia)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "UPDATE Noticias SET "+
                "Noticia ='" +oNoticia.Noticia.Trim() +"',"+
                "RutaImagen ='" +oNoticia.RutaImagen +"'"+
                "WHERE IDNoticia= " + oNoticia.IdNoticia.ToString() ;

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Noticias - InsertNoticia");
            }
        }

        public void DeleteNoticia (int IdNoticia)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection();
                string query = "DELETE Noticias WHERE IdNoticia = " + IdNoticia.ToString();
                conn.Open();
                MySqlCommand myCommand = new MySqlCommand(query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Clone();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - DeleteNoticia");
            }
        }
        #endregion

        #region Propiedades

        public Propiedades Get_Propiedad(int IdPropiedad)
        {
           Propiedades oPropiedades = new Propiedades();


            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT IDPropiedad,Nombre, Plazas, Direccion,Intro " +
                "FROM propiedades WHERE IDPropiedad = " + IdPropiedad.ToString();

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Propiedad");

                foreach (DataRow oFila in myDS.Tables["Propiedad"].Rows)
                {

                    oPropiedades.IdPropiedades = Convert.ToInt32(oFila[0].ToString());
                    oPropiedades.Nombre = oFila[1].ToString();
                    oPropiedades.Plazas = Convert.ToInt32(oFila[2].ToString());
                    oPropiedades.Direccion = oFila[3].ToString();
                    oPropiedades.Intro = oFila[4].ToString();
                    
                }
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get_Propiedad");
            }
            return oPropiedades;
        }

        public List<Prop_Confort>Get_Propiedades_Confort(int IdPropiedad)
        {
            List<Prop_Confort> oLista = new List<Prop_Confort>();
            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = " SELECT IDPropiedad,IDConfort,Descripcion FROM prop_confort Where IDPropiedad = " + IdPropiedad.ToString() +
                " order by IDConfort";
        
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Confort");

                foreach (DataRow oFila in myDS.Tables["Confort"].Rows)
                {
                    Prop_Confort oConfort = new Prop_Confort();
                    oConfort.IdPropiedad = Convert.ToInt32(oFila[0].ToString());
                    oConfort.IdConfort = Convert.ToInt32(oFila[1].ToString());
                    oConfort.Descripcion = oFila[2].ToString();
                    oLista.Add(oConfort);

                }
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get_Propiedades_Confort");
            }
            return oLista;
        }

        public List<Propiedades> Get_Propiedades_All()
        {
            List<Propiedades> oPropiedades = new List<Propiedades>();


            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT IDPropiedad,Nombre, Plazas, Direccion,Intro " +
                "FROM propiedades ";

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Propiedad");

                foreach (DataRow oFila in myDS.Tables["Propiedad"].Rows)
                {
                    Propiedades oPropiedad = new Propiedades();
                    oPropiedad.IdPropiedades = Convert.ToInt32(oFila[0].ToString());
                    oPropiedad.Nombre = oFila[1].ToString();
                    oPropiedad.Plazas = Convert.ToInt32(oFila[2].ToString());
                    oPropiedad.Direccion = oFila[3].ToString();
                    oPropiedad.Intro = oFila[4].ToString();

                    oPropiedades.Add(oPropiedad);
                }
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get_Propiedad_ALL");
            }
            return oPropiedades;
        }

        public Prop_Confort Get_Propiedades_ConfortxID(int IdConfort)
        {
            Prop_Confort oConfort = new Prop_Confort();

            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = " SELECT IDPropiedad, IDConfort, Descripcion from prop_confort Where IDConfort =" + IdConfort.ToString();

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Confort");
            
                foreach (DataRow oFila in myDS.Tables["Confort"].Rows)
                {
                   
                    oConfort.IdPropiedad = Convert.ToInt32(oFila[0].ToString());
                    oConfort.IdConfort = Convert.ToInt32(oFila[1].ToString());
                    oConfort.Descripcion = oFila[2].ToString();
                }

                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get_Propiedades_ConfortxID");
            }

            return oConfort;
        }

        #endregion
    }


   
}

