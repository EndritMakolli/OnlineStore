using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<List<Product>> { }

        public class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(Query request, CancellationToken token)
            {
                return await _context.Products.ToListAsync();
            }
        }
    }
}