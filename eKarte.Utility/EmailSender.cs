using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace eKarte.Utility
{
    public class EmailSender : IEmailSender

    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailsettings)
        {
            _emailSettings = emailsettings.Value;
        }


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {


            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.APIKey, _emailSettings.APIKeySecret),
                EnableSsl = _emailSettings.enableSSL
            };
            return client.SendMailAsync(
                 new MailMessage(_emailSettings.SenderEmail, email, subject, htmlMessage) { IsBodyHtml = true }
             );
        }
    }
}
