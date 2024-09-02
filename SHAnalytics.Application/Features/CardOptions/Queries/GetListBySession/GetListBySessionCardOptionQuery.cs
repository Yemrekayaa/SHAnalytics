using AutoMapper;
using MediatR;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetListBySession
{
    public class GetListBySessionCardOptionQuery : IRequest<IEnumerable<GetListBySessionCardOptionResponse>>
    {
        public int SessionId { get; set; }

        public GetListBySessionCardOptionQuery(int sessionId)
        {
            SessionId = sessionId;
        }

        public class GetListBySessionCardOptionQueryHandler : IRequestHandler<GetListBySessionCardOptionQuery, IEnumerable<GetListBySessionCardOptionResponse>>
        {
            private readonly ICardOptionRepository _cardOptionRepository;
            private readonly IMapper _mapper;

            public GetListBySessionCardOptionQueryHandler(ICardOptionRepository cardOptionRepository, IMapper mapper)
            {
                _cardOptionRepository = cardOptionRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetListBySessionCardOptionResponse>> Handle(GetListBySessionCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entities = await _cardOptionRepository.GetListBySessionIdAsync(request.SessionId);
                var response = _mapper.Map<IEnumerable<GetListBySessionCardOptionResponse>>(entities);
                return response;
            }
        }
    }
}
