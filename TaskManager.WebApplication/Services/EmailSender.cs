using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.WebApplication.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {

            using (SmtpClient client = new SmtpClient())
            {
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("gustavoosantoos95@gmail.com", "05121995");

                using (MailMessage mm = new MailMessage("gustavoosantoos95@gmail.com", email, subject, message))
                {
                    mm.BodyEncoding = Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                    client.Send(mm);
                }
            }

            return Task.CompletedTask;
        }
    }
}
