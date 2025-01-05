using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.BasketItems
{
    public class List
    {
        public class Query : IRequest<List<BasketItem>> { }

        public class Handler : IRequestHandler<Query, List<BasketItem>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<BasketItem>> Handle(Query request, CancellationToken token)
            {
                return await _context.BasketItems.ToListAsync();
            }
        }
    }
}
