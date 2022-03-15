using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;

        public EmailSender(IOptions<EmailSettings> emailsettings, IWebHostEnvironment env)
        {
            _emailSettings = emailsettings.Value;
            _env = env;
        }


        

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {


            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.APIKey, _emailSettings.APIKeySecret),
                EnableSsl = _emailSettings.enableSSL
            };

            MailMessage mail = new MailMessage
            {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
                To = { email },
                From = new MailAddress(_emailSettings.SenderEmail)
            };
            if (subject == StaticData.Subject && htmlMessage == StaticData.htmlMessage)
            {
                mail.Attachments.Add(new Attachment(_env.WebRootPath + @"\karta.pdf"));
               
            }
          
                return client.SendMailAsync(mail);
           


        }
    
    }
}
