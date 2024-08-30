using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Sessions.Queries.GetList
{
    public class GetListSessionQuery : IRequest<IEnumerable<GetListSessionResponse>>
    {
        public class GetListSessionQueryHandler : IRequestHandler<GetListSessionQuery, IEnumerable<GetListSessionResponse>>
        {
            private readonly IGenericRepository<Session> _repository;
            private readonly IMapper _mapper;

            public GetListSessionQueryHandler(IMapper mapper, IGenericRepository<Session> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListSessionResponse>> Handle(GetListSessionQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Session> Sessions = await _repository.GetAllAsync();

                IEnumerable<GetListSessionResponse> response = _mapper.Map<IEnumerable<GetListSessionResponse>>(Sessions);
                return response;
            }
        }
    }
}
