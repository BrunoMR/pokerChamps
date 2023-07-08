using AutoMapper;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Mapper;

public class PlayersProfile : Profile
{
    public PlayersProfile()
    {
        CreateMap<PlayerMatchCreateDto, PlayerMatch>(MemberList.None).ReverseMap();
    }
}