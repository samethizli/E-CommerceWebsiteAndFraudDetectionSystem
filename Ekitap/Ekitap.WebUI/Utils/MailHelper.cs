using Ekitap.Core.Entities;
using System.Net;
using System.Net.Mail;
//mail göndermek için yapıyoruz bu sayfayı

namespace Ekitap.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Contact contact)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadi.com", 587);
            smtpClient.Credentials = new NetworkCredential("info@siteadi.com","mailşifre");
            smtpClient.EnableSsl = false;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadi.com");
            message.To.Add("bilgi@siteadi.com");
            message.Subject = "Siteden mesaj geldi";
            message.Body = $"İsim: {contact.Name}- Soyisim: {contact.Name} - Email {contact.Email}" +
                $"Phone: {contact.Phone} - Mesaj: {contact.Message}";
            message.IsBodyHtml = true;
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}
