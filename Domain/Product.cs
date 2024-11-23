
namespace Domain
{
public class Product
    {
    public Guid Id { get; set; }  // We actually need it to be called very specifically ID, because then Entity Framework will recognize

//that this should be the primary key of that database table when we go ahead and create it.
    public string Name { get; set; }
    public string Description { get; set; }
    public long Price { get; set; }
    public string PictureUrl { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int QuantityInStock { get; set; }
    }
}