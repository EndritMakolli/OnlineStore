using Domain;
		

		namespace Persistence
		{
		public class Seed
		{
		public static async Task SeedData(DataContext context)
		{
		if (context.Products.Any()) return;
		

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
		

		await context.Products.AddRangeAsync(products);
		await context.SaveChangesAsync();
		}
		}
		}

