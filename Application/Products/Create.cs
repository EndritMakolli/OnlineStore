using Domain;
using MediatR;
using Persistence;
using Application.Products;
using FluentValidation;
using Application.Core;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Product Product { get; set; }
        }
          public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Product).SetValidator(new ProductValidator());
                }
            }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

           public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Products.Add(request.Product);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create product");
                return Result<Unit>.Success(Unit.Value);
            }


            Task<Result<Unit>> IRequestHandler<Command, Result<Unit>>.Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}