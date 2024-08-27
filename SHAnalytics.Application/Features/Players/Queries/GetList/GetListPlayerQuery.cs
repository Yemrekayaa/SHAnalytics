using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Players.Queries.GetList
{
    public class GetListPlayerQuery : IRequest<IEnumerable<GetListPlayerResponse>>
    {
        public class GetListPlayerQueryHandler : IRequestHandler<GetListPlayerQuery, IEnumerable<GetListPlayerResponse>>
        {
            private readonly IGenericRepository<Player> _repository;
            private readonly IMapper _mapper;

            public GetListPlayerQueryHandler(IMapper mapper, IGenericRepository<Player> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListPlayerResponse>> Handle(GetListPlayerQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Player> players = await _repository.GetAllAsync();

                IEnumerable<GetListPlayerResponse> response = _mapper.Map<IEnumerable<GetListPlayerResponse>>(players);
                return response;
            }
        }
    }
}
