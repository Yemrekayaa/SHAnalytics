using AutoMapper;
using MediatR;
using NameGenerator.Generators;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Players.Commands.Create
{
    public class CreatePlayerCommand : IRequest<CreatePlayerResponse>
    {

        public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, CreatePlayerResponse>
        {
            RealNameGenerator generator = new RealNameGenerator();
            private readonly IGenericRepository<Player> _repository;
            private readonly IMapper _mapper;
            public CreatePlayerCommandHandler(IGenericRepository<Player> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreatePlayerResponse> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
            {

                Player player = new Player
                {
                    Name = generator.Generate(),
                    CreateTime = DateTime.UtcNow,
                    TotalTime = 0
                };

                await _repository.AddAsync(player);

                CreatePlayerResponse createPlayerResponse = _mapper.Map<CreatePlayerResponse>(player);
                return createPlayerResponse;

            }
        }
    }
}
