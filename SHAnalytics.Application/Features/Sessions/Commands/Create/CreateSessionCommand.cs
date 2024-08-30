using AutoMapper;
using MediatR;
using NameGenerator.Generators;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Sessions.Commands.Create
{
    public class CreateSessionCommand : IRequest<CreateSessionResponse>
    {
        public int PlayerId { get; set; }
        public int SessionTime { get; set; }
        public string Difficulty { get; set; }

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
                    PlayerId = request.PlayerId,
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
