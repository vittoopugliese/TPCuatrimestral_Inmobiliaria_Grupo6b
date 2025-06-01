using System;

namespace Dominio
{
    public class Propiedad
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Direccion { get; set; }
        public string Precio { get; set; }
        public decimal PrecioNumerico { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string TipoOperacion { get; set; }
        public string Superficie { get; set; }
        public string ImagenUrl { get; set; }
        public string Localidad { get; set; }
        public string TipoDueno { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public int Visitas { get; set; }
        public bool Visible { get; set; }
        public bool Eliminada { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Propiedad()
        {
            Id = 0;
            Titulo = string.Empty;
            Direccion = string.Empty;
            Precio = string.Empty;
            PrecioNumerico = 0;
            Descripcion = string.Empty;
            Tipo = string.Empty;
            TipoOperacion = string.Empty;
            Superficie = string.Empty;
            ImagenUrl = string.Empty;
            Localidad = string.Empty;
            TipoDueno = string.Empty;
            Email = string.Empty;
            WhatsApp = string.Empty;
            Visitas = 0;
            Visible = true;
            FechaPublicacion = DateTime.Now;
            IdUsuario = 0;
            FechaModificacion = DateTime.Now;
        }

    }
}