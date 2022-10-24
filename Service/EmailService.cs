using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        
        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("3f3a7378a6bab8", "321969d388b652");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";
        }

        public void montarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noreply@PokedexWeb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
