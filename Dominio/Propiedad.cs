using System;

namespace Dominio
{
    public class Propiedad
    {
        public int IdPropiedad { get; set; }
        public string Titulo { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public decimal Precio { get; set; } // Se mantiene como string para coincidir con la DB
        public string Moneda { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string TipoOperacion { get; set; }
        public string ImagenUrl { get; set; }
        public string Localidad { get; set; }
        public string TipoDueno { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public int Ambientes { get; set; }
        public decimal Sup_m2_Total { get; set; }
        public decimal Sup_m2_Cubierto { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public bool ConPatio { get; set; }
        public bool ConBalcon { get; set; }
        public bool Cochera { get; set; }
        public int AnosAntiguedad { get; set; }
        public bool AptoCredito { get; set; }
        public int IdProvincia { get; set; } // Corregido el nombre de la propiedad
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Visitas { get; set; }
        public bool Visible { get; set; }
        public bool Eliminada { get; set; }
        public bool Reservada { get; set; }
    }
}