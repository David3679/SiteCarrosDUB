using Microsoft.Extensions.Primitives;
using System.Net;
using System.Net.Mail;

namespace SiteCarrosDUB.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;       
        }


        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string username = _configuration.GetValue<string>("SMTP-UserName");
                string nome = _configuration.GetValue<string>("SMTP-Nome");
                string host = _configuration.GetValue<string>("SMTP-Host");
                string senha = _configuration.GetValue<string>("SMTP-Senha");
                int porta = _configuration.GetValue<int>("SMTP-Porta");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Credentials = new NetworkCredential();
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }



        }
    }
}
