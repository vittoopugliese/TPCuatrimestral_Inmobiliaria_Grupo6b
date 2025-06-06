using System;

namespace Dominio
{
    public class Propiedad
    {
        public int IdPropiedad { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public decimal Precio { get; set; }
        public string Moneda { get; set; }
        public string Descripcion { get; set; }
        public int IdTipo { get; set; }
        public string TipoOperacion { get; set; }
        public string TipoPropiedad { get; set; }
        public string ImagenUrl { get; set; } // ver el tema de la lista de imagenes
        public string Localidad { get; set; }
        public string TipoDueno { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public int Visitas { get; set; }
        public bool Visible { get; set; }
        public bool Eliminada { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public int Ambientes { get; set; }
        public decimal Sup_m2_Total { get; set; }
        public decimal Sup_m2_Cubierto { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public bool ConPatio { get; set; }
        public bool ConBalcon { get; set; }
        public int AnosAntiguedad { get; set; }
        public bool AptoCredito { get; set; }
        public bool Reservada { get; set; }
        public int IdProvincia { get; set; }

    }
}