using AutoMapper;
using MediatR;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattle
{
    public class GetListByBattleCardOptionQuery : IRequest<IEnumerable<GetListByBattleCardOptionResponse>>
    {
        public int BattleId { get; set; }

        public GetListByBattleCardOptionQuery(int battleId)
        {
            BattleId = battleId;
        }

        public class GetListByBattleCardOptionQueryHandler : IRequestHandler<GetListByBattleCardOptionQuery, IEnumerable<GetListByBattleCardOptionResponse>>
        {
            private readonly ICardOptionRepository _cardOptionRepository;
            private readonly IMapper _mapper;

            public GetListByBattleCardOptionQueryHandler(ICardOptionRepository cardOptionRepository, IMapper mapper)
            {
                _cardOptionRepository = cardOptionRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetListByBattleCardOptionResponse>> Handle(GetListByBattleCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entities = await _cardOptionRepository.GetListByBattleIdAsync(request.BattleId);
                var response = _mapper.Map<IEnumerable<GetListByBattleCardOptionResponse>>(entities);
                return response;
            }
        }
    }
}
