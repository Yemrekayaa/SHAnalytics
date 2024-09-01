using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Commands.Create
{
    public class CreateCardOptionCommand : IRequest<CreateCardOptionResponse>
    {
        public int BattleId { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPerma { get; set; }
        public string Name { get; set; }

        public class CreateCardOptionCommandHandler : IRequestHandler<CreateCardOptionCommand, CreateCardOptionResponse>
        {
            private readonly IGenericRepository<CardOption> _repository;
            private readonly IMapper _mapper;

            public CreateCardOptionCommandHandler(IGenericRepository<CardOption> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateCardOptionResponse> Handle(CreateCardOptionCommand request, CancellationToken cancellationToken)
            {
                var entity = new CardOption
                {
                    BattleId = request.BattleId,
                    IsSelected = request.IsSelected,
                    IsPerma = request.IsPerma,
                    Name = request.Name
                };

                await _repository.AddAsync(entity);

                var response = _mapper.Map<CreateCardOptionResponse>(entity);

                return response;
            }
        }
    }
}
