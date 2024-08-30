using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.InGames.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.InGames.Queries.GetById
{
    public class GetByIdInGameQuery : IRequest<GetByIdInGameResponse>
    {
        public int Id { get; set; }

        public GetByIdInGameQuery(int id)
        {
            Id = id;
        }

        public class GetByIdInGameQueryHandler : IRequestHandler<GetByIdInGameQuery, GetByIdInGameResponse>
        {
            private readonly IGenericRepository<InGame> _repository;
            private readonly IMapper _mapper;
            public GetByIdInGameQueryHandler(IGenericRepository<InGame> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdInGameResponse> Handle(GetByIdInGameQuery request, CancellationToken cancellationToken)
            {
                InGame InGame = await _repository.GetByIdAsync(request.Id);

                GetByIdInGameResponse response = _mapper.Map<GetByIdInGameResponse>(InGame);

                return response;
            }
        }
    }
}
