using Domain;
using MediatR;
using Persistence;

namespace Application.Baskets
{
    public class Details
    {
        public class Query : IRequest<Basket>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Basket>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Basket> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Baskets.FindAsync(request.Id);
            }
        }
    }
}
