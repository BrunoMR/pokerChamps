using AutoMapper;
using Poker.Api.v1.Dtos.Championship;
using Poker.Api.v1.Dtos.Championship.Ranking;
using Poker.Domain.Entities.Championship;
using Poker.Domain.Entities.Match.Value_Objects;

namespace Poker.Api.v1.Mapper;

public class ChampionshipsProfile : Profile
{
    public ChampionshipsProfile()
    {
        CreateMap<ChampionshipsDto, Championships>(MemberList.None).ReverseMap();
        
        CreateMap<PlayersChampionshipRankingDto, PlayerMatch>(MemberList.None).ReverseMap();
    }
}