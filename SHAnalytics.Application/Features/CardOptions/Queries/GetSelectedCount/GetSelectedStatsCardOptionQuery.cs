using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCount
{
    public class GetSelectedStatsCardOptionQuery : IRequest<IEnumerable<GetSelectedStatsCardOptionResponse>>
    {
        public string? Name { get; set; }

        public GetSelectedStatsCardOptionQuery(string? name)
        {
            Name = name;
        }

        public class GetListByCountCardOptionQueryHandler : IRequestHandler<GetSelectedStatsCardOptionQuery, IEnumerable<GetSelectedStatsCardOptionResponse>>
        {
            private readonly IGenericRepository<CardOption> _repository;
            private readonly IMapper _mapper;

            public GetListByCountCardOptionQueryHandler(IGenericRepository<CardOption> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetSelectedStatsCardOptionResponse>> Handle(GetSelectedStatsCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entities = _repository.GetAll();
                var result = entities.GroupBy(co => co.Name)
                    .Select(g => new GetSelectedStatsCardOptionResponse
                    {
                        Name = g.Key,
                        Total = g.Count(),
                        Selected = g.Count(co => co.IsSelected)
                    });

                if (string.IsNullOrEmpty(request.Name))
                {
                    var response = result.ToList();
                    return response;
                }
                else
                {
                    var response = result.Where(co => co.Name == request.Name).ToList();
                    return response;
                }

            }
        }
    }
}
