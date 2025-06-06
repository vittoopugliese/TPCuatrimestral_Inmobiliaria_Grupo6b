using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int IdPropiedad { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public string Precio { get; set; }
        public string Moneda { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string TipoOperacion { get; set; }
        public string ImagenUrl { get; set; }
        public string Localidad { get; set; }
        public string TipoDueno { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public int Visitas { get; set; } = 0;
        public bool Visible { get; set; } = true;
        public bool Eliminada { get; set; } = false;
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public int Ambientes { get; set; }
        public decimal Sup_m2_Total { get; set; }
        public decimal Sup_m2_Cubierto { get; set; }
        public int Dormitorios { get; set; }
        public int Baños { get; set; }
        public bool ConPatio { get; set; } = false;
        public bool ConBalcon { get; set; } = false;
        public int AnosAntiguedad { get; set; }
        public bool AptoCredito { get; set; } = false;
        public bool Reservada { get; set; } = false;
        public int IdProvincia { get; set; }
    }
}
