using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCount
{
    public class GetSelectedCountCardOptionQuery : IRequest<IEnumerable<GetSelectedCountCardOptionResponse>>
    {

        public class GetListByCountCardOptionQueryHandler : IRequestHandler<GetSelectedCountCardOptionQuery, IEnumerable<GetSelectedCountCardOptionResponse>>
        {
            private readonly IGenericRepository<CardOption> _repository;
            private readonly IMapper _mapper;

            public GetListByCountCardOptionQueryHandler(IGenericRepository<CardOption> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetSelectedCountCardOptionResponse>> Handle(GetSelectedCountCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entities = _repository.GetAll().Where(co => co.IsSelected);
                var response = entities.GroupBy(co => co.Name)
                    .Select(g => new GetSelectedCountCardOptionResponse
                    {
                        Name = g.Key,
                        Count = g.Count()
                    }).ToList();
                return response;
            }
        }
    }
}
