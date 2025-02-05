using Domain;
using MediatR;
using Persistence;

namespace Application.Addresses
{
    public class Details
    {
        public class Query : IRequest<Address>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Address>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Address> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Addresses.FindAsync(request.Id);
            }
        }
    }
}
