using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ProductsController : BaseApiController // http://localhost:5000/api/products
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet] //api/products
        public async Task<ActionResult<List<Product>>> GetActivities() // the thing that's going back is going to be a list of product.
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetActivity(Guid id)
        {
            return await _context.Products.FindAsync(id); // specify that we want the product with that ID that was requested.
        }
    }
}