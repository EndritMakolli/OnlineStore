using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.OrderAggregate;

namespace Application.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task DeleteAsync(Order order);
        Task SaveChangesAsync();
    }
}