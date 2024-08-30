using AutoMapper;
using SHAnalytics.Application.Features.Players.Commands.Create;
using SHAnalytics.Application.Features.Players.Queries.GetList;
using SHAnalytics.Application.Features.Sessions.Commands.Create;
using SHAnalytics.Application.Features.Sessions.Queries.GetList;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Application.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Player, CreatePlayerResponse>().ReverseMap();
            CreateMap<Player, CreatePlayerCommand>().ReverseMap();
            CreateMap<Player, GetListPlayerResponse>().ReverseMap();
            CreateMap<Player, GetByIdPlayerResponse>().ReverseMap();

            CreateMap<Session, CreateSessionResponse>().ReverseMap();
            CreateMap<Session, CreateSessionCommand>().ReverseMap();
            CreateMap<Session, GetListSessionResponse>().ReverseMap();
            CreateMap<Session, GetByIdSessionResponse>().ReverseMap();
            CreateMap<Session, GetListByPlayerSessionResponse>().ReverseMap();

        }
    }
}
