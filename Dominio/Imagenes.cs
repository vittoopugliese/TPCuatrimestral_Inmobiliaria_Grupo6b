using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagenes
    {
        public string nombreImagen { get; set; }
        public int Id { get; set; }
        public int IdPropiedad { get; set; }
        public string UrlImagen { get; set; }
        public bool EsPortada { get; set; } // Para identificar la imagen principal

    }
}
