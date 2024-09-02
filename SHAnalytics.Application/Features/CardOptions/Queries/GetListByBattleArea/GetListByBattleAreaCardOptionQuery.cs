using AutoMapper;
using MediatR;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattleArea
{
    public class GetListByBattleAreaCardOptionQuery : IRequest<IEnumerable<GetListByBattleAreaCardOptionResponse>>
    {
        public int BattleAreaId { get; set; }

        public GetListByBattleAreaCardOptionQuery(int battleId)
        {
            BattleAreaId = battleId;
        }

        public class GetListByBattleAreaCardOptionQueryHandler : IRequestHandler<GetListByBattleAreaCardOptionQuery, IEnumerable<GetListByBattleAreaCardOptionResponse>>
        {
            private readonly ICardOptionRepository _cardOptionRepository;
            private readonly IMapper _mapper;

            public GetListByBattleAreaCardOptionQueryHandler(ICardOptionRepository cardOptionRepository, IMapper mapper)
            {
                _cardOptionRepository = cardOptionRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetListByBattleAreaCardOptionResponse>> Handle(GetListByBattleAreaCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entities = await _cardOptionRepository.GetListByBattleAreaIdAsync(request.BattleAreaId);
                var response = _mapper.Map<IEnumerable<GetListByBattleAreaCardOptionResponse>>(entities);
                return response;
            }
        }
    }
}
