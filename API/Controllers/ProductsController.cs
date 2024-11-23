using Application.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController // http://localhost:5000/api/products
    {
       private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] //api/products
        public async Task<ActionResult<List<Product>>> GetProducts() // the thing that's going back is going to be a list of product.
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id=id});
           // return await _context.Products.FindAsync(id); // specify that we want the product with that ID that was requested.
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {   
            await Mediator.Send(new Create.Command{Product=product});
            return Ok();
        }

        private IActionResult Ok(object v)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(Guid id, Product product)
        {
            product.Id = id;
            await Mediator.Send(new Edit.Command { Product = product });
            return Ok();
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}

