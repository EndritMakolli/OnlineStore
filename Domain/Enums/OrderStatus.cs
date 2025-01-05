namespace Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,       // Order has been created but not processed yet
        Processing = 2,    // Order is currently being prepared
        Shipped = 3,       // Order has been shipped to the customer
        Delivered = 4,     // Order has been delivered to the customer
        Cancelled = 5      // Order was cancelled by the user or system
    }
}