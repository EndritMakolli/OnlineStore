

public interface IPaymentService
{
    Task<bool> ProcessPaymentAsync(PaymentDetails paymentDetails, CancellationToken cancellationToken);
}