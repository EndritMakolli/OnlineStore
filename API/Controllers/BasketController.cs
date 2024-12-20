
using API.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class BasketController : BaseApiController
{
    private readonly DataContext _context;
    public BasketController(DataContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBasket")]
    public async Task<ActionResult<BasketDto>> GetBasket()
    {
        var basket = await _context.Baskets
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);

        if (basket == null) return NotFound();

        return MapBasketToDto(basket);
    }

    [HttpPost]
    public async Task<ActionResult> AddItemToBasket(int productId, int quantity = 1)
    {
        var basket = await RetrieveBasket();

        if (basket == null) basket = CreateBasket();

        var product = await _context.Products.FindAsync(productId);

        if (product == null) return NotFound();

        basket.AddItem(product, quantity);

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return CreatedAtRoute("GetBasket", MapBasketToDto(basket));

        return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });
    }

   [HttpDelete]
public async Task<ActionResult> RemoveBasketItem(Guid productId, int quantity = 1)
{
    var basket = await RetrieveBasket();

    if (basket == null) return NotFound();

    basket.RemoveItem(productId, quantity);

    var result = await _context.SaveChangesAsync() > 0;

    if (result) return Ok();

    return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
}

    private async Task<Basket> RetrieveBasket()
    {
        return await _context.Baskets
            .Include(i => i.Items)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(basket => basket.BuyerId == Request.Cookies["buyerId"]);
    }

    private Basket CreateBasket()
    {
        var buyerId = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
        Response.Cookies.Append("buyerId", buyerId, cookieOptions);
        var basket = new Basket { BuyerId = buyerId };
        _context.Baskets.Add(basket);
        return basket;
    }

private BasketDto MapBasketToDto(Basket basket)
{
    return new BasketDto
    {
        Id = basket.Id,
        BuyerId = basket.BuyerId,
        Items = basket.Items.Select(item => new BasketItemDto
        {
            ProductId = item.ProductId.GetHashCode(),
            Name = item.Product.Name,
            Price = item.Product.Price,
            PictureUrl = item.Product.PictureUrl,
            Type = item.Product.Type,
            Brand = item.Product.Brand,
            Quantity = item.Quantity
        }).ToList()
    };
}

}