using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCount
{
    public class GetSelectedStatsCardOptionQuery : IRequest<IEnumerable<GetSelectedStatsCardOptionResponse>>
    {
        public float? Version { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }

        public GetSelectedStatsCardOptionQuery(float? version)
        {
            Version = version;
        }

        public class GetListByCountCardOptionQueryHandler : IRequestHandler<GetSelectedStatsCardOptionQuery, IEnumerable<GetSelectedStatsCardOptionResponse>>
        {
            private readonly ICardOptionRepository _repository;
            private readonly IGenericRepository<CardOption> _genericRepository;
            private readonly IMapper _mapper;

            public GetListByCountCardOptionQueryHandler(ICardOptionRepository repository, IMapper mapper, IGenericRepository<CardOption> genericRepository)
            {
                _repository = repository;
                _mapper = mapper;
                _genericRepository = genericRepository;
            }

            public async Task<IEnumerable<GetSelectedStatsCardOptionResponse>> Handle(GetSelectedStatsCardOptionQuery request, CancellationToken cancellationToken)
            {
                IQueryable<CardOption>? entities = null;

                if (request.Version != null)
                {
                    entities = _repository.GetStatsByVersionAsync(request.Version);
                }
                else
                {
                    entities = _genericRepository.GetAll();
                }



                var response = entities
                        .GroupBy(co => co.Name)
                        .Select(g => new GetSelectedStatsCardOptionResponse
                        {
                            Name = g.Key,
                            Version = request.Version ?? 0f,
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
