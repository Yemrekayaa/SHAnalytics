using AutoMapper;
using MediatR;
using SHAnalytics.Application.Features.Difficulties.Queries.GetList;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Difficulties.Queries.GetById
{
    public class GetByIdDifficultyQuery : IRequest<GetByIdDifficultyResponse>
    {
        public int Id { get; set; }

        public GetByIdDifficultyQuery(int id)
        {
            Id = id;
        }

        public class GetByIdDifficultyQueryHandler : IRequestHandler<GetByIdDifficultyQuery, GetByIdDifficultyResponse>
        {
            private readonly IGenericRepository<Difficulty> _repository;
            private readonly IMapper _mapper;
            public GetByIdDifficultyQueryHandler(IGenericRepository<Difficulty> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }


            public async Task<GetByIdDifficultyResponse> Handle(GetByIdDifficultyQuery request, CancellationToken cancellationToken)
            {
                Difficulty player = await _repository.GetByIdAsync(request.Id);

                GetByIdDifficultyResponse response = _mapper.Map<GetByIdDifficultyResponse>(player);

                return response;
            }
        }
    }
}
