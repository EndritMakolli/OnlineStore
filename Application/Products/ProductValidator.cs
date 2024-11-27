using Domain;
using FluentValidation;

namespace Application.Products
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.PictureUrl).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Brand).NotEmpty();
            RuleFor(x => x.QuantityInStock).NotEmpty();
        }
    }
}