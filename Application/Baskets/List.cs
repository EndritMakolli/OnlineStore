using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Baskets
{
    public class List
    {
        public class Query : IRequest<List<Basket>> { }

        public class Handler : IRequestHandler<Query, List<Basket>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Basket>> Handle(Query request, CancellationToken token)
            {
                return await _context.Baskets.ToListAsync();
            }
        }
    }
}
