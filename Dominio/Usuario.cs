using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public int IdProvincia { get; set; }
        public int IdRol { get; set; }


        public Usuario() { }

        public Usuario(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;
        }
    }
}
