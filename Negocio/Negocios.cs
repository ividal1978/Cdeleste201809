using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contrato;
using Datos;
using System.Net.Mail;
using System.Configuration;
using NLog;
using System.Data;

namespace Negocio
{


    public partial class Negocio
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");

        // Instancia de la capa de datos
        public Datos.Datos oData = new Datos.Datos();
        #region Usuarios
        public Usuarios GetUsuario(string Usuario, string Password) => oData.GetUsuario(Usuario, Password);

        public Usuarios GetUsuraioXNombre(string Usuario) => oData.GetUsuarioXNombre(Usuario);
        #endregion

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

        public void DeleteNoticia(int IdNoticia) => oData.DeleteNoticia(IdNoticia);

        #endregion

        #region Propiedades
        public Propiedades Get_Propiedad(int IdPropiedad) => oData.Get_Propiedad(IdPropiedad);

        public List<Prop_Confort> Get_Propiedades_Confort(int IdPropiedad) => oData.Get_Propiedades_Confort(IdPropiedad);

        public List<Propiedades> Get_Propiedades_All() => oData.Get_Propiedades_All();

        public Prop_Confort Get_Propiedades_ConfortxID(int IdConfort) => oData.Get_Propiedades_ConfortxID(IdConfort);

        public void Save_Propiedades_Confort(Prop_Confort oConfort) => oData.Save_Propiedades_Confort(oConfort);

        public void Del_Propiedades_Confort(Prop_Confort oConfort) => oData.Del_Propiedades_Confort(oConfort);


        public List<Combo> Get_Propiedades_CMB()
        {
            return oData.Get_Propiedades_CMB();
        }
        #endregion

        #region  Comentarios

        public void Save_Comentario(Comentarios oCometrario)
        {
            oData.Save_Comentario(oCometrario);
        }

        public Comentarios Get_Cometario(int IdComentario) => oData.Get_Cometario(IdComentario);

        public Respuestas Get_Respuesta(int IdRespuesta) => oData.Get_Respuesta(IdRespuesta);

        public void Save_Respuesta(Respuestas oRespuesta)
        { oData.Save_Respuesta(oRespuesta); }

        public List<PreguntaFrecuente> Get_PreguntasFrecuentes(string TipoPregunta, int IdPropiedad) => oData.Get_PreguntasFrecuentes(TipoPregunta, IdPropiedad);
        #endregion

        #region Inquilinos

        public List<InquilinoCMB> GetInquilinoCMB(string Nombre) => oData.GetInquilinoCMB(Nombre);
        public Inquilino Get_Inquilino(int ID) => oData.Get_Inquilino(ID);

        public void Save_Inquilino(Inquilino oInquilino) => oData.Save_Inquilino(oInquilino);
        #endregion

        #region Utiles

        public void Envio_Email(Email eMail)
        {
            try
            {
                //Debo procesar y mandar el mail 
                var fromEmailAddress = ConfigurationManager.AppSettings["UsuarioMail"].ToString();
                var fromEmailPassword = ConfigurationManager.AppSettings["PasswordMail"].ToString();
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
                MailMessage message = new MailMessage(eMail.De, eMail.Para, eMail.Asunto, eMail.Mensaje);
                message.IsBodyHtml = true;


                //Envio de mensaje
                var client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(fromEmailAddress, fromEmailPassword);
                client.Host = smtpHost;
                client.EnableSsl = true;
                client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
                client.Send(message);
            }
            catch (Exception ex)
            {
                _logger1.Error(ex, " Negocios - Utiles - Envio_Email");
            }
        }

        public List<Consulta_Tipo> Get_Consulta_Tipo()
        {
            return oData.Get_Consulta_Tipo();
        }
        public List<Comentarios> Get_ComentariosxTipo(string TipoComentario, string Estado)
        {

            return oData.Get_ComentariosxTipo(TipoComentario, Estado);
        }
        #endregion

        #region Reservas

        public List<Reservas> Get_ReservaxFecha(DateTime Fecha, int IdPropiedad)
        {
            if (IdPropiedad < 0)
                return oData.Get_ReservaxFecha(Fecha);
            else
            {
                var Qreservas = oData.Get_ReservaxFecha(Fecha);
                Qreservas = Qreservas.Where(r => r.IdPropiedad == IdPropiedad).ToList();
                return Qreservas;
            }
        }

        public Reservas Get_ReservasxId(int IdReserva) => oData.Get_ReservaxId(IdReserva);

        public DataTable Get_ReservaxFechaDt(DateTime Fecha) => oData.Get_ReservaxFechaDt(Fecha);

        public void Save_Reserva(Reservas oReserva) => oData.Save_Reserva(oReserva);

        public Boolean Exist_Reserva(Reservas oReserva)
        {
            var ReservasActivas = oData.Exist_Reserva(oReserva);
            return (ReservasActivas.Rows.Count >0);
              
        }

        #endregion

        #region Galeria
        public List<ImagesGaleria> Get_ImagenesGaleria_All()
        {
            return oData.Get_ImagenesGaleria_All();
        }
            #endregion


        }
}