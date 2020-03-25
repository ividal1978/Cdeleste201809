using System;
namespace Contrato
{

    public class Comentarios
    {
        public int IdComentario { get; set; }
        public DateTime FechaComentario { get; set; }
        public string Nombre_Persona { get; set; }
        public string Tel_Persona { get; set; }
        public string Mail_Persona { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        public string Tipo { get; set; }
        public string IdPropiedad { get; set; }

    }

    public class Eventos
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Resource_Id { get; set; }

    }

    public class Inquilinos
    {
        public int IdInquilino { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Obs { get; set; }
        public string Celular { get; set; }
        public string Reside { get; set; }

    }

    public class Noticias
    {
        public int IdNoticia { get; set; }
        public DateTime Fecha { get; set; }
        public string Noticia { get; set; }
        public string Tipo { get; set; }
        public string RutaImagen { get; set; }
    }


    public class Propiedades
    {
        public int IdPropiedades { get; set; }
        public string Nombre { get; set; }
        public int Plazas { get; set; }
        public string Direccion { get; set; }
        public string Intro { get; set; }

    }

    public class Prop_Confort
    {
        public int IdPropiedad { get; set; }
        public int IdConfort { get; set; }
        public string Descripcion { get; set; }
    }

    public class Reservas
    {
        public DateTime FReserva { get; set; }
        public int IdReserva { get; set; }
        public int IdPropiedad { get; set; }
        public string Propiedad_Nombre { get; set; }
        public int IdInquilino { get; set; }
        public string Inquilino_Nombre { get; set; }
        public string Inquilino_Apellido { get; set; }
        public DateTime FDesde { get; set; }
        public DateTime FHasta { get; set; }
        public decimal Monto_Reserva { get; set; }
        public decimal Monto_Total { get; set; }
        public string Pagado { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario_User { get; set; }
        public DateTime FDePago { get; set; }
        public string Estado { get; set; }
    }

    public class Respuestas
    {
        public int IdRespuesta { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Respuesta { get; set; }
        public string Estado { get; set; }
    }

    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Usuario { get; set; }
    }

    public class Combo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class Consulta_Tipo
    {
        public int ID { get; set; }
        public string Descrip { get; set; }
        public string Codigo { get; set; }
    }

    public class Email
    {
        public string Para { get; set; }
        public string De { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string CopiaOculta { get; set; }

    }

    public class InquilinoCMB
    {
        public int IdInquilino { get; set; }
        public string Nombre_inquilino { get; set; }
    }
    public class Inquilino
    {
        public int ID_Inquilino { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Obs { get; set; }
        public string Celular { get; set; }
        public string Reside { get; set; }
    }

    public class PreguntaFrecuente
    {
        public int IdComentario { get; set; }
        public DateTime FechaComentario { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        public string Respuesta { get; set; }
        public string Tipo { get; set; }
        public string IdPropiedad { get; set; }
    }
 
    public class ImagesGaleria
    {
        public string ruta { get; set; }
        public string nombre { get; set; }
        public string reseña { get; set; }
    }
}
