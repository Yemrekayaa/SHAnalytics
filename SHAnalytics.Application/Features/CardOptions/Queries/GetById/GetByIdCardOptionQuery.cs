using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.CardOptions.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Queries.GetById
{
    public class GetByIdCardOptionQuery : IRequest<GetByIdCardOptionResponse>
    {
        public int Id { get; set; }

        public GetByIdCardOptionQuery(int id)
        {
            Id = id;
        }

        public class GetByIdCardOptionQueryHandler : IRequestHandler<GetByIdCardOptionQuery, GetByIdCardOptionResponse>
        {
            private readonly IGenericRepository<CardOption> _repository;
            private readonly IMapper _mapper;
            public GetByIdCardOptionQueryHandler(IGenericRepository<CardOption> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdCardOptionResponse> Handle(GetByIdCardOptionQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdCardOptionResponse>(entity);

                return response;
            }
        }
    }
}
