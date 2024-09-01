using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Battles.Commands.Create
{
    public class CreateBattleCommand : IRequest<CreateBattleResponse>
    {
        public int BattleAreaId { get; set; }
        public int BattleNumber { get; set; }

        public class CreateBattleCommandHandler : IRequestHandler<CreateBattleCommand, CreateBattleResponse>
        {
            private readonly IGenericRepository<Battle> _repository;
            private readonly IMapper _mapper;

            public CreateBattleCommandHandler(IGenericRepository<Battle> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateBattleResponse> Handle(CreateBattleCommand request, CancellationToken cancellationToken)
            {
                var entity = new Battle
                {
                    BattleAreaId = request.BattleAreaId,
                    BattleNumber = request.BattleNumber,
                };

                await _repository.AddAsync(entity);

                var response = _mapper.Map<CreateBattleResponse>(entity);

                return response;
            }
        }
    }
}
