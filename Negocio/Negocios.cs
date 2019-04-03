﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contrato;
using Datos;
using System.Net.Mail;
using System.Configuration;
using NLog;

namespace Negocio
{
    

    public partial class Negocio
    {
        private static readonly Logger _logger1 = LogManager.GetLogger("Logger1");

        // Instancia de la capa de datos
        public Datos.Datos oData = new Datos.Datos();
        #region Usuarios
        public Usuarios GetUsuario(string Usuario, string Password) => oData.GetUsuario(Usuario, Password);
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
        #endregion
    }

}
