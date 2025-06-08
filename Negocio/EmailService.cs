using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Host = "smtp.gmail.com"; // Cambia esto al servidor SMTP que estés utilizando
            server.Port = 587; // Puerto para TLS
            server.EnableSsl = true; // Habilita SSL
            server.Credentials = new NetworkCredential("inmolibre.2025@gmail.com", "fzsk xgnp abyo axxq");
        }

        public void armarCorreo(string emailDestino, string contrasenaGuardada)
        {
            email = new MailMessage();
            email.From = new MailAddress("inmolibre.2025@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = "Recuperación de contraseña";
            email.IsBodyHtml = true;
            email.Body = "<h1>Recuperación de contraseña</h1>" +
                          "<p>Hola,</p>" +
                          "<p>Tu contraseña es: <strong>" + contrasenaGuardada + "</strong></p>" +
                          "<p>Si no solicitaste este correo, por favor ignóralo.</p>" +
                          "<p>Saludos,</p>" +
                          "<p>Equipo de InmoLibre </p>";
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, por ejemplo, registrar el error o mostrar un mensaje al usuario
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}



//mail: inmolibre.2025@gmail.com
//pass: inmo1234
//contraseña de aplicacion: fzsk xgnp abyo axxq