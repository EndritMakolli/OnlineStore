using Application.Interfaces;
using Domain.OrderAggregate;

namespace Application.Services
{
    public class OrderService
    {
        private readonly IEmailSender _emailSender;

        public OrderService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        // Method to send order confirmation email
        public async Task SendOrderConfirmationEmail(Order order)
        {
            var subject = $"Order Confirmation - Order #{order.Id}";
            var body = $@"
                Dear {order.BuyerId},
                
                Thank you for your order!
                Your total amount is: {order.GetTotal()}.
                We are preparing your order and will notify you once it's shipped.

                Regards,
                Online Store Team";

            await _emailSender.SendEmailAsync(order.BuyerId, subject, body);
        }
    }
}