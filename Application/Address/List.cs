using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Addresses
{
    public class List
    {
        public class Query : IRequest<List<Address>> { }

        public class Handler : IRequestHandler<Query, List<Address>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Address>> Handle(Query request, CancellationToken token)
            {
                return await _context.Addresses.ToListAsync();
            }
        }
    }
}
