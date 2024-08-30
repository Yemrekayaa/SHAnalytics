//using AutoMapper;
//using MediatR;
//using SHAnalytics.Application.Features.Sessions.Queries.GetList;
//using SHAnalytics.Core.Interfaces;

//namespace SHAnalytics.Application.Features.Sessions.Queries.GetListByPlayer
//{
//    public class GetListByPlayerSessionQuery : IRequest<IEnumerable<GetListByPlayerSessionResponse>>
//    {
//        public int PlayerId { get; set; }

//        public GetListByPlayerSessionQuery(int playerId)
//        {
//            PlayerId = playerId;
//        }

//        public class GetListByPlayerSessionQueryHandler : IRequestHandler<GetListByPlayerSessionQuery, IEnumerable<GetListByPlayerSessionResponse>>
//        {
//            private readonly ISessionRepository _repository;
//            private readonly IMapper _mapper;

//            public GetListByPlayerSessionQueryHandler(IMapper mapper, ISessionRepository repository)
//            {
//                _mapper = mapper;
//                _repository = repository;
//            }

//            public async Task<IEnumerable<GetListByPlayerSessionResponse>> Handle(GetListByPlayerSessionQuery request, CancellationToken cancellationToken)
//            {
//                var Sessions = await _repository.GetListByPlayerIdAsync(request.PlayerId);

//                var response = _mapper.Map<IEnumerable<GetListByPlayerSessionResponse>>(Sessions);

//                return response;
//            }
//        }
//    }
//}
