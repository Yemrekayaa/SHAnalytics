using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetList
{
    public class GetListCardOptionQuery : IRequest<IEnumerable<GetListCardOptionResponse>>
    {
        public class GetListCardOptionQueryHandler : IRequestHandler<GetListCardOptionQuery, IEnumerable<GetListCardOptionResponse>>
        {
            private readonly IGenericRepository<CardOption> _repository;
            private readonly IMapper _mapper;

            public GetListCardOptionQueryHandler(IMapper mapper, IGenericRepository<CardOption> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListCardOptionResponse>> Handle(GetListCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<IEnumerable<GetListCardOptionResponse>>(entities);
                return response;
            }
        }
    }
}
