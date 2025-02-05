using Domain;

namespace Domain;

public class BasketItem : BaseEntity <Guid>
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid BasketId { get; set; }
    public Basket Basket { get; set; }
}