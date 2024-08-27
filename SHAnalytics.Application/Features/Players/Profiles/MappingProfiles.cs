using AutoMapper;
using SHAnalytics.Application.Features.Players.Commands.Create;
using SHAnalytics.Application.Features.Players.Queries.GetList;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Application.Features.Players.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Player, CreatePlayerResponse>().ReverseMap();
            CreateMap<Player, CreatePlayerCommand>().ReverseMap();
            CreateMap<Player, GetListPlayerResponse>().ReverseMap();
            CreateMap<Player, GetByIdPlayerResponse>().ReverseMap();
        }
    }
}
