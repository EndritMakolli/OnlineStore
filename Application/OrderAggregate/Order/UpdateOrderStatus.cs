using Domain;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.OrderAggregate.Order
{
    public class UpdateOrderStatus
    {
        private readonly DataContext _context;

        public UpdateOrderStatus(DataContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(int orderId, OrderStatus newStatus)
        {
            // Fetch the order from the database
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order not found");
            }

            // Update the order's status
            order.Status = (Domain.Enums.OrderStatus)newStatus;

            // Save the changes
            await _context.SaveChangesAsync();
        }
    }
}    