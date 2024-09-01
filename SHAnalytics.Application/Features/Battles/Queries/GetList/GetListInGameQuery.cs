using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Battles.Queries.GetList
{
    public class GetListBattleQuery : IRequest<IEnumerable<GetListBattleResponse>>
    {
        public class GetListBattleQueryHandler : IRequestHandler<GetListBattleQuery, IEnumerable<GetListBattleResponse>>
        {
            private readonly IGenericRepository<Battle> _repository;
            private readonly IMapper _mapper;

            public GetListBattleQueryHandler(IMapper mapper, IGenericRepository<Battle> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListBattleResponse>> Handle(GetListBattleQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<IEnumerable<GetListBattleResponse>>(entities);
                return response;
            }
        }
    }
}
