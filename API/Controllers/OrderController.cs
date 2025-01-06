using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.OrderAggregate.Order;
using Domain.Enums;
using Domain.OrderAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly UpdateOrderStatus _updateOrderStatus;
        private readonly ILogger<OrderController> _logger;

        private readonly DataContext _context;

        public OrderController(UpdateOrderStatus updateOrderStatus, ILogger<OrderController> logger)
        {
            _updateOrderStatus = updateOrderStatus;
            _logger = logger;
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] Domain.Enums.OrderStatus newStatus)
        {
            try
            {
                _logger.LogInformation($"Updating order {id} to status {newStatus}");
                await _updateOrderStatus.HandleAsync(id, newStatus);
                return Ok($"Order {id} status updated to {newStatus}");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning($"Order not found: {id}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating order {id}: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // Get All Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                _logger.LogInformation("Retrieving all orders.");
                var orders = await _context.Orders.ToListAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving all orders: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // Get Order by ID
 [HttpGet("{id}")]
public async Task<ActionResult<Order>> GetOrderById(int id)
{
    try
    {
        _logger.LogInformation($"Retrieving order with ID {id}");
        var order = await _context.Orders.FindAsync(id); // Correctly use _context.Orders here

        if (order == null)
        {
            _logger.LogWarning($"Order not found: {id}");
            return NotFound($"Order with ID {id} not found.");
        }

        return Ok(order);
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error retrieving order {id}: {ex.Message}");
        return StatusCode(500, ex.Message);
    }
}

        // Delete Order by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                _logger.LogInformation($"Attempting to delete order with ID {id}");
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    _logger.LogWarning($"Order not found: {id}");
                    return NotFound($"Order with ID {id} not found.");
                }

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Order {id} successfully deleted.");
                return Ok($"Order {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order {id}: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}