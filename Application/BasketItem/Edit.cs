using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.BasketItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public BasketItem BasketItem { get; set; }
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
                var basketitem = await _context.BasketItems.FindAsync(request.BasketItem.Id);

                _mapper.Map(request.BasketItem, basketitem);

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
