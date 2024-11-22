using Domain;
		

		namespace Persistence
		{
		public class Seed
		{
		public static async Task SeedData(DataContext context) //  with a static method we can use without creating a new instance of the seed class.
		{
		if (context.Products.Any()) return; //  is going to check in our database to see if we already have products inside
		
		// If we do, we do not want to seed more products inside it.
		// If we do not have any activities, then we're going to create a new list of products and there's a
		var products = new List<Product>
		{
		new Product
		{
                        Name = "Random Product",
                        Description = "This is a randomly generated product.",
                        Price = new Random().Next(1000, 10000), // Random price between 1000 and 10000
                        PictureUrl = "https://example.com/product.jpg",
                        Type = "Electronics",
                        Brand = "RandomBrand",
                        QuantityInStock = new Random().Next(1, 100) // Random quantity between 1 and 100
		},
         new Product
                    {
    
                        Name = "Another Product",
                        Description = "Another randomly generated product.",
                        Price = new Random().Next(1000, 10000),
                        PictureUrl = "https://example.com/product2.jpg",
                        Type = "Home Appliance",
                        Brand = "BrandX",
                        QuantityInStock = new Random().Next(1, 50)
                    }
		
		};
		

		await context.Products.AddRangeAsync(products); // saves into memory
		await context.SaveChangesAsync(); // saves into database
		}
		}
		}

