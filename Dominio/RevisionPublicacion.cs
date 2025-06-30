using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class RevisionPublicacion
    {
        public int IdRevision { get; set; }
        public int IdPropiedad { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaAccion { get; set; }
        public string TipoAccion { get; set; } // "INSERT" o "UPDATE"
        public string EstadoRevision { get; set; }
        public string ObservacionesAdmin { get; set; }

    }
}
