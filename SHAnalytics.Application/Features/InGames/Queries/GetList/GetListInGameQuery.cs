using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.InGames.Queries.GetList
{
    public class GetListInGameQuery : IRequest<IEnumerable<GetListInGameResponse>>
    {
        public class GetListInGameQueryHandler : IRequestHandler<GetListInGameQuery, IEnumerable<GetListInGameResponse>>
        {
            private readonly IGenericRepository<InGame> _repository;
            private readonly IMapper _mapper;

            public GetListInGameQueryHandler(IMapper mapper, IGenericRepository<InGame> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListInGameResponse>> Handle(GetListInGameQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<InGame> InGames = await _repository.GetAllAsync();

                IEnumerable<GetListInGameResponse> response = _mapper.Map<IEnumerable<GetListInGameResponse>>(InGames);
                return response;
            }
        }
    }
}
