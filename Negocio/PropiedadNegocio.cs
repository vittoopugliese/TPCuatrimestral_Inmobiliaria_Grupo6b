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
                    Direccion = "Av. Corrales 3983",
                    Ubicacion = "Devoto, CABA",
                    Precio = "USD 150,000",
                    PrecioNumerico = 150000,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Departamento",
                    TipoOperacion = "Venta",
                    Superficie = "65",
                    ImagenUrl = "https://img.jamesedition.com/listing_images/2025/04/11/16/11/58/c994a270-0cd5-49f5-a35a-d7bfbbc0b03f/je/1900xxs.jpg",
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
                    Direccion = "Belgrano 852",
                    Ubicacion = "San Isidro, CABA",
                    Precio = "USD 280,000",
                    PrecioNumerico = 280000,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Casa",
                    TipoOperacion = "Venta",
                    Superficie = "180",
                    ImagenUrl = "https://img.jamesedition.com/listing_images/2025/04/11/16/11/59/0cc904d5-448a-438e-811f-e6ce6961ddab/je/1900xxs.jpg",
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
                    Direccion = "Av. Corrientes 3500",
                    Ubicacion = " Villa Crespo, CABA",
                    Precio = "USD 1,200/mes",
                    PrecioNumerico = 1200,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Loft",
                    TipoOperacion = "Alquiler",
                    Superficie = "45",
                    ImagenUrl = "https://img-v2.gtsstatic.net/reno/imagereader.aspx?url=https%3A%2F%2Fm.sothebysrealty.com%2F1103i215%2Ff8c4r2phgf03m0tqmh51txasm6i215&w=640&q=75&option=N&permitphotoenlargement=false&fallbackimageurl=https%3A%2F%2Fwww.sothebysrealty.com%2Fassets%2Fimages%2Fcommon%2Fnophoto%2Flisting.jpg",
                    Localidad = "CABA",
                    TipoDueno = "Dueño directo",
                    Email = "propietario3@email.com",
                    WhatsApp = "5491156789012",
                    Visitas = 156,
                    Visible = false,
                    Eliminada = false,
                    FechaPublicacion = DateTime.Now.AddDays(-22),
                    IdUsuario = 2
                },
                new Propiedad
                {
                    Id = 1,
                    Titulo = "Departamento 2 ambientes moderno",
                    Direccion = "Av. Corrales 3983",
                    Ubicacion = "Devoto, CABA",
                    Precio = "USD 150,000",
                    PrecioNumerico = 150000,
                    Descripcion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Tipo = "Departamento",
                    TipoOperacion = "Venta",
                    Superficie = "65",
                    ImagenUrl = "https://img.jamesedition.com/listing_images/2025/04/11/16/11/58/c994a270-0cd5-49f5-a35a-d7bfbbc0b03f/je/1900xxs.jpg",
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
            };
        }

    }

}