using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.BattleAreas.Queries.GetList
{
    public class GetListBattleAreaQuery : IRequest<IEnumerable<GetListBattleAreaResponse>>
    {
        public class GetListBattleAreaQueryHandler : IRequestHandler<GetListBattleAreaQuery, IEnumerable<GetListBattleAreaResponse>>
        {
            private readonly IGenericRepository<BattleArea> _repository;
            private readonly IMapper _mapper;

            public GetListBattleAreaQueryHandler(IMapper mapper, IGenericRepository<BattleArea> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListBattleAreaResponse>> Handle(GetListBattleAreaQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<IEnumerable<GetListBattleAreaResponse>>(entities);
                return response;
            }
        }
    }
}
