using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems) // Include related data if necessary
                .Include(o => o.ShippingAddress)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.ShippingAddress)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}