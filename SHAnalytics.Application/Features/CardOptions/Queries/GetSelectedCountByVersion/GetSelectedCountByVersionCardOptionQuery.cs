using AutoMapper;
using MediatR;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetSelectedCountByVersion
{
    public class GetSelectedCountByVersionCardOptionQuery : IRequest<IEnumerable<GetSelectedCountByVersionCardOptionResponse>>
    {
        public float? Version { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }

        public GetSelectedCountByVersionCardOptionQuery(float? version)
        {
            Version = version;
        }

        public class GetListByCountCardOptionQueryHandler : IRequestHandler<GetSelectedCountByVersionCardOptionQuery, IEnumerable<GetSelectedCountByVersionCardOptionResponse>>
        {
            private readonly ICardOptionRepository _repository;
            private readonly IMapper _mapper;

            public GetListByCountCardOptionQueryHandler(ICardOptionRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetSelectedCountByVersionCardOptionResponse>> Handle(GetSelectedCountByVersionCardOptionQuery request, CancellationToken cancellationToken)
            {


                var entities = _repository.GetStatsByVersionAsync(request.Version);
                var response = entities
                        .GroupBy(co => co.Name)
                        .Select(g => new GetSelectedCountByVersionCardOptionResponse
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
