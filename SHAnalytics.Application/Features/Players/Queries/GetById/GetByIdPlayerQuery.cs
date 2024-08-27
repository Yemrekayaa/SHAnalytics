using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.Players.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Players.Queries.GetById
{
    public class GetByIdPlayerQuery : IRequest<GetByIdPlayerResponse>
    {
        public int Id { get; set; }

        public GetByIdPlayerQuery(int id)
        {
            Id = id;
        }

        public class GetByIdPlayerQueryHandler : IRequestHandler<GetByIdPlayerQuery, GetByIdPlayerResponse>
        {
            private readonly IGenericRepository<Player> _repository;
            private readonly IMapper _mapper;
            public GetByIdPlayerQueryHandler(IGenericRepository<Player> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            public async Task<GetByIdPlayerResponse> Handle(GetByIdPlayerQuery request, CancellationToken cancellationToken)
            {
                Player player = await _repository.GetByIdAsync(request.Id);

                GetByIdPlayerResponse response = _mapper.Map<GetByIdPlayerResponse>(player);

                return response;
            }
        }
    }
}
