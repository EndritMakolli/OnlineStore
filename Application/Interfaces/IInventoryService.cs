using Domain.OrderAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

    public interface IInventoryService
    {
        Task<bool> ValidateInventoryAsync(IEnumerable<OrderItem> items, CancellationToken cancellationToken);
    }
