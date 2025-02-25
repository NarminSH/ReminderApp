using Microsoft.Extensions.Options;
using ReminderApp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace ReminderApp.Infrastructure.Services
{
    public class EmailService: IEmailService
    {
        IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task SendReminderAsync(string to, string content)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:FromAddress"]),
                Body = content,
                IsBodyHtml = true 
            };

            mailMessage.To.Add(to);

            using (var smtpClient = new SmtpClient(_configuration["EmailSettings:Host"], Convert.ToInt32(_configuration["EmailSettings:Port"])))
            {
                smtpClient.Credentials = new NetworkCredential(_configuration["EmailSettings:Login"], _configuration["EmailSettings:Passcode"]);
                smtpClient.EnableSsl = true; 
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
    
}
