using System.Net;
using System.Net.Mail;

namespace Open.Core
{
    public static class EmailSender
    {
        public static MailMessage Send(string address, string body, string subject="Soovitus")
        {
            string username = "medbasetest@gmail.com";
            string password = "Qwerty1!123";
            SmtpClient client = new SmtpClient("mysmtpserver");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(username);
            mailMessage.To.Add(address);
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            client.Send(mailMessage);
            return mailMessage;
        }

        
    }
}