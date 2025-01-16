using System;
using System.Collections.Concurrent; // Provides thread-safe collection classes
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.OrderAggregate;
using Application.Interfaces;

namespace Application.OrderAggregate
{
    /// <summary>
    /// This class demonstrates advanced order processing using concurrency. 
    /// A SemaphoreSlim is used to limit how many concurrent tasks can run at once,
    /// and Task.Run is used to process orders in parallel.
    /// </summary>
    public class AdvancedOrderProcessor
    {
        private readonly IInventoryService _inventoryService; // Handles inventory-related operations
        private readonly IPaymentService _paymentService; // Handles payment processing
        private readonly INotificationService _notificationService; // Sends notifications to customers
        private readonly int _maxDegreeOfParallelism; // Controls the maximum number of concurrent tasks

        /// <summary>
        /// Initializes the AdvancedOrderProcessor with necessary services and sets the maximum parallel tasks.
        /// </summary>
        public AdvancedOrderProcessor(IInventoryService inventoryService, IPaymentService paymentService, INotificationService notificationService, int maxDegreeOfParallelism = 4)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _maxDegreeOfParallelism = maxDegreeOfParallelism; // Default parallelism set to 4
        }

        /// <summary>
        /// Processes a collection of orders asynchronously, using concurrency 
        /// controlled by the SemaphoreSlim below.
        /// </summary>
        /// <param name="orders">Collection of orders to be processed.</param>
        /// <param name="cancellationToken">Cancellation token for stopping the operation.</param>
        public async Task ProcessOrdersAsync(IEnumerable<Domain.OrderAggregate.Order> orders, CancellationToken cancellationToken)
        {
            if (orders == null || !orders.Any())
                throw new ArgumentException("Orders collection is null or empty.", nameof(orders));

            var orderProcessingTasks = new ConcurrentBag<Task>(); // Holds the processing tasks for all orders
            var semaphore = new SemaphoreSlim(_maxDegreeOfParallelism); // Limits the number of concurrent tasks (multithreading control)

            foreach (var order in orders)
            {
                await semaphore.WaitAsync(cancellationToken); // Waits for a slot to become available before starting a new task

                // Each order is processed in its own Task to enable concurrency
                var task = Task.Run(async () =>
                {
                    try
                    {
                        await ProcessSingleOrderAsync(order, cancellationToken); // Processes an individual order
                    }
                    catch (Exception ex)
                    {
                        // Logs any errors during processing
                        Console.WriteLine($"Error processing order {order.Id}: {ex.Message}");
                    }
                    finally
                    {
                        semaphore.Release(); // Releases the semaphore slot after task completion
                    }
                }, cancellationToken);

                orderProcessingTasks.Add(task); // Adds the concurrent task to the collection
            }

            await Task.WhenAll(orderProcessingTasks); // Waits for all concurrent tasks to complete
        }

        /// <summary>
        /// Processes a single order by validating inventory, processing payment, 
        /// and notifying the customer upon success.
        /// </summary>
        /// <param name="order">The order to process.</param>
        /// <param name="cancellationToken">Cancellation token for stopping the operation.</param>
        private async Task ProcessSingleOrderAsync(Domain.OrderAggregate.Order order, CancellationToken cancellationToken)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            Console.WriteLine($"Processing order {order.Id}...");

            // Step 1: Validate Inventory
            var inventoryValidated = await _inventoryService.ValidateInventoryAsync(order.OrderItems, cancellationToken); // Checks if inventory is available
            if (!inventoryValidated)
            {
                Console.WriteLine($"Order {order.Id}: Inventory validation failed.");
                return; // Exits if inventory is insufficient
            }

            // Step 2: Process Payment
            var paymentProcessed = await _paymentService.ProcessPaymentAsync(new PaymentDetails
            {
                CardNumber = "DummyCardNumber", // Replace with actual card details logic if available
                ExpirationDate = "12/25", // Replace with actual data
                Cvv = "123" // Replace with actual data
            }, cancellationToken); // Processes the payment
            if (!paymentProcessed)
            {
                Console.WriteLine($"Order {order.Id}: Payment processing failed.");
                return; // Exits if payment fails
            }

            // Step 3: Notify Customer
            await _notificationService.SendNotificationAsync(order.BuyerId, "Your order has been successfully processed.", cancellationToken); // Sends a success notification

            Console.WriteLine($"Order {order.Id} processed successfully.");
        }
    }
}
