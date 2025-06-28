using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mensajes
    {
        public int IdMensaje { get; set; }
        public int IdPropiedad { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaDePublicacion { get; set; }
    }
}
