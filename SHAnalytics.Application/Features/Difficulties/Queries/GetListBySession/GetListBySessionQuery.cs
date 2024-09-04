using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Difficulties.Queries.GetListBySession
{
    public class GetListBySessionDifficultyQuery : IRequest<IEnumerable<GetListBySessionDifficultyResponse>>
    {
        public int SessionId { get; set; }

        public GetListBySessionDifficultyQuery(int sessionId)
        {
            SessionId = sessionId;
        }

        public class GetListBySessionDifficultyQueryHandler : IRequestHandler<GetListBySessionDifficultyQuery, IEnumerable<GetListBySessionDifficultyResponse>>
        {
            private readonly IGenericRepository<Difficulty> _repository;
            private readonly IMapper _mapper;

            public GetListBySessionDifficultyQueryHandler(IMapper mapper, IGenericRepository<Difficulty> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IEnumerable<GetListBySessionDifficultyResponse>> Handle(GetListBySessionDifficultyQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Difficulty> players = await _repository.FindAsync(x => x.SessionId == request.SessionId);

                IEnumerable<GetListBySessionDifficultyResponse> response = _mapper.Map<IEnumerable<GetListBySessionDifficultyResponse>>(players);
                return response;
            }
        }
    }
}
