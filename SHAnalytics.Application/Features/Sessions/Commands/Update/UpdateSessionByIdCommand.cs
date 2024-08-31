using AutoMapper;
using MediatR;
using NameGenerator.Generators;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Sessions.Commands.Update
{
    public class UpdateSessionByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int SessionTime { get; set; }
        public string EndCause { get; set; }
        public string DeathCause { get; set; }

        public class UpdateSessionByIdCommandHandler : IRequestHandler<UpdateSessionByIdCommand, Unit>
        {
            RealNameGenerator generator = new RealNameGenerator();
            private readonly IGenericRepository<Session> _repository;
            private readonly IMapper _mapper;
            public UpdateSessionByIdCommandHandler(IGenericRepository<Session> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateSessionByIdCommand request, CancellationToken cancellationToken)
            {

                var Session = await _repository.GetByIdAsync(request.Id);
                Session.SessionTime = request.SessionTime;
                Session.EndCause = request.EndCause;
                Session.DeathCause = request.DeathCause;

                _repository.Update(Session);
                return Unit.Value;

            }
        }
    }
}
