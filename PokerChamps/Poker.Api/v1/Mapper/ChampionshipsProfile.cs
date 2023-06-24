using AutoMapper;
using Poker.Api.v1.Dtos.Championship;
using Poker.Api.v1.Dtos.Championship.Ranking;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Championship.Model;

namespace Poker.Api.v1.Mapper;

public class ChampionshipsProfile : Profile
{
    public ChampionshipsProfile()
    {
        CreateMap<ChampionshipsDto, Championships>(MemberList.None).ReverseMap();
        
        CreateMap<PlayerRankingModelDto, PlayerRankingModel>(MemberList.None).ReverseMap();
        CreateMap<PrizeModelDto, PrizeModel>(MemberList.None).ReverseMap();
        CreateMap<ChampionshipRankingModelDto, ChampionshipRankingModel>(MemberList.None).ReverseMap();
    }
}