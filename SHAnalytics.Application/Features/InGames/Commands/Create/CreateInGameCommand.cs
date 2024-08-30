using AutoMapper;
using MediatR;
using NameGenerator.Generators;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.InGames.Commands.Create
{
    public class CreateInGameCommand : IRequest<CreateInGameResponse>
    {
        public int PlayerId { get; set; }
        public int TotalTime { get; set; }
        public float GameVersion { get; set; }

        public class CreateInGameCommandHandler : IRequestHandler<CreateInGameCommand, CreateInGameResponse>
        {
            RealNameGenerator generator = new RealNameGenerator();
            private readonly IGenericRepository<InGame> _repository;
            private readonly IMapper _mapper;
            public CreateInGameCommandHandler(IGenericRepository<InGame> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateInGameResponse> Handle(CreateInGameCommand request, CancellationToken cancellationToken)
            {

                InGame InGame = new InGame
                {
                    PlayerId = request.PlayerId,
                    TotalTime = request.TotalTime,
                    CreatedTime = DateTime.UtcNow,
                    GameVersion = request.GameVersion
                };

                await _repository.AddAsync(InGame);

                CreateInGameResponse createInGameResponse = _mapper.Map<CreateInGameResponse>(InGame);
                return createInGameResponse;

            }
        }
    }
}
