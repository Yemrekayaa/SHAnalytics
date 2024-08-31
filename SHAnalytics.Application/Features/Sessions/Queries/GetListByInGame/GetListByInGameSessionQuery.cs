using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.Sessions.Queries.GetList;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Sessions.Queries.GetListByInGame
{
    public class GetListByInGameSessionQuery : IRequest<IEnumerable<GetListByInGameSessionResponse>>
    {
        public int InGameId { get; set; }

        public GetListByInGameSessionQuery(int inGameId)
        {
            InGameId = inGameId;
        }

        public class GetListByInGameSessionQueryHandler : IRequestHandler<GetListByInGameSessionQuery, IEnumerable<GetListByInGameSessionResponse>>
        {
            private readonly ISessionRepository _repository;
            private readonly IMapper _mapper;

            public GetListByInGameSessionQueryHandler(IMapper mapper, ISessionRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListByInGameSessionResponse>> Handle(GetListByInGameSessionQuery request, CancellationToken cancellationToken)
            {
                var Sessions = await _repository.GetListByInGameIdAsync(request.InGameId);

                var response = _mapper.Map<IEnumerable<GetListByInGameSessionResponse>>(Sessions);

                return response;
            }
        }
    }
}
