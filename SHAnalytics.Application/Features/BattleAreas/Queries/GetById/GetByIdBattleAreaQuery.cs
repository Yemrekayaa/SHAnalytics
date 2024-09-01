using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.BattleAreas.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.BattleAreas.Queries.GetById
{
    public class GetByIdBattleAreaQuery : IRequest<GetByIdBattleAreaResponse>
    {
        public int Id { get; set; }

        public GetByIdBattleAreaQuery(int id)
        {
            Id = id;
        }

        public class GetByIdBattleAreaQueryHandler : IRequestHandler<GetByIdBattleAreaQuery, GetByIdBattleAreaResponse>
        {
            private readonly IGenericRepository<BattleArea> _repository;
            private readonly IMapper _mapper;
            public GetByIdBattleAreaQueryHandler(IGenericRepository<BattleArea> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdBattleAreaResponse> Handle(GetByIdBattleAreaQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdBattleAreaResponse>(entity);

                return response;
            }
        }
    }
}
