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
        public Usuarios GetUsuarioXNombre(string Usuario)
        {
            Usuarios oUsuario = new Usuarios();
            try
            {
                MySqlConnection oConeccion = new MySqlConnection(StringConnection);




                string query = "SELECT Apellido,Nombre, Usuario,Rol ,PASSWORD,IdUsuario FROM Usuarios "
                + " WHERE Usuario = '" + Usuario + "' Limit 1 ";

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
                    oUsuario.IdUsuario = Convert.ToInt32(myDS.Tables["Usuario"].Rows[0].ItemArray[5].ToString());

                }
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get UsuarioxNombre");
            }
            //buscar en base
            return oUsuario;
        }
        #endregion

        #region Noticias
        public List<Noticias> GetNoticias(string Tipo, int Cantidad)
        {
            List<Noticias> oLista = new List<Noticias>();
            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;//"Server=localhost;Database=cdeleste_DB;User ID=cdeleste_rpt ;Password=costa10;";//Pooling=false";
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT Fecha, Noticia, IDNoticia, Tipo, RutaImagen " +
                "FROM Noticias  WHERE Tipo = '" + Tipo + "' ORDER BY Fecha DESC  LIMIT 0 , " + Cantidad.ToString() + "";

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
                "FROM Noticias  WHERE IDNoticia = " + IdNoticia.ToString();

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
                "(now(),'" + oNoticia.Noticia.Trim() + "','" + oNoticia.Tipo + "','" + oNoticia.RutaImagen + "')";

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
                string query = "UPDATE Noticias SET " +
                "Noticia ='" + oNoticia.Noticia.Trim() + "'," +
                "RutaImagen ='" + oNoticia.RutaImagen + "'" +
                "WHERE IDNoticia= " + oNoticia.IdNoticia.ToString();

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

        public void DeleteNoticia(int IdNoticia)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection();
                string query = "DELETE FROM Noticias WHERE IdNoticia = " + IdNoticia.ToString();
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

        public List<Prop_Confort> Get_Propiedades_Confort(int IdPropiedad)
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

        public void Save_Propiedades_Confort(Prop_Confort oConfort)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                if (oConfort.IdConfort > 0)
                {//update

                    Query = "UPDATE prop_confort SET " +
                    " Descripcion = '" + oConfort.Descripcion.Trim() + "'" +
                    " WHERE IDPropiedad =" + oConfort.IdPropiedad + " AND " +
                    " IdConfort = " + oConfort.IdConfort.ToString();
                }
                else
                {//Insert
                    Query = "Insert into prop_confort (IDPropiedad,Descripcion) Values " +
                        "(" + oConfort.IdPropiedad + ",'" + oConfort.Descripcion + "')";
                }

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Propiedades - Save Confort");
            }
        }

        public void Del_Propiedades_Confort(Prop_Confort oConfort)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "DELETE FROM prop_confort " +
                    " WHERE IDPropiedad =" + oConfort.IdPropiedad + " AND " +
                    " IdConfort = " + oConfort.IdConfort.ToString();
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Propiedades - Del Confort");
            }
        }

        public List<Combo> Get_Propiedades_CMB()
        {
            List<Combo> oLista = new List<Combo>();
            try
            {
                //Este proceso carga las noticias existentes
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string query = "SELECT IDPropiedad,Nombre FROM propiedades ";

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Propiedad");

                foreach (DataRow oFila in myDS.Tables["Propiedad"].Rows)
                {
                    Combo oItem = new Combo();
                    oItem.Id = Convert.ToInt32(oFila[0].ToString());
                    oItem.Descripcion = oFila[1].ToString();
                    oLista.Add(oItem);
                }
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Get_Propiedad_ALL");
            }
            return oLista;

        }
        #endregion

        #region Consultas

        public void Save_Comentario(Comentarios oCometrario)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                if (oCometrario.IdComentario > 0)
                {//update

                    Query = "UPDATE Comentarios SET " +
                    " Estado = '" + oCometrario.Estado.Trim() + "'," +
                    " Tipo = '" + oCometrario.Tipo.Trim() + "'" +
                    " WHERE IdComentario =" + oCometrario.IdComentario;

                }
                else
                {//Insert
                    Query = "INSERT INTO Comentarios (FechaComentario,Nombre_Persona, Tel_Persona, Estado, Comentario, Tipo, IdPropiedad, Mail_Persona) Values " +
                        "(now(),'" + oCometrario.Nombre_Persona + "','" + oCometrario.Tel_Persona + "','" +
                        oCometrario.Estado + "','" + oCometrario.Comentario + "','" + oCometrario.Tipo + "'," + Convert.ToInt32(oCometrario.IdPropiedad) + ",'" + oCometrario.Mail_Persona + "')";
                }

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Comentario - Save Comentario ");
            }
        }

        public List<Consulta_Tipo> Get_Consulta_Tipo()
        {
            try {
                List<Consulta_Tipo> oLista = new List<Consulta_Tipo>();
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT * FROM Consultas_Tipo";
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "ConsultasTipos");

                foreach (DataRow oFila in myDS.Tables["ConsultasTipos"].Rows)
                {
                    Consulta_Tipo oItem = new Consulta_Tipo();
                    oItem.ID = Convert.ToInt32(oFila[0].ToString());
                    oItem.Descrip = oFila[1].ToString();
                    oItem.Codigo = oFila[2].ToString();

                    oLista.Add(oItem);
                }
                myCommand.Dispose();
                conn.Close();
                return oLista;
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Comentario - Save Comentario :: " + ex.StackTrace.ToString());
                return null;
            }
        }

        public List<Comentarios> Get_ComentariosxTipo(string TipoComentario, string Estado)
        {
            try
            {
                List<Comentarios> oLista = new List<Comentarios>();
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT * FROM comentarios where Tipo='" + TipoComentario + "' and Estado='" + Estado + "' order by FechaComentario desc";
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Comentarios");

                foreach (DataRow oFila in myDS.Tables["Comentarios"].Rows)
                {
                    Comentarios oItem = new Comentarios();
                    oItem.IdComentario = Convert.ToInt32(oFila[0].ToString());
                    oItem.FechaComentario = Convert.ToDateTime(oFila[1].ToString());
                    oItem.Nombre_Persona = oFila[2].ToString();
                    oItem.Tel_Persona = oFila[3].ToString();
                    oItem.Mail_Persona = oFila[4].ToString();
                    oItem.Estado = oFila[5].ToString();
                    oItem.Comentario = oFila[6].ToString();
                    oItem.Tipo = oFila[7].ToString();
                    oItem.IdPropiedad = oFila[8].ToString();


                    oLista.Add(oItem);
                }
                myCommand.Dispose();
                conn.Close();
                return oLista;
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Comentario - Get Comentario x Tipo y Estado :: " + ex.StackTrace.ToString());
                return null;
            }

        }

        public Comentarios Get_Cometario(int IdComentario)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT * FROM comentarios where IdComentario=" + IdComentario.ToString() + " order by FechaComentario desc";
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Comentarios");

                Comentarios oItem = new Comentarios();
                foreach (DataRow oFila in myDS.Tables["Comentarios"].Rows)
                {
                    oItem.IdComentario = Convert.ToInt32(oFila[0].ToString());
                    oItem.FechaComentario = Convert.ToDateTime(oFila[1].ToString());
                    oItem.Nombre_Persona = oFila[2].ToString();
                    oItem.Tel_Persona = oFila[3].ToString();
                    oItem.Mail_Persona = oFila[4].ToString();
                    oItem.Estado = oFila[5].ToString();
                    oItem.Comentario = oFila[6].ToString();
                    oItem.Tipo = oFila[7].ToString();
                    oItem.IdPropiedad = oFila[8].ToString();
                }
                myCommand.Dispose();
                conn.Close();
                return oItem;
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Comentario - Get Comentario x Id :: " + ex.StackTrace.ToString());
                return null;
            }
        }

        public Respuestas Get_Respuesta(int IdRespuesta)
        {
            try
            {
                List<Comentarios> oLista = new List<Comentarios>();
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT * FROM respuestas where IdRespuesta = " + IdRespuesta.ToString();
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Respuestas");

                Respuestas oItem = new Respuestas();
                foreach (DataRow oFila in myDS.Tables["Respuestas"].Rows)
                {
                    oItem.IdRespuesta = Convert.ToInt32(oFila[0].ToString());
                    oItem.Tipo = oFila[1].ToString();
                    oItem.Fecha = Convert.ToDateTime(oFila[2].ToString());
                    oItem.Respuesta = oFila[3].ToString();
                    oItem.Estado = oFila[4].ToString();
                }
                myCommand.Dispose();
                conn.Close();
                return oItem;
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Respuesta - Get Respuesta x Id :: " + ex.StackTrace.ToString());
                return null;
            }
        }

        public void Save_Respuesta(Respuestas oRespuesta)
        {
            Respuestas Existe = Get_Respuesta(oRespuesta.IdRespuesta);

            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                if (Existe.Respuesta != null)
                {
                    //Realizar un update
                    Query = "UPDATE respuestas SET " +
                    " Estado = '" + oRespuesta.Estado + "'," +
                    " Tipo = '" + oRespuesta.Tipo + "'," +
                    " Fecha = now(), " +
                    " Respuesta = '" + oRespuesta.Respuesta + "'" +
                    " WHERE IdRespuesta =" + oRespuesta.IdRespuesta;
                }
                else
                {
                    //Realizar un insert
                    Query = " INSERT INTO respuestas (IdRespuesta, Tipo, Fecha, Respuesta, Estado) VALUES " +
                    "(" + oRespuesta.IdRespuesta + ",'" + oRespuesta.Tipo + "',now(),'" + oRespuesta.Respuesta + "'" +
                    ",'" + oRespuesta.Estado + "')";

                }
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Comentarios - Save Respuesta :: " + ex.StackTrace.ToString());
            }

        }

        public List<PreguntaFrecuente>Get_PreguntasFrecuentes(string TipoPregunta, int IdPropiedad)
        {
            try
            {
                List<PreguntaFrecuente> oLista = new List<PreguntaFrecuente>();
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = " SELECT c.IdComentario, c.comentario,c.estado,c.fechaComentario, c.Tipo, c.idpropiedad,r.Respuesta " +
                        " FROM comentarios c " +
                        " INNER JOIN respuestas r on c.IdComentaro = r.IdComentario " +
                        " where Tipo='" + TipoPregunta + "' and Estado='Respondida' ";
                if (IdPropiedad > 0)
                    Query += " and c.idpropiedad =" + IdPropiedad;
                Query += " order by FechaComentario desc";

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Comentarios");

                foreach (DataRow oFila in myDS.Tables["Comentarios"].Rows)
                {
                    PreguntaFrecuente oItem = new PreguntaFrecuente();
                    oItem.IdComentario = Convert.ToInt32(oFila[0].ToString());
                    oItem.Comentario = oFila[1].ToString();
                    oItem.Estado = oFila[2].ToString();
                    oItem.FechaComentario = Convert.ToDateTime(oFila[3].ToString());
                    oItem.Tipo = oFila[4].ToString();
                    oItem.IdPropiedad = oFila[5].ToString();
                    oItem.Respuesta = oFila[6].ToString();


                    oLista.Add(oItem);
                }
                myCommand.Dispose();
                conn.Close();
                return oLista;
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Comentario -  Get_PreguntasFrecuentes x Tipo y Propiedad :: " + ex.StackTrace.ToString());
                return null;
            }
        }

        #endregion

        #region Inquilinos

        public List<InquilinoCMB> GetInquilinoCMB(string Nombre)
        {
            List<InquilinoCMB> ListaInquilinos = new List<InquilinoCMB>();
            try
            {
                
                MySqlConnection oConeccion = new MySqlConnection(StringConnection);
                string query = "SELECT IDInquilino, Concat(Nombre,', ', Apellido ) Inquilino from inquilino"+
                                " Where UPPER(Concat(Nombre,' ', Apellido)) like '%"+ Nombre +"%'"+
                                " Order by  Concat(Nombre, ' ', Apellido) desc";

                oConeccion.Open();

                MySqlCommand myCommand = new MySqlCommand(query, oConeccion);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Inquilinos");

                foreach (DataRow Q in myDS.Tables["Inquilinos"].Rows)
                {
                    InquilinoCMB oInq = new InquilinoCMB();
                    oInq.IdInquilino = Convert.ToInt32(Q[0].ToString());
                    oInq.Nombre_inquilino = Q[1].ToString();
                    ListaInquilinos.Add(oInq);

                }
                
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Inquilino - Get InquilinoCMB  :: " + ex.StackTrace.ToString() );
            }
            //buscar en base
            return ListaInquilinos;
   
        }

        public Inquilino Get_Inquilino(int ID)
        {
          Inquilino oInquilino = new Inquilino();
            try
            {

                MySqlConnection oConeccion = new MySqlConnection(StringConnection);
                string query = "SELECT * FROM inquilino WHERE idInquilino = " + ID.ToString();

                oConeccion.Open();

                MySqlCommand myCommand = new MySqlCommand(query, oConeccion);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Inquilino");

                foreach (DataRow Q in myDS.Tables["Inquilino"].Rows)
                {
                    oInquilino.ID_Inquilino = Convert.ToInt32(Q[0].ToString());
                    oInquilino.Nombre = Q[1].ToString();
                    oInquilino.Apellido = Q[2].ToString();
                    oInquilino.Telefono = Q[3].ToString();
                    oInquilino.Email = Q[4].ToString();
                    oInquilino.Obs = Q[5].ToString();
                    oInquilino.Celular = Q[6].ToString();
                    oInquilino.Reside = Q[7].ToString();
                                    }

            }
            catch (Exception ex)
            {
                _logger1.Error(ex, "Datos - Inquilino - Get Inquilino :: " + ex.StackTrace.ToString());
            }
            //buscar en base
            return oInquilino;

        }

        public void Save_Inquilino(Inquilino oInquilino)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string Query = "";
                if (oInquilino.ID_Inquilino > 0)
                {
                    //UPDATE
                     Query = " UPDATE inquilino" +
                                   " SET " +
                                   " Nombre ='" + oInquilino.Nombre + "'," +
                                   " Apellido = '" + oInquilino.Apellido + "'," +
                                   " Telefono = '" + oInquilino.Telefono + "'," +
                                   " Email = '" + oInquilino.Email + "'," +
                                   " Obs = '" + oInquilino.Obs + "'," +
                                   " Celular = '" + oInquilino.Celular + "'," +
                                   " Reside = '" + oInquilino.Reside + "'" +
                                   " WHERE IDInquilino =" + oInquilino.ID_Inquilino + " ;";

                }
                else
                {//INSERT
                    Query = "INSERT INTO inquilino (Nombre,Apellido,Telefono,Email,Obs,Celular,Reside) VALUES " +
                           "('" + oInquilino.Nombre + "','" + oInquilino.Apellido + "','" + oInquilino.Telefono + "','" + oInquilino.Email + "','" +
                             oInquilino.Obs + "','" + oInquilino.Celular + "','" + oInquilino.Reside + "');";
                }

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Inquilino - Save :: " + ex.StackTrace.ToString());
            }

        }
        #endregion 

        #region Reservas

        //una reserva por id
        public Reservas Get_ReservaxId(int IdReserva)
        {
            try
            {
                Reservas oReserva = new Reservas();
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT R.FReserva, R.IDReserva, R.IDPropiedad, P.Nombre,R.IDInquilino,I.Nombre,"+
                        " I.Apellido, R.Fdesde,R.Fhasta, ifnull(R.Monto_Reserva,0),ifnull(R.Monto_Total,0),"+
                        " R.Pagado,R.IDusuario, U.Usuario ,ifnull(R.FdePago,'1900-01-01'), R.Estado" +
                        " From reservas R "+
                        " Inner join inquilino I on R.IDInquilino = I.IDInquilino " +
                        " Inner join propiedades P on R.IDPropiedad = P.IdPropiedad "+
                        " Inner join usuarios U on R.IDusuario = U.idusuario"+
                        " Where IDReserva = " + IdReserva.ToString() +
                        " Limit 1";
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Reservas");

                Respuestas oItem = new Respuestas();
                foreach (DataRow oFila in myDS.Tables["Reservas"].Rows)
                {
                    oReserva.FReserva = Convert.ToDateTime(oFila[0].ToString());
                    oReserva.IdReserva = Convert.ToInt32(oFila[1].ToString());
                    oReserva.IdPropiedad = Convert.ToInt32(oFila[2].ToString());
                    oReserva.Propiedad_Nombre = oFila[3].ToString();
                    oReserva.IdInquilino = Convert.ToInt32(oFila[4].ToString());
                    oReserva.Inquilino_Nombre = oFila[5].ToString();
                    oReserva.Inquilino_Apellido = oFila[6].ToString();
                    oReserva.FDesde = Convert.ToDateTime(oFila[7].ToString());
                    oReserva.FHasta = Convert.ToDateTime(oFila[8].ToString());
                    oReserva.Monto_Reserva = Convert.ToDecimal(oFila[9].ToString());
                    oReserva.Monto_Total = Convert.ToDecimal(oFila[10].ToString());
                    oReserva.Pagado = oFila[11].ToString();
                    oReserva.IdUsuario = Convert.ToInt32(oFila[12].ToString());
                    oReserva.Usuario_User = oFila[13].ToString();
                    oReserva.FDePago = Convert.ToDateTime(oFila[14].ToString());
                    oReserva.Estado = oFila[15].ToString();
                    
                }
                myCommand.Dispose();
                conn.Close();
                return oReserva;
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Reservas - Get Reservas x Id :: " + ex.StackTrace.ToString());
                return null;
            }

        }

        public List<Reservas> Get_ReservaxFecha(DateTime Fecha)
        {
            try
            {
                List<Reservas> oLista = new List<Reservas>();

                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT R.FReserva, R.IDReserva, R.IDPropiedad, P.Nombre,R.IDInquilino,I.Nombre," +
                        " I.Apellido, R.Fdesde,R.Fhasta, ifnull(R.Monto_Reserva,0),ifnull(R.Monto_Total,0)," +
                        " R.Pagado,R.IDusuario, U.Usuario ,ifnull(R.FdePago,'1900-01-01'), R.Estado" +
                        " From reservas R " +
                        " Inner join inquilino I on R.IDInquilino = I.IDInquilino " +
                        " Inner join propiedades P on R.IDPropiedad = P.IdPropiedad " +
                        " Inner join usuarios U on R.IDusuario = U.idusuario" +
                        " Where Fdesde > '" + Fecha.Year.ToString()+"-"+
                         (Fecha.Month <10?"0"+Fecha.Month.ToString(): Fecha.Month.ToString())+"-"+
                         (Fecha.Day <10?"0"+Fecha.Day.ToString(): Fecha.Day.ToString()) + "' Order by Fdesde desc";
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Reservas");

                Respuestas oItem = new Respuestas();
                foreach (DataRow oFila in myDS.Tables["Reservas"].Rows)
                {
                    Reservas oReserva = new Reservas();
                    oReserva.FReserva = Convert.ToDateTime(oFila[0].ToString());
                    oReserva.IdReserva = Convert.ToInt32(oFila[1].ToString());
                    oReserva.IdPropiedad = Convert.ToInt32(oFila[2].ToString());
                    oReserva.Propiedad_Nombre = oFila[3].ToString();
                    oReserva.IdInquilino = Convert.ToInt32(oFila[4].ToString());
                    
                  //  oReserva.Inquilino_Nombre = oFila[5].ToString();

                    oReserva.Inquilino_Apellido = oFila[6].ToString();
                    oReserva.FDesde = Convert.ToDateTime(oFila[7].ToString());
                    oReserva.FHasta = Convert.ToDateTime(oFila[8].ToString());
                    oReserva.Monto_Reserva = Convert.ToDecimal(oFila[9].ToString());
                    oReserva.Monto_Total = Convert.ToDecimal(oFila[10].ToString());
                    oReserva.Pagado = oFila[11].ToString();
                    oReserva.IdUsuario = Convert.ToInt32(oFila[12].ToString());
                    oReserva.Usuario_User = oFila[13].ToString();
                    oReserva.FDePago = Convert.ToDateTime(oFila[14].ToString());
                    oReserva.Estado = oFila[15].ToString();

                    switch(oReserva.Estado)
                    {
                        case "Anulada":
                            oReserva.Inquilino_Nombre = "<i class=\"far fa-window-close\"></i> " + oFila[5].ToString();
                        break;
                        case "Confirmar":
                            oReserva.Inquilino_Nombre = "<i class=\"fas fa-user-clock\"></i> " + oFila[5].ToString();
                            break;
                        case "Reserva":
                            oReserva.Inquilino_Nombre = "<i class=\"fas fa-calendar-check\"></i> " + oFila[5].ToString();
                            break;

                    }
                    oLista.Add(oReserva);
                }
                myCommand.Dispose();
                conn.Close();
                return oLista.ToList();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Reservas - Get Reservas x Fecha :: " + ex.StackTrace.ToString());
                return null;
            }
        }

        public DataTable Get_ReservaxFechaDt(DateTime Fecha)
        {
            try
            {
                List<Reservas> oLista = new List<Reservas>();

                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                string Query = "";
                Query = "SELECT R.FReserva, R.IDReserva, R.IDPropiedad, P.Nombre,R.IDInquilino,I.Nombre," +
                        " I.Apellido, R.Fdesde,R.Fhasta, ifnull(R.Monto_Reserva,0),ifnull(R.Monto_Total,0)," +
                        " R.Pagado,R.IDusuario, U.Usuario ,ifnull(R.FdePago,'1900-01-01'), R.Estado" +
                        " From reservas R " +
                        " Inner join inquilino I on R.IDInquilino = I.IDInquilino " +
                        " Inner join propiedades P on R.IDPropiedad = P.IdPropiedad " +
                        " Inner join usuarios U on R.IDusuario = U.idusuario" +
                        " Where Fdesde > '" + Fecha.Year.ToString() + "-" +
                         (Fecha.Month < 10 ? "0" + Fecha.Month.ToString() : Fecha.Month.ToString()) + "-" +
                         (Fecha.Day < 10 ? "0" + Fecha.Day.ToString() : Fecha.Day.ToString()) + "' Order by Fdesde desc";
                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);

                MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

                DataSet myDS = new DataSet();
                myDA.Fill(myDS, "Reservas");
                DataTable dt = new DataTable();
                myDA.Fill(dt);
                //*  importe como referenias el conector 5.27

                return dt;
       
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Reservas - Get Reservas x Fecha :: " + ex.StackTrace.ToString());
                return null;
            }
        }
        //lista de reservas entre fechas
        //save

        public void Save_Reserva(Reservas oReserva)
        {
            try
            {
                string connectionString = StringConnection;
                MySqlConnection conn = new MySqlConnection(connectionString);
                //*  importe como referenias el conector 5.27
                string Query = "";
                if (oReserva.IdReserva > 0)
                {
                    //UPDATE
                    Query = " UPDATE reservas" +
                            " SET IDPropiedad = " + oReserva.IdPropiedad.ToString() + " ," +
                            " IDInquilino = " + oReserva.IdInquilino.ToString() + "," +
                            " Fdesde  = '" + oReserva.FDesde.ToString("yyyy-MM-dd") + "' ," +
                            " Fhasta = '" + oReserva.FHasta.ToString("yyyy-MM-dd") + "' ," +
                            " Monto_Reserva = " + oReserva.Monto_Reserva.ToString() + " ," +
                            " Monto_Total = " + oReserva.Monto_Total.ToString() + " ," +
                            " Pagado  = '" + oReserva.Pagado.ToString() + "' ," +
                            " IDusuario = " + oReserva.IdUsuario.ToString() + " ,";
                    if (oReserva.FDePago != null)
                        Query += " FdePago = '" + oReserva.FDePago.ToString("yyyy-MM-dd") + "' ,";
                    Query+=" Estado = '" + oReserva.Estado.ToString() + "' " +
                            " WHERE IDReserva =" + oReserva.IdReserva.ToString(); 
                                 
                }
                else
                {//INSERT
                    Query = "INSERT INTO reservas  (FReserva, IDPropiedad, IDInquilino, Fdesde, Fhasta, Monto_Reserva," +
                            " Monto_Total, Pagado, IDusuario, FdePago, Estado) VALUES(" +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + oReserva.IdPropiedad.ToString() + "," + oReserva.IdInquilino.ToString() + " ," +
                            "'" + oReserva.FDesde.ToString("yyyy-MM-dd") + "','" + oReserva.FHasta.ToString("yyyy-MM-dd") + "'," + oReserva.Monto_Reserva.ToString() + "," +
                            "" + oReserva.Monto_Total + ",'" + oReserva.Pagado.ToString() + "'," + oReserva.IdUsuario.ToString() + ",'" + (oReserva.FDePago != null ? oReserva.FDePago.ToString("yyyy-MM-dd") : "") + "',"+
                            "'"+ oReserva.Estado +"')";
                }

                conn.Open();

                MySqlCommand myCommand = new MySqlCommand(Query, conn);
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Datos - Reserva - Save :: " + ex.StackTrace.ToString());
            }

        }


        public DataTable Exist_Reserva(Reservas oReserva)
        {
            string connectionString = StringConnection;
            MySqlConnection conn = new MySqlConnection(connectionString);
            string Query = " SELECT * FROM reservas "+
                           " WHERE idpropiedad = "+ oReserva.IdPropiedad +""+
                           " and Fdesde between ' "+ oReserva.FDesde.ToString("dd/MM/yyyy") +"'and '"+ oReserva.FHasta.ToString("dd/MM/yyyy")+"'"+
                           " and FHasta between '"+oReserva.FDesde.ToString("dd/MM/yyyy")+"' and '"+oReserva.FHasta.ToString("dd/MM/yyyy")+"'"+
                           " and Estado = 'Reserva'  and IdReserva <> "+oReserva.IdReserva+" union "+
                           " SELECT * FROM reservas "+
                           " WHERE idpropiedad = "+ oReserva.IdPropiedad +"" +
                           " and  fdesde >='"+ oReserva.FDesde.ToString("dd/MM/yyyy") +"' and  fhasta <='"+oReserva.FHasta.ToString("dd/MM/yyyy")+"'"+
                           " and Estado = 'Reserva' and  IdReserva <> " + oReserva.IdReserva + "";
            conn.Open();

            MySqlCommand myCommand = new MySqlCommand(Query, conn);

            MySqlDataAdapter myDA = new MySqlDataAdapter(myCommand);

            DataSet myDS = new DataSet();
            myDA.Fill(myDS, "Reservas");
            DataTable dt = new DataTable();
            myDA.Fill(dt);
             return dt;

        }


        //Verificar que la reserva no se Solapa con una previa existente

        #endregion
    }
}

