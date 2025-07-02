using System.Net;
using System.Net.Mail;
using Webshop.Interfaces.Services;

namespace Webshop.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("stockmanagementdani@gmail.com", "ldsspvizmgjnbauv"),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress("stockmanagementdani@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false,
            };

            mail.To.Add(to);

            smtpClient.Send(mail);
        }
    }
}