using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.AppUsers
{
    public class Edit
    {
        public class Command : IRequest
        {
            public AppUser AppUser { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var appuser = await _context.AppUsers.FindAsync(request.AppUser.Id);

                _mapper.Map(request.AppUser, appuser);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }

            Task IRequestHandler<Command>.Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
