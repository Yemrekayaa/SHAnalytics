using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Difficulties.Queries.GetList
{
    public class GetListDifficultyQuery : IRequest<IEnumerable<GetListDifficultyResponse>>
    {
        public class GetListDifficultyQueryHandler : IRequestHandler<GetListDifficultyQuery, IEnumerable<GetListDifficultyResponse>>
        {
            private readonly IGenericRepository<Difficulty> _repository;
            private readonly IMapper _mapper;

            public GetListDifficultyQueryHandler(IMapper mapper, IGenericRepository<Difficulty> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListDifficultyResponse>> Handle(GetListDifficultyQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Difficulty> players = await _repository.GetAllAsync();

                IEnumerable<GetListDifficultyResponse> response = _mapper.Map<IEnumerable<GetListDifficultyResponse>>(players);
                return response;
            }
        }
    }
}
