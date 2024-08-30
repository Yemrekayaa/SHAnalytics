using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.Sessions.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Sessions.Queries.GetById
{
    public class GetByIdSessionQuery : IRequest<GetByIdSessionResponse>
    {
        public int Id { get; set; }

        public GetByIdSessionQuery(int id)
        {
            Id = id;
        }

        public class GetByIdSessionQueryHandler : IRequestHandler<GetByIdSessionQuery, GetByIdSessionResponse>
        {
            private readonly IGenericRepository<Session> _repository;
            private readonly IMapper _mapper;
            public GetByIdSessionQueryHandler(IGenericRepository<Session> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            public async Task<GetByIdSessionResponse> Handle(GetByIdSessionQuery request, CancellationToken cancellationToken)
            {
                Session Session = await _repository.GetByIdAsync(request.Id);

                GetByIdSessionResponse response = _mapper.Map<GetByIdSessionResponse>(Session);

                return response;
            }
        }
    }
}
