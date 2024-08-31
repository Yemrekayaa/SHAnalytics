using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.Sessions.Queries.GetList;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.InGames.Queries.GetListByPlayer
{
    public class GetListByPlayerInGameQuery : IRequest<IEnumerable<GetListByPlayerInGameResponse>>
    {
        public int PlayerId { get; set; }

        public GetListByPlayerInGameQuery(int playerId)
        {
            PlayerId = playerId;
        }

        public class GetListByPlayerInGameQueryHandler : IRequestHandler<GetListByPlayerInGameQuery, IEnumerable<GetListByPlayerInGameResponse>>
        {
            private readonly IInGameRepository _repository;
            private readonly IMapper _mapper;

            public GetListByPlayerInGameQueryHandler(IMapper mapper, IInGameRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListByPlayerInGameResponse>> Handle(GetListByPlayerInGameQuery request, CancellationToken cancellationToken)
            {
                var InGames = await _repository.GetListByPlayerIdAsync(request.PlayerId);

                var response = _mapper.Map<IEnumerable<GetListByPlayerInGameResponse>>(InGames);

                return response;
            }
        }
    }
}
