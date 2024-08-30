using AutoMapper;
using MediatR;
using NameGenerator.Generators;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.InGames.Commands.Update
{
    public class UpdateInGameByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int TotalTime { get; set; }

        public class UpdateInGameByIdCommandHandler : IRequestHandler<UpdateInGameByIdCommand, Unit>
        {
            RealNameGenerator generator = new RealNameGenerator();
            private readonly IGenericRepository<InGame> _repository;
            private readonly IMapper _mapper;
            public UpdateInGameByIdCommandHandler(IGenericRepository<InGame> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateInGameByIdCommand request, CancellationToken cancellationToken)
            {

                var InGame = await _repository.GetByIdAsync(request.Id);
                InGame.TotalTime = request.TotalTime;

                _repository.Update(InGame);
                return Unit.Value;

            }
        }
    }
}
