using System.ComponentModel.DataAnnotations;

namespace Domain.OrderAggregate;

public class Order
{
    public int Id { get; set; }
    public string BuyerId { get; set; }

    [Required]
    public ShippingAddress ShippingAddress { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItem> OrderItems { get; set; }
    public long Subtotal { get; set; }
    public long DeliveryFee { get; set; }
    public OrderStatus Status { get; set; } // Using the enum here

    public virtual long GetTotal()
    {
        return Subtotal + DeliveryFee;
    }
}