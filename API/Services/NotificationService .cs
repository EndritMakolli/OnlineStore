public class NotificationService : INotificationService
{
    public async Task SendNotificationAsync(string customerId, string message, CancellationToken cancellationToken)
    {
        // Simulate sending a notification
        await Task.Delay(200, cancellationToken);
        Console.WriteLine($"Notification to Customer {customerId}: {message}");
    }
}