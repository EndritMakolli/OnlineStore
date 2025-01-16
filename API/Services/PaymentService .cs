public class PaymentService : IPaymentService
{
    public async Task<bool> ProcessPaymentAsync(PaymentDetails paymentDetails, CancellationToken cancellationToken)
    {
        // Simulate payment processing logic
        await Task.Delay(1000, cancellationToken);
        return true; // Assume payment is always successful
    }
}
