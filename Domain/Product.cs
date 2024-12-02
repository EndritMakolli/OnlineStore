
namespace Domain
{
    using System.ComponentModel.DataAnnotations.Schema;


    public class Product
    {
        public Guid Id { get; set; }  // Renamed to match standard convention
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsSuccess { get; set; }

        [NotMapped]
        public object Value { get; set; } // Not stored in the database
    }
}