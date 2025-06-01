using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Negocio
{
    public class PropiedadNegocio
    {
        private BaseDeDatos BaseDeDatos;

        public PropiedadNegocio()
        {
            BaseDeDatos = new BaseDeDatos();
        }

        public List<Propiedad> listar()
        {
            return GenerarDatosDePrueba();
        }

        private List<Propiedad> GenerarDatosDePrueba()
        {
            return new List<Propiedad>
            {
                new Propiedad
                {
                    Id = 1,
                    Titulo = "Departamento 2 ambientes moderno",
                    Direccion = "Av. Santa Fe 1500, Palermo, CABA",
                    Precio = "USD 150,000",
                    PrecioNumerico = 150000,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Departamento",
                    TipoOperacion = "Venta",
                    Superficie = "65",
                    ImagenUrl = "",
                    Localidad = "CABA",
                    TipoDueno = "Dueño directo",
                    Email = "propietario1@email.com",
                    WhatsApp = "5491123456789",
                    Visitas = 245,
                    Visible = true,
                    Eliminada = false,
                    FechaPublicacion = DateTime.Now.AddDays(-15),
                    IdUsuario = 1
                },
                new Propiedad
                {
                    Id = 2,
                    Titulo = "Casa familiar en zona residencial",
                    Direccion = "Calle Belgrano 850, San Isidro, Buenos Aires",
                    Precio = "USD 280,000",
                    PrecioNumerico = 280000,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Casa",
                    TipoOperacion = "Venta",
                    Superficie = "180",
                    ImagenUrl = "",
                    Localidad = "Buenos Aires",
                    TipoDueno = "Inmobiliaria",
                    Email = "inmobiliaria@email.com",
                    WhatsApp = "5491187654321",
                    Visitas = 89,
                    Visible = true,
                    Eliminada = false,
                    FechaPublicacion = DateTime.Now.AddDays(-8),
                    IdUsuario = 1
                },
                new Propiedad
                {
                    Id = 3,
                    Titulo = "Loft moderno estilo industrial",
                    Direccion = "Av. Corrientes 3500, Villa Crespo, CABA",
                    Precio = "USD 1,200/mes",
                    PrecioNumerico = 1200,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Loft",
                    TipoOperacion = "Alquiler",
                    Superficie = "45",
                    ImagenUrl = "",
                    Localidad = "CABA",
                    TipoDueno = "Dueño directo",
                    Email = "propietario3@email.com",
                    WhatsApp = "5491156789012",
                    Visitas = 156,
                    Visible = false,
                    Eliminada = false,
                    FechaPublicacion = DateTime.Now.AddDays(-22),
                    IdUsuario = 2
                }
            };
        }

    }

}