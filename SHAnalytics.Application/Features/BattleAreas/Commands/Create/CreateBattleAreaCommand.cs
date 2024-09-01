using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.BattleAreas.Commands.Create
{
    public class CreateBattleAreaCommand : IRequest<CreateBattleAreaResponse>
    {
        public int SessionId { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

        public class CreateBattleAreaCommandHandler : IRequestHandler<CreateBattleAreaCommand, CreateBattleAreaResponse>
        {
            private readonly IGenericRepository<BattleArea> _repository;
            private readonly IMapper _mapper;

            public CreateBattleAreaCommandHandler(IGenericRepository<BattleArea> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateBattleAreaResponse> Handle(CreateBattleAreaCommand request, CancellationToken cancellationToken)
            {
                var entity = new BattleArea
                {
                    SessionId = request.SessionId,
                    Size = request.Size,
                    Type = request.Type,
                };

                await _repository.AddAsync(entity);

                var response = _mapper.Map<CreateBattleAreaResponse>(entity);

                return response;
            }
        }
    }
}
