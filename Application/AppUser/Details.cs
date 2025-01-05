using Domain;
using MediatR;
using Persistence;

namespace Application.AppUsers
{
    public class Details
    {
        public class Query : IRequest<AppUser>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppUser>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<AppUser> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.AppUsers.FindAsync(request.Id);
            }
        }
    }
}
