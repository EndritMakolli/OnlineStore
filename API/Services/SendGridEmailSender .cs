using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

            public async Task SendEmailAsync(string to, string subject, string body)
        {
            var client = new SendGridClient(_configuration["SendGridSettings:ApiKey"]);

            // Use SendGrid.Helpers.Mail.EmailAddress for both 'from' and 'to'
            var from = new EmailAddress(_configuration["SendGridSettings:From"], "Online Store");
            var toEmail = new EmailAddress(to);

            // Create the email message
            var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, body, body);

            // Send the email
            await client.SendEmailAsync(msg);
        }
    }
}
