using Domain;
using MediatR;
using Persistence;

namespace Application.BasketItems
{
    public class Details
    {
        public class Query : IRequest<BasketItem>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, BasketItem>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<BasketItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.BasketItems.FindAsync(request.Id);
            }
        }
    }
}
