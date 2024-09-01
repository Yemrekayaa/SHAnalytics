using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.Battles.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Battles.Queries.GetById
{
    public class GetByIdBattleQuery : IRequest<GetByIdBattleResponse>
    {
        public int Id { get; set; }

        public GetByIdBattleQuery(int id)
        {
            Id = id;
        }

        public class GetByIdBattleQueryHandler : IRequestHandler<GetByIdBattleQuery, GetByIdBattleResponse>
        {
            private readonly IGenericRepository<Battle> _repository;
            private readonly IMapper _mapper;
            public GetByIdBattleQueryHandler(IGenericRepository<Battle> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdBattleResponse> Handle(GetByIdBattleQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdBattleResponse>(entity);

                return response;
            }
        }
    }
}
