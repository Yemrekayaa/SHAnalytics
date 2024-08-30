using AutoMapper;
using MediatR;
using NameGenerator.Generators;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Sessions.Commands.Create
{
    public class CreateSessionCommand : IRequest<CreateSessionResponse>
    {
        public int InGameId { get; set; }
        public string SelectedHero { get; set; }
        public string Difficulty { get; set; }
        public int SessionTime { get; set; }
        public string EndCause { get; set; }
        public string DeathCause { get; set; }

        public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, CreateSessionResponse>
        {
            RealNameGenerator generator = new RealNameGenerator();
            private readonly IGenericRepository<Session> _repository;
            private readonly IMapper _mapper;
            public CreateSessionCommandHandler(IGenericRepository<Session> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateSessionResponse> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
            {

                Session Session = new Session
                {
                    InGameId = request.InGameId,
                    SelectedHero = request.SelectedHero,
                    EndCause = request.EndCause,
                    DeathCause = request.DeathCause,
                    SessionTime = request.SessionTime,
                    Difficulty = request.Difficulty
                };

                await _repository.AddAsync(Session);

                CreateSessionResponse createSessionResponse = _mapper.Map<CreateSessionResponse>(Session);
                return createSessionResponse;

            }
        }
    }
}
