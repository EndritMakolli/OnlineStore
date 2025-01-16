public interface INotificationService
{
    Task SendNotificationAsync(string customerId, string message, CancellationToken cancellationToken);
}