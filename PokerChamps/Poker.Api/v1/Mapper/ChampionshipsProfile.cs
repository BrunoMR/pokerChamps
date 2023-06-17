using AutoMapper;
using Poker.Api.v1.Dtos.Championship;
using Poker.Domain.Entities.Championship;

namespace Poker.Api.v1.Mapper;

public class ChampionshipsProfile : Profile
{
    public ChampionshipsProfile()
    {
        CreateMap<ChampionshipsDto, Championships>(MemberList.None)
            .ReverseMap();
    }
}