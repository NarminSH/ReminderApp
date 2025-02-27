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
                Subject = "Reminder!",
                Body = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    color: #333;
                    background-color: #f9f9f9;
                    margin: 0;
                    padding: 0;
                }}
                .email-container {{
                    width: 100%;
                    max-width: 600px;
                    margin: 20px auto;
                    padding: 20px;
                    background-color: #ffffff;
                    border-radius: 8px;
                    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                }}
                h1 {{
                    color: #0056b3;
                    font-size: 24px;
                }}
                p {{
                    font-size: 16px;
                    line-height: 1.5;
                    color: #555555;
                }}
            </style>
        </head>
        <body>
            <div class='email-container'>
                <h1>Reminder Notification</h1>
                <p>{content}</p>
            </div>
        </body>
        </html>
    ",
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
