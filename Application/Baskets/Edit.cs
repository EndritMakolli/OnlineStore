using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Baskets
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Basket Basket { get; set; }
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
                var basket = await _context.Baskets.FindAsync(request.Basket.Id);

                _mapper.Map(request.Basket, basket);

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
