using AutoMapper;
using SHAnalytics.Application.Features.BattleAreas.Commands.Create;
using SHAnalytics.Application.Features.BattleAreas.Queries.GetList;
using SHAnalytics.Application.Features.Battles.Commands.Create;
using SHAnalytics.Application.Features.Battles.Queries.GetList;
using SHAnalytics.Application.Features.CardOptions.Commands.Create;
using SHAnalytics.Application.Features.CardOptions.Queries.GetList;
using SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattle;
using SHAnalytics.Application.Features.CardOptions.Queries.GetListByBattleArea;
using SHAnalytics.Application.Features.CardOptions.Queries.GetListBySession;
using SHAnalytics.Application.Features.Difficulties.Commands.Create;
using SHAnalytics.Application.Features.Difficulties.Queries.GetList;
using SHAnalytics.Application.Features.Difficulties.Queries.GetListBySession;
using SHAnalytics.Application.Features.InGames.Commands.Create;
using SHAnalytics.Application.Features.InGames.Commands.Update;
using SHAnalytics.Application.Features.InGames.Queries.GetList;
using SHAnalytics.Application.Features.Players.Commands.Create;
using SHAnalytics.Application.Features.Players.Queries.GetList;
using SHAnalytics.Application.Features.Sessions.Commands.Create;
using SHAnalytics.Application.Features.Sessions.Queries.GetList;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Application.Profiles
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
            CreateMap<Session, UpdateInGameByIdCommand>().ReverseMap();
            CreateMap<Session, UpdateInGameByIdResponse>().ReverseMap();
            CreateMap<Session, GetListByPlayerSessionResponse>()
            .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.InGame.Player.Id)).ReverseMap();
            CreateMap<Session, GetListByInGameSessionResponse>().ReverseMap();

            CreateMap<InGame, CreateInGameResponse>().ReverseMap();
            CreateMap<InGame, CreateInGameCommand>().ReverseMap();
            CreateMap<InGame, GetListInGameResponse>().ReverseMap();
            CreateMap<InGame, GetByIdInGameResponse>().ReverseMap();
            CreateMap<InGame, UpdateInGameByIdCommand>().ReverseMap();
            CreateMap<InGame, UpdateInGameByIdResponse>().ReverseMap();
            CreateMap<InGame, GetListByPlayerInGameResponse>().ReverseMap();

            CreateMap<BattleArea, CreateBattleAreaCommand>().ReverseMap();
            CreateMap<BattleArea, CreateBattleAreaResponse>().ReverseMap();
            CreateMap<BattleArea, GetListBattleAreaResponse>().ReverseMap();
            CreateMap<BattleArea, GetByIdBattleAreaResponse>().ReverseMap();

            CreateMap<Battle, CreateBattleCommand>().ReverseMap();
            CreateMap<Battle, CreateBattleResponse>().ReverseMap();
            CreateMap<Battle, GetListBattleResponse>().ReverseMap();
            CreateMap<Battle, GetByIdBattleResponse>().ReverseMap();

            CreateMap<CardOption, CreateCardOptionCommand>().ReverseMap();
            CreateMap<CardOption, CreateCardOptionResponse>().ReverseMap();
            CreateMap<CardOption, GetListCardOptionResponse>().ReverseMap();
            CreateMap<CardOption, GetByIdCardOptionResponse>().ReverseMap();
            CreateMap<CardOption, GetListBySessionCardOptionResponse>().ReverseMap();
            CreateMap<CardOption, GetListByBattleAreaCardOptionResponse>().ReverseMap();
            CreateMap<CardOption, GetListByBattleCardOptionResponse>().ReverseMap();

            CreateMap<Difficulty, CreateDifficultyCommand>().ReverseMap();
            CreateMap<Difficulty, CreateDifficultyResponse>().ReverseMap();
            CreateMap<Difficulty, GetListDifficultyResponse>().ReverseMap();
            CreateMap<Difficulty, GetByIdDifficultyResponse>().ReverseMap();
            CreateMap<Difficulty, GetListBySessionDifficultyResponse>().ReverseMap();
        }
    }
}
