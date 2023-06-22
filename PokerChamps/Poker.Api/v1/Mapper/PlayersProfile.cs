using AutoMapper;
using Poker.Api.v1.Dtos.Config;
using Poker.Api.v1.Dtos.Match.Create;
using Poker.Api.v1.Dtos.Match.SpecialHand;
using Poker.Api.v1.Dtos.Player;
using Poker.Domain.Entities.Config;
using Poker.Domain.Entities.Config.Value_Objects;
using Poker.Domain.Entities.Match.Model;
using Poker.Domain.Entities.Match.Value_Objects;
using Poker.Domain.Entities.Player;

namespace Poker.Api.v1.Mapper;

public class PlayersProfile : Profile
{
    public PlayersProfile()
    {
        CreateMap<PlayerMatchCreateDto, PlayerMatch>(MemberList.None).ReverseMap();
        
        CreateMap<PlayersDto, Players>(MemberList.None).ReverseMap();
        
        CreateMap<PlayerSpecialHandModelDto, PlayerSpecialHandModel>(MemberList.None).ReverseMap();
    }
}