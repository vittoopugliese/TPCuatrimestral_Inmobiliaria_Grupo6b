using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dominio;

namespace Negocio
{
    public class ClaseDominioEjemploNegocio
    {
        private BaseDeDatos bd;

        public ClaseDominioEjemploNegocio()
        {
            bd = new BaseDeDatos();
        }

    }
}