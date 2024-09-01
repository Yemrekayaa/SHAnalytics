using AutoMapper;
using MediatR;
using SHAnalytics.Core.Entities;
using SHAnalytics.Core.Interfaces;

namespace SHAnalytics.Application.Features.CardOptions.Commands.Update
{
    public class UpdateCardOptionByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool IsSelected { get; set; }

        public class UpdateCardOptionByIdCommandHandler : IRequestHandler<UpdateCardOptionByIdCommand, Unit>
        {
            private readonly IGenericRepository<CardOption> _repository;
            private readonly IMapper _mapper;
            public UpdateCardOptionByIdCommandHandler(IGenericRepository<CardOption> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCardOptionByIdCommand request, CancellationToken cancellationToken)
            {

                var CardOption = await _repository.GetByIdAsync(request.Id);
                CardOption.IsSelected = request.IsSelected;

                _repository.Update(CardOption);
                return Unit.Value;

            }
        }
    }
}
