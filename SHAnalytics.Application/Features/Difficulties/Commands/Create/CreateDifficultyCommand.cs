using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.Difficulties.Commands.Create
{
    public class CreateDifficultyCommand : IRequest<CreateDifficultyResponse>
    {
        public int SessionId { get; set; }
        public string Name { get; set; }

        public class CreateDifficultyCommandHandler : IRequestHandler<CreateDifficultyCommand, CreateDifficultyResponse>
        {
            private readonly IGenericRepository<Difficulty> _repository;
            private readonly IMapper _mapper;

            public CreateDifficultyCommandHandler(IGenericRepository<Difficulty> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateDifficultyResponse> Handle(CreateDifficultyCommand request, CancellationToken cancellationToken)
            {
                var entity = new Difficulty
                {
                    SessionId = request.SessionId,
                    Name = request.Name,
                };

                await _repository.AddAsync(entity);

                var response = _mapper.Map<CreateDifficultyResponse>(entity);

                return response;
            }
        }
    }
}
