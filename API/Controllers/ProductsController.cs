using Application.Products;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
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

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
           // return await _context.Products.FindAsync(id); // specify that we want the product with that ID that was requested.
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {   
            return HandleResult(await Mediator.Send(new Create.Command { Product = product }));
        }

        private IActionResult Ok(object v)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(Guid id, Product product)
        {
            product.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Product = product }));
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}

