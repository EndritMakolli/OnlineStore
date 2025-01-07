namespace Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body); // a class that handles email sending functionality
    }
}