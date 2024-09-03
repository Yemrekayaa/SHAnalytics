using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCount
{
    public class GetSelectedStatsCardOptionQuery : IRequest<IEnumerable<GetSelectedStatsCardOptionResponse>>
    {
        public string? Name { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }

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
                if (!string.IsNullOrEmpty(request.Name))
                {
                    entities = entities.Where(co => co.Name == request.Name);
                }

                var response = entities
                        .GroupBy(co => co.Name)
                        .Select(g => new GetSelectedStatsCardOptionResponse
                        {
                            Name = g.Key,
                            Temp = g.Count(co => !co.IsPerma),
                            Total = g.Count(),
                            Perma = g.Count(co => co.IsPerma),
                            TotalSelected = g.Count(co => co.IsSelected),
                            PermaSelected = g.Count(co => co.IsSelected && co.IsPerma),
                            TempSelected = g.Count(co => co.IsSelected && !co.IsPerma),
                            TotalSelectionRate = (int)Math.Floor((g.Count(co => co.IsSelected) / (double)g.Count()) * 100),
                            PermaSelectionRate = g.Count(co => co.IsPerma) > 0
                            ? (int)Math.Floor((g.Count(co => co.IsSelected && co.IsPerma) / (double)g.Count(co => co.IsPerma)) * 100)
                            : 0,
                            TempSelectionRate = g.Count(co => !co.IsPerma) > 0
                            ? (int)Math.Floor((g.Count(co => co.IsSelected && !co.IsPerma) / (double)g.Count(co => !co.IsPerma)) * 100)
                            : 0,
                        }).ToList();

                return response;


            }
        }
    }
}
