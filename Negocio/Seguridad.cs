using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionIniciada(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.IdUsuario != 0)
                return true;
            else
                return false;
        }


        public static bool EsPropietario(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null && (usuario.IdRol == 2 || usuario.IdRol == 3); // 2 = Inmobiliaria, 3 = Dueño Directo
        }
    }
}
